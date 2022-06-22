using Infra.Data;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos.ProdutoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Implentations
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private DataContext _context;
        public ProdutoRepositorio(DataContext context)
        {
            _context = context;
        }
        public int Editar(Produto produto)
        {
            _context.Update(produto);
            return _context.SaveChanges();
        }

        public bool Excluir(Produto produto)
        {            
            return Editar(produto) > 0;
        }

        public IEnumerable<Produto> Filtrar(SelectProdutoDto produto, int pagina, int itensPorPagina = 5)
        {           

            var result = from prod in _context.Produtos.Include(p => p.Fornecedor)
                         where (produto.CodigoProduto == null || prod.CodigoProduto == produto.CodigoProduto)
                         && (produto.DataFabricacao == null || prod.DataFabricacao == produto.DataFabricacao)
                         && (produto.DataValidade == null || prod.DataValidade == produto.DataValidade)
                         && (produto.Descricao == null || EF.Functions.Like(prod.Descricao, $"%{produto.Descricao}%"))
                         && (produto.Situacao == null || prod.Situacao == produto.Situacao)
                         select prod;
            return result.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina).ToList();                         

        }

        public int Inserir(Produto produto)
        {
            _context.Add(produto);
            return _context.SaveChanges();
        }
       

        public IEnumerable<Produto> Listar(int pagina, int itensPorPagina = 5)
        {
            //return _context.Produtos.Include(p => p.Fornecedor).OrderBy(p => p.CodigoProduto)
            //    .Where(p => p.Situacao == "Ativo" && (p.CodigoProduto > pagina - 1 * itensPorPagina)).Take(itensPorPagina).ToList();
            return _context.Produtos.Include(p => p.Fornecedor).OrderBy(p => p.CodigoProduto)
                   .Where(p => p.Situacao == "Ativo" && (p.CodigoProduto > (pagina - 1) * itensPorPagina))
                   .Take(itensPorPagina).ToList();
        }

        public Produto ObterPorCodigo(int codigo)
        {
            return _context.Produtos.FirstOrDefault(p => p.CodigoProduto == codigo);
        }
    }
}
