﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ToolHelper
{
    public class ImageHelper
    {
        /// <summary>
        ///image file convert to byte array
        /// </summary>
        /// <param name="path">image path</param>
        /// <returns>byte array result</returns>
        public static Byte[] ImageToByteArray(string path)
        {
            try
            {
                using (var fs = File.OpenRead(path))
                {
                    int filelength = 0;
                    filelength = (int)fs.Length;
                    Byte[] imagebyte = new Byte[filelength];
                    fs.Read(imagebyte, 0, filelength);
                    fs.Close();
                    return imagebyte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// image file convert to base64 string
        /// </summary>
        /// <param name="path">image path</param>
        /// <returns>base64 string result</returns>
        public static string ImageToBase64(string path)
        {
            try
            {
                var byteArr = ImageToByteArray(path);
                return Convert.ToBase64String(byteArr);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// base64 to image
        /// </summary>
        /// <param name="base64">base64 string</param>
        /// <param name="path">store path</param>
        public static void Base64ToImage(string base64, string path)
        {
            try
            {
                string filepath = Path.GetDirectoryName(path);
                if (!Directory.Exists(filepath))
                {
                    if (filepath != null) Directory.CreateDirectory(filepath);
                }
                var match = Regex.Match(base64, "data:image/png;base64,([\\w\\W]*)$");
                if (match.Success)
                {
                    base64 = match.Groups[1].Value;
                }
                var photoBytes = Convert.FromBase64String(base64);
                File.WriteAllBytes(path, photoBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// check image is jpg
        /// </summary>
        /// <param name="imageBase64">image base64 string</param>
        /// <returns>true is jpg  false not jpg</returns>
        public static bool IsJPG(string imageBase64)
        {
            try
            {
                var img = Convert.FromBase64String(imageBase64);
                var jpgStr = $"{img[0].ToString()}{img[1].ToString()}";
                return jpgStr.Equals($"{(int)ImageFormat.JPG}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// check image is png
        /// </summary>
        /// <param name="imageBase64">image base64 string</param>
        /// <returns>true is png  false not png</returns>
        public static bool IsPNG(string imageBase64)
        {
            try
            {
                var img = Convert.FromBase64String(imageBase64);
                var jpgStr = $"{img[0].ToString()}{img[1].ToString()}";
                return jpgStr.Equals($"{(int)ImageFormat.PNG}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// check image is gif
        /// </summary>
        /// <param name="imageBase64">image base64 string</param>
        /// <returns>true is gif  false not gif</returns>
        public static bool IsGIF(string imageBase64)
        {
            try
            {
                var img = Convert.FromBase64String(imageBase64);
                var jpgStr = $"{img[0].ToString()}{img[1].ToString()}";
                return jpgStr.Equals($"{(int)ImageFormat.GIF}");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public enum ImageFormat
        {
            JPG = 255216,
            GIF = 7173,
            PNG = 13780,
        }
    }
}
