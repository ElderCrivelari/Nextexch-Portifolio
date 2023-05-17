using CRUD_MVC___Portifolio.Models;
using CRUD_MVC___Portifolio.Repository;
using CRUD_MVC___Portifolio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using System.Web;


namespace CRUD_MVC___Portifolio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;



        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public IActionResult Index(string msgErro, string msgSucesso)
        {
            if (!string.IsNullOrEmpty(msgErro)) ViewBag.msgErro = msgErro;
            if (!string.IsNullOrEmpty(msgSucesso)) ViewBag.msgSucesso = msgSucesso;
            return View();
        }

        public IActionResult Acessar()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Logout()
        {
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(LoginModel usuario)
        {
            var usuarioCriado = _loginRepository.Adicionar(usuario);
            if (usuarioCriado != null)
            {
                ViewBag.msgSucesso = "Usuário cadastrado com sucesso, faça o login!";
                return RedirectToAction("Index", new { ViewBag.msgSucesso });
            }

            ViewBag.msgErro = "Não foi possível criar o usuário, favor entrar em contato com o suporte";
            return RedirectToAction("Index", new { ViewBag.msgErro });

        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Acessar(LoginModel usuario)
        {
            //Procura o usuario no banco
            var usuarioLogado = _loginRepository.Buscar(usuario.Login, usuario.Senha);
            if (usuarioLogado != null)
            {
                //Gera o token
               
                var token = TokenService.Gerartoken(usuarioLogado);
                //cria um cookie com os dados
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddHours(2),
                    SameSite = SameSiteMode.Lax
                };
                Response.Cookies.Append("Nextech", token, cookieOptions); //adiciona o cookie com o token
                return RedirectToAction("Index", "Cliente");

            }
            ViewBag.LoginError = "Usuário não cadastrado, tente novamente!";
            return RedirectToAction("Index", new { msgErro = ViewBag.LoginError });
        }
    }
}
