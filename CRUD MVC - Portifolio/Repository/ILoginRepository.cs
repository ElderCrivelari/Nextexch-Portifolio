using CRUD_MVC___Portifolio.Models;

namespace CRUD_MVC___Portifolio.Repository
{
    public interface ILoginRepository
    {
        LoginModel Adicionar(LoginModel model);
        LoginModel Editar(LoginModel model);
        LoginModel Buscar(string usuario, string senha);

        bool Excluir(LoginModel model);
    }
}