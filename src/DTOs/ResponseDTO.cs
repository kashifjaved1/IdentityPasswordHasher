namespace IdentityPasswordHasher.Models
{
    public class ResponseDTO
    {
        public string Data { get; set; } = null;
        public bool Succeeded { get; set; } = false;
        public object Error { get; set; } = null;
    }
}
