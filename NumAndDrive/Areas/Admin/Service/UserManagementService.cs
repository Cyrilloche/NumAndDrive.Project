
using Microsoft.AspNetCore.Identity;
using MySqlConnector;
using NumAndDrive.Areas.Admin.DTOs;
using NumAndDrive.Models;
using NumAndDrive.ViewModels.Account;
using System.IO;

namespace NumAndDrive.Areas.Admin.Service
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementService(IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public string CreateTemporaryFile(IFormFile file)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\wwwroot\data\");
            string fileName = file.FileName;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileNameWithPath = Path.Combine(path, fileName);

            using var stream = new FileStream(fileNameWithPath, FileMode.Create);
            file.CopyTo(stream);

            return fileName;
        }

        public async Task ReadAndCreateUsersAsync(IFormFile file)
        {
            string fileName = CreateTemporaryFile(file);

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\wwwroot\data\", fileName);
            StreamReader streamReader = new StreamReader(filePath);
            string line;
            string[] values;
            line = streamReader.ReadLine(); // Skip the first line

            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();
                values = line.Split(';');
                string lastname = values[0];
                string firstname = values[1];
                string email = values[2];
                string password = values[3];
                string role = values[4];


                CreateUserDTO newUser = new CreateUserDTO
                {
                    Lastname = lastname,
                    Firstname = firstname,
                    Username = email,
                    Email = email,
                    ProvisoryPaswword = password,
                    Role = role
                };

                await CreateUser(newUser);
            }
            streamReader.Close();

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public async Task CreateUser(CreateUserDTO newUser)
        {
            var user = new User
            {
                Lastname = newUser.Lastname,
                Firstname = newUser.Firstname,
                UserName = newUser.Email,
                Email = newUser.Email
            };

            var result = await _userManager.CreateAsync(user,newUser.ProvisoryPaswword);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, newUser.Role);
            }
        }
    }
}
