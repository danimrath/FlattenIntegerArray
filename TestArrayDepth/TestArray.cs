using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayFlattenNS;
using System.Collections;

namespace TestArrayDepth
{
    [TestClass]
    public class TestArray
    {
        [TestMethod]
        public void TestNestedArrayDepth()
        {
            ArrayFlatten flattener = new ArrayFlatten();
            int[] flatArray1;
            int[] arr = { 1, 2, 3 };
            int[] arr2 = { 4, 5, 6 };
            int[] arr3 = { 7, 8, 9 };
            int[] arr4 = { 10, 11, 12 };
            Object[] arr5 = { arr, arr2 }; 
            Object[] arr6 = { arr3, arr4 }; 
            Object[] arr7 = { 1,arr5, arr6, arr4, arr };

            ArrayList list1 = new ArrayList();
            list1.Add(arr7);
            list1.Add(new ArrayList(arr2));
            flatArray1 = flattener.FlattenArray(list1);

            Assert.IsTrue(flatArray1.Length == 22);
        }
        [TestMethod]
        public void TestMultiDimensionalArray()
        {
            ArrayFlatten flattener = new ArrayFlatten();
            int[] flatArray1;
            int[][] arr = new int[3][];
                
            arr[0] = new int[] { 1, 2, 3 };
            arr[1] = new int[] { 4, 5, 6 };
            arr[2] = new int[] { 7, 8, 9 };

            flatArray1 = flattener.FlattenArray(arr);

            Assert.IsTrue(flatArray1.Length == 9);
        }
        [TestMethod]
        public void TestFlatArrayDepth()
        {
            ArrayFlatten flattener = new ArrayFlatten();
            int[] flatArray;
            int[] arr = { 1, -2, 3 };

            flatArray = flattener.FlattenArray(new ArrayList(arr));

            Assert.IsTrue(flatArray.Length == arr.Length);
            CollectionAssert.AreEqual(flatArray,arr);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestArrayMemberException()
        {
            ArrayFlatten flattener = new ArrayFlatten();
            int[] flatArray;
            int[] arr = { 1, 2, 3 };
            ArrayList list = new ArrayList();
            list.Add(arr);
            list.Add("M");

            flatArray = flattener.FlattenArray(list);
        }
    }
}
