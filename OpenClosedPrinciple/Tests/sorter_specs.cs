using NUnit.Framework;

namespace OpenClosedPrinciple.Tests
{
    public class sorter_specs
    {
        readonly int[] data = new[] {9, 5, 3, 2, -99, 7, 6, 5, 1, 4};

        [Test]
        public void when_using_bubble_sort()
        {
            var result = new Sorter().Sort(data, SortAlgorithms.BubbleSort);
            Assert.That(result, Is.EquivalentTo(new[]{-99, 1,2,3,4,5,5,6,7,9}));
        }

        [Test]
        public void when_using_quick_sort()
        {
            var result = new Sorter().Sort(data);
            Assert.That(result, Is.EquivalentTo(new[]{ -99, 1, 2,3,4,5,5,6,7,9}));
        }

        [Test]
        public void when_using_heap_sort()
        {
            var result = new Sorter().Sort(data, SortAlgorithms.HeapSort);
            Assert.That(result, Is.EquivalentTo(new[]{ -99, 1, 2,3,4,5,5,6,7,9}));
        }
    }
}