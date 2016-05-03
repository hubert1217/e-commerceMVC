using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace e_commerceMVC.Infrastructure
{
    public static class UrlHelpers
    {

        public static string KategoryIconPath(this UrlHelper helper, string kategoryIconFilename)
        {
            var kategoryIconFolder = AppConfig.KategoryIconsFolderRelative;
            var path = Path.Combine(kategoryIconFolder, kategoryIconFilename);
            var absolutePath = helper.Content(path);

            return absolutePath;

        }

        public static string ProductPhotoPath(this UrlHelper helper, string productFilename)
        {

            var productPhotoFolder = AppConfig.PhotosFolderRelative;
            var path = Path.Combine(productPhotoFolder, productFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}