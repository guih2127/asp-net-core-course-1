using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();

            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);

            produtoRepository.SaveProdutos(livros);
        }
    }
}
