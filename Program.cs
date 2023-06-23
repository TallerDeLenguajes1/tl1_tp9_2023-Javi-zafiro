using Clase;
using System.IO;
using System.Net;
using System.Text.Json;

var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";
try
{
    using (WebResponse response = request.GetResponse())
    {
        using (Stream strReader = response.GetResponseStream())
        {
            if (strReader == null) return;
            using (StreamReader objReader = new StreamReader(strReader))
            {
                string responseBody = objReader.ReadToEnd();
                Root Precios = JsonSerializer.Deserialize<Root>(responseBody);
                Console.WriteLine(Precios.bpi.EUR.rate);
                Console.WriteLine(Precios.bpi.USD.rate);
                Console.WriteLine(Precios.bpi.GBP.rate);

                Console.WriteLine(Precios.bpi.EUR.code);
                Console.WriteLine(Precios.bpi.EUR.description);
                Console.WriteLine(Precios.bpi.EUR.rate);
                Console.WriteLine(Precios.bpi.EUR.rate_float);
                Console.WriteLine(Precios.bpi.EUR.symbol);
            }
        }
    }
}
catch (WebException ex)
{
    Console.WriteLine("Problemas de acceso a la API");
}