using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellsControl
{
    public partial class frmVentas : Form
    {

        Ventas ventas = new Ventas();

        double total;

        //Inicializar arreglo de productos
        static string[] productos = { "Teclado", "Impresora", "Monitor", "Bocinas", "Mouses"};

        //Objeto de la clase ArrayList
        ArrayList aProductos = new ArrayList(productos);



        public frmVentas()
        {
            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {

            MostrarFecha();
            MostrarHora();
            LimpiarCampos();
            llenarProducto();
            lbltotalneto.Text = "0.00";

        }
        private void cobproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ventas.producto = cobproductos.Text;
            lblprecio.Text = ventas.AsignarPrecio().ToString("C");
        }
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            ventas.producto = cobproductos.Text;
            ventas.cantidad = int.Parse(txtcantidad.Text);


            ListViewItem fila = new ListViewItem(ventas.producto);
            fila.SubItems.Add(ventas.cantidad.ToString());
            fila.SubItems.Add(ventas.AsignarPrecio().ToString("C"));
            fila.SubItems.Add(ventas.SubTotal().ToString("C"));
            fila.SubItems.Add(ventas.Descuento().ToString("C"));
            fila.SubItems.Add(ventas.Neto().ToString("C"));


            lvregistro.Items.Add(fila);


            total += ventas.Neto();

            lbltotalneto.Text = total.ToString("C");

            LimpiarCampos();
        }

        private void MostrarFecha()
        {
            lblfecha.Text = DateTime.Now.ToShortDateString();

        }

        private void MostrarHora()
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
        }


        private void LimpiarCampos()
        {
            txtcliente.Clear();
            txtcliente.Focus();
            cobproductos.Text = "Seleccione un producto";
            lblprecio.Text = "0.00";
            txtcantidad.Clear();

        }

        private void llenarProducto()
        {
            foreach (string p in aProductos)
            {

                cobproductos.Items.Add(p);


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea Salir..?",  "Ventas", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {

                this.Close();

            }
            else
            {

                LimpiarCampos();
            
            }
        }


    }
}
