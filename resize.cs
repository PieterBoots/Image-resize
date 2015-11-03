using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Resize
{

  public static int classifyX(int[] data)
  {
    double average = 0;
    for (int d = 0; d < data.Length; d++)
    {
      average = average + data[d];
    }

    average = average / data.Length;

    int a1 = 0;

    for (int d = 0; d < data.Length; d++)
    {
      int twos = 1 << d;
      int v = (data[d] > average) ? twos : 0;
      a1 = a1 + v;
    }

    return a1;
  }
  
    public static double filter(double[] W, int[] data)
  {
    double FilterOutput = 0;
    for (int d = 0; d < data.Length; d++)
    {
      FilterOutput = FilterOutput + W[d] * data[d];
    }

    return FilterOutput / data.Length;
  }

}
