using System;
using System.Net;
using System.Drawing;
using System.IO;
using FluentSharp.CoreLib.API;


namespace FluentSharp.CoreLib
{
    public static class Web_ExtensionMethods_Http_Requests
    {
        public static string    getHtml(this Uri uri, bool showDebugMessage)
        {
            showDebugMessage.ifInfo("Downloading html code for: {0}", uri.str());
            return uri.getHtml();
        }        
        public static string    getUrlContents(this Uri uri)
        {
            return uri.getUrlContents(null);
        }
        public static string    getUrlContents(this Uri uri, string cookies)
        {
            return new Web().getUrlContents(uri.str(), cookies, false);
        }
        public static string    getHtml(this Uri uri)
        {
            return uri.getUrlContents();
        }
        public static string    getHtmlAndSave(this Uri uri)
        {
            return uri.getHtmlAndSaveOnFolder("".o2Temp2Dir());
        }
        public static string    getHtmlAndSaveOnFolder(this Uri uri, string targetFolder)
        {
            var html = uri.getHtml();
            if (html.valid())
            {
                var targeFileName = targetFolder.pathCombine(uri.fileNameFriendly());
                return html.save(targeFileName);
            }
            return "";
        }
        public static Bitmap    getImageAsBitmap(this Uri uri)
        {
            var webClient = new WebClient();
            var imageBytes = webClient.DownloadData(uri);
            "image size :{0}".info(imageBytes.size());
            var memoryStream = new MemoryStream(imageBytes);
            var bitmap = new Bitmap(memoryStream);
            return bitmap;
        }
    }
}
