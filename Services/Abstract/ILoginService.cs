using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementRPG.Models.Login;
using System.Threading.Tasks;


namespace BasementRPG.Services.Abstract
{
    public interface ILoginService
    {
        Task<bool> Login(LoginRequest request);
        Task<bool> Logout();
        Task<LoginInfoResponse> GetInfo();
        byte[] VerifyLogin();
        //implement when change to hashing
        //Task<bool> CheckPassword(byte[] id, string password);
        Task<bool> SignUp(SignupRequest request);
    }
}