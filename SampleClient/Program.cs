using System.Net.Http.Json;
using SampleClient;

string catFactUrl = "https://catfact.ninja/fact";
string webhookUrl = "https://hooks.zapier.com/hooks/catch/8338993/ujs9jj9/";
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
	score = 00
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

try{
	List<ScoreEntry>? scores =
		await client.GetFromJsonAsync<List<ScoreEntry>>(
			"https://script.google.com/macros/s/AKfycbys5aEPMvNCutyhNYYCcQcCjzsi2UtqNspmKyCH-AicJxJbCJMrAoT0LUaYaXhTWA8n/exec"
		);

	foreach (ScoreEntry score in scores!)
	{
		Console.WriteLine(
			$"{score.Name}: {score.Score}"
		);
	}
}
catch (HttpRequestException e){
	Console.WriteLine(e.Message);
}

public class ScoreEntry{
	public string Name{ get; set; } = "";
	public int Score {get; set;}
}


