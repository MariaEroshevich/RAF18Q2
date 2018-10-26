using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace WebDriverForAvBY.Utilities
{
    public class JSONDeSerializer
    {
        private List<Car> carOptions = new List<Car>();

        public List<Car> ReadJsonFile(string file)
        {
            carOptions = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(file));
            return carOptions;
        }
    }
}
