using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PairLibary;

namespace PairLibary.Test
{
    [TestClass]
    public class UnitTestPairs
    {

        [TestMethod]
        public void DuplicatePairs()
        {
            try
            {
                int[] arrayInts = new int[] { 1, 9, 3, 4, 5, 6, 2, 9, 0 };

                Pairs[] returnValue = Pairs.DivisiblePairs(arrayInts);

                bool testError = true;
                string msg = "Success!";
                foreach (Pairs par in returnValue)
                {
                    if (par.Dividend % par.Divider != 0)
                    {
                        testError = false;
                        msg = "There are pairs that are not divisible.";
                        break;
                    }
                }

                Assert.AreEqual(true, testError, msg);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }

        [TestMethod]
        public void NoDuplicatePairs()
        {
            try
            {
                int[] arrayInts = new int[] { 1, 9, 3, 4, 5, 6, 2, 9, 0 };

                Pairs[] returnValue = Pairs.DivisiblePairs(arrayInts, true);

                bool testError = true;
                string msg = "Success!";
                List<Pairs> pairAlreadyTested = new List<Pairs>();

                foreach (Pairs pair in returnValue)
                {
                    if (pair.Dividend % pair.Divider != 0)
                    {
                        testError = false;
                        msg = "There are pairs that are not divisible.";
                        break;
                    }

                    if (pairAlreadyTested.Where(x => pair.Dividend == x.Dividend && pair.Divider == x.Divider).Count() > 0)
                    {
                        testError = false;
                        msg = "There are duplicate items.";
                        break;
                    }

                    pairAlreadyTested.Add(pair);
                }

                Assert.AreEqual(true, testError, msg);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }

        [TestMethod]
        public void PairsWithoutDividers()
        {
            try
            {
                int[] arrayInts = new int[] { 7, 9, 13, 19 };

                Pairs[] returnValue = Pairs.DivisiblePairs(arrayInts, true);

                bool testError = true;
                string msg = "Success!";
                List<Pairs> pairAlreadyTested = new List<Pairs>();

                foreach (Pairs par in returnValue)
                {
                    if (par.Dividend % par.Divider != 0)
                    {
                        testError = false;
                        msg = "There are pairs that are not divisible.";
                        break;
                    }

                    if (pairAlreadyTested.Where(x => par.Dividend == x.Dividend && par.Divider == x.Divider).Count() > 0)
                    {
                        testError = false;
                        msg = "Existem itens duplicados";
                        break;
                    }

                    pairAlreadyTested.Add(par);
                }

                Assert.AreEqual(true, testError, msg);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }

        [TestMethod]
        public void PairsNullOrEmpty()
        {
            try
            {
                int[] arrayInts = new int[] { };

                Pairs[] returnValue = Pairs.DivisiblePairs(arrayInts, true);

                Assert.AreEqual(true, true, "Success!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }

        [TestMethod]
        public void PairsNull()
        {
            try
            {
                int[] arrayInts = null;
                Pairs[] returnValue = Pairs.DivisiblePairs(arrayInts, true);


                Assert.AreEqual(true, true, "Success!");
            }
            catch (ArrayIntNullException)
            {
                Assert.AreEqual(true, true, "Success!");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(true, false, ex.Message);
            }
        }
    }
}
