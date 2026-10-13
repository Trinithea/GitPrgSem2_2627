# Základy OOP hezky česky
Vysvětlení kódu z hodiny pro ty co byli duchem či jinak nepřítomni.

## Motivace
- OOP = *Object-Oriented Programming*
- způsob programování, který dělá kód lépe čitelným, znovupoužitelným, rošiřitelným a více odpovídá tomu, jak vypadá modelovaný systém v reálném světě
- př. Člověk - má jméno, věk, může něco dělat... bez znalosti vlastních tříd a objektů bychom ho reprezentovali nanejvýš tak nějakým polem či více proměnnými (navíc v poli nemůžeme ukládat prvky různých typů)
- hodí se tedy i pro přehledné a efektivní uchovávání více věcí najednou
- zabraňuje zbytečnému opakování kódu a jeho kopírování

## Třída (class)
- vytvořením třídy `class Clovek { ... }` definujeme nový datový typ (ale jde pouze o definici, nezbaíráme tím zatím žádné místo v paměti programu)
- typicky v ní definujeme: privátní datové položky, veřejné vlastnosti, veřejné nebo privátní metody, konstruktor 
### Privátní datové položky
- př. `private int _zdravi` 
- název začíná podtržítkem, obyčejná celočíselná proměnná, skrytá pro zbytek kódu mimo třídu
### Veřejné vlastnosti
- př. `public string Jmeno {get; set;}` 
- název začíná velkým písmenem, jde vlastně spíš o dvojici metod (`get_Jmeno()` a `set_Jmeno(value)`, které se navenek tvaří jako proměnná, ale můžeme do ní vložit nějakou logiku např. nastavování hodnot) 
- kód `public string Jmeno {get; set;}` je jen syntaktickou zkratkou za:
    ```csharp
    private string _jmeno; // Skryté záložní pole vytvořené kompilátorem na pozadí

    public string Jmeno
    {
        get { return _jmeno; }
        set { _jmeno = value; }
    }
    ```
- můžeme např. říct, že vlastnost může být zvenku jen pro čtení, ale přepisovat ji lze pouze uvnitř třídy: `public string Jmeno { get; private set; }`
- nebo říct, že její hodnotu lze určit nejpozději v konstruktoru a pak už nikdy: `public string Jmeno { get; }`
- můžeme omezit nastavení vlastnosti na konkrétní hodnoty:
    ```csharp
    public int Zdravi
    {
        get { return _zdravi; }
        private set
        {
            // Validace v SETteru: zdraví nesmí klesnout pod 0 ani přesáhnout 100
            if (value < 0) _zdravi = 0;
            else if (value > 100) _zdravi = 100;
            else _zdravi = value;
        }
    }
    ```
### Veřejné nebo privátní metody 
- př. `public void Pozdrav() { ... }`
- ty dobře známe, takže více nerozvádím

### Konstruktor
- př. `public Clovek()` - je to tedy metoda, která je veřejná, nazývá se stejně jako daná třída a nepíšeme u ní návratový typ
- spouští se při vytváření nové instance dané třídy:
    - př. `Clovek pepa = new Clovek();` poslední část tohoto příkazu je právě volání bezparametrického kontstruktoru, který má každá třída
- můžeme si ale vytvořit i konstruktor s parametry (případně více konstruktorů s jinými parametry)
    - slouží to k tomu, aby už při vytvoření měla daná instance všechny potřebné vlasnosti nastavené
    - např. člověka bychom neměli zakládat bez jména:
        ```csharp
        public Clovek(string jmeno){
            Jmeno = jmeno; // přiřadíme ho dané vlastnosti
        }
        ```
        - pak bychom nového člověka museli založit jako `Clovek pepa = new Clovek("Pepa");`

### Statické členy
- Klíčové slovo `static` znamená, že člen (proměnná, metoda, vlastnost) patří samotné třídě, nikoli konkrétním instancím.

- Neplatí pro něj `new`. Volá se přímo přes název třídy (např. `Math.Sqrt()`, `Console.WriteLine()`).

- Statická proměnná: Je sdílená napříč všemi instancemi (např. globální počítadlo vytvořených objektů).

## Struktura (struct)
- principiálně velmi podobné třídě, ale z hlediska chování v C# se liší
- struktura je *hodnotového* typu (ukládá se na zásobník)
    - zatímco třída je *referenčního* typu (ukládá se na haldu)
    - kopíruje se tedy celá hodnota, ne jen odkaz na haldu
- obecně zabírá v paměti méně místa a hodí se pro jednodušší objekty bez interní logiky (např. souřadnice bodu - dvě čísla X, Y)
```csharp
public struct BodStruct
{
    public int X { get; set; }
    public int Y { get; set; }

    public BodStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}
```