using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Progra
    {
        static void Main(string[] args)
        {
            //MacroExpansionClass.MacroExpansion(new[] { 1, 2, 1, 2, 3 }, 2, new[] { 7, 8, 9 })
            MacroExpansionClass.MacroExpansion(new[] { 1, 2, 1, 2, 3 }, 2, new[] { 7, 8, 9 })
            .ToList()
            .ForEach(Console.WriteLine);
        }
    }
}
