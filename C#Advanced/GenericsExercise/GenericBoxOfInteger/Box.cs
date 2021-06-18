using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            Type type = typeof (T);
            string name = type.FullName;

            return $"{name}: {Value}"; 
        }
    }
}
