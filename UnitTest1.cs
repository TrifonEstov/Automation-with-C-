namespace FirstTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int sum = 5 + 10;
            Assert.AreEqual(15, sum);
        }
    }
}