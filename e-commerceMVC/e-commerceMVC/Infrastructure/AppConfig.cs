using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace e_commerceMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _kategoryIconsFolderRelative = ConfigurationManager.AppSettings["KategoryIconsFolder"];


        public static string KategoryIconsFolderRelative 
        {
            get 
            {
                return _kategoryIconsFolderRelative;
            }
            
        
        }


        private static string _photosFolderRelative = ConfigurationManager.AppSettings["PhotosFolder"];

        public static string PhotosFolderRelative 
        {
            get 
            {
                return _photosFolderRelative;
            }
        }




    }
}