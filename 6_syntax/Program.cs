namespace Spojak;
    internal class Program
    {
        static void Main(string[] args)
        {
          Database kino = new Database();
          Console.BackgroundColor = ConsoleColor.Black;
          Console.Clear();
          // kino.addHall();
          // kino.printHall("hala");
          // kino.nakup("hala");
          bool exit = false;
          Console.WriteLine("add - přídání sálu");
          Console.WriteLine("show - zobrazení sálů");
          Console.WriteLine("choose - vybrání sálu");
          Console.WriteLine("help - pomoc");
          Console.WriteLine("exit - konec");
          while(exit == false){
            string option1 = input("");
            switch (option1){
              case "add":
                kino.addHall();
                Console.WriteLine("přidáno");
                break;

              case "help":
                Console.WriteLine("add - přídání sálu");
                Console.WriteLine("show - zobrazení sálů");
                Console.WriteLine("choose - vybrání sálu");
                Console.WriteLine("help - pomoc");
                Console.WriteLine("exit - konec");
                Console.WriteLine();
                break;

              case "show":
                foreach(var i in kino.DatabazeSalu.Keys){
                  Console.WriteLine(i);
                }
                break;

              case "choose":
                Console.WriteLine("sály: \n------");
                foreach(var i in kino.DatabazeSalu.Keys){
                  Console.WriteLine(i);
                }
                string vyber = input("------\n");
                while(!kino.DatabazeSalu.ContainsKey(vyber)){
                  Console.WriteLine("tento sál už existuje");
                  vyber = input("Název: ");
                }
                bool isInHall = true;
                Console.WriteLine("\njste v sálu\n");
                Console.WriteLine("show - zobrazení sálu");
                Console.WriteLine("buy - koupit lístky");
                Console.WriteLine("help - pomoc");
                Console.WriteLine("back - zpět na přehled kina");
                while(isInHall){
                  string option2 = input("");
                  switch(option2){
                    case "help":
                      Console.WriteLine("show - zobrazení sálu");
                      Console.WriteLine("buy - koupit lístky");
                      Console.WriteLine("help - pomoc");
                      Console.WriteLine("back - zpět na přehled kina");
                      break;

                    case "show":
                      kino.printHall(vyber);
                      Console.WriteLine("Sál {0} vybráno", vyber);
                      break;

                    case "buy":
                      kino.nakup(vyber);
                      break;

                    case "back":
                      isInHall = false;
                      break;
                    
                    default:
                      Console.WriteLine("chybný vstup");
                      break;
                  }

                }
                break;

              case "exit":
                return;
                
                default:
                  Console.WriteLine("chybný vstup");
                  break;
            }

          }


        }
        class Database{
          //vytvoříme databázi všech sálů
          public Dictionary<string, Int32[,]> DatabazeSalu = new Dictionary<string, Int32[,]>();
          private Dictionary<string, Int32[][]> HistorieNakupu = new Dictionary<string, Int32[][]>();
          private Int32 Rad = 8;
          private Int32 Sedadel = 10;
          private Int32 Cena = 180;
          private Int32 VIPCena = 70; // plus Cena
          private Int32[] VIPRady = [7,8];
          
          
          public void addHall(){
            // Console.Write("Název:\tab");
            string nazev = input("Název: ");
            while(DatabazeSalu.ContainsKey(nazev)){
              Console.WriteLine("tento sál už existuje");
              nazev = input("Název: ");
            }
            //budeme indexovat od 1 kvůli uživatelskému přehledu a usnadnění práce při práci s daty
            Int32 rRad = Rad+1;
            Int32 rSedadel = Sedadel+1;
            Int32[,] kino = new Int32[rRad,rSedadel];
            // 0 -> volno
            // 1 -> VIP volno
            // 2 -> obsazeno
            // 3 -> vybrano
            // 4 -> vybrano VIP
            foreach(Int32 rada in VIPRady){
              for (int sedadlo = 1; sedadlo <= Sedadel; sedadlo++){
                kino[rada,sedadlo] = 1;              
              }
            }
            DatabazeSalu.Add(nazev,kino);

          }

          public void nakup(string nazevSalu){
            string worspaceHallName = checkedRandomString(5);
            Int32[,] pomoc = (Int32[,])DatabazeSalu[nazevSalu].Clone();
            DatabazeSalu.Add(worspaceHallName, pomoc);
            string souhlas;
            string[] reject = {"n","N"};
            Int32 pocet = input("Počet vstupenek: ",1)[0];
            Int32[][] listky = new Int32[pocet+1][];
            do{
              DatabazeSalu[nazevSalu] = (Int32[,])DatabazeSalu[worspaceHallName].Clone();
              Int32[,] sal = DatabazeSalu[nazevSalu];
              printHall(nazevSalu);
              Console.WriteLine("Mista rada a sedadlo");
              for(int cislo = 1; cislo <= pocet; cislo++){
                Int32[] misto = input(cislo.ToString() + " ",2);
                if(isSeatPossible(misto,nazevSalu)){
                    // listky se používá k ukládání údajů o nákupu k vypočítání ceny a pozdějšímu vrácení
                    Int32 test = sal[misto[0],misto[1]];
                    listky[cislo] = [misto[0],misto[1],test];
                    sal[misto[0],misto[1]] += 3;

                    printHall(nazevSalu);
                    Console.WriteLine("Mista rada a sedadlo");
                }
                else{
                  Console.WriteLine("Místo neexistuje nebo je zabrané");
                  //cislo se pocita znova
                  cislo--;
                }
              }
              printHall(nazevSalu);
              souhlas = input("souhlasÍ Y/N: ");
            }while(reject.Contains(souhlas));
            
            Int32 cena = 0;
            cena = cenaCelkem(listky,worspaceHallName);
            Console.WriteLine("Cena za lístky {0} Kč",cena);
            Console.WriteLine("Kód objednávky: {0}",worspaceHallName);
            // dáme do úložiště pro případné vrácení
            DatabazeSalu.Remove(worspaceHallName);
            HistorieNakupu.Add(worspaceHallName,listky);
            // return cena;
          }

          private Int32 cenaCelkem(Int32[][] listky, string nazevSalu){
            Int32 cena = 0;
            for(Int32 i = 1; i < listky.Count(); i++){
              // VIPCena je příplatek k základu
              if(listky[i][2] == 1){
                cena += VIPCena;
              }
              cena += Cena;
              
            }
            return cena;
          }

          private bool isSeatPossible(Int32[] pozice, string nazevSalu){
            if(pozice[0] > Rad || pozice[1] > Sedadel);
            else if(pozice[0] <= 0 || pozice[1] <= 0);
            else if(DatabazeSalu[nazevSalu][pozice[0],pozice[1]] > 1);
            else{
              return true;
            }
            return false;

          }

          // aby se zabránilo nešťastným schodám
          private string checkedRandomString(int delka){
            string vystup;
            do{
              vystup = RandomString(delka);
                
            } while(DatabazeSalu.ContainsKey(vystup) || HistorieNakupu.ContainsKey(vystup));

            return vystup;
          }


          public void printHall(string nazevSalu){
            if(!DatabazeSalu.ContainsKey(nazevSalu)){
              Console.WriteLine("Error 204: Sál neexistuje");
            }
            else{
              Console.Clear();
              Console.WriteLine("Sál {0}",nazevSalu);
              Int32[,] sal = DatabazeSalu[nazevSalu];
              for(Int32 rada = 1; rada<= Rad; rada++){
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("{0}:", rada);
                for (int sedadlo = 1; sedadlo <= Sedadel; sedadlo++){
                  Int32 stav = sal[rada,sedadlo];
                  if(stav == 0){
                    Console.BackgroundColor = ConsoleColor.Green;
                  }
                  else if(stav == 1){
                    Console.BackgroundColor = ConsoleColor.Yellow;
                  }
                  else if(stav == 2){
                    Console.BackgroundColor = ConsoleColor.Red;
                  }
                  else if(stav == 3 || stav == 4){
                    Console.BackgroundColor = ConsoleColor.White;
                  }
                  Console.Write(" {0} ", sedadlo);
                }
                Console.WriteLine();
              }
              Console.BackgroundColor = ConsoleColor.Black;
            }
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

        public static Int32[] input(string? text,Int32 pocet){
          // null == chybný vstup
          Int32[]? parse;
          do{
            Console.Write(text);
            parse = inputParse(Console.ReadLine(),pocet);
            if(parse == null){
              Console.WriteLine("Neplatný vstup");
            }
          }while(parse == null);
          return parse;
        }

        private static Random random = new Random();

        public static string RandomString(int delka) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, delka)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // pokusí se zpracovat string do Int32 => pokud ne vrátí null
        public static Int32[]? inputParse(string? vstup, Int32 pocet){
          if (vstup == null){return null;}
          string[]? postup = vstup.Split(null);
          if(postup.Count() != pocet){
            return null;
          }
          // projde jednotlivá čísla a převede je do intů: chyba == return null
          Int32[]? vystup = new Int32[10];
          Int16 cislo = 0;
          // uloží všechny čísla do array
          foreach(var i in postup){
            if (Int32.TryParse(i,out vystup[cislo]) == false){
              return null;
            }
            cislo++;
          }
          return vystup;
        }
    }
