using System.ComponentModel;
using System.Collections;

namespace Spojak;
    internal class Program
    {
        static void Main(string[] args)
        {
            bool vstup = false;
            Int32[] num = new Int32[2];
            while(vstup == false){
              try{
              string data = Console.ReadLine();
              num = data.Split(' ').Select(n => Convert.ToInt32(n)).ToArray(); 
              if (num[0] <= 0 || num[1] < 0 || num.Count() != 2){
                Console.WriteLine("neplatný vstup");
              }
              else{
                vstup = true;
              }
              }
              catch{
                Console.WriteLine("neplatný vstup");
              }
            }
            Database database = new Database(num);
            database.addData();
            // List<Int32> line = database.connect(data);
            Console.WriteLine("line of people: ");

            num = new Int32[2];
            vstup = false;
            while(vstup == false){
              try{
              string data = Console.ReadLine();
              num = data.Split(' ').Select(n => Convert.ToInt32(n)).ToArray(); 
              if (num[0] < 0 || num[1] < 0 || num.Count() != 2){
                Console.WriteLine("neplatný vstup");
              }
              else{
                vstup = true;
              }
              }
              catch{
                Console.WriteLine("neplatný vstup err");
              }
            }
            Console.WriteLine("pocet");
            database.connect([num[0],num[1]]);
            // foreach(Int32 i in line){
              // Console.Write("{0}-",i);
            // }
            // Console.WriteLine("{0}", string.Join(" -> ", line));

            
            // int[] cisla2 = {1,2,3,4,6,6,3,6,3,3};
            // foreach(int i in cisla2){
            // }
        }
    class Database{
      public Dictionary<Int32,Dictionary<Int32,Int32[]>> cesty = new Dictionary<Int32, Dictionary<Int32,Int32[]>>(); 
      //<prvni strana {druha strana, [vzdalenost, placena]}
      private Dictionary<Int32,List<Int32>> neplacena = new Dictionary<Int32, List<Int32>>(); 
      //<kam, list [cesty]>
      private Dictionary<Int32,List<Int32>> placena = new Dictionary<Int32, List<Int32>>(); 
      //<kam, list [cesty]>
      private PriorityQueue<Dictionary<string,Int32>,Int32> fronta = new PriorityQueue<Dictionary<string,Int32>, Int32>(); 
      //<[kam, odkud, placena,byla placena, celkem, vzdalenost], vzdalenost>

      Int32 Mesta = 0;
      Int32 Hrany = 0;
      public  Database(Int32[] data) {
            Mesta = data[0];
            Hrany = data[1];
            

            for(int i = 0 ;i < Mesta;i++){
              cesty.Add(i,new Dictionary<Int32,Int32[]>()); //<druha strana, [vzdalenost,placena,vzdalenost,placena]>
              
            }
      }
      public void addData(){{

        int pomoc = 0;
        while (pomoc < Hrany){
          string data = Console.ReadLine();
          try{
            // Console.WriteLine(pomoc);
            Int32[] num = data.Split(' ').Select(n => Convert.ToInt32(n)).ToArray(); 

            if ((num.Count() == 4) && num[2] > 0 && num[3] <= 1 && num[3] >= 0 && num[1] < Mesta){
              // Int32[] help = [num[3],num[2]];
              Console.WriteLine("{0}{1}{2}{3}", num[0],num[1],num[2],num[3]);
              cesty[num[0]].Add(num[1],[num[2],num[3]]);
              cesty[num[1]].Add(num[0],[num[2],num[3]]);
              pomoc ++;
            }
            else{
              Console.WriteLine("neplatný vstup");
            }
            
          }
          catch{
            Console.WriteLine("Neplatný vstup");
          }
          }
        }

      }
      
      public void connect(Int32[] test){
        Dictionary<string,Int32> blbost = new Dictionary<string, Int32>();
        // g.Push(0);
        // neplacena.Add(0,g);
        blbost.Add("kam",test[0]);
        blbost.Add("odkud",test[0]);
        blbost.Add("placena", 0);
        blbost.Add("bPlacena", 0);
        blbost.Add("celkem", 0);
        blbost.Add("vzdalenost", 0);
        fronta.Enqueue(blbost,0);
        
        while(fronta.Count > 0){
          var element = fronta.Dequeue();
          Console.WriteLine("{0}{1}{2}{3}{4}{5}",element["odkud"],element["kam"],element["placena"],element["bPlacena"],element["vzdalenost"],element["celkem"]);
          if (element["kam"] == test[1]){
            Console.WriteLine("vyreseno {0}",element["celkem"]);
            if(element["placena"] == 1){
              foreach(var i in placena[element["odkud"]]){
                Console.Write("{0}->",i);
              }

            }
            else {
              foreach(var i in neplacena[element["odkud"]]){
                Console.Write("{0}->",i);
              }
            }
            // Console.Write(element["kam"]);
            Console.WriteLine(element["kam"]);
            return;
          }

          Int32 pridano = 0;
          if(neplacena.Count == 0){
          List<Int32> g = new List<Int32>();
          g.Add(0);
          neplacena.Add(0,g);
          placena.Add(0,g);
            pridano = 1;
          }

          if(element["placena"] == 1){
            if (!placena.ContainsKey(element["kam"])){
              pridano = 1;
              List<Int32> a;
              if (element["bPlacena"] == 1){
                a = new List<int>(placena[element["odkud"]]);
              }
              else{
                a = new List<int>(neplacena[element["odkud"]]);
              }
              Console.WriteLine("kamp :{0}",element["kam"]);
              a.Add(element["kam"]);
              Console.WriteLine("cesta");
              Console.Write(a[1]);
              placena.Add(element["kam"],a);
            }
          }
          else if (!neplacena.ContainsKey(element["kam"])){
              pridano = 1;
              // neplacena.Add(element[0],element[1]);
              Console.WriteLine("kamn :{0}",element["kam"]);
              List<Int32> a = new List<Int32>(neplacena[element["odkud"]]);
              a.Add(element["kam"]);
              Console.WriteLine("cesta");
              Console.Write(a[1]);
              neplacena.Add(element["kam"],a);
            
            
          }

          if(pridano > 0){
            foreach(var h in cesty[element["kam"]]){
              Dictionary<string, Int32> postup = new Dictionary<string, int>(element);
              postup["bPlacena"] = postup["placena"];
              postup["vzdalenost"] = h.Value[0];
              postup["odkud"] = element["kam"];
              postup["kam"] = h.Key;
              postup["celkem"] = postup["vzdalenost"] + element["celkem"];
              // postup["placena"] = h.Value[1];
              if (postup["placena"] == 0){
                postup["placena"] = h.Value[1];
              }
              // postup["placen"];
              // Console.WriteLine(pridano);

              // Console.WriteLine("postup {0}{1}{2}{3}{4}{5}",postup["odkud"],postup["kam"],postup["placena"],postup["vzdalenost"],postup["celkem"],element["kam"]);
              if (h.Value[1] == 0 && postup["bPlacena"] == 1){
                  fronta.Enqueue(postup,postup["celkem"]);
                // Console.WriteLine("placena {0}",pridano);
              }
              else if(postup["bPlacena"] == 0){
                // Console.WriteLine("neplacena {0}",pridano);
                fronta.Enqueue(postup,postup["celkem"]);
              }
              else{
                Console.WriteLine("nic");
              }

            }
            Console.WriteLine("nove cislo");
          }
          
        }
        Console.WriteLine("konec");

      }

      public void print(){
        // foreach(var person in cesty){
        //   Console.Write("person {0} :",person.Key);
        //   foreach (var connection in person.Value.Values){
        //     Console.Write(" {0}",connection);
        //   }
        //   Console.Write("\n");
        // }
        
      }

    }
    }
