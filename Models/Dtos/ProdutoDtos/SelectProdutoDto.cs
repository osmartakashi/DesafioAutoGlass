using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dtos.ProdutoDtos
{
    public class SelectProdutoDto
    {
        public int? CodigoProduto { get; set; }
        public string? Descricao { get; set; }
        public string? Situacao { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int Pagina { get; set; }
        public int ItensPorPagina { get; set; }

    }
}
