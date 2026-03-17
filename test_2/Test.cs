namespace Test;
    internal class Program
    {
        static void Main(string[] args)
        {
          Spoje spoje = new Spoje();
          spoje.Data();
        }
        class Spoje(){
          public Dictionary<int,List<int>> Rady = new Dictionary<int, List<int>>();
          
          public void Data(){
            int pocetStanic = vstup();

            for(int i = 1; i<= pocetStanic; i++){
              Rady.Add(i,new List<int>());
            }
            int pocet = 2;
            int[] vstupData = vstup(2);
            while(vstupData.Count() == 2){

              Rady[vstupData[0]].Add(vstupData[1]);
                Rady[vstupData[1]].Add(vstupData[0]);

                vstupData = vstup(2);
              }
              int[] body = new int[2];
              body[0] = vstupData[0];
              body[1] = vstup(1)[0];
              List<int> objeveno = new List<int>();
              Dictionary<int,List<int>> frontaData = new Dictionary<int, List<int>>();
              Queue<int> fronta = new Queue<int>(); 
              fronta.Enqueue(body[0]);
              frontaData.Add(body[0],new List<int>());
              while(frontaData.Count() != 0){
                // foreach(int i in frontaData.Keys){
                //   Console.Write(i);
                // }
                Console.WriteLine();
                int bod = fronta.Dequeue();
                List<int> data = frontaData[bod];
                frontaData.Remove(bod);
                objeveno.Add(bod);
                if(bod == body[1]){
                  foreach(int i in data){
                    Console.Write("{0} -> ",i);
                  }
                  Console.WriteLine("{0} ",bod);
                  return;
                }
                data.Add(bod);
                foreach(int i in Rady[bod]){
                  if(!objeveno.Contains(i) && !frontaData.ContainsKey(i)){
                    Console.WriteLine(i);
                    frontaData.Add(i,data);
                    fronta.Enqueue(i);
                }
                
              }
            }
            Console.WriteLine("neexistuje");
            
            // kam, odkud[]
            



            // for(int i = 0; i<pocetStanic; i++){
            //   int[] data = vstup(2);
            //   if(!Rady.ContainsKey(data[0])){
            //     Rady.Add(data[0],new List<int>());
            //   }
            //   if(!Rady.ContainsKey(data[1])){
            //     Rady.Add(data[1],new List<int>());
            //   }
            //   Rady[data[0]].Add(data[1]);
            //   Rady[data[1]].Add(data[0]);
            //
            // }
          }








          private int vstup(){
            int cislo = 0;
            do{
            string? data = Console.ReadLine();
            cislo = parse(data);
            }while(cislo == 0);
            return cislo;

          }
          private int[] vstup(int pocet){
            int[] cislo;
            do{
            string? data = Console.ReadLine();
            if(data.Count() == 1){
              int cisloJ = parse(data);
              int[] vystup = {cisloJ};
              return vystup;

            }
            cislo = parse(data,pocet);
            }while(cislo.Count() > pocet);
            return cislo;

          }

          private int[] parse(string? data, int pocet){
            string[] i = data.Trim().Split();
            return Array.ConvertAll(i,int.Parse);
          }

          private int parse(string? data){
            int.TryParse(data,out int output);
            return output;
          }

        }
    }
