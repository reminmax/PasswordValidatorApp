namespace PasswordValidatorApp.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<string>> GetDataForValidation();
    }
}
