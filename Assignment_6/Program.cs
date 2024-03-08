using System;
using System.IO;
using System.Net.Http;



class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter the URL: ");
        string url = Console.ReadLine();

        string content = await DownloadContent(url);

        await Write("A.txt", content);

        Console.WriteLine("Content downloaded and saved to A.txt.");
    }

    static async Task<string> DownloadContent(string url)
    {
        using var client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    static async Task Write(string filename, string content)
    {
        await File.WriteAllTextAsync(filename, content);
    }
}
