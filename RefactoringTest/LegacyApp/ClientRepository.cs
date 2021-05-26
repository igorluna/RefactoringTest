using System;
using System.Collections.Generic;
using System.Text;

namespace LegacyApp
{
    public class ClientRepository
    {
        public Client GetById(int clientId) 
        {
            return new Client { Name = "ImportantClient" };
        }
    }
}
