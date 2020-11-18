using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaDeFactoracion
{
    public class Producto{

        public String codigo { get; set; }
        public String descripcion { get; set; }
        public String precio { get; set; }
        public int IVA { get; set; }
        public int cantidad { get; set; }
        public int subtotal { get; set; }
        public int valorIVA { get; set; }
        public int total { get; set; }

        public Producto(String codigo, String descripcion, String precio, int IVA, int cantidad, int subtotal, int valorIVA, int total ){
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.IVA = IVA;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
            this.valorIVA = valorIVA;
            this.total = total;
        }
                
    }
}
