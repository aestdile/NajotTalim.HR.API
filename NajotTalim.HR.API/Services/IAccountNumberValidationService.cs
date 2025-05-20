namespace NajotTalim.HR.API.Services
{
    public interface IAccountNumberValidationService
    {
        bool IsValid(string accountNumber);
    }
}
