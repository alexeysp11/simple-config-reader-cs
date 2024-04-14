using SimpleConfigReader.Core.ConfigurationManagers;
using SimpleConfigReader.Core.ObjectPooling;

namespace SimpleConfigReader.ConsoleApp;

/// <summary>
/// Class for standardized launch of an application instance.
/// </summary>
public class StartupInstance : IStartupInstance
{
    private IConfigurationManager m_xmlConfigurationManager;
    private IConfigurationManager m_csvConfigurationManager;
    private IConfigurationPool m_configurationPool;

    public StartupInstance(
        XmlConfigurationManager xmlConfigurationManager,
        CsvConfigurationManager csvConfigurationManager,
        IConfigurationPool configurationPool)
    {
        m_xmlConfigurationManager = xmlConfigurationManager;
        m_csvConfigurationManager = csvConfigurationManager;
        m_configurationPool = configurationPool;
    }

    /// <summary>
    /// Method for standardized launch of an application instance.
    /// </summary>
    public void Start()
    {
        string directoryPath = "data";

        // Reading XML configurations.
        ReadConfigurations(directoryPath, "*.xml", "XML", ImportConfigurationFromXml);
        ReadConfigurations(directoryPath, "*.csv", "CSV", ImportConfigurationFromCsv);

        PrintConfigurations();
    }

    private void ReadConfigurations(
        string directoryPath,
        string mask,
        string fileExtension,
        Action<string> processingDelegate)
    {
        string[] files = Directory.GetFiles(directoryPath, mask);
        if (files.Length == 0)
            return;

        Task[] tasks = new Task[files.Length];

        System.Console.WriteLine($"Reading {fileExtension} configurations: started");
        for (int i = 0; i < files.Length; i++)
        {
            int index = i;
            tasks[index] = Task.Run(() => processingDelegate(files[index]));
            //processingDelegate(files[index]);
        }
        Task.WaitAll(tasks);
        System.Console.WriteLine($"Reading {fileExtension} configurations: finished");
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

    private void ImportConfigurationFromCsv(string filePath)
    {
        try
        {
            var configuration = m_csvConfigurationManager.ImportConfiguration(filePath);
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
            System.Console.WriteLine(config);
        }
    }
}