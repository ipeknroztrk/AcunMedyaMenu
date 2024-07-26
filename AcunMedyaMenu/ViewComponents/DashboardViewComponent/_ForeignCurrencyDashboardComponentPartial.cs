using AcunMedyaMenu.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class _ForeignCurrencyDashboardComponentPartial : ViewComponent
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "212vJOoZEYmCGHkmoJ6lR1:6VAJfIotcAmVa1WH32iZbF"; // API anahtarınızı buraya ekleyin

    public _ForeignCurrencyDashboardComponentPartial(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await GetCurrencyRatesAsync();
        return View(model);
    }

    private async Task<ForeignCurrencyModel> GetCurrencyRatesAsync()
    {
        // Döviz kurlarını al
        var currencyUrl = $"https://www.alphavantage.co/query?function=FX_DAILY&from_symbol=USD&to_symbol=TRY&apikey={_apiKey}";
        var currencyResponse = await _httpClient.GetStringAsync(currencyUrl);
        var currencyJson = JObject.Parse(currencyResponse);

        // En son döviz kuru (USD/TRY)
        var latestRate = currencyJson["Time Series FX (Daily)"]?
            .First?.First?["4. close"]?.ToObject<decimal>() ?? 0;

        // Euro ve Pound için aynı şekilde API'ye çağrı yapabilirsiniz veya mevcut verileri kullanabilirsiniz
        var euroRate = await GetExchangeRateAsync("USD", "EUR");
        var poundRate = await GetExchangeRateAsync("USD", "GBP");

        var model = new ForeignCurrencyModel
        {
            BaseCurrency = "USD",
            EuroRate = euroRate * latestRate, // Türk Lirası cinsinden Euro kuru
            DollarRate = latestRate, // Türk Lirası cinsinden Dolar kuru
            PoundRate = poundRate * latestRate, // Türk Lirası cinsinden Pound kuru
        };

        return model;
    }

    private async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
    {
        var url = $"https://www.alphavantage.co/query?function=FX_DAILY&from_symbol={fromCurrency}&to_symbol={toCurrency}&apikey={_apiKey}";
        var response = await _httpClient.GetStringAsync(url);
        var json = JObject.Parse(response);

        // En son döviz kuru
        var latestRate = json["Time Series FX (Daily)"]?
            .First?.First?["4. close"]?.ToObject<decimal>() ?? 0;

        return latestRate;
    }
}
