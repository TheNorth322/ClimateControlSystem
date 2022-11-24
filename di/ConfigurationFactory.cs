using System;
namespace ClimateControlSystemNamespace
{
    public class ClimateControlSystemSerializer
    {
        public ClimateControlSystemSerializer() {}
            
        
        public void Serialize(object system)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(object));
            string path = $@"C:\Users\TheNorth\source\repos\ClimateControlSystem\ClimateControlSystem\Configurations\{System.DateTime.Now.ToString("MM-dd")}.xml";
            System.IO.FileStream configurationFile = System.IO.File.Create(path);

            writer.Serialize(configurationFile, system);
            configurationFile.Close(); 
        }

        public ClimateControlSystem Deserialize(string path)
        { 
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(ClimateControlSystem));
            System.IO.StreamReader configurationFile = new System.IO.StreamReader(path);

            ClimateControlSystem climateControlSystem = (ClimateControlSystem) reader.Deserialize(configurationFile);
            
            if (climateControlSystem == null)
                throw new ApplicationException("Unable to create climate control system object! Maybe configuration file is empty?");

            configurationFile.Close();
            return climateControlSystem;
        }
    }
}
