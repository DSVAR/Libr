using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Libr.RepeatsCodes
{
    public class SaveFile
    {
      static  public string UpLoadFile(IFormFile photo, IWebHostEnvironment _IwebHostEnvironment)
        {
            string folder = Path.Combine(_IwebHostEnvironment.WebRootPath, "images");
            string UniqName = null;
            if (photo != null)
            {
                UniqName = Guid.NewGuid().ToString() + "__" + photo.FileName;
                string FilePath = Path.Combine(folder, UniqName);
                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    photo.CopyTo(fs);
                }
            }
            return UniqName;
        }
    }
}
