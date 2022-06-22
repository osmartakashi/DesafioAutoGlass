using Models.Dtos.ProdutoDtos;
using System.ComponentModel.DataAnnotations;

namespace Models.CustomAttributes
{
    public class DataFabricacaoValidator : ValidationAttribute
    {

        public string GetErrorMessage() =>
        $"A data de fabricação não pode ser maior ou igual a data de validade";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var tp = validationContext.ObjectInstance;
            if (tp is Produto)
            {
                var produto = (Produto)validationContext.ObjectInstance;

                if (produto.DataFabricacao >= produto.DataValidade)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if(tp is CreateProdutoDto)
            {
                var produto = (CreateProdutoDto)validationContext.ObjectInstance;

                if (produto.DataFabricacao >= produto.DataValidade)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if(tp is UpdateProdutoDto)
            {
                var produto = (UpdateProdutoDto)validationContext.ObjectInstance;

                if (produto.DataFabricacao >= produto.DataValidade)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }
    }
}
