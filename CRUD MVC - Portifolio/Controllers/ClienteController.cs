using CRUD_MVC___Portifolio.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC___Portifolio.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILoginRepository _loginRepository;

        public ClienteController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
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
    }
}
