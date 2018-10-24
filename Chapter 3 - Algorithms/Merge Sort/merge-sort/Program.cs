using System;
using System.Collections.Generic;

namespace merge_sort
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };

            Merge(nums1, nums2);

        }
        private static int[] Merge(int[] nums1, int[] nums2)
        {
            var length = nums1.Length + nums2.Length;
            var output = new int[length];

            int i = 0, j = 0;
            for (int k = 0; k < length; k++)
            {
                if (i == nums1.Length-1)
                {
                    output[k] = nums2[j];
                    j++;
                }
                else if (j == nums2.Length-1)
                {   
                    output[k] = nums1[i];
                    j++;
                }
                else if (nums1[i] <= nums2[j])
                {
                    output[k] = nums1[i];
                    i++;
                }
                else
                {
                    output[k] = nums2[j];
                    j++;
                }
            }

            return output;
        }
    }
}
