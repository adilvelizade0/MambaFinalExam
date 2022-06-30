using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extentions
    {
        public static async Task<string> CreateImage(this IFormFile file, string path, string fileDir)
        {
            string fileName = file.FileName;
            if (fileName.Length > 219)
            {
                fileName.Substring(fileName.Length - 219, 219);
            }

            fileName = Guid.NewGuid().ToString() + fileName;

            string root = Path.Combine(path, "uploads",fileDir,fileName);

            await using(FileStream fs = new FileStream(root, FileMode.Create))
            {
               await file.CopyToAsync(fs);
            }

            return fileName;

        }
    }
}
