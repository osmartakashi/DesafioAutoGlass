using Models.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int CodigoProduto { get; set; }

        [Required(ErrorMessage ="O campo descrição é obrigatório")]
        [MaxLength(1024)]
        public string Descricao { get; set; }

        [MaxLength(10)]
        public string Situacao { get; set; }

        [Required]
        [DataFabricacaoValidator]
        public DateTime DataFabricacao { get; set; }

        [Required]
        public DateTime DataValidade { get; set; }
        
        public int CodigoFornecedor { get; set; }

        [ForeignKey("CodigoFornecedor")]
        public Fornecedor Fornecedor { get; set; }
    }
}
