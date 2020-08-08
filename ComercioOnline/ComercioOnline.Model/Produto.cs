using dn32.infraestrutura.Generico;
using System;

namespace ComercioOnline.Model
{
    public class Produto : ModelGenericoComNome
    {
        public decimal Valor { get; set; }
        public string CodigoDeBarras { get; set; }
    }
}
