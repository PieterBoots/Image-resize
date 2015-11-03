# Image-resize
interpolation non linear

 private void button_Click(object sender, EventArgs e)
      {

        pictureBox1.Image = Image.FromFile("clown.bmp");
        Bitmap bmp = (Bitmap)pictureBox1.Image;
        Bitmap bmp2 = new Bitmap(bmp.Width * 2, bmp.Height * 2);


        int[,] dat = new int[bmp.Width, bmp.Height];
        int[,] dat2 = new int[bmp.Width * 2, bmp.Height * 2];



        for (int y = 0; y < bmp.Height; y++)
        {
          for (int x = 0; x < bmp.Width; x++)
          {
            dat[x, y] = bmp.GetPixel(x, y).R;

          }
        }

        for (int y = 1; y < bmp.Height - 1; y++)
        {
          for (int x = 1; x < bmp.Width - 1; x++)
          {
            int[] Vs = new int[]
          {dat[x-1,y-1],
            dat[x,y-1],
            dat[x+1,y-1],
            dat[x-1,y],
            dat[x,y],
            dat[x+1,y],
            dat[x-1,y+1],
            dat[x,y+1],
            dat[x+1,y+1]};
            int cls = Resize.classifyX(Vs);

            double[] W1 = new double[9];
            double[] W2 = new double[9];
            double[] W3 = new double[9];
            double[] W4 = new double[9];
            for (int t = 0; t < 9; t++)
            {
              W1[t] = Resize.data3x3[cls, 0, t];
              W2[t] = Resize.data3x3[cls, 1, t];
              W3[t] = Resize.data3x3[cls, 2, t];
              W4[t] = Resize.data3x3[cls, 3, t];
            }

            double r1 = Resize.filter(W1, Vs);
            double r2 = Resize.filter(W2, Vs);
            double r3 = Resize.filter(W3, Vs);
            double r4 = Resize.filter(W4, Vs);

            if (r1 > 255) { r1 = 255; }; if (r1 < 0) { r1 = 0; }
            if (r2 > 255) { r2 = 255; }; if (r2 < 0) { r2 = 0; }
            if (r3 > 255) { r3 = 255; }; if (r3 < 0) { r3 = 0; }
            if (r4 > 255) { r4 = 255; }; if (r4 < 0) { r4 = 0; }


            dat2[x * 2, y * 2] = Convert.ToInt32(r1);
            dat2[x * 2 + 1, y * 2] = Convert.ToInt32(r2);
            dat2[x * 2, y * 2 + 1] = Convert.ToInt32(r3);
            dat2[x * 2 + 1, y * 2 + 1] = Convert.ToInt32(r4);
          }
        }

        for (int y = 0; y < bmp2.Height; y++)
        {
          for (int x = 0; x < bmp2.Width; x++)
          {
            bmp2.SetPixel(x, y, Color.FromArgb(255, dat2[x, y], dat2[x, y], dat2[x, y]));
          }
        }

        pictureBox1.Image = bmp2;

        bmp2.Save("outp.bmp");
      }

