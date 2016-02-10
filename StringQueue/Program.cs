using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringQueue
{
    class StringQueue
    {
        private int _capacity;
        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        private int _length;
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private int _frontIndex;
        public int FrontIndex
        {
            get { return _frontIndex; }
            set { _frontIndex = value; }
        }
        public int BackIndex
        {
            get { return (FrontIndex + Length) % Capacity; }
        }
        private string[] _elements;

        protected string[] Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public StringQueue()
        {
            Elements = new string[Capacity]; 
        }

        public StringQueue(int capacity)
        {
            Capacity = capacity;
            Elements = new string[Capacity];
        }

        public void Enqueue(string str)
        {
            if (this.Length == Capacity)
            {
                IncreaseCapacity();
            }
           
            
                Elements[BackIndex] = str;
                Length++;
           
        }

        public string Dequeue()
        {
            if (this.Length == 0)
            {
                return "Queue is empty!";
            }
            else
            {
               string str = Elements[FrontIndex];
               Elements[FrontIndex] = default(string);
               Length--;
               FrontIndex = (FrontIndex + 1) % Capacity;
               return str;

            }

        }

        public int IncreaseCapacity()
        {
            this.Capacity++;
            this.Capacity *= 2;
            string[] tempElements = new string[this.Capacity];
            for (int i = 0; i < Length ; i ++ )
            {
                tempElements[i] = Elements[i];
            }
             Elements = tempElements;
            return Capacity;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringQueue myQueue = new StringQueue();
            myQueue.Enqueue("a");
            myQueue.Enqueue("b");
            Console.WriteLine(myQueue.Length);
        }
    }
}
