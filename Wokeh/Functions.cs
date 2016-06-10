using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows;

namespace Wokeh
{
    class Functions
    {
        public string htmlEntt(int Entt)
        {
            string text = Clipboard.GetText();
            string result = Entt == 0 ? WebUtility.HtmlEncode(text) : WebUtility.HtmlDecode(text);
            Clipboard.SetText(result);
            return result;
        }
        public string toBase64()
        {
            OpenFileDialog dOpen = new OpenFileDialog();
            dOpen.Filter = "Image Files|*.bmp;*.png;*.jpg;*.jpeg;*.gif;";
            Nullable<bool> y = dOpen.ShowDialog();
            if (y == true)
            {
                string loc = dOpen.FileName;
                string ext = Path.GetExtension(loc).Replace(".", "");

                using (Image img = Image.FromFile(loc))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, img.RawFormat);
                        string imgString = "data:image/"+ext+";base64," + Convert.ToBase64String(ms.ToArray());
                        Clipboard.SetText(imgString);
                        return imgString;
                    }
                }
            }
            else return "No image Selected";
        }
    }
}
