using System.IO;

namespace ClimateControlSystem.Domain
{
    public class ConfigurationPathValidator
    {
        public bool Validate(string _path)
        {
            if (File.Exists(_path))
                return true;
            return false;
        }
    }
}