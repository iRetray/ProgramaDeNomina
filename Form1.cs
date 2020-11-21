using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaDeFactoracion {
    public partial class Form1 : Form {
        Nomina facturador = new Nomina();
        DataTable tablaDatos = new DataTable();

        public Form1() {
            InitializeComponent();
            tablaDatos.Columns.Add("Cédula");
            tablaDatos.Columns.Add("Nombres");
            tablaDatos.Columns.Add("Sueldo");
            tablaDatos.Columns.Add("Días");
            tablaDatos.Columns.Add("NHED");
            tablaDatos.Columns.Add("NHEN");
            tablaDatos.Columns.Add("NHEDD");
            tablaDatos.Columns.Add("NHEDN");
            tablaDatos.Columns.Add("NHRN");
            tablaDatos.Columns.Add("Transporte");
            tablaDatos.Columns.Add("NHED Valor");
            tablaDatos.Columns.Add("NHEN Valor");
            tablaDatos.Columns.Add("NHEDD Valor");
            tablaDatos.Columns.Add("NHEDN Valor");
            tablaDatos.Columns.Add("NHRN Valor");
            tablaDatos.Columns.Add("Valor extras");
            tablaDatos.Columns.Add("Devengado");
            tablaDatos.Columns.Add("Salud");
            tablaDatos.Columns.Add("Pensión");
            tablaDatos.Columns.Add("Aporte solidario");
            tablaDatos.Columns.Add("UVT");
            tablaDatos.Columns.Add("Retefuente");
            tablaDatos.Columns.Add("Deducido");
            tablaDatos.Columns.Add("Neto");
            gridDatos.DataSource = tablaDatos;
            actualizarDatosEnTabla();
        }

        private void buttonAñadir_Click(object sender, EventArgs e) {
            int cedula = Convert.ToInt32(textCedula.Text);
            String nombre = textNombre.Text;
            double sueldo = Convert.ToDouble(textSueldo.Text);
            int dias = Convert.ToInt32(textDias.Text);
            int NHED = Convert.ToInt32(textNHED.Text);
            int NHEN = Convert.ToInt32(textNHEN.Text);
            int NHEDD = Convert.ToInt32(textNHEDD.Text);
            int NHEDN = Convert.ToInt32(textNHEDN.Text);
            int NHRN = Convert.ToInt32(textNHRN.Text);
            Trabajador newT = new Trabajador(
                cedula,
                nombre,
                sueldo,
                dias,
                NHED,
                NHEN,
                NHEDD,
                NHEDN,
                NHRN,
                0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                0.0, 0.0, 0.0, 0.0, 0.0
               );
            facturador.insertIntoDB(newT);
            actualizarDatosEnTabla();
        }

        private void actualizarDatosEnTabla() {
            tablaDatos.Clear();
            foreach (var trabajador in facturador.getDataDB()) {
                DataRow nuevaFila = tablaDatos.NewRow();
                nuevaFila["Cédula"] = trabajador.cedula;
                nuevaFila["Nombres"] = trabajador.nombre;
                nuevaFila["Sueldo"] = trabajador.sueldo;
                nuevaFila["Días"] = trabajador.dias;
                nuevaFila["NHED"] = trabajador.nhed;
                nuevaFila["NHEN"] = trabajador.nhen;
                nuevaFila["NHEDD"] = trabajador.nhedd;
                nuevaFila["NHEDN"] = trabajador.nhedn;
                nuevaFila["NHRN"] = trabajador.nhrn;
                nuevaFila["Transporte"] = trabajador.transporte;
                nuevaFila["NHED Valor"] = trabajador.nhedValor;
                nuevaFila["NHEN Valor"] = trabajador.nhenValor;
                nuevaFila["NHEDD Valor"] = trabajador.nheddValor;
                nuevaFila["NHEDN Valor"] = trabajador.nhednValor;
                nuevaFila["NHRN Valor"] = trabajador.nhrnValor;
                nuevaFila["Valor extras"] = trabajador.extras;
                nuevaFila["Devengado"] = trabajador.devengado;
                nuevaFila["Salud"] = trabajador.salud;
                nuevaFila["Pensión"] = trabajador.pension;
                nuevaFila["Aporte solidario"] = trabajador.solidiario;
                nuevaFila["UVT"] = trabajador.uvt;
                nuevaFila["Retefuente"] = trabajador.retefuente;
                nuevaFila["Deducido"] = trabajador.deducido;
                nuevaFila["Neto"] = trabajador.neto;
                tablaDatos.Rows.Add(nuevaFila);
                limpiarCampos();
            }
        }

        private void limpiarCampos() {

            textCedula.Text = "";
            textNombre.Text = "";
            textSueldo.Text = "";
            textDias.Text = "";
            textNHED.Text = "";
            textNHEN.Text = "";
            textNHEDD.Text = "";
            textNHEDN.Text = "";
            textNHRN.Text = "";

            cedulaGet.Text = "";
            cedulaDelete.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }
    }
}
