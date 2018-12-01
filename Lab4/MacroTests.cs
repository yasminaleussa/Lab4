using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using NUnit.Framework;

namespace Lab4
{
    [TestFixture]

    public class MacroTests

    {
        [Test]
        public void TestSequenceNull()
        {
            {
                Assert.That(()=>MacroExpansionClass.MacroExpansion(null,2,null), Throws.TypeOf<ArgumentNullException>());
            }
        }
        [Test]
        public void TestNewValuesNull()
        {
            {
               Assert.That(() => MacroExpansionClass.MacroExpansion(null,2, null), Throws.TypeOf<ArgumentNullException>());
            }
        }

        [Test]
        public void TestNotContainValue()
        {
            {
                IEnumerable <int> sol = MacroExpansionClass.MacroExpansion(new[] { 1, 2, 1, 2, 3 }, 4, new[] { 1, 2, 1, 5, 3 });
                Assert.That(sol, Is.EqualTo(new[] { 1, 2, 1, 2, 3 }));
            }
        }
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 7, 8, 9 }, new[] { 7,8,9,2,3,4,5 })]
        [TestCase(new[] { 1, 2, 4, 3, 5 }, 4, new[] { 7, 8, 9 }, new[] { 1,2,7,8,9,3,5 })]
        [TestCase(new[] { 1, 2, 3, 5, 4 }, 4, new[] { 7, 8, 9 }, new[] { 1,2,3,5,7,8,9 })]
        public void TestAppearOnes(IEnumerable<int> s, int v, IEnumerable<int> ns, IEnumerable<int> res )
        {
            {
                IEnumerable<int> sol = MacroExpansionClass.MacroExpansion(s,v,ns);
                Assert.That(sol, Is.EqualTo(res));

            }
        }

        [Test]
        public void TestAppearsMultiple()
        {
            IEnumerable<string> sol = MacroExpansionClass.MacroExpansion(new[] {"one", "two", "four","two"}, "two",
                new[] {"six", "seven"});
            Assert.That(sol, Is.EqualTo(new[] { "one", "six", "seven", "four", "six", "seven" }));

        }
        [Test]
        public void TestNewValuesAppearOnes()
        {
            {
                IEnumerable<int> sol = MacroExpansionClass.MacroExpansion(new[] { 1, 2, 5, 4 }, 4, new[] { 6, 7 });
                Assert.That(sol, Is.EqualTo(new[] { 1, 2, 5, 6, 7 }));
            }
        }
        [Test]
        public void TestNewValuesAppearMultiple()
        {
            {
                IEnumerable<int> sol = MacroExpansionClass.MacroExpansion(new[] { 1, 4, 5, 4 }, 4, new[] { 6, 7 });
                Assert.That(sol, Is.EqualTo(new[] { 1, 6, 7, 5, 6, 7 }));
            }
        }
        [Test]
        public void TestNewValuesIsEmpty()
        {
            {
                IEnumerable<int> sol = MacroExpansionClass.MacroExpansion(new List<int>(), 9, new List<int>());
                Assert.That(sol, Is.EqualTo(new List<int>()));
            }
        }


    }

    
}
