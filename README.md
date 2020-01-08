![](https://github.com/KevWK314/ThreeFourteen.FinnhubClient/workflows/BuildAndTest/badge.svg)

# ThreeFourteen Finnhub Client

A client that can be used to access Finnhub Market Data.

To use this library you will need to register with [Finnhub](https://finnhub.io/) and get hold of an API Key.

Please take a look at the [Finnhub API Documentation](https://finnhub.io/docs/api) to see what data is available. 

## Create the Client

Creating a client is very simple, all you need is the API key. If you would like to inject your own instance of [HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient), there is an overload for the constructor (be sure not to set BaseAddress on the HttpClient).

```c#
// Without HttpClient
var client = new FinnhubClient(apiKey);

...

// With HttpClient
var client = new FinnhubClient(httpClient, apiKey);
```

## Use the Client

To use the client it's a simple as using Intellisense to guide you. The API calls have been abstracted to be inline with the [API documentation](https://finnhub.io/docs/api). Find the data you require and make the call.

```c#
// Stock
var company = await client.Stock.GetCompany("AAPL");
var compensation = await client.Stock.GetCompensation("AAPL");
var recommendations = await client.Stock.GetRecommendationTrends("AAPL");
var priceTarget = await client.Stock.GetPriceTarget("AAPL");
var peers = await client.Stock.GetPeers("AAPL");
var earnings = await client.Stock.GetEarnings("AAPL");
var exchanges = await client.Stock.GetExchanges();
var symbols = await client.Stock.GetSymbols("US");
var quote = await client.Stock.GetQuote("AAPL");
var candles = await client.Stock.GetCandles("AAPL", Resolution.Day, 10);

// Forex
var exchanges = await client.Forex.GetExchanges();
var symbols = await client.Forex.GetSymbols("fxcm");
var candles = await client.Forex.GetCandles(symbols.First().CandleSymbol, Resolution.Day, 10);

// Crypto
var exchanges = await client.Crypto.GetExchanges();
var symbols = await client.Crypto.GetSymbols("Binance");
var candles = await client.Crypto.GetCandles(symbols.First().CandleSymbol, Resolution.Day, 10);
```

There is a way to get hold of the raw response data for any call but you will have to managed deserialisation yourself (the response type is a string). This will allow the use of the client even when all the calls have not been implemented (yet).

```c#
// Get Raw Data
var rawData = await client.GetRawDataAsync("stock/profile", new Field(FieldKeys.Symbol, "AAPL"));
```

# In Closing

The Author of this library is not affiliated with Finnhub, so please do not send questions on the data or the API to myself. 

But if you do have any questions or changes you would like to see (for this library), please feel free to raise an issue. I can't guarantee it will be addressed instantly but I will get to it as soon as I can.

Please be aware that you use this library at your own risk and I take no responsibility for any defects (but I will try fix them if you ask nicely).
