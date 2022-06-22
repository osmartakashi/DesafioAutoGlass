using Infra.Data;
using Infra.Implentations;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfraTestes
{
    public class ProdutoRepositorioTestes
    {
        private DbContextOptions<DataContext> dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "autoglass")
            .Options;

        private IProdutoRepositorio _repositorio;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDatabase();
            _repositorio = new ProdutoRepositorio(new DataContext(dbContextOptions));
        }

       

        [TestCase(1,2)]
        [TestCase(2, 2)]
        public void MetodoListarDeveListarTodosOsProdutosPaginado(int pagina, int itensPorPagina)
        {           
            var produtos = _repositorio.Listar(pagina, itensPorPagina);
            Assert.IsTrue(produtos.Count() == 2);       
        }

        [TestCase("Parabrisa",1,3)]
        [TestCase("Espelho", 1, 3)]
        public void MetodoFiltrarDeveFiltrarPorParametrosDistintos(string filtro, int pagina, int itensPorPagina)
        {
            var produtos = _repositorio.Filtrar(new Models.Dtos.ProdutoDtos.SelectProdutoDto
            {
                Descricao = filtro
            }, pagina, itensPorPagina);
            Assert.IsTrue(produtos.Any());
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void MetodoObterPorCodigoDeveRetornarUmProduto(int codigo)
        {
            var produto = _repositorio.ObterPorCodigo(codigo);
            Assert.IsNotNull(produto);
        }


        private void SeedDatabase()
        {
            var context = new DataContext(dbContextOptions);
            context.Fornecedor.Add(new Fornecedor
            {
                Descricao = "AutoGlass",
                CodigoFornecedor = 1,
                Cnpj = "08.223.587/0001-00"
            });

            var listaProdutos = new List<Produto>
            {
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 1,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Parabrisa dianteiro Ford Ranger",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 2,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Parabrisa dianteiro Ford Focus",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 3,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Parabrisa dianteiro Vw Gol",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 4,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Espelho Retrovisor LD ford Ranger",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 5,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Espelho Retrovisor LD Vw Gol",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 6,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Parachoque dianteiro ford escort",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 7,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Parabrisa dianteiro Chevrolet Onix",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 8,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Farol de Neblina Fiat Toro",
                    Situacao = "Ativo"
                },
                new Produto
                {
                    CodigoFornecedor = 1,
                    CodigoProduto = 9,
                    DataFabricacao = DateTime.Now.AddYears(-1),
                    DataValidade = DateTime.Now.AddYears(1),
                    Descricao = "Parabrisa dianteiro Ford Ranger",
                    Situacao = "Ativo"
                },
            };
            context.AddRange(listaProdutos);

            context.SaveChanges();
        }
    }
}