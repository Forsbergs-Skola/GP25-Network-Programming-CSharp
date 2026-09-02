string catFactUrl = "https://catfact.ninja/fact";

HttpClient client = new HttpClient();

// GET Request
try{
	string response = await client.GetStringAsync(catFactUrl);
	Console.WriteLine(response);
}
catch (HttpRequestException e){
	Console.WriteLine(e.Message);
}



