using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            Stack<string> stack = new Stack<string>();

            foreach (string str in collection)
            {
                stack.Push(str);
            }

            return stack;
        }
    }
}
