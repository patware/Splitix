using Splitix.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Splitix.TestProject
{
    
    
    /// <summary>
    ///This is a test class for InputParserTest and is intended
    ///to contain all InputParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InputParserTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for parseIntoItemsPerColumn
        ///</summary>
        [TestMethod()]
        public void parse_Empty_No_Input()
        {
            InputParser target = new InputParser();
            string input = string.Empty;
            int numberOfItems = 0;
            string expected = "Enter something";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Columns, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void parse_1_Item_1_Column_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A";
            int numberOfItems = 1;
            string expected = "A";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Columns, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void parse_1_Item_2_Column_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A";
            int numberOfItems = 2;
            string expected = "A";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Columns, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void parse_2_Items_1_Column_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A\r\nB";
            int numberOfItems = 1;
            string expected = "A\r\nB";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Columns, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void parse_5_Items_2_Column_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A\r\nB\r\nC\r\nD\r\nE";
            int numberOfItems = 2;
            string expected = "A\tD\r\nB\tE\r\nC";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Columns, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void parse_5_Items_2_Column_RowFirst()
        {
            InputParser target = new InputParser();
            string input = "A\r\nB\r\nC\r\nD\r\nE";
            int numberOfItems = 2;
            string expected = "A\tB\r\nC\tD\r\nE";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Columns, Orientation.RowFirst);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for parseIntoColumns
        ///</summary>
        [TestMethod()]
        public void parse_Empty_Item_0_Row_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = string.Empty;
            int numberOfItems = 0;
            string expected = "Enter something";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Rows, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void parse_1_Item_1_Row_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A";
            int numberOfItems = 1;
            string expected = "A";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Rows, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void parse_2_Item_1_Row_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A\r\nB";
            int numberOfItems = 1;
            string expected = "A\tB";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Rows, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void parse_3_Item_1_Row_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A\r\nB\r\nC";
            int numberOfItems = 1;
            string expected = "A\tB\tC";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Rows, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void parse_3_Item_2_Row_ColumnFirst()
        {
            InputParser target = new InputParser();
            string input = "A\r\nB\r\nC";
            int numberOfItems = 2;
            string expected = "A\tC\r\nB";
            string actual;
            actual = target.Parse(input, numberOfItems, Axis.Rows, Orientation.ColumnFirst);
            Assert.AreEqual(expected, actual);
        }

    }
}
