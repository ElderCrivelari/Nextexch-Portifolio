using CRUD_MVC___Portifolio.Models;
using System.Collections.Generic;

namespace CRUD_MVC___Portifolio.Repository
{
    public interface IClienteRepository
    {

        ClienteModel Adicionar(ClienteModel cliente);
        List<ClienteModel> BuscarClientes(string userId);
        ClienteModel BuscarCliente(int id,string userId);
        ClienteModel SalvarEdicao(ClienteModel cliente);

        bool ConfirmarExclusao(ClienteModel cliente);
    }
}