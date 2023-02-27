
using AtoTax.API.Authentication;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.DTOs.AuthDTOs;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using AutoMapper;
using Azure;
using EmailService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using Org.BouncyCastle.Ocsp;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace AtoTax.API.Repository.Repos
{
    public class UserRepository : IUserRepository
    {

        private readonly AtoTaxDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<EmpJobRole> _logger;
        private readonly IMapper _mapper;
        private string secretkey;
        protected APIResponse _response;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;


        public UserRepository(AtoTaxDbContext context, ILogger<EmpJobRole> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _mapper = mapper;
            _response = new();
            _emailSender = emailSender;
            secretkey = config.GetValue<string>("ApiSettings:Secret");
            _config = config;
        }
        public bool IsUniqueUser(string username)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {

            //check user is valid?
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

            //check if user's password is valid?
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || isValid == false)
            {

                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null
                };
            }
            //assign roles here

            var roles = await _userManager.GetRolesAsync(user);


            //token generator here
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretkey);

            var tokenDescricptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, string.Join(", ",roles))
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhandler.CreateToken(tokenDescricptor);

            LoginResponseDTO loginResponseDTO = new()
            {
                User = _mapper.Map<UserDTO>(user),
                Roles = string.Join(",", roles),
                Token = tokenhandler.WriteToken(token)
            };

            return loginResponseDTO;

        }

        public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            // var localuser =  _mapper.Map<LocalUser>(registrationRequestDTO);

            ApplicationUser appUser = new();
            appUser.Name = registrationRequestDTO.Name;
            appUser.Email = registrationRequestDTO.Email;
            appUser.NormalizedEmail = registrationRequestDTO.Email.ToUpper();
            appUser.UserName = registrationRequestDTO.UserName;
            
            
            

            try
            {
                var result = await _userManager.CreateAsync(appUser, registrationRequestDTO.Password);

                if (!result.Succeeded)
                {
                    var exceptionText = result.Errors.Aggregate("User Creation Failed - Identity Exception. Errors were: \n\r\n\r", (current, error) => current + (" - " + error + "\n\r"));
                    throw new Exception(exceptionText);
                }

                // Send Mail ID confirmation email

                string[] paths = { Directory.GetCurrentDirectory(), "ConfirmEmail.html" };
                string FilePath = Path.Combine(paths);
                _logger.LogInformation("Email template path " + FilePath);
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                str.Close();

                var domain = _config.GetSection("Domain").Value;
                MailText = MailText.Replace("{Domain}", domain);

                var builder = new MimeKit.BodyBuilder();
                var receiverEmail = registrationRequestDTO.Email;
                string subject = "AtoTax: Confirm your Email Id";

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
                string txtdata = "https://" + domain + "/confirm-email?token=" + token + "&email=" + registrationRequestDTO.Email;

                MailText = MailText.Replace("{Domain}", domain);

                builder.HtmlBody = MailText;

                EmailDto emailDto = new EmailDto();
                emailDto.To = receiverEmail;
                emailDto.Subject = subject;
                emailDto.Body = builder.HtmlBody;

                await _emailSender.SendEmailAsync(emailDto);
                _logger.LogInformation("Confirm Email: " + receiverEmail + " Mail ID Confirmation Email Sent for the user!");


                bool isroleExists = await _roleManager.RoleExistsAsync("Admin");
                if (!isroleExists)
                {
                    //var role = await  _context.Roles.AddAsync(new IdentityRole("admin"));
                    //  _context.SaveChanges(); //error points here


                    IdentityRole identityRole = new();
                    identityRole.Name = "Admin";


                    IdentityResult rolAddresult = await _roleManager.CreateAsync(identityRole);

                    if (!rolAddresult.Succeeded)
                    {
                        var roleAddException = rolAddresult.Errors.Aggregate("Admin role assignment failed", (current, error) => current + (" - " + error + "\n\r"));
                        throw new Exception(roleAddException);
                    }

                }
                if (result.Succeeded)
                {
                    IdentityRole role = await _roleManager.FindByNameAsync("Admin");
                    IdentityResult addRoleResult = await _userManager.AddToRoleAsync(appUser, role.Name);

                    if (!addRoleResult.Succeeded)
                    {
                        var exceptionRole = addRoleResult.Errors.Aggregate("Admin role assignment failed", (current, error) => current + (" - " + error + "\n\r"));
                        throw new Exception(exceptionRole);
                    }

                    var usertoReturn = _context.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);


                    return _mapper.Map<UserDTO>(usertoReturn);

                }
            }
            catch (Exception)
            {

                throw;
            }

            return new UserDTO();
        }

        public async Task<APIResponse> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO)
        {

            var userName = forgotPasswordDTO.username;
            var email = forgotPasswordDTO.email;
            string token = null;
            if (userName == null && email == null)
            {
                _response.Result = forgotPasswordDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Username or Email is required" };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;

            }

            ApplicationUser appuser = new();
            if (!userName.IsNullOrEmpty())
            {
                appuser = _userManager.Users.FirstOrDefault(u => u.UserName == userName);
            }
            else
            {
                appuser = await _userManager.FindByEmailAsync(email);
            }

            if (appuser == null)
            {
                _response.Result = forgotPasswordDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "User not found" };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;
            }
            bool isUserConfirmed = await _userManager.IsEmailConfirmedAsync(appuser);

            if (!isUserConfirmed)
            {
                _response.Result = forgotPasswordDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Your email ID has not been confirmed yet. Cant reset the password!" };
                _response.StatusCode = HttpStatusCode.BadRequest;
                return _response;
            }
            if (appuser != null && isUserConfirmed)
                if (appuser != null)
                {
                    token = await _userManager.GeneratePasswordResetTokenAsync(appuser);
                    token = token.Replace("+", "^^^");
                }

            // Send Token via email for password reset

            string[] paths = { Directory.GetCurrentDirectory(), "PasswordReset.html" };
            string FilePath = Path.Combine(paths);
            _logger.LogInformation("Email template path " + FilePath);
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            var domain = _config.GetSection("Domain").Value;
            MailText = MailText.Replace("{Domain}", domain);

            var builder = new MimeKit.BodyBuilder();
            var receiverEmail = appuser.Email;
            string subject = "Password Reset Link";
            string txtdata = "https://" + domain + "/resetpassword?token=" + token + "&email=" + appuser.Email;

            MailText = MailText.Replace("{PasswordResetUrl}", txtdata);

            builder.HtmlBody = MailText;

            EmailDto emailDto = new EmailDto();
            emailDto.To = receiverEmail;
            emailDto.Subject = subject;
            emailDto.Body = builder.HtmlBody;

            await _emailSender.SendEmailAsync(emailDto);
            _logger.LogInformation("ForgotPassword: " + receiverEmail + "Password Reset Email Sent with token");

            _response.Result = forgotPasswordDTO;
            _response.IsSuccess = true;
            _response.ErrorMessages = null;
            _response.StatusCode = HttpStatusCode.OK;

            return _response;
        }


        public async Task<APIResponse> ConfirmEmail(ConfirmEmailDTO confirmEmailDTO)
        {
            if (confirmEmailDTO.email == null || confirmEmailDTO.token == null)
            {
                _response.Result = confirmEmailDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Trouble with confirmation email link, contact Admin" };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            var user = await _userManager.FindByEmailAsync(confirmEmailDTO.email);

            if (user == null)
            {
                _response.Result = confirmEmailDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "User not found!" };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }


            var result = await _userManager.ConfirmEmailAsync(user, confirmEmailDTO.token);

            if (result.Succeeded)
            {
                _response.Result = confirmEmailDTO;
                _response.IsSuccess = true;
                _response.ErrorMessages = null;
                _response.StatusCode = HttpStatusCode.OK;
            }
            return _response;
        }

        public async Task<APIResponse> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {

            string email = resetPasswordDTO.Email;
            string token = resetPasswordDTO.Token;
            string newPassword = resetPasswordDTO.NewPassword;

            var appuser = await _userManager.FindByEmailAsync(email);

            if (appuser == null)
            {
                _response.Result = resetPasswordDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Email is invalid" };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            if (appuser != null)
            {

                token = token.Replace("^^^", "+");
                var result = await _userManager.ResetPasswordAsync(appuser, token, newPassword);
                if (result.Succeeded)
                {
                    var receiverEmail = email;
                    string subject = "You have successfully reset your Password";
                    string body = "Your new Password is: " + newPassword;

                    EmailDto emailDto = new EmailDto();
                    emailDto.To = receiverEmail;
                    emailDto.Subject = subject;
                    emailDto.Body = body;

                    await _emailSender.SendEmailAsync(emailDto);
                    _logger.LogInformation("Password Reset: " + receiverEmail + "Password has been Reset");

                    _response.Result = null;
                    _response.IsSuccess = true;
                    _response.ErrorMessages = null;
                    _response.StatusCode = HttpStatusCode.OK;
                }

            }
            return _response;
        }

        public async Task<APIResponse> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            string email = changePasswordDTO.Email;
            string oldPassword = changePasswordDTO.Oldpassword;
            string newPassword = changePasswordDTO.NewPassword;

            var appuser = await _userManager.FindByEmailAsync(email);

            if (appuser == null)
            {
                _response.Result = changePasswordDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Email ID is invalid" };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            //ApplicationUser? user = await _userManager.GetUserAsync(HttpContext.User);
            //EmpId = int.Parse(HttpContext.User.Claims.First(c => c.Type == "EmployeeId").Value);

            if (appuser != null)
            {
                var validCredentials = await _signinManager.UserManager.CheckPasswordAsync(appuser, newPassword);

                if (!validCredentials)
                {
                    _response.Result = changePasswordDTO;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Current Password is incorrect" }; ;
                    _response.StatusCode = HttpStatusCode.BadRequest;

                }

                var result = await _userManager.ChangePasswordAsync(appuser, oldPassword, newPassword);

                if (result.Succeeded)
                {
                    var receiverEmail = email;
                    string subject = "You have successfully reset your Password";
                    string body = "Your new Password is: " + newPassword;

                    EmailDto emailDto = new EmailDto();
                    emailDto.To = receiverEmail;
                    emailDto.Subject = subject;
                    emailDto.Body = body;

                    await _emailSender.SendEmailAsync(emailDto);
                    _logger.LogInformation("Password Reset: " + receiverEmail + "Password has been Reset");

                    _response.Result = null;
                    _response.IsSuccess = true;
                    _response.ErrorMessages = null;
                    _response.StatusCode = HttpStatusCode.OK;
                }

            }
            return _response;
        }

        public async Task<APIResponse> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            _response.Result = users;
            _response.IsSuccess = true;
            _response.ErrorMessages = null;
            _response.StatusCode = HttpStatusCode.OK;

            return _response;
        }
    }
}

