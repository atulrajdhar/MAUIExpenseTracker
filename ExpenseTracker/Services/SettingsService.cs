namespace ExpenseTracker.Services;

public class SettingsService : ISettingsService
{
    public Task<T> Get<T>(string key, T defaultValue)
    {
        var result = Preferences.Default.Get<T>(key, defaultValue);

        return Task.FromResult(result);
    }

    public Task Save<T>(string key, T value)
    {
        Preferences.Default.Set(key, value);

        return Task.CompletedTask;
    }
}
