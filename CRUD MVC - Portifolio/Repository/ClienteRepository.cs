using CRUD_MVC___Portifolio.Data;
using CRUD_MVC___Portifolio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

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

        public List<ClienteModel> BuscarClientes(string userId)
        {
            return _bancoContext.Clientes.Where(u => u.UsuarioId == userId).ToList();
        }

        public ClienteModel BuscarCliente(int id,string userId)
        {
            return _bancoContext.Clientes.FirstOrDefault(c => c.Id == id && c.UsuarioId == userId);
        }

        public ClienteModel SalvarEdicao(ClienteModel cliente)
        {
            ClienteModel clienteDB = BuscarCliente(cliente.Id,cliente.UsuarioId);
            if (clienteDB == null) throw new System.Exception("Houve um erro ao editar o cliente!");

            clienteDB.Nome = cliente.Nome;
            clienteDB.Telefone = cliente.Telefone;
            clienteDB.Endereco = cliente.Endereco;
            clienteDB.Email = cliente.Email;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();
            return clienteDB;
        }

        public bool ConfirmarExclusao(ClienteModel cliente)
        {
            if (cliente == null) throw new System.Exception("Registro não encontrado");
            
            _bancoContext.Clientes.Remove(cliente);
            _bancoContext.SaveChanges();

            return true;
           
        }
    }
}
