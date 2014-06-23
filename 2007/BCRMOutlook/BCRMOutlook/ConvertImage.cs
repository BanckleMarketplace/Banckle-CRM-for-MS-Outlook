using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCRMOutlook
{
	sealed public class ConvertImage : System.Windows.Forms.AxHost
	{
		private ConvertImage()
			: base(null)
		{
		}

		public static stdole.IPictureDisp Convert(System.Drawing.Image image)
		{
			return (stdole.IPictureDisp)System.Windows.Forms.AxHost.GetIPictureDispFromPicture(image);
		}
	}
}
