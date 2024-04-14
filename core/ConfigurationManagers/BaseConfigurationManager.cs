using SimpleConfigReader.Core.Models;

namespace SimpleConfigReader.Core.ConfigurationManagers;

/// <summary>
/// Base class for configuration managers.
/// </summary>
public abstract class BaseConfigurationManager : IConfigurationManager
{
    protected readonly string m_rootObjectName;
    protected Dictionary<string, List<string>> m_fieldMappings = new Dictionary<string, List<string>>();

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="rootObjectName"></param>
    public BaseConfigurationManager(string jsonFilePath, string rootObjectName)
    {
        if (string.IsNullOrEmpty(jsonFilePath))
            throw new System.ArgumentNullException(nameof(jsonFilePath), "JSON file path could not be null or empty");
        if (string.IsNullOrEmpty(rootObjectName))
            throw new System.ArgumentNullException(nameof(rootObjectName), "Root object name could not be null or empty");

        m_rootObjectName = rootObjectName;
        LoadFieldMappingsFromJson(jsonFilePath);
    }

    /// <summary>
    /// Load all possible field names from the JSON file.
    /// </summary>
    /// <param name="jsonFilePath">Name of the JSON file.</param>
    private void LoadFieldMappingsFromJson(string jsonFilePath)
    {
        string jsonContent = System.IO.File.ReadAllText(jsonFilePath);

        // Stub!!!
        m_fieldMappings["Name"] = new List<string>
        {
            "Name",
            "name",
            "ConfigName",
            "configName",
            "configname"
        };
        m_fieldMappings["Description"] = new List<string>
        {
            "Description",
            "description",
            "ConfigDescription",
            "configDescription",
            "configdescription"
        };

        //JObject jsonObject = JObject.Parse(jsonContent);

        //m_fieldMappings.Clear();
        //foreach (var property in jsonObject[m_rootObjectName])
        //{
        //    string fieldName = property.Key;
        //    m_fieldMappings[fieldName] = property.Value.ToObject<List<string>>();
        //}
    }

    /// <summary>
    /// Read the configuration from the config file.
    /// </summary>
    /// <param name="configFilePath">Specified name of the config file.</param>
    /// <returns>Instance of the Configuration object.</returns>
    public abstract Configuration ImportConfiguration(string configFilePath);
}
