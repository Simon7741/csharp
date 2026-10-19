# Vývoj bankovního systému
Postupujte podle jednotlivých bodů zadání a vyzkoušejte si sami základy OOP.

## 1. Struktura (Poštovní adresa)

Vytvořte hodnotový typ — strukturu `PostovniAdresa`, která bude uchovávat adresu majitele účtu.

Požadavky:

- Struktura bude obsahovat automatické vlastnosti: `Ulice`, `CisloPopisne`, `Mesto` a `PSC`.
- Přidejte konstruktor pro nastavení všech těchto čtyř hodnot při vytvoření struktury.

## 2. Vlastní třída a privátní datové položky

Vytvořte novou třídu s názvem `BankovniUcet`.

Požadavky:
- Uvnitř třídy definujte privátní datové položky (fields):

    - `_cisloUctu` (řetězec),

    - `_zustatek` (desetinné číslo / decimal),

    - `_adresaMajitele` (typ PostovniAdresa z 1. úkolu).

- Uvedené položky musí být dostupné pouze zevnitř třídy `BankovniUcet` (použijte modifikátor `private`).

## 3. Vlastnost s privátním setterem

Zpřístupněte některé hodnoty pro čtení zvenčí pomocí vlastností (*Properties*), ale zabraňte jejich přímé úpravě.

Požadavky:

- Vytvořte vlastnost `CisloUctu` (pouze pro čtení – `get`).

- Vytvořte vlastnost `Zustatek` s veřejným `get` a privátním setterem (`private set`). Tím zajistíte, že stav účtu nebude možné zvenčí libovolně přepsat (např. `ucet.Zustatek = 1000000;`).

## 4. Vlastnost s omezením setteru (Validace)

Přidejte do třídy vlastnost, která při zápisu provádí kontrolu zadaných dat.

Požadavky:

- Vytvořte privátní položku `_urokovaSazba` a k ní veřejnou vlastnost `UrokovaSazba` (v procentech).

- V jejím setteru ošetřete hodnotu: Úroková sazba nesmí být záporná a nesmí přesáhnout 15 %. Pokud někdo zadá neplatnou hodnotu, nastavte bezpečné minimum (0 %) a vypište varování do konzole.

## 5. Hlavní konstruktor

Zajistěte, aby objekt účtu nebylo možné vytvořit v neplatném stavu.

Požadavky:

- Definujte veřejný konstruktor, který při vytvoření účtu přijme: `cisloUctu`, `adresaMajitele` a `pocatecniVklad`.

- Hodnoty uložte do příslušných položek/vlastností. Pokud je počáteční vklad záporný, nastavte zůstatek na 0.

## 6. Přetížený konstruktor (Constructor Overloading)

Umožněte vytvoření účtu i bez zadání počátečního vkladu.

Požadavky:

- Vytvořte druhý konstruktor, který přijímá pouze `cisloUctu` a `adresaMajitele`.

- Využijte provázání konstruktorů (klíčové slovo this), kterým předáte počáteční vklad roven 0.

## 7. Metody (Chování objektu)

Definujte chování, pomocí kterého lze s účtem manipulovat.

Požadavky:

- Vytvořte veřejnou metodu `Vlozit(decimal castka)`. Metoda přičte částku k zůstatku (pouze pokud je částka kladná).

- Vytvořte veřejnou metodu `Vybrat(decimal castka)`. Metoda ověří, zda je na účtu dostatek peněz a zda je částka kladná. Pokud ano, odečte ji ze zůstatku a vrátí `true`. Pokud peníze nestačí, operaci zamítne a vrátí `false`.

## 8. Statické pole (Static field)

Sledujte globální stav bankovního systému napříč všemi instancemi.

Požadavky:

- Přidejte do třídy `BankovniUcet` statickou privátní proměnnou `_celkovyPocetUctu`.

- V konstruktoru třídy tuto proměnnou inkrementujte (++), aby uchovávala přesný počet dosud vytvořených účtů v aplikaci.

## 9. Statická metoda (Static method)

Vytvořte způsob, jak přistoupit k celkovému počtu účtů bez nutnosti odkazovat se na konkrétního klienta.

Požadavky:

- Vytvořte veřejnou statickou metodu `ZobrazPocetAktivnichUctu()`.

- Metoda vypíše do konzole aktuální hodnotu ze statického pole `_celkovyPocetUctu`.

## 10. Přepis metody ToString (Override)

Upravte textovou reprezentaci objektu pro čitelnější výpis do konzole.

Požadavky:

- Přepište (`override`) zdeděnou metodu `ToString()`.

- Metoda vrátí naformátovaný řetězec obsahující číslo účtu, město majitele a aktuální zůstatek (např. "Účet 1234/0800 | Město: Praha | Zůstatek: 15 000 Kč").

## 11. Vytvoření vlastních instancí a testování

Otestujte celou funkčnost v hlavní metodě Main.

Požadavky:

- Vytvořte alespoň 2 vlastní instance třídy `BankovniUcet` (použijte různé konstruktory).

- Vyzkoušejte provést:
    - vklad, 
    - neplatný výběr (více než je zůstatek) 
    - a platný výběr.

- Vypište informace o účtech přímo do konzole pomocí `Console.WriteLine(ucet1);` (využije se vaše metoda `ToString`).

- Zavolejte statickou metodu pro zobrazení celkového počtu účtů.

## 12. Vlastní myšlenka – Objektový návrh (Architektura)

Zamyslete se nad tím, jak byste systém dále rozšířili, aby odpovídal reálnému světu.

Zadání:

- Představte si, že máte do systému přidat historii transakcí (každý pohyb na účtu musíme dohledat) a možnost převodu peněz z jednoho účtu na druhý.

- Napište stručný slovní návrh nebo náčrt kódu:

    - Jakou novou třídu nebo strukturu byste vytvořili a jaké vlastnosti by měla mít?

    - Jakým způsobem by třída `BankovniUcet` uchovávala seznam svých minulých transakcí?

    - Jak by logicky a objektově měla vypadat metoda pro převod peněz mezi dvěma účty (např. `PrevestPeníze(...)`)? Jaké objekty vstupují do hry a jaké metody by se měly zavolat?