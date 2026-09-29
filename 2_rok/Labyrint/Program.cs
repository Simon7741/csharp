namespace Labyrint;

class Program
{
    static void Main(string[] args)
    {
      Labyrint hra = new Labyrint();
      hra.Vstup();
      for(int i =0;i<20;i++){
      hra.Tah();
      Console.WriteLine("\n{0}. krok",i);


      hra.Print();
      }
    }
    
}
class Labyrint{
  public Int32 vyska, sirka;
  private Int32[,] Pole;
  private Int32[,] PoleTah;
  private char[] creatur = {'<','^','>','v'};
  public static Int32[,] Pohyb = {{1,0},{0,-1},{-1,0},{0,1}};
  public List<Creatur> Entity = new List<Creatur>();
  char[] znaky = { '>', '^', '<', 'v', 'X', '.' };
  // private Int32[] rozmery = {0,0};
  ///převodník znaků na Int32 pro jednodušší práci
  Dictionary<char,Int32> vzhled = new Dictionary<char, Int32> {
      { '>', 0 },
      { '^', 1 },
      { '<', 2 },
      { 'v', 3 },
      { 'X', 4 },
      { '.', 5 },
  };
  public void Vstup(){
    sirka = Convert.ToInt32(Console.ReadLine());
    vyska = Convert.ToInt32(Console.ReadLine());
    Pole = new Int32[sirka,vyska];
    // rozmery = [sirka,vyska];
    for (int y = 0; y < vyska; y++){
      string vstup = Console.ReadLine();
      for (int x = 0; x<sirka; x++){
        if(creatur.Contains(vstup[x])){
          Entity.Add(new Creatur([x,y,vzhled[vstup[x]],0]));
          // Console.WriteLine("creatura {0},{1}",x,y);
          Pole[x,y] = 5;
        }
        else{
          Pole[x,y] = vzhled[vstup[x]];
        }
      }
    }
  }
  public void Tah(){
    PoleTah = (Int32[,])Pole.Clone();
    foreach(Creatur stvoreni in Entity){
      Int32[] pozice = (Int32[])stvoreni.Pozice.Clone();
      // if (PoleTah[pozice[0]+Pohyb[pozice[2],0],pozice[1]+Pohyb[pozice[2],1]] != vzhled['.']){
      //   stvoreni.Move(0);
      // }
      if (PoleTah[pozice[0]+Pohyb[(pozice[2]+3)%4,0],pozice[1]+Pohyb[(pozice[2]+3)%4,1]] == vzhled['.'] && pozice[3]==0){
        stvoreni.Move(-1);

      }
      else if(PoleTah[pozice[0]+Pohyb[pozice[2],0],pozice[1]+Pohyb[pozice[2],1]] == vzhled['.']){
        stvoreni.Move(0);
      }
      else{
        stvoreni.Move(1);
      }
      // pozice = stvoreni.Pozice;
      pozice = stvoreni.Pozice;
      PoleTah[pozice[0],pozice[1]] = pozice[2];
    }

  }

  public void Print(){
    for (int y = 0; y < PoleTah.GetLength(1); y++){
      for (int x = 0; x < PoleTah.GetLength(0); x++){
          // Console.Write(Pole[x, y]);
          Console.Write(znaky[PoleTah[x, y]]);
      }
      Console.WriteLine();
    }

    

  }

}
class Creatur(Int32[] pozice){
  public Int32[] Pozice { get; set; } = pozice;
  // public int Vek { get; set; }
  public void Move(int zateras = 0){
    if(zateras==0){
    Pozice[0] += Labyrint.Pohyb[Pozice[2],0];
    Pozice[1] += Labyrint.Pohyb[Pozice[2],1];
    Pozice[3] = 0;
    }
    else if(zateras == 1){
      Pozice[2] ++;
      Pozice[2] %= 4;
      Pozice[3] = 1;
    }
    else if(zateras == -1){
      Pozice[2] += 3;
      Pozice[2] %= 4;
      Pozice[3] = 1;
    }
  }
}
