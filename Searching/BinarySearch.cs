using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Searching
{
    class BinarySearch
    {
        public static int Recursve(int[] anArray, int x)
        {
            return SearchRecursive(anArray, x, 0, anArray.Count() - 1);
        }

        private static int SearchRecursive(int[] anArray, int x, int aLeft, int aRigth)
        {
            if (aLeft > aRigth)
                return -1;
            else
            {
                var mid = (aLeft + aRigth) / 2;
                if (anArray[mid] == x)
                    return mid;
                else
                {
                    if (x < anArray[mid])
                        return SearchRecursive(anArray, x, aLeft, mid - 1);
                    else
                        return SearchRecursive(anArray, x, mid + 1, aRigth);
                }
            }
        }

        public static int Iterative(int[] anArray, int x)
        {
            bool found = false;
            int left = 0;
            int right = anArray.Count() - 1;
            int mid = -1;
            while ((left <= right) && !found)
            {
                mid = (left + right) / 2;
                if (anArray[mid] == x)
                    found = true;
                else
                {
                    if (anArray[mid] < x)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return found ? mid : -1;
        }

    }
}
