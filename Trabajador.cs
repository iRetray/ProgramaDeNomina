using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaDeFactoracion
{
    public class Trabajador{

        public int cedula { get; set; }
        public String nombre { get; set; }
        public double sueldo { get; set; }
        public int dias { get; set; }
        public int nhed { get; set; }
        public int nhen { get; set; }
        public int nhedd { get; set; }
        public int nhedn { get; set; }
        public int nhrn { get; set; }
        public double transporte { get; set; }
        public double nhedValor { get; set; }
        public double nhenValor { get; set; }
        public double nheddValor { get; set; }
        public double nhednValor { get; set; }
        public double nhrnValor { get; set; }
        public double extras { get; set; }
        public double devengado { get; set; }
        public double salud { get; set; }
        public double pension { get; set; }
        public double solidiario { get; set; }
        public double uvt { get; set; }
        public double retefuente { get; set; }
        public double deducido { get; set; }
        public double neto { get; set; }

        public Trabajador(int cedula, string nombre, double sueldo, int dias, int nhed, int nhen, int nhedd, int nhedn, int nhrn, double transporte, double nhedValor, double nhenValor, double nheddValor, double nhednValor, double nhrnValor, double extras, double devengado, double salud, double pension, double solidiario, double uvt, double retefuente, double deducido, double neto)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.dias = dias;
            this.nhed = nhed;
            this.nhen = nhen;
            this.nhedd = nhedd;
            this.nhedn = nhedn;
            this.nhrn = nhrn;
            this.transporte = transporte;
            this.nhedValor = nhedValor;
            this.nhenValor = nhenValor;
            this.nheddValor = nheddValor;
            this.nhednValor = nhednValor;
            this.nhrnValor = nhrnValor;
            this.extras = extras;
            this.devengado = devengado;
            this.salud = salud;
            this.pension = pension;
            this.solidiario = solidiario;
            this.uvt = uvt;
            this.retefuente = retefuente;
            this.deducido = deducido;
            this.neto = neto;
        }

    }
}
