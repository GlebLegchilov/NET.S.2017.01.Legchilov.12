using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

namespace Task1Test
{
    [TestFixture]
    public class QueueTest
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        public int? Queue_PositivTestSize(int[] array)
        {
            Task1.Queue<int> queue = new Task1.Queue<int>(array);
            return queue.Count;
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 13 }, ExpectedResult = 13)]
        public int? Queue_PositivTestLast(int[] array)
        {
            Task1.Queue<int> queue = new Task1.Queue<int>(array);
            return queue.Dequeue();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 15)]
        public int? Queue_PositivTestForeach(int[] array)
        {
            int result = 0;
            Task1.Queue<int> queue = new Task1.Queue<int>(array);
            foreach (var item in queue)
                result += item;
            return result;
        }

    }
}
