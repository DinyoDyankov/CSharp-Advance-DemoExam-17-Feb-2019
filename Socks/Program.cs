namespace Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] leftSocksInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rightSocksInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> leftSocks = new Stack<int>();
            Queue<int> rightSocks = new Queue<int>();

            List<int> allPairsOfSocks = new List<int>();

            for (int i = 0; i < leftSocksInput.Length; i++)
            {
                leftSocks.Push(leftSocksInput[i]);
            }

            for (int i = 0; i < rightSocksInput.Length; i++)
            {
                rightSocks.Enqueue(rightSocksInput[i]);
            }

            while (leftSocks.Count != 0 && rightSocks.Count != 0)
            {
                if (leftSocks.Peek() > rightSocks.Peek())
                {
                    int pairSum = leftSocks.Pop() + rightSocks.Dequeue();

                    allPairsOfSocks.Add(pairSum);
                }
                else if (leftSocks.Peek() == rightSocks.Peek())
                {
                    rightSocks.Dequeue();

                    int currentLeftSockValue = leftSocks.Pop() + 1;

                    leftSocks.Push(currentLeftSockValue);
                }
                else if (leftSocks.Peek() < rightSocks.Peek())
                {
                    leftSocks.Pop();
                }
            }

            int biggestPair = -1;

            foreach (var pair in allPairsOfSocks)
            {
                if (biggestPair < pair)
                {
                    biggestPair = pair;
                }
            }

            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(' ', allPairsOfSocks));
        }
    }
}
