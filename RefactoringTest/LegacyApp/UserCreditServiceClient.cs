using LegacyApp.Services.Contracts;
namespace LegacyApp
{
    using System;

    public class UserCreditServiceClient : IUserCreditServiceClient, IDisposable
    {
        public int GetCreditLimit(string firstName, string surname, DateTime dateOfBirth)
        {
            return 200;
        }

        public void Dispose()
        {

        }
    }
}
