using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
// string companies = File.ReadAllText(@"./data.json");
// var company = JsonSerializer.Deserialize<Company>(companies);
// Console.WriteLine(companies);


public class Program
{
    public static void Main(string[] args)
    {
        string jsonString = File.ReadAllText(@"./data.json");

        List<Company> companies = JsonSerializer.Deserialize<List<Company>>(jsonString);
        string htmlContent = GenerateHtml(companies);

        File.WriteAllText("output.html", htmlContent);
        Console.WriteLine("HTML file generated successfully.");
    }

    private static string GenerateHtml(List<Company> companies)
    {
        var html = new System.Text.StringBuilder();
        html.Append("<html><body><table border='1'><tr><th>Name</th><th>Ticker</th><th>Stock Price</th><th>Daily Change</th></tr>");

        foreach (var company in companies)
        {
            html.Append($"<tr><td>{company.name}</td><td>{company.ticker}</td><td>{company.price}</td><td>{company.delta}</td></tr>");
        }

        html.Append("</table></body></html>");
        return html.ToString();
    }
}