
using CRUD_MVC___Portifolio.Models;
using CRUD_MVC___Portifolio.Repository;
using CRUD_MVC___Portifolio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace CRUD_MVC___Portifolio.Controllers
{
    
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private static string _userId;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            
            
        }
        public IActionResult Index()
        {
            var cookie = Request.Cookies["Nextech"];
            var cookieData = TokenService.DecodeToken(cookie);

            _userId = cookieData?.FindFirstValue(ClaimTypes.Name);

            if (_userId == null) return RedirectToAction("Index", "Login");

            var clientes = _clienteRepository.BuscarClientes(_userId);
            return View(clientes);


        }
        
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            if (_userId == null) return RedirectToAction("Index", "Login");

            ClienteModel cliente = _clienteRepository.BuscarCliente(id, _userId);
            return View(cliente);
        }
        public IActionResult Apagar(ClienteModel cliente)
        {
            if (_userId == null) return RedirectToAction("Index", "Login");
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id, string userId)
        {
            if (_userId == null) return RedirectToAction("Index", "Login");
            var cliente = _clienteRepository.BuscarCliente(id, _userId);
            return View(cliente);
        }
        public IActionResult ConfirmarExclusao(int id)
        {
            if (_userId == null) return RedirectToAction("Index", "Login");
            
            ClienteModel cliente = _clienteRepository.BuscarCliente(id, _userId);
            _clienteRepository.ConfirmarExclusao(cliente);
            return RedirectToAction("Index");
        }

        

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            if (_userId == null) return RedirectToAction("Index", "Login");
            cliente.UsuarioId = _userId;
            _clienteRepository.Adicionar(cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SalvarEdicao(ClienteModel cliente)
        {
            if (_userId == null) return RedirectToAction("Index", "Login");

            _clienteRepository.SalvarEdicao(cliente);
            return RedirectToAction("Index");
        }
    }
}
