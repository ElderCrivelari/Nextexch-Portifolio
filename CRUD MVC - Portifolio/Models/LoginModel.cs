namespace CRUD_MVC___Portifolio.Models
{
    public class LoginModel
    {
        public int Id { get; set; } 
        public string Login { get; set; }
        public string Senha { get; set; }
        public byte[] SenhaC { get; set; }
        public byte[] Ckey { get; set; }
        public byte[] Dkey { get; set; }

    }
}
