using System.Runtime.Serialization;

namespace WebDriverForAvBY
{
    [DataContract]
    public class Car
    {
        [DataMember(Name = "Mark")]
        public string Mark { get; set; }
        [DataMember(Name = "Model")]
        public string Model { get; set; }
        [DataMember(Name = "YearFrom")]
        public int YearFrom { get; set; }
        [DataMember(Name = "YearTo")]
        public int YearTo { get; set; }
        [DataMember(Name = "Transmission")]
        public string Transmission { get; set; }
        [DataMember(Name = "BodyType")]
        public string BodyType { get; set; }
        [DataMember(Name = "Fuel")]
        public string Fuel { get; set; }
        [DataMember(Name = "PriceFrom")]
        public double PriceFrom { get; set; }
        [DataMember(Name = "PriceTo")]
        public double PriceTo { get; set; }
    }
}
