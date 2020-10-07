using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyWash.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            teste teste1 = new teste();

            Assert.AreEqual(4, teste1.soma());
        }
        
    }

    public class teste
    {
        int valor1 = 1;
        int valor2 = 2;

        public int soma()
        {
            return valor1 + valor2;
        }
    }

}
