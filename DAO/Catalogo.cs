using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.DAO
{
    public class Catalogo
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string CodBar { get; set; }
        public string QuantEstoque { get; set; }
        public string Descricao { get; set; }
    }
}
