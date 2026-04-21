namespace Spojak;
    internal class Program
    {
        static void Main(string[] args)
        {
          string text = input("prefix / postfix: ");
          Data data = new Data();
          string poststring = "postfix";
          string prestring = "prefix";
          if (poststring.Contains(text)){
            data.postfix();
          }
          else if(prestring.Contains(text)){
            data.prefix();
          }

        }
        class Data {
              string[] veci = {"+","-","*","/"};

              public void postfix(){
                string[]? data = inputParse(input("pozadejte retez:\n"));
                Stack<double?> zasobaCisel = new Stack<double?>();
                foreach(string i in data){
                  if(veci.Contains(i)){
                    if(zasobaCisel.Count() < 2){
                      Console.WriteLine("Chybí číslo");
                      return;
                    }
                    else{
                      if(i == "+"){
                        zasobaCisel.Push(plus(zasobaCisel.Pop(),zasobaCisel.Pop()));
                      }
                      else if(i == "-"){
                        zasobaCisel.Push(minus(zasobaCisel.Pop(),zasobaCisel.Pop()));
                      }
                      else if(i == "*"){
                        zasobaCisel.Push(times(zasobaCisel.Pop(),zasobaCisel.Pop()));
                      }
                      else if(i == "/"){
                        if (zasobaCisel.Peek() == 0){
                          Console.WriteLine("nulou nelze dělit !");
                          return;
                        }
                        zasobaCisel.Push(divide(zasobaCisel.Pop(),zasobaCisel.Pop()));
                      }
                      
                    }


                  }
                  else{
                    double cislo;
                    if (double.TryParse(i,out cislo)){
                      zasobaCisel.Push(cislo);
                    }
                  }

                }
                if(zasobaCisel.Count() > 1){
                  Console.WriteLine("Chybí znaménko");
                }
                else{
                  Console.WriteLine(zasobaCisel.Pop());
                }

              }
              public void prefix(){
                string[]? data = inputParse(input("zadejte retez:\n"));
                Stack<double?> zasoba = new Stack<double?>();
                Stack<string> operandy = new Stack<string>();
                double?[] LastTrNum = {0,0,0};
                foreach(string i in data){
                  double cislo;
                  if(veci.Contains(i)){
                    zasoba.Push(null);
                    operandy.Push(i);


                  }
                  else if (double.TryParse(i,out cislo)){
                    zasoba.Push(cislo);
                  }
                  bool zmena = false;
                  do{
                  zmena = false;
                  if(zasoba.Count() > 2){
                    LastTrNum = [zasoba.Pop(),zasoba.Pop(),zasoba.Pop()];
                    // for(int k = 0;k<3;k++){
                    //   if (LastTrNum[k] != null){
                    //   Console.WriteLine(LastTrNum[k]);
                    //   }
                    //   else{
                    //     Console.WriteLine(operandy.Peek());
                    //   }
                    // }
                    // Console.WriteLine("dsa");
                    if (LastTrNum[0] != null && LastTrNum[1] != null){
                      if(LastTrNum[2] != null){
                        Console.WriteLine("Chybí znaménko");
                        return;
                      }
                      string operand = operandy.Pop();
                      if(operand == "+"){
                        zasoba.Push(plus(LastTrNum[0],LastTrNum[1]));
                      }
                      else if(operand == "-"){
                        zasoba.Push(minus(LastTrNum[0],LastTrNum[1]));
                      }
                      else if(operand == "*"){
                        zasoba.Push(times(LastTrNum[0],LastTrNum[1]));
                      }
                      else if(operand == "/"){
                        if (LastTrNum[0] == 0){
                          Console.WriteLine("nulou nelze dělit !");
                          return;
                        }
                        zasoba.Push(divide(LastTrNum[0],LastTrNum[1]));
                      }
                      zmena = true;
                      Console.WriteLine(zasoba.Peek());

                    }
                    else{
                      for(int k = 2;k>=0;k--){
                        zasoba.Push(LastTrNum[k]);
                      }
                    }


                  }
                  else{
                  }
                }while(zmena == true);
                }
                if(zasoba.Count() > 1){
                  Console.WriteLine("Chybí číslo");
                }
                else{
                  Console.WriteLine(zasoba.Pop());
                }

              }
              private double? times(double? num2,double? num1){
                return num1 * num2;
              }
              private double? plus(double? num2,double? num1){
                return num1 + num2;
              }
              private double? minus(double? num2,double? num1){
                return num1 - num2;
              }
              private double? divide(double? num2,double? num1){
                return num1 / num2;
              }
        }
        public static string input(string? text){
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

        public static string[]? inputParse(string? vstup){
          if (vstup == null){return null;}
          string[]? vystup = vstup.Split(" ");
          return vystup;
        }
    }
