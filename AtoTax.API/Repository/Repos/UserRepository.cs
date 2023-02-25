
using AtoTax.API.Authentication;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.DTOs.AuthDTOs;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtoTax.API.Repository.Repos
{
    public class UserRepository : IUserRepository
    {

        private readonly AtoTaxDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<EmpJobRole> _logger;
        private readonly IMapper _mapper;
        private string secretkey;
        public UserRepository(AtoTaxDbContext context, ILogger<EmpJobRole> logger, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            secretkey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        public bool IsUniqueUser(string username)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x=> x.UserName == username);
            if(user == null)
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
                    new Claim(ClaimTypes.Role, string.Join(",",roles))
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


                bool isroleExists = await _roleManager.RoleExistsAsync("admin");
                if (!isroleExists)
                {
                    //var role = await  _context.Roles.AddAsync(new IdentityRole("admin"));
                    //  _context.SaveChanges(); //error points here


                    IdentityRole identityRole = new();
                    identityRole.Name = "Admin";
             

                    IdentityResult rolAddresult = await _roleManager.CreateAsync(identityRole);

                    if (!rolAddresult.Succeeded)
                    {
                        var roleAddException= rolAddresult.Errors.Aggregate("Admin role assignment failed", (current, error) => current + (" - " + error + "\n\r"));
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

                    var usertoReturn = _context.ApplicationUsers.FirstOrDefault(u=> u.UserName== registrationRequestDTO.UserName);


                    return _mapper.Map<UserDTO>(usertoReturn);
                   
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           return new UserDTO();
        }
    }
}

