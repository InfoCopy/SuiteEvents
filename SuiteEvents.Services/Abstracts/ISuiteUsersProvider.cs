namespace SuiteEvents.Providers.Abstracts
{
    public interface ISuiteUsersProvider
    {
        void CreateSuiteUser(string userName, string password, string applicationName, string nome, string cognome, string email);
    }
}
