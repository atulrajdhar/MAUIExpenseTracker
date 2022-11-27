namespace ExpenseTracker.IServices;
public interface ISettingsService
{
    Task<T> Get<T> (string key, T defaultValue);
    Task Save<T> (string key, T value);
}
