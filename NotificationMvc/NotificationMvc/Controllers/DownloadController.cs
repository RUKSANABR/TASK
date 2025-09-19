using Microsoft.AspNetCore.Mvc;
using NotificationMvc.Models;

namespace NotificationMvc.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult StartDownload()
        {
            var downloader = new FileDownloader();
            var user = new User();

            // Subscribe to event
            downloader.DownloadCompleted += user.DownloadCompleted;

            // Call method
            string status = downloader.DownloadFile("hello.pdf");

            // Pass data to view
            ViewBag.DownloadStatus = status;
            ViewBag.Notification = user.Message;

            return View();
        }
    }
}