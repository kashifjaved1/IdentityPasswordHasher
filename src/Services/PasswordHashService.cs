using IdentityPasswordHasher.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityPasswordHasher.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public PasswordHashService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseDTO> GenerateHash(string password)
        {
            IdentityUser user = new()
            {
                UserName = "test-user",
            };

            var result = await _userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                var existingUser = await _userManager.FindByNameAsync(user.UserName);

                ResponseDTO response = new()
                {
                    Data = existingUser.PasswordHash,
                    Succeeded = result.Succeeded,
                };

                await _userManager.DeleteAsync(existingUser);

                return response;
            }

            return new ResponseDTO
            {
                Error = result.Errors.ToList(),
            };
        }
    }
}
