using CRUD_MVC___Portifolio.Models;
using CRUD_MVC___Portifolio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC___Portifolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository) 
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar() //login/index ---- METODO GET/SOMENTE BUSCA
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }

        public IActionResult Logar() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(LoginModel login)
        {
            _loginRepository.Adicionar(login);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(LoginModel login)
        {

            return View();
        }
    }
}
