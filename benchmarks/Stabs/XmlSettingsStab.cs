using System.Collections.Generic;
using SimpleConfigReader.Core.Models;

namespace SimpleConfigReader.Benchmarks.Stabs;

public static class XmlSettingsStab
{
    private static XmlSettings s_xmlSettings;

    static XmlSettingsStab()
    {
        s_xmlSettings = new XmlSettings
        {
            RootObjectName = "config",
            FieldMappings = new Dictionary<string, List<string>>()
        };
        s_xmlSettings.FieldMappings["Name"] = new List<string>
        {
            "Name",
            "name",
            "ConfigName",
            "configName",
            "configname"
        };
        s_xmlSettings.FieldMappings["Description"] = new List<string>
        {
            "Description",
            "description",
            "ConfigDescription",
            "configDescription",
            "configdescription"
        };
    }

    public static XmlSettings GetXmlSettings()
    {
        return s_xmlSettings;
    }
}