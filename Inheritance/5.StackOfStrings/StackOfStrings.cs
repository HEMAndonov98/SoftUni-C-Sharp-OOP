using System;
using System.Collections.Generic;

namespace CustomStack
{
	public class StackOfStrings : Stack<string>
	{
		public bool IsEmpty()
        {
			return base.Count <= 0;
        }

		public void AddRange(IEnumerable<string> strings)
        {
            foreach (var item in strings)
            {
                base.Push(item);
            }
        }
	}
}

