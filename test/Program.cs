// See https://aka.ms/new-console-template for more information

int student;
do {
  Console.WriteLine("Zadejte pocet studentu:");
} while (int.TryParse(Console.ReadLine(), out student) == false);
  Console.WriteLine(student);

List<string> jmeno = new List<string>();
List<int> vek = new List<int>();
List<float> prumer = new List<float>();
// ArrayList prumer = new ArrayList();
bool exit = false;
for (int j = 0; j < student; j++) {
  Console.Write("Zadejte jmeno studenta {0}: ",j);
  jmeno.Add(Console.ReadLine());

  float prumerHelp ;
  do{
    Console.Write("Zadejte prumer studenta {0}: ",j);
  } while (float.TryParse(Console.ReadLine(), out prumerHelp) == false);
  prumer.Add(prumerHelp);

  int vek_help ;
  do{
    Console.Write("Zadejte vek studenta {0}: ",j);
  } while (int.TryParse(Console.ReadLine(), out vek_help) == false);
  vek.Add(vek_help);
  Console.WriteLine("{0}{1}{2}",vek[j],prumer [j],jmeno[j]);
    // Console.WriteLine(jmeno[0]);
}
while(exit == false){

}
