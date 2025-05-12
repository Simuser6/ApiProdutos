
internal class CustomLoggerProvider : ILoggerProvider
{
    private CustomLoggerProviderConfiguration customLoggerProviderConfiguration;

    public CustomLoggerProvider(CustomLoggerProviderConfiguration customLoggerProviderConfiguration)
    {
        this.customLoggerProviderConfiguration = customLoggerProviderConfiguration;
    }
}