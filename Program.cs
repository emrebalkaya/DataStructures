using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace DSProject
{
    class Müşteri
    {
        private String MüşteriAdı;
        private int ÜrünSayısı;
        public String müşteriadı
        {
            get { return MüşteriAdı; }
        }
        public int ürünsayısı
        {
            get { return ÜrünSayısı; }
        }
        public Müşteri(String MüşteriAdı, int ÜrünSayısı)// constructor
        {
            this.MüşteriAdı = MüşteriAdı;
            this.ÜrünSayısı = ÜrünSayısı;
        }
        public override String ToString()
        {
            return "Müşteri: (" + MüşteriAdı + "," + ÜrünSayısı + ")";
        }
    }
    class Stack
    {
        private int maxSize; // size of stack array
        private Müşteri[] stackArray;
        private int top; // top of stack                            
        public Stack(int s) // constructor
        {
            maxSize = s; // set array size
            stackArray = new Müşteri[maxSize]; // create array
            top = -1; // no items yet
        }
        public void push(Müşteri j) // put item on top of stack
        {
            stackArray[++top] = j; // increment top, insert item
        }
        public Müşteri pop() // take item from top of stack
        {
            return stackArray[top--]; // access item, decrement top
        }
        public Müşteri peek() // peek at top of stack
        {
            return stackArray[top];
        }
        public bool isEmpty() // true if stack is empty
        {
            return (top == -1);
        }
        public bool isFull() // true if stack is full
        {
            return (top == maxSize - 1);
        }
    }
    class Queue
    {
        private int maxSize;
        private Müşteri[] queue;
        private int front;
        private int rear;
        private int nItems;
        public Queue(int s) // constructor
        {
            maxSize = s;
            queue = new Müşteri[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }
        public void insert(Müşteri j) // put item at rear of queue
        {
            if (rear == maxSize - 1) // deal with wraparound
                rear = -1;
            queue[++rear] = j; // increment rear and insert
            nItems++; // one more item
        }
        public Müşteri remove() // take item from front of queue
        {
            Müşteri temp = queue[front++]; // get value and incr front
            if (front == maxSize) // deal with wraparound
                front = 0;
            nItems--; // one less item
            return temp;
        }
        public bool isEmpty() // true if queue is empty
        {
            return (nItems == 0);
        }
        public int size() // number of items in queue
        {
            return nItems;
        }
    }
    class ÖncelikliKuyruk
    {
        private List<Müşteri> queue;
        int rear = -1;
        public ÖncelikliKuyruk()
        {
            queue = new List<Müşteri>();
        }
        public void ekle(Müşteri x)// listenin sonuna eleman ekler.
        {
            if (rear == queue.Count - 1) // deal with wraparound
                rear = -1;
            queue.Insert(++rear, x); // rear arttırılır ve ekleme işlemi yapılır.
        }
        public Müşteri sil()//ürün sayısı en fazla olan müşteriyi siler.
        {
            int ürünmax = 0, index = 0;
            Müşteri çıkacakmüşteri = queue.ElementAt(0);
            for (int i = 0; i < queue.Count; i++)
            {
                if (queue[i].ürünsayısı >= ürünmax)
                {
                    ürünmax = queue[i].ürünsayısı;
                    index = i;
                    çıkacakmüşteri = queue.ElementAt(index);
                }
            }
            queue.RemoveAt(index);
            return çıkacakmüşteri;
        }
        public bool bosMu()//kuyruk boşsa true döndürür.
        {
            return queue.Count == 0;
        }
    }
    class ÖncelikliKuyrukArtan
    {
        private List<Müşteri> pqueue;
        int rear = -1;
        public ÖncelikliKuyrukArtan()
        {
            pqueue = new List<Müşteri>();
        }
        public void ekle(Müşteri x)
        {
            if (rear == pqueue.Count - 1) // deal with wraparound
                rear = -1;
            pqueue.Insert(++rear, x);
        }
        public Müşteri sil()//ürün sayısı en az olan müşteriyi siler.
        {
            int ürünmin = pqueue.ElementAt(0).ürünsayısı, index = 0;
            Müşteri çıkacakmüşteri = pqueue.ElementAt(0);
            for (int i = 0; i < pqueue.Count; i++)
            {
                if (pqueue[i].ürünsayısı <= ürünmin)//ürün sayısı karşılaştırma
                {
                    ürünmin = pqueue[i].ürünsayısı;
                    index = i;
                    çıkacakmüşteri = pqueue.ElementAt(index);
                }
            }
            pqueue.RemoveAt(index);// müşteriyi silme
            return çıkacakmüşteri;
        }
        public bool bosMu()// liste boşsa true döndürür.
        {
            return pqueue.Count == 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            String[] MüşteriAdı = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };
            int[] ÜrünSayısı = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };
            ArrayList customers = new ArrayList();
            List<Müşteri> müşteriList = new List<Müşteri>();//Müşterilerin tutulacağı Generic List
            Random rnd = new Random();//Generic List'e kaç tane müşteri atılacağını belirler.
            int maxsize = rnd.Next(1, 6);
            for (int i = 0; i < MüşteriAdı.Length; i++)
            {
                Müşteri müşteri = new Müşteri(MüşteriAdı[i], ÜrünSayısı[i]);
                müşteriList.Add(müşteri);
                if (müşteriList.Count == maxsize)//Eğer Belirtilen maxsize kadar olduysa o listeyi arrayliste ekler.
                {
                    customers.Add(müşteriList);                       
                    müşteriList = new List<Müşteri>();
                    maxsize = rnd.Next(1, 6);//Ekleme yapıldığı için yeni liste için yeni maxsize belirlenir.                        
                    if ((i + 1) + maxsize > MüşteriAdı.Length)
                    {                            
                        maxsize = MüşteriAdı.Length - (i + 1);//listenin sonuna doğru maxsize listenin uzunluğunu geçiyorsa düzenleme yapılır.
                    }
                }  
            }
            foreach (List<Müşteri> x in customers)
            {
                for (int i = 0; i < x.Count; i++)
                {
                    Console.WriteLine(x[i]);
                }
                Console.WriteLine("******************");
            }     
            Console.WriteLine("ArrayList eleman(Liste) sayısı:" + customers.Count);
            Console.WriteLine("Listelerin ortalama eleman sayısı:" + (MüşteriAdı.Length / customers.Count));            
            //-----------STACK--------------
            Stack stack = new Stack(MüşteriAdı.Length);
            for(int i = 0; i < MüşteriAdı.Length; i++)
            {
                Müşteri stackmüşteri = new Müşteri(MüşteriAdı[i], ÜrünSayısı[i]);//Müşterilerin oluşturulup Stack veri yapısına eklenmesi
                stack.push(stackmüşteri);
            }
            Console.WriteLine("-------Stack-------");
            while (!stack.isEmpty())//Stackteki elemanları çıkartarak yazdırılması
            { 
                Console.WriteLine("Çıkan Müşteri: "+ stack.pop());
            }            
            //------------QUEUE--------------
            Queue que = new Queue(MüşteriAdı.Length);
            for (int i =0; i < MüşteriAdı.Length; i++)
            {
                Müşteri quemüşteri = new Müşteri(MüşteriAdı[i], ÜrünSayısı[i]);///Öncelikli Kuyruktaki elemanlar çıkartılarak yazdırılır
                que.insert(quemüşteri);
            }
            Console.WriteLine("-------Queue-------");
            int queişlemsüresi = 0;
            int işlemsüresi = 0;
            while (!que.isEmpty())
            {                
                Müşteri çıkanmüşteri = que.remove();//Kuyruktaki elemanlar çıkartılarak yazdırılır
                işlemsüresi += çıkanmüşteri.ürünsayısı;// Her müşterinin işlem süresi hesaplanır                
                Console.WriteLine("Çıkan müşteri: " + çıkanmüşteri+ " işlem süresi: "+işlemsüresi);                
                queişlemsüresi += işlemsüresi;//Toplam işlem süresi hesaplanır               
            }
            Console.WriteLine("Kuyruk için geçen toplam işlem tamamlanma süresi: " + queişlemsüresi);
            Console.WriteLine("Kuyruk için ortalama işlem tamamlanma süresi: " + (queişlemsüresi /MüşteriAdı.Length));
            //--------ÖNCELİKLİ KUYRUK----------
            ÖncelikliKuyruk pq = new ÖncelikliKuyruk();
            for(int i = 0; i < MüşteriAdı.Length; i++)
            {
                Müşteri pqmüşteri = new Müşteri(MüşteriAdı[i], ÜrünSayısı[i]);//Müşterilerin oluşturulup Öncelikli Kuyruk veri yapısına eklenmesi
                pq.ekle(pqmüşteri);
            }
            Console.WriteLine("-------Önceklikli Kuyruk------");
            int pqueişlemsüresi = 0;
            int işlemsüresipq = 0;
            while (!pq.bosMu())
            {
                Müşteri çıkanmüşteripq = pq.sil();//Öncelikli Kuyruktaki elemanlar çıkartılarak yazdırılır
                işlemsüresipq += çıkanmüşteripq.ürünsayısı;// Her müşterinin işlem süresi hesaplanır 
                Console.WriteLine("Çıkan müşteri: " + çıkanmüşteripq+" işlem süresi :"+ işlemsüresipq);
                pqueişlemsüresi += işlemsüresipq;//Toplam işlem süresi hesaplanır
            }
            Console.WriteLine("Öncelikli Kuyruk(azalan) için geçen toplam işlem tamamlanma süresi: " + pqueişlemsüresi);
            Console.WriteLine("Öncelikli Kuyruk(azalan) için ortalama işlem tamamlanma süresi: " + (pqueişlemsüresi / MüşteriAdı.Length));
            //-------ÖNCELİKLİ KUYRUK ARTAN--------
            ÖncelikliKuyrukArtan pqa = new ÖncelikliKuyrukArtan();
            for (int i = 0; i < MüşteriAdı.Length; i++)
            {
                Müşteri pqamüşteri = new Müşteri(MüşteriAdı[i], ÜrünSayısı[i]);//Müşterilerin oluşturulup Artan Öncelikli Kuyruk veri yapısına eklenmesi
                pqa.ekle(pqamüşteri);
            }
            Console.WriteLine("------Öncelikli Kuyruk Artan-----");
            int apqueişlemsüresi = 0;
            int işlemsüresipqa = 0;
            while (!pqa.bosMu())
            {
                Müşteri çıkanmüşteripqa = pqa.sil();//Artan Öncelikli Kuyruktaki elemanlar çıkartılarak yazdırılır
                işlemsüresipqa += çıkanmüşteripqa.ürünsayısı;// Her müşterinin işlem süresi hesaplanır 
                Console.WriteLine("Çıkan müşteri: " + çıkanmüşteripqa + "işlem süresi :" + işlemsüresipqa);
                apqueişlemsüresi += işlemsüresipqa;//Toplam işlem süresi hesaplanır
            }
            Console.WriteLine("Öncelikli Kuyruk(artan) için geçen toplam işlem tamamlanma süresi: " + apqueişlemsüresi);
            Console.WriteLine("Öncelikli Kuyruk(artan) için ortalama işlem tamamlanma süresi: " + (apqueişlemsüresi / MüşteriAdı.Length));
            Console.ReadKey();
        }
    }
}
