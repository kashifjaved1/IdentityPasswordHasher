using IdentityPasswordHasher.Models;

namespace IdentityPasswordHasher.Services
{
    public interface IPasswordHashService
    {
        Task<ResponseDTO> GenerateHash(string password);
    }
}
