using System;

namespace test;
public class InputMethodDemoTwo
{
    public static void Main()
    {
      int[] pole = { 1, 2, 4,7 };

      Console.WriteLine("Max number of Array: {0}",Maximum(pole));

      SortArray(pole, out pole);
      Console.Write("Sorter Array: ");
      foreach (int i in pole) {
        Console.Write("{0}, ",i);
          
      }
      Console.WriteLine("\nBinary Search {0}",BinarySearch(pole, 2));
    }

    public static int Maximum(int[] pole)
    {
      int max = pole[0];
      foreach (int cislo in pole) {
        if(max< cislo){
          max = cislo;
        }
          
      }
      return max;
    }

    public static void SortArray(int[] pole,out int[] pole2)
    {
      int n = pole.Length;
      for (int i = 0; i < n - 1; i++)
      {
          for (int j = 0; j < n - i - 1; j++)
          {
              if (pole[j] < pole[j + 1])
              {
                  int temp = pole[j];
                  pole[j] = pole[j + 1];
                  pole[j + 1] = temp;
              }
          }
      }
      pole2 = pole;
    }

    public static int BinarySearch(int[] pole, int cislo){
      int min = 0;
      int max = pole.Length -1;
      while (min < max) {
        int mid = (min + max)/2;
        int mcislo = pole[mid];
        if(mid == min || max == mid){
          return -1;
        }
        if(cislo == mcislo){
          return mid;
        }
        else if(cislo > mcislo){
          max = mid;
        }
        else{
          min = mid;
        }
      }
      return -1;
    }

}
