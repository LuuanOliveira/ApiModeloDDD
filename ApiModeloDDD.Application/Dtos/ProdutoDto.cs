using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModeloDDD.Application.Dtos
{
    public class ProdutoDto
    {
        public Guid id { get; set; }

        public string descricao { get; set; }

        public DateTime? dataImportacao { get; set; }

        public DateTime dataEntrega { get; set; }

        public int quantidade { get; set; }

        public decimal valorUnitario { get; set; }

        public decimal? valorTotal { get; set; }

        public bool ativo { get; set; }
    }
}