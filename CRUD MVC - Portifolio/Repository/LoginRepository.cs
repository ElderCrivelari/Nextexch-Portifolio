using CRUD_MVC___Portifolio.Data;
using CRUD_MVC___Portifolio.Models;
using System;
using System.Linq;
using System.Text;

namespace CRUD_MVC___Portifolio.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly BancoContext _bancoContext;

        public LoginRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public LoginModel Adicionar(LoginModel login)
        {
            //Cria a sequencia de chaves para criptografia

            var chaveBit = CryptoUtils.GerarChaveAleatoria(32);
            var chaveIV = CryptoUtils.GerarIvAleatorio(16);

            var senhaByte = CryptoUtils.Criptografar(login.Senha, chaveBit, chaveIV);
            


            login.Ckey = chaveBit;
            login.Dkey = chaveIV;
            login.Senha = "";
            login.SenhaC = senhaByte;

            _bancoContext.Logins.Add(login);
            _bancoContext.SaveChanges();

            return login;
        }

        public LoginModel Buscar(string usuario, string senha)
        {
            var usuarioLogado = _bancoContext.Logins.FirstOrDefault(c => c.Login == usuario);
            if (usuarioLogado !=null )
            {
                string senhaDescriptografada = CryptoUtils.Descriptografar(usuarioLogado.SenhaC, usuarioLogado.Ckey, usuarioLogado.Dkey);
                if (senha == senhaDescriptografada)
                {
                    return usuarioLogado;
                }
                
            }
            return null;
        }

        public LoginModel Editar(LoginModel model)
        {
            throw new System.NotImplementedException();
        }

        public bool Excluir(LoginModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
