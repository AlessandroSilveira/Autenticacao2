using Application2.Domain.Interfaces.Service;
using Autenticacao2.Infra.Security;
using Moq;
using NUnit.Framework;

namespace Application2.Infra.Test
{
    [TestFixture]
    public class CriptografiaTest
    {
        private MockRepository _repository;
        private Mock<ICriptografia> _criptografiaMock;
        private Criptografia _criptografia;

        [SetUp]
        public void Setup()
        {
            _repository = new MockRepository(MockBehavior.Strict);
            _criptografiaMock = _repository.Create<ICriptografia>();
            _criptografia = new Criptografia();
        }

        [Test]
        public void HashTest()
        {
            var senha = "123";

            _criptografia.Hash(senha);

            _repository.VerifyAll();
        }
    }
}
