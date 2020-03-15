using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioTienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (conexionTiendaDataContext dbTienda = new conexionTiendaDataContext())
            {
                cbCategoria.DataSource = dbTienda.Categorias.ToList();
                cbCategoria.DisplayMember = "NombreCategoria";
                cbCategoria.ValueMember = "IdCategoria";
                Categoria objCategoria = cbCategoria.SelectedItem as Categoria;
                if (objCategoria != null)
                {
                    dgvProductos.DataSource = dbTienda.ObtenerProductosPorIdCategoria(objCategoria.IdCategoria);
                }
            }
        }

        private void cbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Categoria objCategoria = cbCategoria.SelectedItem as Categoria;
            if (objCategoria != null)
            {
                using (conexionTiendaDataContext dbTienda = new conexionTiendaDataContext())
                {
                    dgvProductos.DataSource = dbTienda.ObtenerProductosPorIdCategoria(objCategoria.IdCategoria);
                }
            }
        }
    }
}
