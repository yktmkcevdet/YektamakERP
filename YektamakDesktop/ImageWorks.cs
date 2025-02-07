using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Models;

namespace YektamakDesktop
{
    internal static class ImageWorks
    {
        internal static byte[] GetBytesFromImage(Image image,ImageFormat format)
        {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, format);
            byte[] resimData= new byte[stream.Length];
            stream.Position=0;
            stream.Read(resimData, 0, resimData.Length);
            return resimData;
        }
        internal static ImageFormat GetImageFileFormatFromPath(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            ImageFormat returnFormat = null;
            
            switch( extension)
            {
                case ".jpg": returnFormat = ImageFormat.Jpeg; break;
                case ".jpeg": returnFormat = ImageFormat.Jpeg; break;
                case ".png": returnFormat = ImageFormat.Png; break;
                case ".ico": returnFormat = ImageFormat.Icon; break;
                case ".bmp": returnFormat = ImageFormat.Bmp; break;
                case ".gif": returnFormat = ImageFormat.Gif; break;
                case ".tif": returnFormat = ImageFormat.Tiff; break;
                case ".tiff": returnFormat = ImageFormat.Tiff; break;
                default:break;
            }            
            return returnFormat;
        }
        internal static ImageFormat GetImageFormatFromString(string imageFormat)
        {
            ImageFormat returnFormat = null;
            if (imageFormat == null) return returnFormat;
            switch (imageFormat.ToLower())
            {
                case ".jpg": returnFormat = ImageFormat.Jpeg; break;
                case ".jpeg": returnFormat = ImageFormat.Jpeg; break;
                case ".png": returnFormat = ImageFormat.Png; break;
                case ".ico": returnFormat = ImageFormat.Icon; break;
                case ".bmp": returnFormat = ImageFormat.Bmp; break;
                case ".gif": returnFormat = ImageFormat.Gif; break;
                case ".tif": returnFormat = ImageFormat.Tiff; break;
                case ".tiff": returnFormat = ImageFormat.Tiff; break;
                case "jpg": returnFormat = ImageFormat.Jpeg; break;
                case "jpeg": returnFormat = ImageFormat.Jpeg; break;
                case "png": returnFormat = ImageFormat.Png; break;
                case "ico": returnFormat = ImageFormat.Icon; break;
                case "bmp": returnFormat = ImageFormat.Bmp; break;
                case "gif": returnFormat = ImageFormat.Gif; break;
                case "tif": returnFormat = ImageFormat.Tiff; break;
                case "tiff": returnFormat = ImageFormat.Tiff; break;
                default: returnFormat = ImageFormat.Jpeg; break;
            }
            return returnFormat;
        }
        internal static Image GetImageFromBytes(byte[] imageData, ImageFormat format)
        {
            if(imageData == null || format==null) return null;
            if (imageData.Length < 2) return null;
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                Image image = Image.FromStream(stream);
                // Image format bilgisini kaydetmek için, format parametresini kullanarak resmi yeniden kaydedin
                using (MemoryStream newStream = new MemoryStream())
                {
                    image.Save(newStream, format);
                    return Image.FromStream(newStream);
                }
            }
        }
    }
}