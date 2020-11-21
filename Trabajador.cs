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
        public int sueldo { get; set; }
        public int dias { get; set; }
        public int nhed { get; set; }
        public int nhen { get; set; }
        public int nhedd { get; set; }
        public int nhedn { get; set; }
        public int nhrn { get; set; }
        public int transporte { get; set; }
        public int nhedValor { get; set; }
        public int nhenValor { get; set; }
        public int nheddValor { get; set; }
        public int nhednValor { get; set; }
        public int nhrnValor { get; set; }
        public int extras { get; set; }
        public int devengado { get; set; }
        public int salud { get; set; }
        public int pension { get; set; }
        public int solidiario { get; set; }
        public int uvt { get; set; }
        public int retefuente { get; set; }
        public int deducido { get; set; }
        public int neto { get; set; }

        public Trabajador(int cedula, string nombre, int sueldo, int dias, int nhed, int nhen, int nhedd, int nhedn, int nhrn, int transporte, int nhedValor, int nhenValor, int nheddValor, int nhednValor, int nhrnValor, int extras, int devengado, int salud, int pension, int solidiario, int uvt, int retefuente, int deducido, int neto)
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
