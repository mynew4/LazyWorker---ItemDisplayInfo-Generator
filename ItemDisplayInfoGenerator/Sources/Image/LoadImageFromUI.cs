using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ItemDisplayInfoGenerator.Sources.Image
{
    class LoadImageFromUI
    {
        public static void LoadIconFromWoWHead(System.Windows.Forms.PictureBox PictureBox, string icon)
        {
            var request = WebRequest.Create("http://wow.zamimg.com/images/wow/icons/large/" + icon + ".jpg");

            try
            {
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    PictureBox.Image = Bitmap.FromStream(stream);
                }
            }
            catch
            {

            }
        }
    }
}
