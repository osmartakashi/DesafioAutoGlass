using Models;
using Models.Dtos.ProdutoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutoGestor
    {
        public IEnumerable<Produto> Listar(int pagina, int itensPorPagina = 5);

        public IEnumerable<Produto> Filtrar(SelectProdutoDto produto);

        public Produto ObterPorCodigo(int codigo);

        public int Inserir(CreateProdutoDto produto);

        public int Editar(UpdateProdutoDto produto);

        public bool Excluir(UpdateProdutoDto produto);

    }
}
