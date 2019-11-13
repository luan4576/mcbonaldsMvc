using System.IO;
using mcbonaldsMvc.Models;

namespace mcbonaldsMvc.Repositories
{
    public class ClienteRepository
    {
        private const string PATH = "Database/cliente.csv";
        public ClienteRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }

        }
            public bool Inserir (Cliente cliente)
            {
                var linha = new string[] {PrepararRegistroCSV(cliente)};
                File.AppendAllLines (PATH,linha);
                return true;
            
            }
            private string PrepararRegistroCSV(Cliente cliente)
            {
                return $"nome={cliente.Nome};endereço={cliente.Endereco};telefone={cliente.Telefone};senha={cliente.Senha};email={cliente.Email};data_nascimento={cliente.DataNascimento}";
            }
    }
}