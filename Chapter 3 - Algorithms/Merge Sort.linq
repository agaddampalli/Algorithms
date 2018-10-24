<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>


    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 8, 7, 9, 1, 4, 3, 5, 1 };

            MergeSort(a, 0, a.Length - 1);
            a.Dump();
        }

        private static void MergeSort(int[] inputArray, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;

                MergeSort(inputArray, leftIndex, middleIndex);

                MergeSort(inputArray, middleIndex + 1, rightIndex);

//                Console.WriteLine($"LeftIndex: {leftIndex} ; MiddleIndex: {middleIndex}; RightIndex: {rightIndex}");
                Merge(inputArray, leftIndex, middleIndex, rightIndex);
            }
        }

        private static void Merge(int[] inputArray, int leftIndex, int middleIndex, int rightIndex)
        {
            var leftArray = new int[middleIndex - leftIndex + 1];
            var rightArray = new int[rightIndex - middleIndex];

            Array.Copy(inputArray, leftIndex, leftArray, 0, middleIndex - leftIndex + 1);
            Array.Copy(inputArray, middleIndex + 1, rightArray, 0, rightIndex - middleIndex);

            int x = 0;
            int y = 0;
            for (int i = leftIndex; i < rightIndex + 1; i++)
            {
                if (x == rightArray.Length)
                {
                    inputArray[i] = rightArray[y];
                    y++;
                }
                else if (y == leftArray.Length)
                {
                    inputArray[i] = leftArray[x];
                    x++;
                }
                else if (leftArray[x] <= rightArray[y])
                {
                    inputArray[i] = leftArray[x];
                    x++;
                }
                else
                {
                    inputArray[i] = rightArray[y];
                    y++;
                }
            }
        }
    }
