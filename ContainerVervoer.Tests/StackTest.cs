using NUnit.Framework;

namespace ContainerVervoer.Tests
{
    public class StackTest
    {
        private Stack _stack;
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack();
        }

        [Test]
        public void WeightTest()
        {
            _stack.Add(new Container(5000, ContainerType.Normal));
            _stack.Add(new Container(3000, ContainerType.Cooled));
            _stack.Add(new Container(2000, ContainerType.Cooled));
            _stack.Add(new Container(3000, ContainerType.Cooled));
            Assert.AreEqual(13000,_stack.Weight);
        }

        [Test]
        public void TopWeightTest()
        {
            _stack.Add(new Container(5000, ContainerType.Normal));
            _stack.Add(new Container(3000, ContainerType.Cooled));
            _stack.Add(new Container(3000, ContainerType.Cooled));
            Assert.AreEqual(6000,_stack.GetTopWeight());
        }

        [Test]
        public void EmptyTopWeight()
        {
            Assert.AreEqual(0,_stack.GetTopWeight());
        }

        [Test]
        public void ContainsValuableTest()
        {
            _stack.Add(new Container(3000,ContainerType.Valuable));
            Assert.AreEqual(true,_stack.ContainsValuableContainer());
        }

        [Test]
        public void NoValuableTest()
        {
            _stack.Add(new Container(3000,ContainerType.Cooled));
            Assert.AreEqual(false,_stack.ContainsValuableContainer());
        }

        [Test]
        public void AddContainerWithValuableInside()
        {
            _stack.Add(new Container(3000,ContainerType.Valuable));
            _stack.Add(new Container(2000, ContainerType.Normal));
            Assert.AreEqual(3000,_stack.GetTopWeight());
        }
    }
}