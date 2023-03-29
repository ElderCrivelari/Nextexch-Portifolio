using CRUD_MVC___Portifolio.Data;
using CRUD_MVC___Portifolio.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_MVC___Portifolio.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }

        public List<ClienteModel> BuscarClientes()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel BuscarCliente(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public ClienteModel SalvarEdicao(ClienteModel cliente)
        {
            ClienteModel clienteDB = BuscarCliente(cliente.Id);
            if (clienteDB != null) throw new System.Exception("Houve um erro ao editar o cliente!");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Telefone = cliente.Telefone;
            clienteDB.Endereco = cliente.Endereco;
            clienteDB.Email = cliente.Email;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();
            return clienteDB;
        }
    }
}
