using System.ComponentModel;
using System.Collections;

namespace Spojak;
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Database database = new Database(num);
            string data = Console.ReadLine();
            database.add(data);
            // database.add(5,8);
            database.print();
            data = Console.ReadLine();
            List<Int32> line = database.connect(data);
            Console.WriteLine("line of people: ");
            // foreach(Int32 i in line){
              // Console.Write("{0}-",i);
            // }
            Console.WriteLine("{0}", string.Join(" -> ", line));

            
            // int[] cisla2 = {1,2,3,4,6,6,3,6,3,3};
            // foreach(int i in cisla2){
            // }
        }
    class Database{
      public Dictionary<Int32,Hashtable> People = new Dictionary<Int32, Hashtable>();
      private Dictionary<Int32,Int32> queue = new Dictionary<Int32, Int32>();
      private Dictionary<Int32,Int32> pass = new Dictionary<Int32, Int32>();
      public  Database(int num) {


            for(int i = 1 ;i <=num;i++){
              People.Add(i,new Hashtable());
              // Console.WriteLine(People.Values);
              
            }
      }
      public List<Int32> connect(string data){
          Int32[] test = data.Split(' ').Select(n => Convert.ToInt32(n)).ToArray(); 
          return connect(test[0],test[1]);

      }

      public List<Int32> connect(Int32 person1, Int32 person2){
        List<int> line = new List<Int32>();
        follower(person1,person1);
        while(pass.ContainsKey(person2) == false){
          // foreach(var i in queue.Keys){
          //   Console.WriteLine(i);
          // }
          if (queue.Count() == 0){
            Console.WriteLine("empty");
            // break;
            return [-1];
          }
          
          follower(queue.Values.First(),queue.Keys.First());
        }

        
        line.Add(person2);
        Console.WriteLine("finish");
        while(line.Last() != person1){
          line.Add(pass[line.Last()]);
          
        }
        // Console.WriteLine(line.Count());
        
        return line;

      }
      private void follower(Int32 from,Int32 number){
        pass.Add(number,from);
        queue.Remove(number);
        foreach(Int32 i in People[number].Keys){
          if(pass.ContainsKey(i) == false && queue.ContainsKey(i) == false){
            queue.Add(i,number);
            // Console.WriteLine(i);
          }

        }

      }
      public void add(Int32 person1,Int32 person2){
        // Console.WriteLine(test);
        //       Console.WriteLine(People[1]);
        People[person2].Add(person1,person2);
        People[person1].Add(person2,person1);
        // Console.WriteLine(;
        // People[num].Add(numto,numto);

      }

      public void add(string rawdata){
          string[] halfparse = rawdata.Split(" ");
          foreach(string preparse in halfparse){
            int[] test = preparse.Split('-').Select(n => Convert.ToInt32(n)).ToArray(); 
            add(test[0],test[1]);

          }
      }

      public void print(){
        foreach (var person in People) {
          Console.Write("person {0} :",person.Key);
          foreach (var connection in person.Value.Keys){
            Console.Write(" {0}",connection);
          }
          Console.Write("\n");
          
        }
      }

    }
    }
