using System;
using System.Collections.Generic;
using System.Linq;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IterTools.Tests
{
    [TestClass]
    public class ToolsTests
    {
        [TestMethod]
        public void Repeat_Returns_CorrectNumberOfItems()
        {
            var expected = 10;
            var actual = Tools.Repeat("a", expected).Count();
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void DropWhile_Returns()
        {
            var expected = new List<int> {6,4,1};
            var actual = EnumHelper.DropWhile(new List<int> {1,4,6,4,1}, i => i<5).ToList();
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        
        [TestMethod]
        public void Cycle_Returns()
        {
            var expected = new List<string> {"A", "B", "C", "D","A", "B", "C", "D","A", "B", "C", "D","A", "B", "C", "D","A", "B", "C", "D"};
            var actual = EnumHelper.Cycle(new List<string> {"A", "B", "C", "D"}).Take(20).ToList();
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
        
        [TestMethod]
        public void Chain_Returns_Concatenation_Lists()
        {
            var actual = Tools.Chain(new List<int> {1,2,3,4,5}, new List<int> {6,7,8,9,10});
            Assert.IsTrue(new List<int> {1,2,3,4,5,6,7,8,9,10}.SequenceEqual(actual));
        }

        [TestMethod]
        public void Combination_4x2()
        {
            var actual = Tools.Combination(new List<string> {"A", "B", "C", "D"}, 2).ToList();
            var expected = new List<List<string>>
            {
                new List<string> {"A", "B"}, new List<string> {"A", "C"}, new List<string> {"A", "D"},
                new List<string> {"B", "C"}, new List<string> {"B", "D"}, new List<string> {"C", "D"}
            };

            for (int i = 0; i < expected.Count(); i++)
            {
                var expectedList = expected[i];
                var actualList = actual[i];
                Assert.IsTrue(expectedList.SequenceEqual(actualList));
            }
        }

        [TestMethod]
        public void Range_Returns_AscendingList()
        {
            var actual = EnumHelper.Range(0, 10, 1).ToList();
            Assert.IsTrue((new List<int> {0,1,2,3,4,5,6,7,8,9}).SequenceEqual(actual));
        }
        
        [TestMethod]
        public void Range_Returns_DescendingList()
        {
            var actual = EnumHelper.Range(10, 0, -1).ToList();
            Assert.IsTrue((new List<int> {10,9,8,7,6,5,4,3,2,1}).SequenceEqual(actual));
        }
        
        [TestMethod]
        public void Range_Returns_NegativeList()
        {
            var actual = EnumHelper.Range(0, -10, -1).ToList();
            Assert.IsTrue((new List<int> {0,-1,-2,-3,-4,-5,-6,-7,-8,-9}).SequenceEqual(actual));
        }


        [TestMethod]
        public void Product_Two_List()
        {
            var actual = Tools.Product(new List<string> {"A", "B", "C", "D"}, new List<string> {"x", "y"}).ToList();
            var expected = new List<List<string>>
            {
                new List<string> {"A", "x"}, new List<string> {"A", "y"}, new List<string> {"B", "x"},
                new List<string> {"B", "y"}, new List<string> {"C", "x"}, new List<string> {"C", "y"},
                new List<string> {"D", "x"}, new List<string> {"D", "y"}
            };
            
            for (int i = 0; i < expected.Count(); i++)
            {
                var expectedList = expected[i];
                var actualList = actual[i];
                Assert.IsTrue(expectedList.SequenceEqual(actualList));
            }
            
        }

        [TestMethod]
        public void Product_Twice()
        {
            var actual = Tools.Product(new List<string> {"A", "B", "C", "D"}, 2).ToList();
            var expected = new List<List<string>>
            {
                new List<string> {"A", "A"}, new List<string> {"A", "B"}, new List<string> {"A", "C"},
                new List<string> {"A", "D"}, new List<string> {"B", "A"}, new List<string> {"B", "B"},
                new List<string> {"B", "C"}, new List<string> {"B", "D"}, new List<string> {"C", "A"},
                new List<string> {"C", "B"}, new List<string> {"C", "C"}, new List<string> {"C", "D"},
                new List<string> {"D", "A"}, new List<string> {"D", "B"}, new List<string> {"D", "C"},
                new List<string> {"D", "D"}
            };
            
            for (int i = 0; i < expected.Count(); i++)
            {
                var expectedList = expected[i];
                var actualList = actual[i];
                Assert.IsTrue(expectedList.SequenceEqual(actualList));
            }
            
        }

        [TestMethod]
        public void Product_4x()
        {
            var actual = Tools.Product(new List<string> {"A", "B", "C", "D"}, 4).ToList();
            var expected = new List<List<string>>
            {
                new List<string> {"A", "A", "A", "A"}, new List<string> {"A", "A", "A", "B"},
                new List<string> {"A", "A", "A", "C"}, new List<string> {"A", "A", "A", "D"},
                new List<string> {"A", "A", "B", "A"}, new List<string> {"A", "A", "B", "B"},
                new List<string> {"A", "A", "B", "C"}, new List<string> {"A", "A", "B", "D"},
                new List<string> {"A", "A", "C", "A"}, new List<string> {"A", "A", "C", "B"},
                new List<string> {"A", "A", "C", "C"}, new List<string> {"A", "A", "C", "D"},
                new List<string> {"A", "A", "D", "A"}, new List<string> {"A", "A", "D", "B"},
                new List<string> {"A", "A", "D", "C"}, new List<string> {"A", "A", "D", "D"},
                new List<string> {"A", "B", "A", "A"}, new List<string> {"A", "B", "A", "B"},
                new List<string> {"A", "B", "A", "C"}, new List<string> {"A", "B", "A", "D"},
                new List<string> {"A", "B", "B", "A"}, new List<string> {"A", "B", "B", "B"},
                new List<string> {"A", "B", "B", "C"}, new List<string> {"A", "B", "B", "D"},
                new List<string> {"A", "B", "C", "A"}, new List<string> {"A", "B", "C", "B"},
                new List<string> {"A", "B", "C", "C"}, new List<string> {"A", "B", "C", "D"},
                new List<string> {"A", "B", "D", "A"}, new List<string> {"A", "B", "D", "B"},
                new List<string> {"A", "B", "D", "C"}, new List<string> {"A", "B", "D", "D"},
                new List<string> {"A", "C", "A", "A"}, new List<string> {"A", "C", "A", "B"},
                new List<string> {"A", "C", "A", "C"}, new List<string> {"A", "C", "A", "D"},
                new List<string> {"A", "C", "B", "A"}, new List<string> {"A", "C", "B", "B"},
                new List<string> {"A", "C", "B", "C"}, new List<string> {"A", "C", "B", "D"},
                new List<string> {"A", "C", "C", "A"}, new List<string> {"A", "C", "C", "B"},
                new List<string> {"A", "C", "C", "C"}, new List<string> {"A", "C", "C", "D"},
                new List<string> {"A", "C", "D", "A"}, new List<string> {"A", "C", "D", "B"},
                new List<string> {"A", "C", "D", "C"}, new List<string> {"A", "C", "D", "D"},
                new List<string> {"A", "D", "A", "A"}, new List<string> {"A", "D", "A", "B"},
                new List<string> {"A", "D", "A", "C"}, new List<string> {"A", "D", "A", "D"},
                new List<string> {"A", "D", "B", "A"}, new List<string> {"A", "D", "B", "B"},
                new List<string> {"A", "D", "B", "C"}, new List<string> {"A", "D", "B", "D"},
                new List<string> {"A", "D", "C", "A"}, new List<string> {"A", "D", "C", "B"},
                new List<string> {"A", "D", "C", "C"}, new List<string> {"A", "D", "C", "D"},
                new List<string> {"A", "D", "D", "A"}, new List<string> {"A", "D", "D", "B"},
                new List<string> {"A", "D", "D", "C"}, new List<string> {"A", "D", "D", "D"},
                new List<string> {"B", "A", "A", "A"}, new List<string> {"B", "A", "A", "B"},
                new List<string> {"B", "A", "A", "C"}, new List<string> {"B", "A", "A", "D"},
                new List<string> {"B", "A", "B", "A"}, new List<string> {"B", "A", "B", "B"},
                new List<string> {"B", "A", "B", "C"}, new List<string> {"B", "A", "B", "D"},
                new List<string> {"B", "A", "C", "A"}, new List<string> {"B", "A", "C", "B"},
                new List<string> {"B", "A", "C", "C"}, new List<string> {"B", "A", "C", "D"},
                new List<string> {"B", "A", "D", "A"}, new List<string> {"B", "A", "D", "B"},
                new List<string> {"B", "A", "D", "C"}, new List<string> {"B", "A", "D", "D"},
                new List<string> {"B", "B", "A", "A"}, new List<string> {"B", "B", "A", "B"},
                new List<string> {"B", "B", "A", "C"}, new List<string> {"B", "B", "A", "D"},
                new List<string> {"B", "B", "B", "A"}, new List<string> {"B", "B", "B", "B"},
                new List<string> {"B", "B", "B", "C"}, new List<string> {"B", "B", "B", "D"},
                new List<string> {"B", "B", "C", "A"}, new List<string> {"B", "B", "C", "B"},
                new List<string> {"B", "B", "C", "C"}, new List<string> {"B", "B", "C", "D"},
                new List<string> {"B", "B", "D", "A"}, new List<string> {"B", "B", "D", "B"},
                new List<string> {"B", "B", "D", "C"}, new List<string> {"B", "B", "D", "D"},
                new List<string> {"B", "C", "A", "A"}, new List<string> {"B", "C", "A", "B"},
                new List<string> {"B", "C", "A", "C"}, new List<string> {"B", "C", "A", "D"},
                new List<string> {"B", "C", "B", "A"}, new List<string> {"B", "C", "B", "B"},
                new List<string> {"B", "C", "B", "C"}, new List<string> {"B", "C", "B", "D"},
                new List<string> {"B", "C", "C", "A"}, new List<string> {"B", "C", "C", "B"},
                new List<string> {"B", "C", "C", "C"}, new List<string> {"B", "C", "C", "D"},
                new List<string> {"B", "C", "D", "A"}, new List<string> {"B", "C", "D", "B"},
                new List<string> {"B", "C", "D", "C"}, new List<string> {"B", "C", "D", "D"},
                new List<string> {"B", "D", "A", "A"}, new List<string> {"B", "D", "A", "B"},
                new List<string> {"B", "D", "A", "C"}, new List<string> {"B", "D", "A", "D"},
                new List<string> {"B", "D", "B", "A"}, new List<string> {"B", "D", "B", "B"},
                new List<string> {"B", "D", "B", "C"}, new List<string> {"B", "D", "B", "D"},
                new List<string> {"B", "D", "C", "A"}, new List<string> {"B", "D", "C", "B"},
                new List<string> {"B", "D", "C", "C"}, new List<string> {"B", "D", "C", "D"},
                new List<string> {"B", "D", "D", "A"}, new List<string> {"B", "D", "D", "B"},
                new List<string> {"B", "D", "D", "C"}, new List<string> {"B", "D", "D", "D"},
                new List<string> {"C", "A", "A", "A"}, new List<string> {"C", "A", "A", "B"},
                new List<string> {"C", "A", "A", "C"}, new List<string> {"C", "A", "A", "D"},
                new List<string> {"C", "A", "B", "A"}, new List<string> {"C", "A", "B", "B"},
                new List<string> {"C", "A", "B", "C"}, new List<string> {"C", "A", "B", "D"},
                new List<string> {"C", "A", "C", "A"}, new List<string> {"C", "A", "C", "B"},
                new List<string> {"C", "A", "C", "C"}, new List<string> {"C", "A", "C", "D"},
                new List<string> {"C", "A", "D", "A"}, new List<string> {"C", "A", "D", "B"},
                new List<string> {"C", "A", "D", "C"}, new List<string> {"C", "A", "D", "D"},
                new List<string> {"C", "B", "A", "A"}, new List<string> {"C", "B", "A", "B"},
                new List<string> {"C", "B", "A", "C"}, new List<string> {"C", "B", "A", "D"},
                new List<string> {"C", "B", "B", "A"}, new List<string> {"C", "B", "B", "B"},
                new List<string> {"C", "B", "B", "C"}, new List<string> {"C", "B", "B", "D"},
                new List<string> {"C", "B", "C", "A"}, new List<string> {"C", "B", "C", "B"},
                new List<string> {"C", "B", "C", "C"}, new List<string> {"C", "B", "C", "D"},
                new List<string> {"C", "B", "D", "A"}, new List<string> {"C", "B", "D", "B"},
                new List<string> {"C", "B", "D", "C"}, new List<string> {"C", "B", "D", "D"},
                new List<string> {"C", "C", "A", "A"}, new List<string> {"C", "C", "A", "B"},
                new List<string> {"C", "C", "A", "C"}, new List<string> {"C", "C", "A", "D"},
                new List<string> {"C", "C", "B", "A"}, new List<string> {"C", "C", "B", "B"},
                new List<string> {"C", "C", "B", "C"}, new List<string> {"C", "C", "B", "D"},
                new List<string> {"C", "C", "C", "A"}, new List<string> {"C", "C", "C", "B"},
                new List<string> {"C", "C", "C", "C"}, new List<string> {"C", "C", "C", "D"},
                new List<string> {"C", "C", "D", "A"}, new List<string> {"C", "C", "D", "B"},
                new List<string> {"C", "C", "D", "C"}, new List<string> {"C", "C", "D", "D"},
                new List<string> {"C", "D", "A", "A"}, new List<string> {"C", "D", "A", "B"},
                new List<string> {"C", "D", "A", "C"}, new List<string> {"C", "D", "A", "D"},
                new List<string> {"C", "D", "B", "A"}, new List<string> {"C", "D", "B", "B"},
                new List<string> {"C", "D", "B", "C"}, new List<string> {"C", "D", "B", "D"},
                new List<string> {"C", "D", "C", "A"}, new List<string> {"C", "D", "C", "B"},
                new List<string> {"C", "D", "C", "C"}, new List<string> {"C", "D", "C", "D"},
                new List<string> {"C", "D", "D", "A"}, new List<string> {"C", "D", "D", "B"},
                new List<string> {"C", "D", "D", "C"}, new List<string> {"C", "D", "D", "D"},
                new List<string> {"D", "A", "A", "A"}, new List<string> {"D", "A", "A", "B"},
                new List<string> {"D", "A", "A", "C"}, new List<string> {"D", "A", "A", "D"},
                new List<string> {"D", "A", "B", "A"}, new List<string> {"D", "A", "B", "B"},
                new List<string> {"D", "A", "B", "C"}, new List<string> {"D", "A", "B", "D"},
                new List<string> {"D", "A", "C", "A"}, new List<string> {"D", "A", "C", "B"},
                new List<string> {"D", "A", "C", "C"}, new List<string> {"D", "A", "C", "D"},
                new List<string> {"D", "A", "D", "A"}, new List<string> {"D", "A", "D", "B"},
                new List<string> {"D", "A", "D", "C"}, new List<string> {"D", "A", "D", "D"},
                new List<string> {"D", "B", "A", "A"}, new List<string> {"D", "B", "A", "B"},
                new List<string> {"D", "B", "A", "C"}, new List<string> {"D", "B", "A", "D"},
                new List<string> {"D", "B", "B", "A"}, new List<string> {"D", "B", "B", "B"},
                new List<string> {"D", "B", "B", "C"}, new List<string> {"D", "B", "B", "D"},
                new List<string> {"D", "B", "C", "A"}, new List<string> {"D", "B", "C", "B"},
                new List<string> {"D", "B", "C", "C"}, new List<string> {"D", "B", "C", "D"},
                new List<string> {"D", "B", "D", "A"}, new List<string> {"D", "B", "D", "B"},
                new List<string> {"D", "B", "D", "C"}, new List<string> {"D", "B", "D", "D"},
                new List<string> {"D", "C", "A", "A"}, new List<string> {"D", "C", "A", "B"},
                new List<string> {"D", "C", "A", "C"}, new List<string> {"D", "C", "A", "D"},
                new List<string> {"D", "C", "B", "A"}, new List<string> {"D", "C", "B", "B"},
                new List<string> {"D", "C", "B", "C"}, new List<string> {"D", "C", "B", "D"},
                new List<string> {"D", "C", "C", "A"}, new List<string> {"D", "C", "C", "B"},
                new List<string> {"D", "C", "C", "C"}, new List<string> {"D", "C", "C", "D"},
                new List<string> {"D", "C", "D", "A"}, new List<string> {"D", "C", "D", "B"},
                new List<string> {"D", "C", "D", "C"}, new List<string> {"D", "C", "D", "D"},
                new List<string> {"D", "D", "A", "A"}, new List<string> {"D", "D", "A", "B"},
                new List<string> {"D", "D", "A", "C"}, new List<string> {"D", "D", "A", "D"},
                new List<string> {"D", "D", "B", "A"}, new List<string> {"D", "D", "B", "B"},
                new List<string> {"D", "D", "B", "C"}, new List<string> {"D", "D", "B", "D"},
                new List<string> {"D", "D", "C", "A"}, new List<string> {"D", "D", "C", "B"},
                new List<string> {"D", "D", "C", "C"}, new List<string> {"D", "D", "C", "D"},
                new List<string> {"D", "D", "D", "A"}, new List<string> {"D", "D", "D", "B"},
                new List<string> {"D", "D", "D", "C"}, new List<string> {"D", "D", "D", "D"}
            };
            
            for (int i = 0; i < expected.Count(); i++)
            {
                var expectedList = expected[i];
                var actualList = actual[i];
                Assert.IsTrue(expectedList.SequenceEqual(actualList));
            }
            
        }

        [TestMethod]
        public void Product_3x()
        {
            var actual = Tools.Product(new List<string> {"A", "B", "C", "D"}, 3).ToList();
            var expected = new List<List<string>>
            {
                new List<string> {"A", "A", "A"}, new List<string> {"A", "A", "B"}, new List<string> {"A", "A", "C"},
                new List<string> {"A", "A", "D"}, new List<string> {"A", "B", "A"}, new List<string> {"A", "B", "B"},
                new List<string> {"A", "B", "C"}, new List<string> {"A", "B", "D"}, new List<string> {"A", "C", "A"},
                new List<string> {"A", "C", "B"}, new List<string> {"A", "C", "C"}, new List<string> {"A", "C", "D"},
                new List<string> {"A", "D", "A"}, new List<string> {"A", "D", "B"}, new List<string> {"A", "D", "C"},
                new List<string> {"A", "D", "D"}, new List<string> {"B", "A", "A"}, new List<string> {"B", "A", "B"},
                new List<string> {"B", "A", "C"}, new List<string> {"B", "A", "D"}, new List<string> {"B", "B", "A"},
                new List<string> {"B", "B", "B"}, new List<string> {"B", "B", "C"}, new List<string> {"B", "B", "D"},
                new List<string> {"B", "C", "A"}, new List<string> {"B", "C", "B"}, new List<string> {"B", "C", "C"},
                new List<string> {"B", "C", "D"}, new List<string> {"B", "D", "A"}, new List<string> {"B", "D", "B"},
                new List<string> {"B", "D", "C"}, new List<string> {"B", "D", "D"}, new List<string> {"C", "A", "A"},
                new List<string> {"C", "A", "B"}, new List<string> {"C", "A", "C"}, new List<string> {"C", "A", "D"},
                new List<string> {"C", "B", "A"}, new List<string> {"C", "B", "B"}, new List<string> {"C", "B", "C"},
                new List<string> {"C", "B", "D"}, new List<string> {"C", "C", "A"}, new List<string> {"C", "C", "B"},
                new List<string> {"C", "C", "C"}, new List<string> {"C", "C", "D"}, new List<string> {"C", "D", "A"},
                new List<string> {"C", "D", "B"}, new List<string> {"C", "D", "C"}, new List<string> {"C", "D", "D"},
                new List<string> {"D", "A", "A"}, new List<string> {"D", "A", "B"}, new List<string> {"D", "A", "C"},
                new List<string> {"D", "A", "D"}, new List<string> {"D", "B", "A"}, new List<string> {"D", "B", "B"},
                new List<string> {"D", "B", "C"}, new List<string> {"D", "B", "D"}, new List<string> {"D", "C", "A"},
                new List<string> {"D", "C", "B"}, new List<string> {"D", "C", "C"}, new List<string> {"D", "C", "D"},
                new List<string> {"D", "D", "A"}, new List<string> {"D", "D", "B"}, new List<string> {"D", "D", "C"},
                new List<string> {"D", "D", "D"}
            };

            for (int i = 0; i < expected.Count(); i++)
            {
                var expectedList = expected[i];
                var actualList = actual[i];
                Assert.IsTrue(expectedList.SequenceEqual(actualList));
            }
        }


        [TestMethod]
        public void Permutations_4x2()
        {
            var actual = Tools.Permutations(new List<string> {"A", "B", "C", "D"}, 2).ToList();
            var expected = new List<List<string>>
            {
                new List<string> {"A", "B"}, new List<string> {"A", "C"}, new List<string> {"A", "D"},
                new List<string> {"B", "A"}, new List<string> {"B", "C"}, new List<string> {"B", "D"},
                new List<string> {"C", "A"}, new List<string> {"C", "B"}, new List<string> {"C", "D"},
                new List<string> {"D", "A"}, new List<string> {"D", "B"}, new List<string> {"D", "C"}
            };
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
        }

        [TestMethod]
        public void Permutations_4x3()
        {
            var actual = Tools.Permutations(new List<int> {0,1,2,3}, 3).ToList();
            var expected = new List<List<int>>
            {
                new List<int> {0, 1, 2}, new List<int> {0, 1, 3}, new List<int> {0, 2, 1}, new List<int> {0, 2, 3},
                new List<int> {0, 3, 1}, new List<int> {0, 3, 2}, new List<int> {1, 0, 2}, new List<int> {1, 0, 3},
                new List<int> {1, 2, 0}, new List<int> {1, 2, 3}, new List<int> {1, 3, 0}, new List<int> {1, 3, 2},
                new List<int> {2, 0, 1}, new List<int> {2, 0, 3}, new List<int> {2, 1, 0}, new List<int> {2, 1, 3},
                new List<int> {2, 3, 0}, new List<int> {2, 3, 1}, new List<int> {3, 0, 1}, new List<int> {3, 0, 2},
                new List<int> {3, 1, 0}, new List<int> {3, 1, 2}, new List<int> {3, 2, 0}, new List<int> {3, 2, 1}
            };
            for (int i = 0; i < expected.Count(); i++)
            {
                Assert.IsTrue(expected[i].SequenceEqual(actual[i]));
            }
        }
    }
}
