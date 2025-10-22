
# Úlohy – Analýza časové a prostorové složitosti (C#)

Níže naleznete sadu úloh pro určení časové a prostorové složitosti algoritmů pracujících s poli, seznamy, spojovými seznamy, zásobníkem a frontou.

Pokud u úlohy není uveden kód, popište (pomocí číslovaného seznamu) kroky algoritmu.


---

## Úloha 1 – Součet prvků pole
```csharp
public static int SumArray(int[] arr)
{
    int sum = 0;
    foreach (int x in arr)
        sum += x;
    return sum;
}
```
⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(1)

---

## Úloha 2 – Nalezení maxima v poli
```csharp
public static int FindMax(int[] arr)
{
    int max = arr[0];
    foreach (int x in arr)
        if (x > max)
            max = x;
    return max;
}
```
⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(1)

---

## Úloha 3 – Hledání prvku v poli
```csharp
public static bool Contains(int[] arr, int target)
{
    foreach (int x in arr)
        if (x == target)
            return true;
    return false;
}
```
⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(1)

---

## Úloha 4 – Bubble sort
```csharp
public static void BubbleSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}
```
⌛ **Časová složitost:** O(n^2)

💾 **Prostorová složitost:** O(1)

---

## Úloha 5 – Binární vyhledávání

🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(log n)

💾 **Prostorová složitost:** O(1)



## Úloha 6 – Quicksort
```csharp
public static List<int> QuickSort(List<int> arr)
{
    if (arr.Count <= 1)
        return arr;
    int pivot = arr[arr.Count / 2];
    List<int> left = new List<int>();
    List<int> middle = new List<int>();
    List<int> right = new List<int>();

    foreach (int x in arr)
    {
        if (x < pivot) left.Add(x);
        else if (x == pivot) middle.Add(x);
        else right.Add(x);
    }

    List<int> result = new List<int>();
    result.AddRange(QuickSort(left));
    result.AddRange(middle);
    result.AddRange(QuickSort(right));
    return result;
}
```
⌛ **Časová složitost:** O(n^2)

💾 **Prostorová složitost:** O(n)

Změnila by se časová složitost nějak, kdyby se nám podařilo jako pivot vždy určit medián podposloupnosti?

⌛ **Časová složitost:** O(nlog n)

---

## Úloha 7 – Spojový seznam: zavolání konstruktoru třídy Node
```csharp
public class Node
{
    public int Value;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}
```
⌛ **Časová složitost:** O(1)

💾 **Prostorová složitost:** O(1)

---

## Úloha 8 – Otočení spojového seznamu
🧠 **Kroky algoritmu:**

1. 

⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(3)


## Úloha 9 – Nalezení prvku ve spojovém seznamu
```csharp
public static bool Find(Node head, int target)
{
    Node current = head;
    while (current != null)
    {
        if (current.Value == target)
            return true;
        current = current.Next;
    }
    return false;
}
```
⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(1)

---

## Úloha 10 – Odstranění prvku ze spojového seznamu
🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(2)

## Úloha 11 – Odstranění posledního prvku ze spojového seznamu
🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(2)

## Úloha 12 – Destruktivní sjednocení dvou spojových seznamů
🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(n)

## Úloha 13 – Destruktivní průnik dvou spojových seznamů
🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(n)

💾 **Prostorová složitost:** O(n)

## Úloha 14 - Hanojské věže
Na stole jsou tři tyče: A, B a C.
Na tyči A je naskládáno N disků různých velikostí — největší dole, nejmenší nahoře.
Cílem je přesunout všechny disky z tyče A na tyč C, přičemž platí tato pravidla:

1. V jednom kroku lze přesunout pouze jeden disk.
2. Nikdy nesmíš položit větší disk na menší.
3. Pomocná tyč (B) může být použita k dočasnému odložení disků.

🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(2^n)

💾 **Prostorová složitost:** O(3n)

## Úloha 15 - Problém 8 dam
Úkolem je rozmístit 8 šachových dam na šachovnici 8×8 tak,
aby se žádné dvě dámy neohrožovaly — tzn. nesmí být ve stejném řádku, sloupci ani diagonále. 

🧠 **Kroky algoritmu:**

1. 


⌛ **Časová složitost:** O(2^n)

💾 **Prostorová složitost:** O(n^2)
