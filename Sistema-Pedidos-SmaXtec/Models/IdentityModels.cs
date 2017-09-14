using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sistema_Pedidos_SmaXtec.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }

        public string NomeUsuario { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Sistema_Pedidos_SmaXtec.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<Sistema_Pedidos_SmaXtec.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<Sistema_Pedidos_SmaXtec.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<Sistema_Pedidos_SmaXtec.Models.OrderDetail> OrderDetails { get; set; }
    }
}