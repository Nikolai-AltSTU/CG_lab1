using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
	public class Pair<T, K>
	{
		public Pair(T t, K k) {
			First = t;
			Second = k;
		}

		public T First { get; set; }
		public K Second { get; set; }
	}
}
