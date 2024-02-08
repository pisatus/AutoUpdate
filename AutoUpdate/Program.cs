using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;

class Program
{
    private static string outputCsvFolder = "output"; // Path to your CSV output file


    private static string authToken = "";

    static async Task Main()
    {
        Console.WriteLine("Hello, Windows App!");

        string latestVersion = GetLatestVersionFromGitHub();
        Console.WriteLine($"latestVersion {latestVersion}");
        Console.WriteLine("Finished.");
        // Pause the application until any key is pressed
        Console.ReadKey();
    }

    public static void CheckForUpdates()
    {
        string latestVersion = GetLatestVersionFromGitHub();
        string currentVersion = GetCurrentVersion();

        if (latestVersion != currentVersion)
        {
            DownloadAndReplaceExecutable();
            RestartApplication();
        }
    }

    private static string GetLatestVersionFromGitHub()
    {
        string owner = "pisatus";
        string repo = "AutoUpdate";
        string url = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";
        string responseJson;

        using (WebClient client = new WebClient())
        {
            client.Headers.Add("User-Agent", "request");
            responseJson = client.DownloadString(url);
        }

        dynamic releaseInfo = JObject.Parse(responseJson);
        return releaseInfo.tag_name;
    }


    private static string GetCurrentVersion()
    {
        // Retrieve the version from the assembly information
        Version version = Assembly.GetExecutingAssembly().GetName().Version;
        return version.ToString();
    }

    private static void DownloadAndReplaceExecutable()
    {
        // Implement code to download the latest executable from GitHub release assets
        // and replace the existing executable with the new one
    }

    private static void RestartApplication()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        //Process.Start(System.Windows.Forms.Application.ExecutablePath);        Environment.Exit(0);
        Process.Start(Process.GetCurrentProcess().MainModule.FileName); Environment.Exit(0);
        //System.Net.Mime.MediaTypeNames.Application.Restart();        Environment.Exit(0);
    }
}
