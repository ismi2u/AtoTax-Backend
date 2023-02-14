
using AtoTax.API.Authentication;
using AtoTax.API.Repository.Interfaces;
using AtoTax.Domain.DTOs;
using AtoTax.Domain.DTOs.AuthDTOs;
using AtoTax.Domain.Entities;
using AtoTaxAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtoTax.API.Repository.Repos
{
    public class UserRepository : IUserRepository
    {

        private readonly AtoTaxDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<EmpJobRole> _logger;
        private readonly IMapper _mapper;
        private string secretkey;
        public UserRepository(AtoTaxDbContext context, ILogger<EmpJobRole> logger, 
            UserManager<ApplicationUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
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
           var user = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower() && u.Password == loginRequestDTO.Password );


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

            var roles = _userManager.GetRolesAsync(user);


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

        public Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
        {
          // var localuser =  _mapper.Map<LocalUser>(registrationRequestDTO);

            LocalUser localuser = new();
            localuser.Name = registrationRequestDTO.Name;
            localuser.UserName = registrationRequestDTO.UserName;
            localuser.Password = registrationRequestDTO.Password;
            localuser.Role = registrationRequestDTO.Role;
            
            _context.LocalUsers.Add(localuser);
            _context.SaveChanges();
            localuser.Password = "";

            return Task.FromResult(localuser);
        }
    }
}

