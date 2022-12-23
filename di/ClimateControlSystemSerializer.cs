using System;
using System.IO;
using System.Xml.Serialization;

namespace ClimateControlSystemNamespace
{
    public class ClimateControlSystemSerializer
    {
        public void Serialize(ClimateControlSystem system, string path)
        {
            var writer = new XmlSerializer(typeof(ClimateControlSystem));
            var Path = $@"{path}";
            var configurationFile = File.Create(Path);

            writer.Serialize(configurationFile, system);
            configurationFile.Close();
        }

        public ClimateControlSystem Deserialize(string path)
        {
            var reader = new XmlSerializer(typeof(ClimateControlSystem));
            var configurationFile = new StreamReader(path);

            var climateControlSystem = (ClimateControlSystem)reader.Deserialize(configurationFile);

            if (climateControlSystem == null)
                throw new ApplicationException(
                    "Unable to create climate control system object! Maybe configuration file is empty?");

            configurationFile.Close();
            return climateControlSystem;
        }
    }
}