using Newtonsoft.Json.Linq;

namespace AcunMedyaMenu.Models
{
    public class ForeignCurrencyModel
    {
        public string BaseCurrency { get; set; }
        public decimal EuroRate { get; set; }
        public decimal DollarRate { get; set; }
        public decimal PoundRate { get; set; }
    }
}
