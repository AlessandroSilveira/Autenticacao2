using System.Data.Entity;
using Application2.Domain.Entities;
using Application2.Domain.Interfaces.Service;
using Autenticacao2.Infra.Data.Context;
using Autenticacao2.Infra.Data.Repository;
using Moq;
using NUnit.Framework;

namespace Application2.Infra.Test.Infra.Data.Test
{
    //[TestFixture]
    //public class AbstractFixtureBase
    //{
    
    //}

    //[TestFixture(typeof(Usuario))]
    //public class DerivedFixture<T> : AbstractFixtureBase
    //{
    //    private MockRepository _repository;
    //    private AutenticacaoContext Db;
    //    private DbSet<Usuario> DbSet;
    //    private readonly Repository<Usuario> _repositoryMock;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        _repository = new MockRepository(MockBehavior.Strict);
           
    //    }

    //    [Test]
    //    public void DisposeTest()
    //    {
    //        _repositoryMock.Dispose();
    //        _repository.VerifyAll();
    //    }
    //}
}
