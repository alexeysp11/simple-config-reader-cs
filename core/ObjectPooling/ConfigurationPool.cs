using SimpleConfigReader.Core.Models;

namespace SimpleConfigReader.Core.ObjectPooling;

/// <summary>
/// A class that implements an object pool pattern for storing the Configuration instances.
/// </summary>
public sealed class ConfigurationPool
{
    private object m_lockObject;
    private List<Configuration> m_configurations;
    private List<Configuration> m_cachedConfigurations;

    /// <summary>
    /// A cached collection of configuration settings.
    /// </summary>
    public IReadOnlyList<Configuration> Configurations
    {
        get
        {
            if (m_cachedConfigurations == null)
            {
                m_cachedConfigurations = new List<Configuration>(m_configurations);
            }
            return m_cachedConfigurations;
        }
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ConfigurationPool()
    {
        m_lockObject = new object();
        m_configurations = new List<Configuration>();
    }

    /// <summary>
    /// Add an instance of the Configuration object to the pool.
    /// </summary>
    /// <param name="configuration">Instance of the Configuration object</param>
    public void AddConfiguration(Configuration configuration)
    {
        lock (m_lockObject)
        {
            m_configurations.Add(configuration);
        }
        ClearCachedFields();
    }

    private void ClearCachedFields()
    {
        m_cachedConfigurations = null;
    }
}