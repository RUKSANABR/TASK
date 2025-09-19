using System;
using System.Threading;

namespace NotificationMvc.Models
{
    //Define the delegate
    public delegate void Download(string fileName);

    public class FileDownloader
    {
        //Define the event
        public event Download DownloadCompleted;

        //method
        public string DownloadFile(string fileName)
        {
            // Simulate download
            Thread.Sleep(1000);

            // Raise event
            DownloadCompleted?.Invoke(fileName);

            return $"{fileName} download finished.";
        }
    }
}
