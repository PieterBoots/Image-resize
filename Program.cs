using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Image_resize
{
  class Program
  {
    static void Main(string[] args)
    {
  
      Bitmap bmp =(Bitmap) Bitmap.FromFile("clown.bmp");
      Bitmap bmp2 = new Bitmap(bmp.Width * 2, bmp.Height * 2);

      Color[,] dat2 = Resize.run(bmp);

      for (int y = 0; y < bmp2.Height; y++)
      {
        for (int x = 0; x < bmp2.Width; x++)
        {
          bmp2.SetPixel(x, y, dat2[x, y]);
        }
      }
 
      bmp2.Save("result.bmp");
    }

  }
}
