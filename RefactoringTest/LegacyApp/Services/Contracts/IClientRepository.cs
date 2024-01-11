namespace LegacyApp.Services.Contracts
{
    public interface IClientRepository
    {
        Client GetById(int clientId);
    }
}
