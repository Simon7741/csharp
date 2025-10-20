using System.ComponentModel;
using System.Collections;

namespace Spojak;
    internal class Program
    {
        static void Main(string[] args)
        {
            // časová náročnost = n
            LinkedList spojak = new LinkedList();
            int[] cisla1 = {1,2,3,4,6,6,3,6,3,4,5};
            foreach(int i in cisla1){
            spojak.AddToEnd(i);
            }
            LinkedList spojak2 = new LinkedList();
            int[] cisla2 = {1,2,3,4,6,6,3,6,3,3};
            foreach(int i in cisla2){
            spojak2.AddToEnd(i);
            }

            // časová náročnost n
            // spojak.Print();

            // časová náročnost n
            // spojak.Remove();
            //
            // spojak.Print();
            //
            // časová náročnost n
            // bool prvek = spojak.FindX(9);
            // if(prvek){
            //   Console.WriteLine("Prvek je uvnitr");
            // }
            // else{
            //   Console.WriteLine("Prvek neni uvnitr");
            // }
            
            // časová náročnost = n
            // spojak.Remove(3);
            spojak.Print();
            
            // odhadovaná časová náročnost je 2n neboť zde používám hash mapu k ukládání čísel a následnému hledání
            // LinkedList vysledek = spojak.Intersection(spojak,spojak2);

            // odhadovaná časová náročnost je 2n neboť zde používám hash mapu k ukládání čísel a následnému hledání
            // LinkedList vysledek = spojak.Union(spojak,spojak2);

            // vysledek.Print();
        }
    }
    class Node
    {
        // konstruktor.
        public Node(int value) 
        { 
            Value = value;
            Next = null; 
        }
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class LinkedList
    {
        public Node Head { get; set; }
        public void AddToEnd(int value)
        {
            if(Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Node currentNode = Head;
                while(currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new Node(value);
            }
        }
    
        public void Print()
        {
            Node node = Head;
            while ( node!=null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            
        }

        // TODO: Najít maximum
        public int? FindMax()
        // int s otazníkem znamená nullovatelný int - může obsahovat číslo i null 
        {
            if (Head == null)
            {
                Console.WriteLine("Tento seznam je przádný");
                return null; // nullem naznačíme, že maximum nebylo nalezeno
            }
            else
            {
                Node node = Head;
                int x = node.Value;
                while (node != null)
                {
                    if (node.Value > x)
                    {
                        x = node.Value;
                    }
                    node = node.Next;
                }
                return x;
            }

        }

        // odebrat prvek z konce
        public void Remove(){
          Node currentNode = Head;
          Node lastNode = Head;
          while(currentNode.Next != null) {

              lastNode = currentNode;
              currentNode = currentNode.Next;
          }
          if(lastNode.Next == null){
            Console.WriteLine("seznam nic neobsahuje");
          }
          else
          {
            lastNode.Next = null;
          }
        }

        // najít prvek a vrátit True nebo False, jestli tam je
        public bool FindX(int reference)
        {
            Node node = Head;
            while ( node!=null)
            {
                if(reference == node.Value){
                  return true;
                }
                node = node.Next;
            }
            return false;
            
        }

        // odebrat prvek z konce
        public void Remove(int reference){
          if(Head.Value == reference){
            Head = Head.Next;

          }
          Node currentNode = Head;
          Node lastNode = Head;
          while(currentNode != null) {

              if(currentNode.Value == reference){
                lastNode.Next = currentNode.Next;
                currentNode = currentNode.Next;
              }
              else{
              lastNode = currentNode;
              currentNode = currentNode.Next;
              }
          }
        }

        //vytvoří list společných prvků obou seznamů
        public LinkedList Intersection(LinkedList a, LinkedList b){
          Node nodeA = a.Head;
          Node nodeB = b.Head;
          Hashtable hashA = new Hashtable();
          while(nodeA != null){
            if(!hashA.ContainsKey(nodeA.Value)){
            hashA.Add(nodeA.Value,nodeA.Value);
            }
            nodeA = nodeA.Next;
            
          }
          Hashtable hashB = new Hashtable();
          LinkedList output = new LinkedList();
          while(nodeB != null){
            if(hashA.ContainsKey(nodeB.Value) && !hashB.ContainsKey(nodeB.Value)){
              output.AddToEnd(nodeB.Value);
              hashB.Add(nodeB.Value,nodeB.Value);
            }
            nodeB = nodeB.Next;
            
          }
          return output;
        }

        //vytvoří list ze všech prvků obou seznamů
        public LinkedList Union(LinkedList a, LinkedList b){
          Node nodeA = a.Head;
          Node nodeB = b.Head;
          Hashtable hash = new Hashtable();
          LinkedList output = new LinkedList();
          while(nodeA != null){
            if(!hash.ContainsKey(nodeA.Value)){
            hash.Add(nodeA.Value,nodeA.Value);
            output.AddToEnd(nodeA.Value);
            }
            nodeA = nodeA.Next;
            
          }
          while(nodeB != null){
            if(!hash.ContainsKey(nodeB.Value)){
              output.AddToEnd(nodeB.Value);
              hash.Add(nodeA.Value,nodeA.Value);
            }
            nodeB = nodeB.Next;
            
          }
          return output;
        }
        


    }
