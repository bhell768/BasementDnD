using System.Data;

namespace BasementDnD.Models
{
    public class LoginInfoResponse
    {
        public bool Islogged{get; set;}
        public string Username{get; set;}
        public string Displayname{get; set;}
    }
}