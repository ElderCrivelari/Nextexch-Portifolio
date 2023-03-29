using CRUD_MVC___Portifolio.Data;
using CRUD_MVC___Portifolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_MVC___Portifolio.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly BancoContext _bancoContext;

        //Injetar o banco de dados context dentro do repositorio
        public LoginRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public LoginModel Adicionar(LoginModel login)
        {
            login.DataCadastro = DateTime.Now.Date.ToString();
            _bancoContext.Logins.Add(login);
            _bancoContext.SaveChanges();
            return login;
        }

        public LoginModel BuscarLogins(int id)
        {

            var userLogin = _bancoContext.Logins.Find(id);

            return userLogin;
        }

       
    }
}
