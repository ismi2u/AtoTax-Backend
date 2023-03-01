
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

        public bool IsUniqueEmail(string email)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return true;
            }
            return false;
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

        public async Task<APIResponse> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            _response.Result = roles;
            _response.IsSuccess = true;
            _response.ErrorMessages = null;
            _response.StatusCode = HttpStatusCode.OK;

            return _response;
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

        public async Task<APIResponse> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            // var localuser =  _mapper.Map<LocalUser>(registrationRequestDTO);

            bool ifUserUniqueName = IsUniqueUser(registrationRequestDTO.UserName);

            if (!ifUserUniqueName)
            {
                _response.Result = registrationRequestDTO;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("UserName already exists");

                return _response;
            }

            ApplicationUser appuser = new ApplicationUser();
            if (!registrationRequestDTO.UserName.IsNullOrEmpty())
            {
                appuser = _userManager.Users.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
            }
            else
            {
                appuser = await _userManager.FindByEmailAsync(registrationRequestDTO.Email);
            }

            if (appuser != null)
            {
                _response.Result = registrationRequestDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Username and Email should be unique" };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;
            }

            ApplicationUser newAppUser = new ApplicationUser();

            newAppUser.Name = registrationRequestDTO.Name;
            newAppUser.Email = registrationRequestDTO.Email;
            newAppUser.NormalizedEmail = registrationRequestDTO.Email.ToUpper();
            newAppUser.UserName = registrationRequestDTO.UserName;
            
            try
            {
                var result = await _userManager.CreateAsync(newAppUser, registrationRequestDTO.Password);

                if (!result.Succeeded)
                {
                    _response.Result = registrationRequestDTO;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { result.Errors.Aggregate("User Registration Failed", (current, error) => current + (" - " + error.Description.ToString() + "\n\r")) };
                    _response.StatusCode = HttpStatusCode.BadRequest;

                    return _response;
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

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newAppUser);
                string txtdata = "http://" + domain + "/confirm-email?token=" + token + "&email=" + registrationRequestDTO.Email;

                MailText = MailText.Replace("{Domain}", domain);
                MailText = MailText.Replace("{ConfirmEmailUrl}", txtdata);


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
                        _response.Result = registrationRequestDTO;
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string> { result.Errors.Aggregate("User Registered, but Role assignment failed", (current, error) => current + (" - " + error.Description.ToString() + "\n\r")) };
                        _response.StatusCode = HttpStatusCode.BadRequest;

                        return _response;
                    }

                }
                if (result.Succeeded)
                {
                    IdentityRole role = await _roleManager.FindByNameAsync("Admin");
                    IdentityResult addRoleResult = await _userManager.AddToRoleAsync(newAppUser, role.Name);

                    if (!addRoleResult.Succeeded)
                    {
                        _response.Result = registrationRequestDTO;
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string> { result.Errors.Aggregate("Admin role assignment failed", (current, error) => current + (" - " + error.Description.ToString() + "\n\r")) };
                        _response.StatusCode = HttpStatusCode.BadRequest;

                        return _response;
                    }

                    var usertoReturn = _context.ApplicationUsers.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);


                    _response.Result = _mapper.Map<UserDTO>(usertoReturn);
                    _response.IsSuccess = true;
                    _response.SuccessMessage = "New user registered";
                    _response.ErrorMessages = null;
                    _response.StatusCode = HttpStatusCode.OK;

                    return _response;
                }
            }
            catch (Exception ex)
            {

                _response.Result = registrationRequestDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            _response.Result = registrationRequestDTO;
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Error Occured while registering user" };
            _response.StatusCode = HttpStatusCode.BadRequest;

            return _response;
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
                _response.ErrorMessages = new List<string> { "Your email ID has not been confirmed yet. Can't reset the password!" };
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
            string txtdata = "http://" + domain + "/resetpassword?token=" + token + "&email=" + appuser.Email;

            MailText = MailText.Replace("{PasswordResetUrl}", txtdata);

            builder.HtmlBody = MailText;

            EmailDto emailDto = new EmailDto();
            emailDto.To = receiverEmail;
            emailDto.Subject = subject;
            emailDto.Body = builder.HtmlBody;

            await _emailSender.SendEmailAsync(emailDto);
            _logger.LogInformation("ForgotPassword: " + receiverEmail + "Password reset email has been sent @ " + receiverEmail +" Please check your email to reset password.");

            _response.Result = forgotPasswordDTO;
            _response.IsSuccess = true;
            _response.SuccessMessage = "Password reset email has been sent @ " + receiverEmail + ". Please check your email to reset password.";
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
                _response.SuccessMessage = "Your email has been verified successfully.";
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
                    _response.SuccessMessage = "Your password has been reset successfully.";
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
                var validCredentials = await _signinManager.UserManager.CheckPasswordAsync(appuser, oldPassword);

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
                    _logger.LogInformation("Password Change: " + receiverEmail + "Password has been changed successfully.");

                    _response.Result = null;
                    _response.IsSuccess = true;
                    _response.SuccessMessage = "Password has been changed successfully.";
                    _response.ErrorMessages = null;
                    _response.StatusCode = HttpStatusCode.OK;
                }

            }
            return _response;
        }

        

        public async Task<APIResponse> DeleteUser(DeleteUserDTO deleteUserDTO)
        {

            ApplicationUser appuser = await _userManager.FindByIdAsync(deleteUserDTO.UserId);
            if(appuser != null)
            {
                var users = await _userManager.DeleteAsync(appuser);
                _response.Result = appuser;
                _response.IsSuccess = true;
                _response.SuccessMessage = "User removed successfully";
                _response.ErrorMessages = null;
                _response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                _response.Result = appuser;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "User not found!" };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            return _response;
        }

        public async Task<APIResponse> UpdateUser(UpdateUserDTO updateUserDTO)
        {

            if (updateUserDTO.UserName == null || updateUserDTO.Password == null)
            {
                _response.Result = updateUserDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Username Password required to update Name/Email" };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;
            }

            if (updateUserDTO.UserName == null ||
                updateUserDTO.OldEmail == null && updateUserDTO.NewEmail == null ||
                updateUserDTO.OldName == null && updateUserDTO.NewName == null )
            {
                _response.Result = updateUserDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Username/Email/Name/Password are required" };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;

            }


            ApplicationUser appuser = new();


            if (!updateUserDTO.UserName.IsNullOrEmpty())
            {
                appuser = _userManager.Users.FirstOrDefault(u => u.UserName == updateUserDTO.UserName);
               
            }
            else if (appuser == null)
            {
                _response.Result = updateUserDTO;
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "UserName not found" };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;
            }
            else
            {
                bool ifUserUniqueEmail = IsUniqueEmail(updateUserDTO.NewEmail);

                if (!ifUserUniqueEmail)
                {
                    _response.Result = updateUserDTO;
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { "Email Id should be Unique" };
                    _response.StatusCode = HttpStatusCode.BadRequest;

                    return _response;
                }
            }

            var validCredentials = await _signinManager.UserManager.CheckPasswordAsync(appuser, updateUserDTO.Password);

            if (validCredentials)
            {
                appuser.Email = updateUserDTO.NewEmail;
                appuser.Name = updateUserDTO.NewName;
            }

            IdentityResult result = await _userManager.UpdateAsync(appuser);

            if (!result.Succeeded)
            {
                _response.Result = result;
                _response.IsSuccess = false;
                _response.SuccessMessage = null;
                _response.ErrorMessages = new List<string> { result.Errors.Aggregate("User updation Failed", (current, error) => current + (" - " + error.Description.ToString() + "\n\r")) };
                _response.StatusCode = HttpStatusCode.BadRequest;

                return _response;
            }
            _response.Result = result;
            _response.IsSuccess = true; 
            _response.SuccessMessage = "User data updated successfully.";
            _response.ErrorMessages = null;
            _response.StatusCode = HttpStatusCode.OK;

            return _response;
        }

        public async Task<APIResponse> AssignRoles(AssignRolesDTO assignRolesDTO)
        {
            string userId = assignRolesDTO.UserId;

            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            //Remove Exisint Roles.
            var roles = await _userManager.GetRolesAsync(user);
            IdentityResult roleRemoval= await _userManager.RemoveFromRolesAsync(user, roles.ToArray());

            if(!roleRemoval.Succeeded) {

                _response.Result = roleRemoval;
                _response.IsSuccess = false; 
                _response.ErrorMessages = new List<string> { roleRemoval.Errors.Aggregate("Error occured while removing existing Roles", (current, error) => current + (" - " + error.Description.ToString() + "\n\r")) };
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }

          
            foreach (string RoleId in assignRolesDTO.RoleIds)
            {
                IdentityRole role = await _roleManager.FindByIdAsync(RoleId);
                IdentityResult result = await _userManager.AddToRoleAsync(user, role.Name);

                if (!result.Succeeded)
                {
                    _response.ErrorMessages.Add("Role : " + role.Name + " Assignment failed");
                  
                }
                else
                {
                    _response.ErrorMessages.Add("Role : "  + role.Name + " Assigned Successfully");
                }
            }

            return _response;
        }
    }
}

