namespace LegacyApp.Services.Contracts
{
    using System;

    public interface IUserCreditServiceClient
    {
        int GetCreditLimit(string firstName, string surname, DateTime dateOfBirth);
    }
}
