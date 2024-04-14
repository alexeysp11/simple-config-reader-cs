using System.Xml;
using SimpleConfigReader.Core.Models;

namespace SimpleConfigReader.Core.ConfigurationManagers;

/// <summary>
/// Manager for getting configuration from XML files.
/// </summary>
public class XmlConfigurationManager : BaseConfigurationManager, IConfigurationManager
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="rootObjectName"></param>
    public XmlConfigurationManager(string jsonFilePath, string rootObjectName) : base(jsonFilePath, rootObjectName)
    {
    }

    /// <summary>
    /// Read the configuration from the config file.
    /// </summary>
    /// <param name="configFilePath">Specified name of the config file.</param>
    /// <returns>Instance of the Configuration object.</returns>
    public override Configuration ImportConfiguration(string configFilePath)
    {
        if (string.IsNullOrEmpty(configFilePath))
            throw new System.ArgumentNullException(nameof(configFilePath), "Config file path could not be null or empty");

        XmlDocument doc = new XmlDocument();
        doc.Load(configFilePath);

        var configuration = new Configuration();
        foreach (var fieldName in m_fieldMappings.Keys)
        {
            foreach (string xmlField in m_fieldMappings[fieldName])
            {
                XmlNode fieldNode = doc.SelectSingleNode($"/{m_rootObjectName}/{xmlField}");
                if (fieldNode != null)
                {
                    if (fieldName == "Name")
                        configuration.Name = fieldNode.InnerText;
                    else if (fieldName == "Description")
                        configuration.Description = fieldNode.InnerText;
                }
            }
        }
        if (string.IsNullOrEmpty(configuration.Name))
            throw new System.Exception($"The instance of the Configuration object must have a name when attempting to parse the specified file: '{configFilePath}'");

        return configuration;
    }
}