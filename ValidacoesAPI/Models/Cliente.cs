using System.ComponentModel.DataAnnotations;
using ValidacoesAPI.Validations;

namespace ValidacoesAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [CustomValidationPrimeiraLetraMaiuscula]
        [StringLength(50, ErrorMessage = "O Nome deve ter entre 05 e 50 caracteres !", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        //[EmailAddress(ErrorMessage = "Deve ser um e-mail válido !")]
        [CustomValidationEmail(ErrorMessage = "O E-Mail está em um formato incorreto.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(30, ErrorMessage = "O Nome deve ter entre 05 e 30 caracteres.", MinimumLength = 5)]
        public string Cartao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [CustomValidationNumeroCartao]
        public string NumeroCartao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [CustomValidationCVVCartao]
        public string CVV { get; set; }
    }
}
