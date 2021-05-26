using System;
using System.Collections.Generic;
using System.Text;

namespace LegacyApp
{
    public class UserCreditServiceClient : IDisposable
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
