namespace SimpleConfigReader.Core.Models;

public class Configuration
{
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}";
    }
}