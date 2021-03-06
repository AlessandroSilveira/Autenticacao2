﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Application2.Domain.Interfaces.Repository;
using Autenticacao2.Infra.Data.Context;

namespace Autenticacao2.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AutenticacaoContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(AutenticacaoContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj);
            SaveChanges();
            return objReturn;
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public TEntity Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            SaveChanges();
            return obj;
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return DbSet.FirstOrDefault(expr);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}