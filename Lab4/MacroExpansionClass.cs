using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace Lab4
{
    public static class MacroExpansionClass
    {
        public static IEnumerable<T> MacroExpansion<T>(IEnumerable<T> sequence, T value, IEnumerable<T> newValues )
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            if (newValues == null) throw new ArgumentNullException(nameof(newValues));

            if (!sequence.Contains(value)) 
            return sequence;

            List<T> list = new List<T>();

            foreach (var s in sequence)
            {
               if(s.Equals(value)) 
                    list.AddRange(newValues);
                    else list.Add(s);
            }
            return list;
        }
    }
}
