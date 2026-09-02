using System.Net.Http.Json;

string catFactUrl = "https://catfact.ninja/fact";

HttpClient client = new HttpClient();

// GET Request with JSON to Class Conversion
try{
	CatFact? catFact = await client.GetFromJsonAsync<CatFact>(catFactUrl);
	
	Console.WriteLine(catFact?.Fact);
}
catch (HttpRequestException e){
	Console.WriteLine(e.Message);
}



