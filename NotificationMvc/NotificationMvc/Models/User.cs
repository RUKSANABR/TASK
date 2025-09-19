namespace NotificationMvc.Models
{
    public class User
    {
        public string Message { get; set; }

        public void DownloadCompleted(string fileName)
        {
            Message = $"{fileName} has been downloaded.";
        }
    }
}
