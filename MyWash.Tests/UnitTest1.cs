using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWash.Model.Entity;

namespace MyWash.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testarQuandoSenhaForVazia()
        {
            User user = new User("Marcos", "narsd@gmai.com", "123");

            Assert.AreEqual("Senha não pode ser vazia", user.defineNewPassword(""));
        }

        [TestMethod]
        public void testarQuandoSenhaForValida()
        {
            User user = new User("Marcos", "narsd@gmai.com", "123");

            Assert.AreEqual("Sucesso", user.defineNewPassword("1234"));
        }
    }
}
