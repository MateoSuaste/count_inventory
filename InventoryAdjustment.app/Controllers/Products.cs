using InventoryAdjustment.Data;
using InventoryAdjustment.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryAdjustment.app.Controllers
{
    public partial class Products : Form
    {
        private InventoryAdjustamentContext? _dbcontext;
        private int? idAdjustament;
        private CancellationTokenSource? _cancellationTokenSource;
        private formInventoryAdjustament? form1;

        public Products(int idAdjustament)
        {
            InitializeComponent();
            _dbcontext = new InventoryAdjustamentContext();
            this.idAdjustament = idAdjustament;
            _cancellationTokenSource = new CancellationTokenSource();
            form1 = new formInventoryAdjustament();
        }

        async protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dataGridProducts.EditMode = DataGridViewEditMode.EditOnEnter;
            await LoadProducts();
        }


        async private Task LoadProducts()
        {
            try
            {
                var products = await _dbcontext.ProductAdjustments.Select(p => new
                {
                    p.ExternalId,
                    p.BarCode,
                    p.Difference,
                    p.QuantityCounted,
                    p.Description,
                    p.QuantityHand,
                    p.AdjustamentId
                })
                    .Where(p => p.AdjustamentId == idAdjustament)
                    .ToListAsync();

                if (products.Count == 0 || products == null)
                {
                    MessageBox.Show("No hay productos para mostrar");
                    _cancellationTokenSource.Cancel();
                    this.Close();
                    form1.Show();
                    return;
                }

                this.productAdjustamentBindingSource.DataSource = products;

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error al mostrar los productos", error.Message);
                _cancellationTokenSource.Cancel();
                this.Close();
                form1.Show();
                throw;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this._dbcontext?.Dispose();
            this._dbcontext = null;
        }

        private void viewAdjustamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();


            this.Close();
            form1.Show();
        }
    }
}
