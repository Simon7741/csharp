using System.Text;
using System.IO;
using System.Collections;

namespace PololetniUloha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5 algoritmem s lineární časovou složitostí vzhledem k počtu známek. 
            // Vypište je na řádek a pak vypište i četnosti jednotlivých známek.
            using(StreamReader sr = new StreamReader("znamky.txt")) // otevření souboru pro čtení
            {
                Dictionary<Int16,Int128> databazeZnamek = new Dictionary<Int16, Int128>();
                
                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    Int16 znamka = Convert.ToInt16(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    if(!databazeZnamek.ContainsKey(znamka)){
                      databazeZnamek.Add(znamka,0);
                    }
                    databazeZnamek[znamka] += 1;
                    
                }
                for(short i = 1; i<=5; i++){
                  Int128 pocet = databazeZnamek[i];
                  for (int k = 0; k < pocet; k++)
                  {
                      Console.Write("{0} ",i);
                  }
                }
                Console.WriteLine();
                for(short i = 1; i<=5; i++){
                  Int128 pocet = databazeZnamek[i];
                  Console.WriteLine("{0}: x{1} ",i,pocet);
                }
                

            }
            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort



            // (40b) 2. Ze souboru znamky_prezdivky.csv vytvořte objekty typu Student se správně přiřazenou známkou a přezdívkou.
            // Seřaďte je podle známek (stabilně = dodržte pořadí v souboru) a vypište seřazené dvojice (znamka: přezdívka) - na každý řádek jednu.
            using(StreamReader sr = new StreamReader("znamky_prezdivky.csv"))
            {
                
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(";");
                    List<Student>[] znamkyStudentu =
                    {
                        new List<Student>(), new List<Student>(), new List<Student>(), new List<Student>(), new List<Student>()
                    };
                    

                }                

            }
            // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort (přihrádkové řazení)




            // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu




            // (+60b) 4. BONUS: Napište kód, který bude řadit lexikograficky velká čísla v lineárním čase. Využijte dat ze souboru velka_cisla.txt

        }
    }

    class Student
    {
        public string Prezdivka { get; } // tím, že je zde pouze get říkáme, že tato vlastnost třídy Student jde mimo třídu pouze číst, nikoli upravovat
        public int Znamka { get; }
        public Student(string prezdivka, int znamka) // konstruktor třídy
        {
            // použitím samotného { get; } také říkáme, že tyto vlastnosti jdou nastavit nejpozději v konstruktoru - tedy v této metodě
            Prezdivka = prezdivka;
            Znamka = znamka;
        }
    }
}
