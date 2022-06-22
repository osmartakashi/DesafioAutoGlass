using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Fornecedor
    {
        [Key]
        [Required]
        public int CodigoFornecedor { get; set; }

        [Required(ErrorMessage ="O campo descrição é obrigatório")]
        [MaxLength(1024)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(20)]     
        public string Cnpj { get; set; }
     
    }
}
