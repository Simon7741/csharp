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

            
            int[] cisla2 = {1,2,3,4,6,6,3,6,3,3};
            foreach(int i in cisla2){
            }
        }
    class Database{
      public Dictionary<Int32,Hashtable> People = new Dictionary<Int32, Hashtable>();
      public string test = "sd";
      public  Database(int num) {


            for(int i = 1 ;i <=num;i++){
              People.Add(i,new Hashtable());
              // Console.WriteLine(People.Values);
              
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
