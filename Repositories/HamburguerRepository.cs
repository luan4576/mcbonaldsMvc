using System.Collections.Generic;
using System.IO;
using mcbonaldsMvc.Models;

namespace mcbonaldsMvc.Repositories
{
    public class HamburguerRepository
    {
        private const string PATH = "Database/Hamburguer.csv";
        public HamburguerRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }


        public List<Hamburguer> ObterTodos()
        {
            List<Hamburguer> hamburguers = new List<Hamburguer>();
            string [] linhas = File.ReadAllLines(PATH);
            foreach(var linha in linhas)
            {
                Hamburguer h = new Hamburguer();
                string [] dados = linha.Split(";");
                h.Nome = dados[0];
                h.Preco = double.Parse(dados[1]);
                hamburguers.Add(h);

            }

            return hamburguers;
        }
    }
}