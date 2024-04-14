using SimpleConfigReader.Core.ConfigurationManagers;
using SimpleConfigReader.Core.ObjectPooling;

namespace SimpleConfigReader.ConsoleApp;

/// <summary>
/// Class for standardized launch of an application instance.
/// </summary>
public class StartupInstance : IStartupInstance
{
    private IConfigurationManager m_xmlConfigurationManager;
    private ConfigurationPool m_configurationPool;

    public StartupInstance()
    {
        string appSettings = "appsettings.json";
        m_xmlConfigurationManager = new XmlConfigurationManager(appSettings, "config");
        m_configurationPool = new ConfigurationPool();
    }

    /// <summary>
    /// Method for standardized launch of an application instance.
    /// </summary>
    public void Run()
    {
        string directoryPath = "data";

        // Reading XML configurations.
        string[] files = Directory.GetFiles(directoryPath, "*.xml");
        System.Console.WriteLine("Reading XML configurations: started");
        foreach (var file in files)
        {
            ImportConfigurationFromXml(file);
        }
        System.Console.WriteLine("Reading XML configurations: finished");

        //files = Directory.GetFiles(directoryPath, "*.csv");
        //foreach (var file in files)
        //{
        //    ImportConfigurationFromCsv(file);
        //}

        PrintConfigurations();
    }

    private void ImportConfigurationFromXml(string filePath)
    {
        try
        {
            var configuration = m_xmlConfigurationManager.ImportConfiguration(filePath);
            m_configurationPool.AddConfiguration(configuration);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"- Exception while parsing the file '{filePath}': '{ex.Message}'");
        }
    }

    private void PrintConfigurations()
    {
        Console.WriteLine("Configurations:");
        var configurations = m_configurationPool.Configurations;
        foreach (var config in configurations)
        {
            Console.WriteLine(config);
        }
    }
}