using System.Data;

namespace BasementDnD.Models.Login
{
    public class Login
    {
        public byte[] Id_Bin {get; set;}
        public string Displayname {get; set;}
        public string Username{get; set;}
        public string Email{get; set;}
        public string Password {get; set;}
    }
}