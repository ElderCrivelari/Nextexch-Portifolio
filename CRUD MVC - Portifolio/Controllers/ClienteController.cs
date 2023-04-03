
using CRUD_MVC___Portifolio.Models;
using CRUD_MVC___Portifolio.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUD_MVC___Portifolio.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
           _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            var clientes = _clienteRepository.BuscarClientes();
            return View(clientes);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepository.BuscarCliente(id);
            return View(cliente);
        }
        public IActionResult Apagar(ClienteModel cliente)
        {
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var cliente = _clienteRepository.BuscarCliente(id);
            return View(cliente);
        }
        public IActionResult ConfirmarExclusao(int id)
        {
            ClienteModel cliente = _clienteRepository.BuscarCliente(id);
            _clienteRepository.ConfirmarExclusao(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            _clienteRepository.Adicionar(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SalvarEdicao(ClienteModel cliente)
        {
            _clienteRepository.SalvarEdicao(cliente);
            return RedirectToAction("Index");
        }
    }
}
