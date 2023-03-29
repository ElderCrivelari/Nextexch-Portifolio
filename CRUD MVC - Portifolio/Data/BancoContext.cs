using CRUD_MVC___Portifolio.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC___Portifolio.Data
{
    public class BancoContext : DbContext //Esta é a Herança do DBContext do Entity Framework
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<LoginModel> Logins { get; set; } //"mostra" qual o Modelo de tabela para o banco de dados.

        public DbSet<ClienteModel> Clientes{ get; set; } //"mostra" qual o Modelo de tabela para o banco de dados.



    }
}


//código do console NuGet para criar o migration :
//Add-Migration <NomeDaMigration> -Context BancoContext
//Após, o VStudio criará a migration para ser executa, com o comando:
//Update-Database -Context BancoContext