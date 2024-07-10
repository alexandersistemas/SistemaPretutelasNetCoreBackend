using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class SubCategoriaDTO
    {
        public int IdSubCategoria { get; set; }
        public int IdCategoria { get; set; }
        public string NombreSubCategoria { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
