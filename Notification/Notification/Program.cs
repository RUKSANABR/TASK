using System;
using System.Threading;

// delegate
public delegate void Download(string fileName);

public class FileDownloader
{
    // event using deligate
    public event Download DownloadCompleted;

    // raise the event
    public void DownloadFile(string fileName)
    {
        Console.WriteLine($"Downloading {fileName}...");
        Thread.Sleep(1000);
        Console.WriteLine($"{fileName} download finished.");

        // Raise the event
        DownloadCompleted?.Invoke(fileName);
    }
}

// method to handles the event
public class User
{
    public void DownloadCompleted(string fileName)
    {
        Console.WriteLine($"Notification: {fileName} has been downloaded.");
    }
}

class Program
{
    static void Main()
    {
        // Create objects
        FileDownloader downloader = new FileDownloader();
        User user = new User();

        // Subscribe method to the event
        downloader.DownloadCompleted += user.DownloadCompleted;

        // Start download
        downloader.DownloadFile("hello.pdf");
    }
}
