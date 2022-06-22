using Application.Interfaces;
using AutoMapper;
using Infra.Interfaces;
using Models;
using Models.Dtos.ProdutoDtos;
using System;
using System.Collections.Generic;

namespace Application
{
    public class ProdutoGestor : IProdutoGestor
    {
        private IProdutoRepositorio _produtoRepositorio;
        private IMapper _mapper;
        public ProdutoGestor(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }
        public int Editar(UpdateProdutoDto produto)
        {
            Produto prod = _mapper.Map<Produto>(produto);
            return _produtoRepositorio.Editar(prod);
        }

        public bool Excluir(UpdateProdutoDto produto)
        {
            Produto prod = _mapper.Map<Produto>(produto);
            prod.Situacao = "Inativo";
            return _produtoRepositorio.Excluir(prod);
        }

        public IEnumerable<Produto> Filtrar(SelectProdutoDto produto)
        {
            return _produtoRepositorio.Filtrar(produto, produto.Pagina, produto.ItensPorPagina);
        }

        public int Inserir(CreateProdutoDto produto)
        {
            Produto prod = _mapper.Map<Produto>(produto);
            return _produtoRepositorio.Inserir(prod);
        }    

        public IEnumerable<Produto> Listar(int pagina, int itensPorPagina = 5)
        {
            return _produtoRepositorio.Listar(pagina, itensPorPagina);            
        }

        public Produto ObterPorCodigo(int codigo)
        {
            return _produtoRepositorio.ObterPorCodigo(codigo);
        }
    }
}
