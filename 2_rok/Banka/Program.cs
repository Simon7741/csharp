namespace Banka;

class Program
{
    static void Main(string[] args)
    {
        PostovniAdresa honzaAdresa = new PostovniAdresa("K zavisi","15/5","Brno","285 48");
        BankovniUcet ucet1 = new BankovniUcet("1201-45/2455",honzaAdresa);
        BankovniUcet ucet2 = new BankovniUcet("2201-45/2455",honzaAdresa, 1500);

        ucet1.Vlozit(2500);
        if(ucet2.Vybrat(2500))Console.WriteLine("probehlo");
        else Console.WriteLine("neprobehlo");
        if(ucet2.Vybrat(500))Console.WriteLine("probehlo");
        else Console.WriteLine("neprobehlo");
        
        Console.WriteLine(ucet1);
        Console.WriteLine(ucet2);

        BankovniUcet.ZobrazPocetAktivnichUctu();

    }
}
public struct PostovniAdresa {
    public string Ulice { get; set; }
    public string CisloPopisne { get; set; }
    public string Mesto { get; set; }
    public string PSC { get; set; }

    public PostovniAdresa(string ulice, string cisloPopisne, string mesto, string psc) {
        Ulice = ulice;
        CisloPopisne = cisloPopisne;
        Mesto = mesto;
        PSC = psc;
    }
}

public class BankovniUcet{
  private string _cisloUctu;
  private decimal _zustatek;
  private PostovniAdresa _adresaMajitele;
  private int _urokovaSazba;
  private static int _celkovyPocetUctu = 1;

  public string CisloUctu {
    get{return _cisloUctu;}
  }
  public decimal Zustatek {
    get{return _zustatek;}
    private set{ _zustatek = value;}
  }
  public int UrokovaSazba{
    get{return _urokovaSazba;}
    set{
      if (value < 0 || value > 15) {
        _urokovaSazba = 0;
        Console.WriteLine("nespravne udaje");
      }
      else _urokovaSazba = value; 
    }
  }
  public BankovniUcet(string cisloUctu, PostovniAdresa adresaMajitele, decimal pocatecniVklad){
    _cisloUctu = cisloUctu;
    _adresaMajitele = adresaMajitele; 
    _celkovyPocetUctu ++;
    if (pocatecniVklad < 0) pocatecniVklad = 0;
    _zustatek = pocatecniVklad;
  }
  public BankovniUcet(string cisloUctu, PostovniAdresa adresaMajitele){
    _cisloUctu = cisloUctu;
    _adresaMajitele = adresaMajitele; 
    _zustatek = 0;
  }

  public static void ZobrazPocetAktivnichUctu(){
    Console.WriteLine(_celkovyPocetUctu);
  }
  
  public void Vlozit(decimal castka) {
    if(castka>0) _zustatek += castka;
  }
  public bool Vybrat(decimal castka) {
    if(castka>0 && _zustatek - castka > 0){
      _zustatek -= castka;
      return true;
    } 
    return false;
  }


  public override string ToString(){
        return $"Účet {_cisloUctu} | Město: {_adresaMajitele.Mesto} | Zůstatek: {_zustatek} Kč";
  }
  


}


// no tak určitě tu historii transakcí, kterou bych ukládal každému zvlášť ale pak bych přes static zobrazil log.
// vytvořil bych půjčku, měla by mít úrok a měsíční splátku
// byla by to static metoda, která by vzala 2 své interní a pokud by to šlo, tak by převedla peníze. 
