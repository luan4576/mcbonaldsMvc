using System;
using System.IO;
using mcbonaldsMvc.Models;

namespace mcbonaldsMvc.Repositories
{
    public class ClienteRepository : RepositoryBase
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

            public Cliente ObterPor(string email)
            {
                var linhas = File.ReadAllLines(PATH);
                foreach(var linha in linhas)
                {
                    if(ExtrairValorDoCampo("email", linha).Equals(email))
                    {
                        Cliente c = new Cliente ();
                        c.Nome = ExtrairValorDoCampo("nome",linha);
                        c.Email = ExtrairValorDoCampo("email", linha);
                        c.Senha = ExtrairValorDoCampo("senha", linha);
                        c.Endereco = ExtrairValorDoCampo("endereco", linha);
                        c.Telefone = ExtrairValorDoCampo("telefone",linha);
                        c.DataNascimento = DateTime.Parse(ExtrairValorDoCampo("data_nascimento",linha));
                        c.TipoUsuario =  uint.Parse(ExtrairValorDoCampo("tipo_usuario",linha));
                        return c;
                    }
                    
                }
                return null;
            }

            private string PrepararRegistroCSV(Cliente cliente)
            {
                return $"tipo_usuario={cliente.TipoUsuario};nome={cliente.Nome};endereco={cliente.Endereco};telefone={cliente.Telefone};senha={cliente.Senha};email={cliente.Email};data_nascimento={cliente.DataNascimento}";
            }

    }
}