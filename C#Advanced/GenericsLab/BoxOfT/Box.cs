using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> elements;
        public Box()
        {
            elements = new Stack<T>();
        }
        public int Count { get => elements.Count;}

        public void Add(T element)
        {
            elements.Push(element);
        }

        public T Remove()
        {
            T element = elements.Pop();
            return element;
        }
    }
}
