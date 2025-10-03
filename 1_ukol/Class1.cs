namespace test2;


public class Class1
{
  static void Main(string[] args){

    // See https://aka.ms/new-console-template for more information

    int student;
    do {
      Console.WriteLine("Zadejte pocet studentu:");
    } while (int.TryParse(Console.ReadLine(), out student) == false);
      Console.WriteLine(student);

    List<string> jmeno = new List<string>();
    List<int> vek = new List<int>();
    List<float> prumer = new List<float>();
    bool exit = false;
    for (int j = 0; j < student; j++) {
      Console.Write("Zadejte jmeno studenta : ",j);
      jmeno.Add(Console.ReadLine());

      int vek_help ;
      do{
        Console.Write("Zadejte vek studenta {0}: ",jmeno[j]);
      } while (int.TryParse(Console.ReadLine(), out vek_help) == false);
      vek.Add(vek_help);
      
      float prumerHelp ;
      do{
        Console.Write("Zadejte prumer studenta {0}: ",jmeno[j]);
      } while (float.TryParse(Console.ReadLine(), out prumerHelp) == false);
      prumer.Add(prumerHelp);
    }
    while(exit == false){
      string operation = Console.ReadLine();
      if (operation == "a"){
        for (int i = 0; i< student;i++){
          Console.WriteLine("{0}({1}):{2}",jmeno[i],vek[i],prumer[i]);

        }
      }
      else if (operation == "b"){
        for (int i = 0; i< student;i++){
          if (prumer[i] < 2){
            Console.WriteLine("{0}({1}):{2}",jmeno[i],vek[i],prumer[i]);
          }
        }
      }
      else if (operation == "c"){
        float prumerVeku = 0;
        foreach (var d in vek){ 
            prumerVeku += d;
        }
        prumerVeku = prumerVeku / student;
        Console.WriteLine("Prumerny vek je: {0}",prumerVeku);
      
      }
      else if (operation == "d"){
        exit = true;

      }

    }
  }
}
