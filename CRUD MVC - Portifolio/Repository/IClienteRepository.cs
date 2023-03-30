using CRUD_MVC___Portifolio.Models;
using System.Collections.Generic;

namespace CRUD_MVC___Portifolio.Repository
{
    public interface IClienteRepository
    {

        ClienteModel Adicionar(ClienteModel cliente);

        List<ClienteModel> BuscarClientes();
        ClienteModel BuscarCliente(int id);

        ClienteModel SalvarEdicao(ClienteModel cliente);

        bool Apagar(int id);
    }
}