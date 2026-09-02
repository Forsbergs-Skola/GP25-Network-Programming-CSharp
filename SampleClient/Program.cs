using System.Net.Http.Json;
using SampleClient;

string catFactUrl = "https://catfact.ninja/fact";
string webhookUrl = "https://webhook.site/984ddf2f-3b80-4576-94e5-22095f5c9f0b";
HttpClient client = new HttpClient();


await GetCatFact();

async Task GetCatFact(){
	// GET Request with JSON to Class Conversion
	try{
		CatFact? catFact = await client.GetFromJsonAsync<CatFact>(catFactUrl);
	
		Console.WriteLine(catFact?.Fact);
	}
	catch (HttpRequestException e){
		Console.WriteLine(e.Message);
	}
}

// Format the payload in JSON
var data = new{
	name = "Ben",
	lunch = "rice",
	priceOfLunch = 32.5,
	isFull = true
};

try {
	// POST while expecting a response
	HttpResponseMessage postResponse = await client.PostAsJsonAsync(webhookUrl, data);
	
	postResponse.EnsureSuccessStatusCode();
	// Converts response to readable String
	string result = await postResponse.Content.ReadAsStringAsync();
	
	// Show the converted response
	Console.WriteLine(result);
}

catch (HttpRequestException e){
	Console.WriteLine(e.Message);
}



