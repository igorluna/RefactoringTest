namespace LegacyApp
{
    using LegacyApp.Services.Contracts;

    public class ClientRepository : IClientRepository
    {
        public Client GetById(int clientId) 
        {
            return new Client { Name = "ImportantClient" };
        }
    }
}
