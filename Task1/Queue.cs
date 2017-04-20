using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Queue<T> : IEnumerable<T>
    {


        private T[] container;

        public int Count { get { return container.Length; } }

        private T this[int index]
        {
            get { return container[index]; }
            set { container[index] = value; }
        }

        public Queue()
        {

            container = new T[0];
        }

        public Queue(T[] array)
        {
            container = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                container[i] = array[i];
            }
        }

        public T Dequeue()
        {
            if (container.Length == 0) throw new InvalidOperationException();
            T result = container[container.Length - 1];
            Array.Resize<T>(ref container, container.Length - 1);
            return result;
        }

        public void Enqueue(T item)
        {

            container[container.Length - 1] = item;
        }

        public bool Contains(T item)
        {
            return container.Contains<T>(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private struct Iterator : IEnumerator<T>
        {
            private readonly Queue<T> collection;
            private int currentIndex;

            public Iterator(Queue<T> collection)
            {
                currentIndex = collection.Count;
                this.collection = collection;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return collection[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Reset()
            {

                currentIndex = collection.Count;
            }

            public bool MoveNext()
            {
                return --currentIndex >= 0;
            }

            public void Dispose() { }
        }
    }
}
