using LegacyApp.Services;
using LegacyApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IDateTimeService dateTimeService;
        private readonly IClientRepository clientRepository;
        private readonly IUserCreditServiceClient userCreditServiceClient;
        private readonly IUserDataAccess userDataAccess;

        public UserService(
            IDateTimeService datetimeService,
            IClientRepository clientRepository,
            IUserCreditServiceClient userCreditServiceClient,
            IUserDataAccess userDataAccess)
        {
            this.dateTimeService = datetimeService;
            this.clientRepository = clientRepository;
            this.userCreditServiceClient = userCreditServiceClient;
            this.userDataAccess = userDataAccess;
        }

        public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firname)
                || string.IsNullOrEmpty(surname))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains(","))
            {
                return false;
            }

            var now = dateTimeService.GetCurrentDateTime();
            var age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                Firstname = firname,
                Surname = surname
            };

            if (client.Name == "VeryImportantClient")
            {
                user.HasCredtLimit = false;
            }
            else if (client.Name == "ImportantClient")
            {
                user.HasCredtLimit = true;
                var creditLimit = userCreditServiceClient.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCredtLimit = true;
                using (var userCreditService = new UserCreditServiceClient())
                {
                    var creditLimit = userCreditService.GetCreditLimit(user.Firstname, user.Surname, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCredtLimit && user.CreditLimit < 500)
            {
                return false;
            }

            userDataAccess.AddUser(user);

            return true;
        }
    }
}
