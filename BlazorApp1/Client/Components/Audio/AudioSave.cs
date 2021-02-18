using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace BlazorApp1.Client
{
    public class AudioSave : Controller
    {
        IHostingEnvironment _hostingEnvironment;

        public AudioSave(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("api/[controller]/Save")]
        [HttpPost]
        public async Task<IActionResult> Save(IFormFile file)
        {
            if (file.ContentType != "audio/wav")
            {
                return BadRequest("Wrong file type");
            }
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");//uploads where you want to save data inside wwwroot

            //var filePath = Path.Combine(uploads, Path.GetRandomFileName() + ".wav");
            var filePath = Path.Combine(uploads, file.FileName + ".wav");
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok("File uploaded successfully");
        }
    }
}
