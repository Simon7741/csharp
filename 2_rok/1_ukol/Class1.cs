namespace test2;


public class Class1
{
  static void Main(string[] args){
    Film film1 = new Film();
    film1.Nazev = "To neznas";
    film1.JmenoRezisera = "karlik";

    List<Film> filmy = new List<Film>();
    

  }
  class Film{
    public string Nazev;
    public string JmenoRezisera;
    public string PrijmeniRezisera;
    public int RokVzniku;
    private uint SumaHodnoceni = 0;
    private uint PocetHodnoceni = 0;
    public float Hodnoceni;
    public void PridatHodnoceni(uint noveHodnoceni){
      SumaHodnoceni += noveHodnoceni;
      PocetHodnoceni ++;
      Hodnoceni = SumaHodnoceni/PocetHodnoceni;
      }
    public override ToString(){
        return $"{Nazev} ({RokVzniku}; {PrijmeniRezisera}, {JmenoRezisera[0]}): {Hodnoceni};";
    }
  }
}
