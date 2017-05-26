using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ArrayFlattenNS
{
    //ArrayFlatten allows you to pass multi-
    public class ArrayFlatten
    {
        public int[] FlattenArray (ArrayList anyDepthArray)
        {
            int[] flatArray;

            flatArray = FlattenList(anyDepthArray);

            return flatArray;
        }

        public int[] FlattenArray (Object[] anyDepthArray)
        {
            int[] flatArray;

            flatArray = FlattenList(new ArrayList (anyDepthArray));

            return flatArray;
        }

        //Recursively loop through an ArrayList to create a single dimension Integer array
        private int[] FlattenList (ArrayList jaggedArray)
        {
            List<int> returnList = new List<int>();
 
            foreach (Object member in jaggedArray)
            {
                //if the object is a single integer just add it
                if (member.GetType().Equals(typeof(int)))
                {
                    returnList.Add((int)member);
                }
                //if the object is an integer array just add it
                else if (member.GetType().Equals(typeof(int[])))
                {
                    returnList.AddRange((int[])member);
                }
                //if the object is an array of objects recursively call FlattenList on it
                else if (member.GetType().Equals(typeof(Object[])))
                {
                    returnList.AddRange(FlattenList(new ArrayList((Object[])member)));
                }
                //if the object is an ArrayList recursively call FlattenList on it
                else if (member.GetType().Equals(typeof(ArrayList)))
                {
                    returnList.AddRange(FlattenList((ArrayList)member));
                }
                //if the object is not an integer or an array throw an exception
                else
                {
                    throw new System.ArgumentException("Invalid array member " + member, " is not an Integer or an array.");
                }

            }
            return returnList.ToArray();
        }
    }
}
