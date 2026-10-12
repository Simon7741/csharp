namespace Manzelstvi;

class Program
{
    static void Main(string[] args)
    {
      Volenka volenka = new Volenka();
      volenka.Vstup();
      volenka.Vyber();
        // Console.WriteLine("Hello, World!");
    }
}
class Volenka(){
  Int32[] VolbyZen;
  Int32[] VolbyMuzu;
  List<Int32[]> Muzi = new List<int[]>();
  List<Int32[]> Zeny = new List<int[]>();
  Int32 PocetMuZen;

  public void Vstup(){
    PocetMuZen = parse(Console.ReadLine());

    for (int n = 0; n < PocetMuZen*2; n++){
      string? data = Console.ReadLine();
      Int32[] cislo = parse(data,PocetMuZen);
      if(n<PocetMuZen){
        for (int i = 0; i < PocetMuZen; i++) cislo[i]--; 
        Zeny.Add(cislo);
      }
      else{
        for (int i = 0; i < PocetMuZen; i++) cislo[i]--; 
        Muzi.Add(cislo);
      }
    }
      VolbyZen = new Int32[PocetMuZen];
        VolbyMuzu = new Int32[PocetMuZen];
    }
    public void Vyber(){
      Queue<Int32> rada = new Queue<int>();
      for (int i = 0; i < PocetMuZen; i++) {
        rada.Enqueue(i);
        VolbyMuzu[i] = PocetMuZen ;
      }

      // volby muzu budou obsahovat Indexy preferenci
      while(rada.Count() > 0){
        Int32 naRade = rada.Dequeue();
        Int32 onaChce = kohoChce(Zeny,VolbyZen,naRade) ; //koho ted chce ona
        Int32 onJi = Muzi[onaChce].IndexOf(naRade); //index jak moc on chce ji
        ref Int32 onChce = ref VolbyMuzu[onaChce]; //koho aktualne chce

        // Console.Write("zena {0} chce {1}, co ",naRade,onaChce);
        if (onChce == PocetMuZen){
          // Console.Write("if");
          onChce = onJi;
        }
        else if (onChce > onJi){
          // Console.Write("ifelse");
          rada.Enqueue(Muzi[onaChce][onChce]); //vyhozeni stare zeny zpet do fronty
          VolbyZen[Muzi[onaChce][onChce]] ++;
          onChce = onJi ;
        }
        else{
          // Console.Write("else");
          rada.Enqueue(naRade);
          VolbyZen[naRade] ++;
        }
          // Console.WriteLine(" ted chce {0} a muzi {1},{2},{3},{4}",kohoChce(Zeny,VolbyZen,naRade),VolbyMuzu[0],VolbyMuzu[1],VolbyMuzu[2],VolbyMuzu[3]);
      
    }
    for (int i = 0; i < PocetMuZen; i++){
        Console.WriteLine("Z{0}-M{1}",i+1,Zeny[i][VolbyZen[i]]+1);
    }

  }
  private Int32 kohoChce(List<Int32[]> seznam, Int32[] volby, Int32 rada) {return seznam[rada][volby[rada]];}
  // public 
  private int[] parse(string? data, int pocet){
    string[] i = data.Trim().Split();
    return Array.ConvertAll(i,int.Parse);
  }
  private int parse(string? data){
    int.TryParse(data,out int output);
    return output;
  }
}
