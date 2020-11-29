using System;
using System.ComponentModel.DataAnnotations;

namespace ApiModeloDDD.Domain.Entitys
{
    public class Produto
    {
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime dataImportacao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime dataEntrega { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int quantidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal valorUnitario { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal valorTotal { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public bool ativo { get; set; }
    }
}