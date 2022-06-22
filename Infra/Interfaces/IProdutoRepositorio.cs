using Models;
using Models.Dtos.ProdutoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IProdutoRepositorio
    {
        public Produto ObterPorCodigo(int codigo);

        public IEnumerable<Produto> Listar(int pagina, int itensPorPagina = 10);

        public IEnumerable<Produto> Filtrar(SelectProdutoDto produto, int pagina, int itensPorPagina = 5);

        public int Inserir(Produto produto);

        public int Editar(Produto produto);

        public bool Excluir(Produto produto);
    }
}
