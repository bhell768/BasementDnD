using System.Data;

namespace BasementRPG.Models.Login
{
    public class SignupRequest
    {
        public string Username{ get; set; }
        public string Displayname{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string VPassword { get; set; }
        public bool Persistent{get; set;}
    }
}