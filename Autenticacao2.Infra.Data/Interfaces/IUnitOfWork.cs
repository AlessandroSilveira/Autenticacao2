namespace Autenticacao2.Infra.Data.Interfaces
{
	public interface IUnitOfWork
	{
		void BeginTransaction();
		void Commit();
	}
}