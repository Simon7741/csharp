namespace Spojak;
    internal class Program
    {
        static void Main(string[] args)
        {
          Slovnik slovnik = new Slovnik();
          string[] vstupData = input().Split();
          slovnik.vstup(vstupData);
          slovnik.poradi();
          slovnik.vystup();


        }


        class Slovnik(){
          public Dictionary<char,List<char>> Mensi = new Dictionary<char,List<char>>();
          public List<char> serazenePismena = new List<char>();
          
          // vytvoření databáze
          public void vstup(string[] data){
            foreach(string i in data){
              // a < b
              if(!Mensi.ContainsKey(i[0])){
                Mensi.Add(i[0],new List<char>());

              }
              if(!Mensi.ContainsKey(i[2])){
                Mensi.Add(i[2],new List<char>());

              }

              Mensi[i[2]].Add(i[0]);
            }
          }
          public void poradi(){
            char prazdne = ' ';
            foreach(var i in Mensi){
              if(i.Value.Count() == 0){
              // Console.WriteLine("{1},{0}",i.Value.Count(),i.Key);
              if(prazdne == ' '){
                prazdne = i.Key;
              }
              else{
                Console.WriteLine("nema jedno reseni");
                return;
              }
              }
              
            }
            if(prazdne != ' '){
              serazenePismena.Add(prazdne);
              Mensi.Remove(prazdne);
              foreach(var i in Mensi.Values){
                if(i.Contains(prazdne)){
                  i.Remove(prazdne);
                }
              }
              poradi();
              
            }

          }
          public void vystup(){
            for(int i = 0; i<serazenePismena.Count()-1; i++){
              Console.Write("{0}->",serazenePismena[i]);

            }
              Console.WriteLine("{0}",serazenePismena.Last());
            // foreach(var i in serazenePismena){
            //   Console.Write("{0}->",i);
            // }
          }

        }

        public static string input(string? text = ""){
          string? vstup;
          do{
            Console.Write(text);
            vstup = Console.ReadLine();
            if(vstup == null){
                Console.WriteLine("Neplaný vstup");
            }
              
          } while(vstup == null);
          return vstup;

        }
    }
