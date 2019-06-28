using System.Data;

namespace BasementDnD.Models
{
    public class LoginRequest
    {
        public string Username{get; set;}
        public string Password{get; set;}
        public bool Persistent{get; set;}
    }
}