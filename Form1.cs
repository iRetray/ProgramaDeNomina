using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramaDeFactoracion
{
    public partial class Form1 : Form
    {
        Facturador facturador = new Facturador();
        DataTable tablaDatos = new DataTable();

        public Form1()
        {
            InitializeComponent();
            tablaDatos.Columns.Add("Código");
            tablaDatos.Columns.Add("Artículo");
            tablaDatos.Columns.Add("Precio unitario con IVA incluido");
            tablaDatos.Columns.Add("Porcentaje IVA");
            tablaDatos.Columns.Add("Cantidad");
            tablaDatos.Columns.Add("Subtotal sin IVA");
            tablaDatos.Columns.Add("Valor IVA");
            tablaDatos.Columns.Add("Total");
            gridDatos.DataSource = tablaDatos;
            facturador.conectarSQL();
        }

        private void buttonAñadir_Click(object sender, EventArgs e) {
            int valorIVA = Convert.ToInt32(value: textPrecio.Text) * Convert.ToInt32(value: textIVA.Text) / 100 * Convert.ToInt32(value: textCantidad.Text);
            int total = Convert.ToInt32(value: textPrecio.Text) * Convert.ToInt32(value: textCantidad.Text);
            int subtotal = total - valorIVA;
            Producto newProducto = new Producto( 
                textCodigo.Text, 
                textDescripcion.Text, 
                textPrecio.Text, 
                Convert.ToInt32(value: textIVA.Text), 
                Convert.ToInt32(value: textCantidad.Text), 
                subtotal, 
                valorIVA, 
                total 
            );
            facturador.añadirProducto(newProducto);
            actualizarDatosEnTabla();
        }

        private void actualizarDatosEnTabla() {
            tablaDatos.Clear();
            foreach ( var producto in facturador.obtenerProductos() ) {
                DataRow nuevaFila = tablaDatos.NewRow();
                nuevaFila["Código"] = producto.codigo;
                nuevaFila["Artículo"] = producto.descripcion;
                nuevaFila["Precio unitario con IVA incluido"] = producto.precio;
                nuevaFila["Porcentaje IVA"] = producto.IVA;
                nuevaFila["Cantidad"] = producto.cantidad;
                nuevaFila["Subtotal sin IVA"] = producto.subtotal;
                nuevaFila["Valor IVA"] = producto.valorIVA;
                nuevaFila["Total"] = producto.total;
                tablaDatos.Rows.Add(nuevaFila);
                limpiarCampos();
            }
        }

        private void limpiarCampos() {
            textCantidad.Text = "";
            textCodigo.Text = "";
            textDescripcion.Text = "";
            textIVA.Text = "";
            textPrecio.Text = "";
        }
    }
}
