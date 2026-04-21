namespace QuickSort;

internal class Program
{
        static void Main(string[] args)
        {

        }

        class QuickSort<T>{
          
          public QuickSort(int key){
            Key = key;
          }
        public int Key;

        }
        class Node<T>{
          public Node(List<int> seznam){
            Seznam = seznam;
            Lenght = seznam.Count();
          }
          public List<int> Seznam;
          public int Lenght;

          public Node<T> LeftSon;
          public Node<T> RightSon;
        }

}
