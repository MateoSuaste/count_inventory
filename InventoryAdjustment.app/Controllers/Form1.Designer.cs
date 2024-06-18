namespace InventoryAdjustment.app.Controllers
{
    partial class formInventoryAdjustament
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
            TreeNode treeNode2 = new TreeNode("Nodo0");
            menuStrip1 = new MenuStrip();
            tsmimportAjustament = new ToolStripMenuItem();
            tsmNewAdjustament = new ToolStripMenuItem();
            tsmExportAjustament = new ToolStripMenuItem();
            tsmDeleteAdjustament = new ToolStripMenuItem();
            treeViewAdjustament = new TreeView();
            adjustamentBindingSource = new BindingSource(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adjustamentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Silver;
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmimportAjustament });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
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
            tsmNewAdjustament.Name = "tsmNewAdjustament";
            tsmNewAdjustament.Size = new Size(248, 22);
            tsmNewAdjustament.Text = "New Inventory Adjustament";
            tsmNewAdjustament.Click += tsmNewAdjustament_Click;
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
            tsmDeleteAdjustament.Click += tsmDeleteAdjustament_Click;
            // 
            // treeViewAdjustament
            // 
            treeViewAdjustament.BackColor = Color.Silver;
            treeViewAdjustament.Cursor = Cursors.Hand;
            treeViewAdjustament.Dock = DockStyle.Bottom;
            treeViewAdjustament.ForeColor = SystemColors.WindowText;
            treeViewAdjustament.Location = new Point(0, 48);
            treeViewAdjustament.Margin = new Padding(0, 0, 0, 5);
            treeViewAdjustament.Name = "treeViewAdjustament";
            treeNode2.Checked = true;
            treeNode2.ImageIndex = -2;
            treeNode2.Name = "Nodo0";
            treeNode2.Text = "Nodo0";
            treeViewAdjustament.Nodes.AddRange(new TreeNode[] { treeNode2 });
            treeViewAdjustament.RightToLeftLayout = true;
            treeViewAdjustament.Size = new Size(800, 402);
            treeViewAdjustament.TabIndex = 1;
            treeViewAdjustament.Tag = "";
            treeViewAdjustament.AfterSelect += treeViewAdjustament_AfterSelect;
            treeViewAdjustament.DoubleClick += treeViewAdjustament_DoubleClick;
            // 
            // adjustamentBindingSource
            // 
            adjustamentBindingSource.DataSource = typeof(Shared.Adjustament);
            // 
            // formInventoryAdjustament
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            ClientSize = new Size(800, 450);
            Controls.Add(treeViewAdjustament);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            Name = "formInventoryAdjustament";
            Text = "Inventory Adjustament";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)adjustamentBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmimportAjustament;
        private ToolStripMenuItem tsmNewAdjustament;
        private ToolStripMenuItem tsmExportAjustament;
        public TreeView treeViewAdjustament;
        private BindingSource adjustamentBindingSource;
        private ToolStripMenuItem tsmDeleteAdjustament;
    }
}