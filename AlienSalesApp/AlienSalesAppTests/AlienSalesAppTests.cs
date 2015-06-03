using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using AlienSalesApp;

namespace AlienSalesAppTests
{
    [TestClass]
    public class AlienSalesAppTests
    {
        [TestMethod]
        public void Check_onlyDigits_AcceptsGoodString()
        {
            string input = string.Format("123456789 \r\n{0}", Environment.NewLine);
            alienSalesApplication app = new alienSalesApplication();
            bool result = app.onlyDigits(input);
            Assert.IsTrue(result, "onlyDigits rejected a good input string");
        }

        [TestMethod]
        public void Check_onlyDigits_RejectsBadString()
        {
            string input = "123 abc";
            alienSalesApplication app = new alienSalesApplication();
            bool result = app.onlyDigits(input);
            Assert.IsFalse(result, "onlyDigits accepted bad input string");
        }

        [TestMethod]
        public void Check_findK_EvaluatesK()
        {
            string input = "1";
            alienSalesApplication app = new alienSalesApplication();
            int k = app.findK(input);
            Assert.AreEqual(1, k, "findK failed");
        }

        [TestMethod]
        public void Check_findDN_ValidDN()
        {
            // Test lower bounds of D and N
            string input_lower = "2 2";
            alienSalesApplication app = new alienSalesApplication();
            int[] dn_lower = app.findDN(input_lower);
            Assert.AreEqual(2, dn_lower[0], "findDN had invalid D");
            Assert.AreEqual(2, dn_lower[1], "findDN had invalid N");

            // Test upper bounds of D and N
            string input_upper = "7 10";
            int[] dn_upper = app.findDN(input_upper);
            Assert.AreEqual(7, dn_upper[0], "findDN had invalid D");
            Assert.AreEqual(10, dn_upper[1], "findDN had invalid N");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Check_findDN_InvalidDN()
        {
            alienSalesApplication app = new alienSalesApplication();

            string input_lower = "8 11";
            int[] dn_lower = app.findDN(input_lower);

            string input_upper = "8 11";
            int[] dn_upper = app.findDN(input_upper);
        }

        [TestMethod]
        public void Check_findDenoms_ValidDenoms()
        {
            string input = "2 3";
            int D = 3;
            alienSalesApplication app = new alienSalesApplication();
            int[] denoms = app.findDenoms(input, D);
            Assert.AreEqual(2, denoms[0], "findDenom gave invalid value");
            Assert.AreEqual(3, denoms[1], "findDenom gave invalid value");
            Assert.AreEqual(D-1, denoms.Length, "Denoms array has incorrect length");
        }

        [TestMethod]
        public void Check_findPrice_CalculatePrice()
        {
            string input = "1 1";
            int D = 2;
            int[] denoms = { 2 };
            alienSalesApplication app = new alienSalesApplication();
            int price = app.findPrice(input, D, denoms);
            Assert.AreEqual(3, price, "findPrice calculated incorrect price");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Check_findPrice_IndexOutOfRangeException()
        {
            string input = "1 1";
            int D = 3;
            int[] denoms = { 2 };
            alienSalesApplication app = new alienSalesApplication();
            int price = app.findPrice(input, D, denoms);
        }
    }
}
