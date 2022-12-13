using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.Runner;

public class PuzzleInputProvider
{
	public static PuzzleInputProvider Instance { get; } = new();

	private readonly HttpClient _httpClient;

	private PuzzleInputProvider()
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables()
			.Build();
		var sessionId = configuration["sessionId"];

		var baseAddress = new Uri("https://adventofcode.com");
		var cookieContainer = new CookieContainer();
		cookieContainer.Add(baseAddress, new Cookie("session", sessionId));

		_httpClient = new HttpClient(
			new HttpClientHandler
			{
				CookieContainer = cookieContainer,
				AutomaticDecompression = DecompressionMethods.All,
			})
		{
			BaseAddress = baseAddress,
			DefaultRequestHeaders =
			{
				{ "User-Agent", ".NET/7.0 (https://github.com/HeathDev/adventofcode by stuart@turner-isageek.com)" },
			},
		};
	}

	public PuzzleInput GetRawInput(int year, int day)
	{
		//var inputFile = @$"Inputs\{year}\day{day:00}.input.txt";
		var inputFile = Path.Combine(Environment.CurrentDirectory,
			@$"..\..\..\..\Puzzles\{year}\AdventOfCode{year}\Challenges\D{day:00}\input.txt");
		Directory.CreateDirectory(Path.GetDirectoryName(inputFile)!);
		if (File.Exists(inputFile))
			return new PuzzleInput(
				File.ReadAllBytes(inputFile),
				File.ReadAllText(inputFile),
				File.ReadAllLines(inputFile));
		var response = _httpClient.GetAsync($"{year}/day/{day}/input")
			.GetAwaiter()
			.GetResult();
		response.EnsureSuccessStatusCode();

		var text = response.Content.ReadAsStringAsync()
			.GetAwaiter()
			.GetResult();
		File.WriteAllText(inputFile, text);

		return new PuzzleInput(
			File.ReadAllBytes(inputFile),
			File.ReadAllText(inputFile),
			File.ReadAllLines(inputFile));
	}
}
