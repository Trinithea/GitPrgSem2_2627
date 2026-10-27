
# 🧠 C# – Opakování OOP: Zapouzdření, Dědičnost, Polymorfismus, Abstrakce

---

## 🧩 **1. Zapouzdření (Encapsulation)**

### Kód:
```csharp
class Osoba
{
    private int _vek;

    public int Vek
    {
        get { return _vek; }
        set
        {
            if (value >= 0)
                _vek = value;
        }
    }
}

class Program
{
    static void Main()
    {
        Osoba o = new Osoba();
        o.Vek = -5;
        Console.WriteLine(o.Vek);
    }
}
```

### ✅ **Řešení:**
```
0
```

### 💬 **Vysvětlení:**
- Datová položka `_vek` je **soukromá** (`private`), nelze ji změnit zvenčí.  
- Vlastnost `Vek` lze nastavit na nějakou hodnotu jen, pokud je kladná.  
- Protože jsme zadali `-5`, hodnota se nezmění a `vek` zůstává na výchozí `0`.  
➡️ Ukazuje princip **zapouzdření** a **kontroly přístupu k datům**.

---

## 🧩 **2. Dědičnost (Inheritance)**

### Kód:
```csharp
class Zvire
{
    public void Zvuk()
    {
        Console.WriteLine("Nějaký zvuk...");
    }
}

class Pes : Zvire
{
    public void Haf()
    {
        Console.WriteLine("Haf!");
    }
}

class Program
{
    static void Main()
    {
        Pes p = new Pes();
        p.Zvuk();
        p.Haf();
    }
}
```

### ✅ **Řešení:**
```
Nějaký zvuk...
Haf!
```

### 💬 **Vysvětlení:**
- `Pes` dědí z `Zvire`, takže má přístup ke všem jeho metodám.  
- Může používat jak `Zvuk()`, tak svou vlastní `Haf()`.  
➡️ Ukázka **dědičnosti** a rozšiřování funkcionality.

---

## 🧩 **3. Virtuální metody (Virtual Methods)**

### Kód:
```csharp
class Zvire
{
    public virtual void Zvuk()
    {
        Console.WriteLine("Neznámý zvuk");
    }
}

class Pes : Zvire
{
    public override void Zvuk()
    {
        Console.WriteLine("Haf!");
    }
}

class Program
{
    static void Main()
    {
        Zvire z = new Pes();
        z.Zvuk();
    }
}
```

### ✅ **Řešení:**
```
Haf!
```

### 💬 **Vysvětlení:**
- `Zvuk()` je virtuální metoda.  
- Objekt typu `Pes` ji **přepisuje** pomocí `override`.  
- Proměnná `z` má sice typ `Zvire`, ale obsahuje instanci `Pes`.  
➡️ Díky **polymorfismu** se volá implementace z potomka (`Pes`), ne z rodiče.

---

## 🧩 **4. Abstraktní třídy (Abstract Classes)**

### Kód:
```csharp
abstract class Tvar
{
    public abstract double Obvod();
}

class Kruh : Tvar
{
    private double _r;

    public Kruh(double polomer)
    {
        _r = polomer;
    }

    public override double Obvod()
    {
        return 2 * Math.PI * _r;
    }
}

class Program
{
    static void Main()
    {
        Tvar t = new Kruh(3);
        Console.WriteLine(t.Obvod());
    }
}
```

### ✅ **Řešení (přibližně):**
```
18.84955592153876
```

### 💬 **Vysvětlení:**
- `Tvar` je **abstraktní třída** – nelze od ní přímo vytvořit instanci (`new Tvar()` by nešlo).  
- `Kruh` ji dědí a **implementuje** abstraktní metodu `Obvod()`.  
- `Tvar t = new Kruh(3);` představuje vytvoření instance třídy `Kruh` a její uložení do proměnné typu `Tvar`. Skrze proměnnou `t` můžete standardně volat pouze ty metody, které jsou definované v obecné třídě `Tvar` (-> zabezepčení: lze potom změnit obsah proměnné `t` třeba na `Ctverec` a víme, že zbytek kódu nám nevyhodí chybu, protože jsme nikde po obecném tvaru nemohli chtít např. Poloměr).

➡️ Demonstruje **abstrakci** – definování rozhraní bez konkrétní implementace.

---

## 🧩 **5. Polymorfismus v praxi**

### Kód:
```csharp
class Tvar
{
    public virtual void Vykresli()
    {
        Console.WriteLine("Tvar");
    }
}

class Ctverec : Tvar
{
    public override void Vykresli()
    {
        Console.WriteLine("Čtverec");
    }
}

class Trojuhelnik : Tvar
{
    public override void Vykresli()
    {
        Console.WriteLine("Trojúhelník");
    }
}

class Program
{
    static void Main()
    {
        Tvar[] tvary = { new Ctverec(), new Trojuhelnik(), new Tvar() };
        foreach (var t in tvary)
        {
            t.Vykresli();
        }
    }
}
```

### ✅ **Řešení:**
```
Čtverec
Trojúhelník
Tvar
```

### 💬 **Vysvětlení:**
- Všechny objekty mají typ `Tvar`, ale chovají se podle **skutečné instance**.  
- `override` zajišťuje, že se volá správná verze metody.  
➡️ Klasická ukázka **dynamického polymorfismu**.

---

## 🧩 **6. Kombinace – zapouzdření + polymorfismus**

### Kód:
```csharp
class Uzivatel
{
    private string _jmeno;

    public string Jmeno
    {
        get { return _jmeno; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                _jmeno = value;
        }
    }

    public virtual void Zdrav()
    {
        Console.WriteLine($"Ahoj, jsem {Jmeno}");
    }
}

class Admin : Uzivatel
{
    public override void Zdrav()
    {
        Console.WriteLine($"Zdravím, jsem administrátor {Jmeno}");
    }
}

class Program
{
    static void Main()
    {
        Uzivatel u = new Admin();
        u.Jmeno = "Petr";
        u.Zdrav();
    }
}
```

### ✅ **Řešení:**
```
Zdravím, jsem administrátor Petr
```

### 💬 **Vysvětlení:**
- Vlastnost `Jmeno` využívá **zapouzdření** (get/set s podmínkou).  
- `Zdrav()` je **virtuální metoda**, přepsaná v `Admin`.  
- I když proměnná `u` má typ `Uzivatel`, metoda `Zdrav()` se volá z potomka `Admin`.  
➡️ Ukazuje **zapouzdření** + **polymorfismus** v jednom.


---

## 🧩 **7. private vs. protected a volání konstruktorů**

### Kód:
```csharp
class Zaklad
{
    private string text = "Soukromý text";

    public Zaklad()
    {
        Console.WriteLine("Konstruktor třídy Zaklad");
        Vypis();
    }

    protected virtual void Vypis()
    {
        Console.WriteLine(text);
    }
}

class Potomek : Zaklad
{
    private string text = "Potomek text";

    public Potomek()
    {
        Console.WriteLine("Konstruktor třídy Potomek");
    }

    protected override void Vypis()
    {
        Console.WriteLine(text);
    }
}

class Program
{
    static void Main()
    {
        Zaklad z = new Potomek();
    }
}
```

### ✅ **Řešení:**
```
Konstruktor třídy Zaklad
Potomek text
Konstruktor třídy Potomek
```

### 💬 **Vysvětlení:**
- Nejprve se volá konstruktor rodiče (`Zaklad`), i když vytváříme instanci `Potomek`.  
- Konstruktor `Zaklad` volá virtuální metodu `Vypis()`, která je přepsaná v potomkovi.   
- Vypíše se tedy hodnota `"Potomek text"`.  
- Metoda `Vypis()` je `protected`, takže je dostupná v odděděných třídách, ale nmůžeme ji použít např. v `Program.Main()`. 

➡️ Ukazuje pořadí volání konstruktorů a riziko volání virtuálních metod z konstruktoru.

---

## 🧩 **8. Volání bázového konstruktoru (nutné pro konstruktor s parametry)**

### Kód:
```csharp
public class Osoba
{
    public string Jmeno { get; set; }

    public Osoba() { } // Bezparametrický konstruktor

    public Osoba(string jmeno)
    {
        Jmeno = jmeno;
    }
}

public class Zamestnanec : Osoba
{
    public decimal Plat { get; set; }

    public Zamestnanec(string jmeno, decimal plat) : base(jmeno)
    {
        Plat = plat;
    }
}

public class Program
{
    public static void Main()
    {
        Osoba o = new Zamestnanec("Pepa", 1000);
        Console.WriteLine(o.Jmeno);
    }
}
```

### ✅ **Řešení:**
```
Pepa
```

### 💬 **Vysvětlení:**
- Bez `: base(jmeno)` by se zavolal `Osoba()` a `Jmeno` by zůstalo `null`.
- Pomocí `: base(jmeno)` vynutíme volání konstruktoru `Osoba(string jmeno)`.

➡️ Ukazuje využití `base` pro volání bázového konstruktoru s parametry.

---

## 🧩 **9. Objektový návrh**

### Neideální kód:
```csharp
public void Jed(Vozidlo v) 
{ 
    // Nepřehledné větvění na základě vlastnosti Typ 
    if (v.Typ == "Bus") 
    { 
        Console.WriteLine($"Autobus na lince {v.Linka} jede po silnici a odbočuje na křižovatce."); 
    } 
    else if (v.Typ == "Tramvaj") 
    { 
        Console.WriteLine($"Tramvaj na lince {v.Linka} jede po kolejích a využívá troleje."); 
    } 
    else if (v.Typ == "Metro") 
    { 
        Console.WriteLine($"Metro na lince {v.Linka} jede v tunelu pod zemí."); 
    } 
}
```

### ✅ **Jak to udělat lépe objektově:**
```csharp
public abstract class Vozidlo
{
    public string Linka { get; }

    protected Vozidlo(string linka)
    {
        Linka = linka;
    }

    public abstract string Jed();
}

public class Bus : Vozidlo
{
    public Bus(string linka) : base(linka) { }

    public override string Jed() 
    {
        return $"Autobus na lince {Linka} jede po silnici a odbočuje na křižovatce.";
    }
}

public class Tramvaj : Vozidlo
{
    public Tramvaj(string linka) : base(linka) { }

    public override string Jed() 
        => $"Tramvaj na lince {Linka} jede po kolejích a využívá troleje.";
}

public class Metro : Vozidlo
{
    public Metro(string linka) : base(linka) { }

    public override string Jed() 
        => $"Metro na lince {Linka} jede v tunelu pod zemí.";
}
```

### 💬 **Vysvětlení:**
- Nový kód je krásně rozšiřitelný o např. `Trolejbus`, aniž bychom museli přepisovat interní fungování (již otestovaných) metod.
- Teď můžeme zavolat pro každé vozidlo metodu `Jed()` a každé se rozjede po svém, aniž bychom kód museli zbytečně větvit.
- **Výpis do konzole by neměl probíhat z konkrétních tříd** , proto `Jed()` nakonec vrací string a případnou jízdu vypíšeme z `Main()`.
- Pokud metoda jen něco vrací, můžeme ji syntakticky zkrátit pomocí `=>`.