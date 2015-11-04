# Image-resize
interpolation non linear


 static void Main(string[] args)
    {
    
        Bitmap bmp =(Bitmap) Image.FromFile("clown.bmp");
        Bitmap bmp2 = new Bitmap(bmp.Width * 2, bmp.Height * 2);

        Color[,] dat = new Color[bmp.Width, bmp.Height];
        Color[,] dat2 = new Color[bmp.Width * 2, bmp.Height * 2];
        

        for (int y = 0; y < bmp.Height; y++)
        {
          for (int x = 0; x < bmp.Width; x++)
          {
            dat[x, y] = bmp.GetPixel(x, y);
          }
        }

        for (int y = 1; y < bmp.Height - 1; y++)
        {
          for (int x = 1; x < bmp.Width - 1; x++)
          {         

            int[] Vs = new int[]
          {dat[x-1,y-1].R,
            dat[x,y-1].R,
            dat[x+1,y-1].R,
            dat[x-1,y].R,
            dat[x,y].R,
            dat[x+1,y].R,
            dat[x-1,y+1].R,
            dat[x,y+1].R,
            dat[x+1,y+1].R};

            int cls = AdaptiveFilter.classifyX(Vs);
            int[] Rsubs=CalcSubPixels(Vs,cls);

             Vs = new int[]
          {dat[x-1,y-1].G,
            dat[x,y-1].G,
            dat[x+1,y-1].G,
            dat[x-1,y].G,
            dat[x,y].G,
            dat[x+1,y].G,
            dat[x-1,y+1].G,
            dat[x,y+1].G,
            dat[x+1,y+1].G};

             cls = AdaptiveFilter.classifyX(Vs);
             int[] Gsubs = CalcSubPixels(Vs, cls);

             Vs = new int[]
          {dat[x-1,y-1].B,
            dat[x,y-1].B,
            dat[x+1,y-1].B,
            dat[x-1,y].B,
            dat[x,y].B,
            dat[x+1,y].B,
            dat[x-1,y+1].B,
            dat[x,y+1].B,
            dat[x+1,y+1].B};

             cls = AdaptiveFilter.classifyX(Vs);
             int[] Bsubs = CalcSubPixels(Vs, cls);


             dat2[x * 2, y * 2] = Color.FromArgb(255, Rsubs[0], Gsubs[0], Bsubs[0]);
             dat2[x * 2 + 1, y * 2] = Color.FromArgb(255, Rsubs[1], Gsubs[1], Bsubs[0]);
             dat2[x * 2, y * 2 + 1] = Color.FromArgb(255, Rsubs[2], Gsubs[2], Bsubs[0]);
             dat2[x * 2 + 1, y * 2 + 1] = Color.FromArgb(255, Rsubs[3], Gsubs[3], Bsubs[0]);
          }
        }

        for (int y = 0; y < bmp2.Height; y++)
        {
          for (int x = 0; x < bmp2.Width; x++)
          {
            bmp2.SetPixel(x, y,  dat2[x, y]);
          }
        }

        bmp2.Save("outp.bmp");
        }
