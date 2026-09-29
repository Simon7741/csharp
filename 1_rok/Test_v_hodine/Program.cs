using System.ComponentModel;
using System.Collections;

namespace Spojak;
    internal class Program
    {
        static void Main(string[] args){
          var troj = new Trojuhelnik();
          while(true){
          string vstup1 = Console.ReadLine();
          if (vstup1 == "q" || vstup1 == "Q"){
            break;
          }
          Int32 ax = Int32.Parse(vstup1);
          Int32 ay = Int32.Parse(Console.ReadLine());
          Int32 bx = Int32.Parse(Console.ReadLine());
          Int32 by = Int32.Parse(Console.ReadLine());
          Int32 cx = Int32.Parse(Console.ReadLine());
          Int32 cy = Int32.Parse(Console.ReadLine());
          int[] a = troj.pozice(ax,ay);
          int[] b = troj.pozice(bx,by);
          int[] c = troj.pozice(cx,cy);
          List<double> rozmery = troj.spocti(a,b,c);
          if (rozmery[0] + rozmery[1] > rozmery[2] && rozmery[1] + rozmery[2] > rozmery[0] && rozmery[0] + rozmery[2] > rozmery[1]){
              Console.WriteLine("vysledek:");
            foreach(var i in rozmery){
              Console.WriteLine(i);
            }
          }
          else {
            Console.WriteLine("Tyto tři body netvoří trojúhelník");
          }
          }
        }
        class Trojuhelnik {
          public Int32[] pozice(Int32 x,Int32 y){
            List<Int32> bod = new List<int>();
            Int32[] pole = new Int32[2] {x,y};
            // return bod;
            return pole;
          }
          public double vzdalenost(Int32[] a,Int32[] b){
            return Math.Sqrt(Math.Pow(a[0]-b[0],2)+Math.Pow(a[1]-b[1],2));

          }
          public List<double> spocti(int[] A , int[] B, int[] C){
            List<double> pole = new List<double>();
            double a = vzdalenost(B,C);
            double b = vzdalenost(A,C);
            double c = vzdalenost(A,B);
            pole.Add(a);
            pole.Add(b);
            pole.Add(c);
            return pole;

            
            // return a;

          }

        }
    }
