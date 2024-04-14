using SimpleConfigReader.Core.Models;

namespace SimpleConfigReader.Core.ConfigurationManagers;

/// <summary>
/// Manager for getting configuration from CSV files.
/// </summary>
public class CsvConfigurationManager : BaseConfigurationManager, IConfigurationManager
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public CsvConfigurationManager(string jsonFilePath, string rootObjectName) : base(jsonFilePath, rootObjectName)
    {
    }

    /// <summary>
    /// Read the configuration from the config file.
    /// </summary>
    /// <param name="configFilePath">Specified name of the config file.</param>
    /// <returns>Instance of the Configuration object.</returns>
    public override Configuration ImportConfiguration(string configFilePath)
    {
        throw new NotImplementedException();
    }
}