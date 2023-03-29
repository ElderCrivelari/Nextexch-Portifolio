using CRUD_MVC___Portifolio.Models;
using System.Collections.Generic;

namespace CRUD_MVC___Portifolio.Repository
{
    public interface ILoginRepository
    {
        LoginModel BuscarLogins(int id);

        LoginModel Adicionar(LoginModel login);


    }
}
