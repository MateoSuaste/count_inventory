namespace InventoryAdjustment.app.Controllers
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            tsmimportAjustament = new ToolStripMenuItem();
            tsmNewAdjustament = new ToolStripMenuItem();
            tsmExportAjustament = new ToolStripMenuItem();
            tsmDeleteAdjustament = new ToolStripMenuItem();
            viewAdjustamentToolStripMenuItem = new ToolStripMenuItem();
            dataGridProducts = new DataGridView();
            productAdjustamentBindingSource = new BindingSource(components);
            externalIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            barCodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityHandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityCountedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            differenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productAdjustamentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Silver;
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmimportAjustament, viewAdjustamentToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmimportAjustament
            // 
            tsmimportAjustament.BackColor = Color.Silver;
            tsmimportAjustament.DropDownItems.AddRange(new ToolStripItem[] { tsmNewAdjustament, tsmExportAjustament, tsmDeleteAdjustament });
            tsmimportAjustament.Font = new Font("Sitka Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmimportAjustament.Margin = new Padding(1, 1, 2, 1);
            tsmimportAjustament.Name = "tsmimportAjustament";
            tsmimportAjustament.Size = new Size(63, 22);
            tsmimportAjustament.Text = "Archive";
            // 
            // tsmNewAdjustament
            // 
            tsmNewAdjustament.BackColor = Color.Silver;
            tsmNewAdjustament.Enabled = false;
            tsmNewAdjustament.Name = "tsmNewAdjustament";
            tsmNewAdjustament.Size = new Size(248, 22);
            tsmNewAdjustament.Text = "New Inventory Adjustament";
            // 
            // tsmExportAjustament
            // 
            tsmExportAjustament.BackColor = Color.Silver;
            tsmExportAjustament.Enabled = false;
            tsmExportAjustament.ForeColor = Color.Black;
            tsmExportAjustament.Name = "tsmExportAjustament";
            tsmExportAjustament.Size = new Size(248, 22);
            tsmExportAjustament.Text = "Export Inventory Adjustament";
            // 
            // tsmDeleteAdjustament
            // 
            tsmDeleteAdjustament.BackColor = Color.Silver;
            tsmDeleteAdjustament.Enabled = false;
            tsmDeleteAdjustament.Name = "tsmDeleteAdjustament";
            tsmDeleteAdjustament.Size = new Size(248, 22);
            tsmDeleteAdjustament.Text = "Delete Adjustament";
            // 
            // viewAdjustamentToolStripMenuItem
            // 
            viewAdjustamentToolStripMenuItem.Name = "viewAdjustamentToolStripMenuItem";
            viewAdjustamentToolStripMenuItem.Size = new Size(115, 24);
            viewAdjustamentToolStripMenuItem.Text = "View Adjustament";
            viewAdjustamentToolStripMenuItem.Click += viewAdjustamentToolStripMenuItem_Click;
            // 
            // dataGridProducts
            // 
            dataGridProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dataGridProducts.AutoGenerateColumns = false;
            dataGridProducts.Columns.AddRange(new DataGridViewColumn[] { externalIdDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, barCodeDataGridViewTextBoxColumn, quantityHandDataGridViewTextBoxColumn, quantityCountedDataGridViewTextBoxColumn, differenceDataGridViewTextBoxColumn });
            dataGridProducts.DataSource = productAdjustamentBindingSource;
            dataGridProducts.Location = new Point(0, 44);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.Size = new Size(800, 268);
            dataGridProducts.TabIndex = 2;
            // 
            // productAdjustamentBindingSource
            // 
            productAdjustamentBindingSource.DataSource = typeof(Shared.ProductAdjustament);
            // 
            // externalIdDataGridViewTextBoxColumn
            // 
            externalIdDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            externalIdDataGridViewTextBoxColumn.DataPropertyName = "ExternalId";
            externalIdDataGridViewTextBoxColumn.HeaderText = "ExternalId";
            externalIdDataGridViewTextBoxColumn.Name = "externalIdDataGridViewTextBoxColumn";
            externalIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            barCodeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            barCodeDataGridViewTextBoxColumn.DataPropertyName = "BarCode";
            barCodeDataGridViewTextBoxColumn.HeaderText = "BarCode";
            barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityHandDataGridViewTextBoxColumn
            // 
            quantityHandDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quantityHandDataGridViewTextBoxColumn.DataPropertyName = "QuantityHand";
            quantityHandDataGridViewTextBoxColumn.HeaderText = "QuantityHand";
            quantityHandDataGridViewTextBoxColumn.Name = "quantityHandDataGridViewTextBoxColumn";
            quantityHandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityCountedDataGridViewTextBoxColumn
            // 
            quantityCountedDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            quantityCountedDataGridViewTextBoxColumn.DataPropertyName = "QuantityCounted";
            quantityCountedDataGridViewTextBoxColumn.HeaderText = "QuantityCounted";
            quantityCountedDataGridViewTextBoxColumn.Name = "quantityCountedDataGridViewTextBoxColumn";
            // 
            // differenceDataGridViewTextBoxColumn
            // 
            differenceDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            differenceDataGridViewTextBoxColumn.DataPropertyName = "Difference";
            differenceDataGridViewTextBoxColumn.HeaderText = "Difference";
            differenceDataGridViewTextBoxColumn.Name = "differenceDataGridViewTextBoxColumn";
            differenceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(128, 128, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridProducts);
            Controls.Add(menuStrip1);
            Name = "Products";
            Text = "Products";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productAdjustamentBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmimportAjustament;
        private ToolStripMenuItem tsmNewAdjustament;
        private ToolStripMenuItem tsmExportAjustament;
        private ToolStripMenuItem tsmDeleteAdjustament;
        private DataGridView dataGridProducts;
        private BindingSource productAdjustamentBindingSource;
        private ToolStripMenuItem viewAdjustamentToolStripMenuItem;
        private DataGridViewTextBoxColumn externalIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityHandDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityCountedDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn differenceDataGridViewTextBoxColumn;
    }
}