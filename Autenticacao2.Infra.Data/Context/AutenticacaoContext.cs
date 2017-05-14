using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Application2.Domain.Entities;
using Autenticacao2.Infra.Data.EntityConfig;

namespace Autenticacao2.Infra.Data.Context
{
	
	public class AutenticacaoContext : DbContext
	{
		public AutenticacaoContext()
			: base("AutenticacaoContext")
		{
		}

		public virtual IDbSet<Usuario> Usuario { get; set; }
		public virtual IDbSet<Telefone> Telefone { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
			modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

			
			modelBuilder.Configurations.Add(new UsuarioConfiguration());
			modelBuilder.Configurations.Add(new TelefoneConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	    private void FixEfProviderServicesProblem()
	    {
	        // The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
	        // for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
	        // Make sure the provider assembly is available to the running application. 
	        // See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.
	        var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
	    }
    }
}
