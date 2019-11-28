using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}
