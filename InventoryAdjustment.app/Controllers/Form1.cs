using InventoryAdjustment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using InventoryAdjustment.Shared;
using System.Diagnostics;
using System.DirectoryServices;
using Microsoft.IdentityModel.Tokens;

namespace InventoryAdjustment.app.Controllers
{
    public partial class formInventoryAdjustament : Form
    {
        private InventoryAdjustamentContext? _dbContext;
        private Panel? panelSelectionArchive;
        private Button? buttonSelectionArchive;
        private Button? buttonCLose;
        private CancellationTokenSource? _cancellationTokenSource;
        private TextBox? textPath;
        private Button? buttonLoad;
        private string? filePath;
        private TextBox? nameAdjustament;
        private Label? labelNameAdjustament;
        private Products Products;
        public formInventoryAdjustament()
        {
            InitializeComponent();
            _dbContext = new InventoryAdjustamentContext();
            _cancellationTokenSource = new CancellationTokenSource();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            panelSelectionArchive = new Panel
            {
                Location = new System.Drawing.Point(86, 34),
                Size = new System.Drawing.Size(371, 169),
                Visible = false,
                Name = "panelSelection"
            };

            this.Controls.Add(panelSelectionArchive);

            buttonSelectionArchive = new Button
            {
                Location = new System.Drawing.Point(16, 51),
                Size = new System.Drawing.Size(91, 40),
                Text = "Seleccionar Archivo",
                Name = "btnSelection"
            };

            buttonSelectionArchive.Click += new EventHandler(SelectFile_Click);

            panelSelectionArchive.Controls.Add(buttonSelectionArchive);

            buttonCLose = new Button
            {
                Text = "X",
                Size = new System.Drawing.Size(30, 30),
                Location = new System.Drawing.Point(panelSelectionArchive.Width - 35, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            buttonCLose.Click += new EventHandler(CloseButton_Click);

            panelSelectionArchive.Controls.Add(buttonCLose);

            textPath = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Modified = false,
                BackColor = Color.Silver,
                Size = new System.Drawing.Size(147, 40),
                Location = new System.Drawing.Point(113, 51)

            };

            panelSelectionArchive.Controls.Add(textPath);

            buttonLoad = new Button
            {
                Text = "Cargar",
                Location = new System.Drawing.Point(16, 108),
                Size = new System.Drawing.Size(102, 35),
            };

            buttonLoad.Click += new EventHandler(LoadAdjustament_Click);
            panelSelectionArchive.Controls.Add(buttonLoad);

            labelNameAdjustament = new Label
            {
                Text = "Nombre",
                BackColor = Color.Silver,
                Location = new System.Drawing.Point(16, 14),
                Size = new System.Drawing.Size(56, 15)
            };

            panelSelectionArchive.Controls.Add(labelNameAdjustament);

            nameAdjustament = new TextBox
            {
                Size = new System.Drawing.Size(190, 23),
                Location = new System.Drawing.Point(78, 11),
                BackColor = Color.Silver
            };

            panelSelectionArchive.Controls.Add(nameAdjustament);

        }


        async private Task LoadNodesAdjustament()
        {
            try
            {
                treeViewAdjustament.Nodes.Clear();
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                var settings = await _dbContext.Adjustaments.Select(a => new
                {
                    a.Name,
                    a.Date_created,
                    a.Id
                })
                    .ToListAsync();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

                if (settings == null || settings.Count == 0)
                {
                    treeViewAdjustament.Nodes.Add("Aun no hay registros");
                    treeViewAdjustament.ExpandAll();
                    return;
                }

                foreach (var setting in settings)
                {
                    TreeNode settingNode = new TreeNode($"NOMBRE: {setting.Name}, {setting.Date_created.ToShortDateString()}");
                    settingNode.Tag = setting.Id;
                    treeViewAdjustament.Nodes.Add(settingNode);


                }

                treeViewAdjustament.ExpandAll();
            }
            catch (Exception error)
            {

                MessageBox.Show("Error al renderizar los ajustes", error.Message);
            }
        }



        async protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadNodesAdjustament();
        }

        private void CloseButton_Click(object? sender, EventArgs e)
        {
            textPath.Text = "";
            nameAdjustament.Text = "";

            _cancellationTokenSource?.Cancel();

            panelSelectionArchive.Visible = false;
            treeViewAdjustament.Visible = true;
        }

        private void SelectFile_Click(object? sender, EventArgs e)
        {
            OpenFileDialog selectionFile = new OpenFileDialog();

            selectionFile.ShowDialog();

            filePath = selectionFile.FileName;
            if (!filePath.Contains("xlsx"))
            {
                MessageBox.Show("Seleccione un archivo correcto");

                return;
            }

            textPath.Text = System.IO.Path.GetFileName(filePath);

        }

        async private void LoadAdjustament_Click(object? sender, EventArgs e)
        {
            try
            {
                if (filePath.IsNullOrEmpty() || nameAdjustament.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("No se completaron todos los campos");
                    _cancellationTokenSource = new CancellationTokenSource();
                    _cancellationTokenSource.Cancel();
                    panelSelectionArchive.Visible = false;
                    treeViewAdjustament.Visible = true;
                    textPath.Text = "";
                    nameAdjustament.Text = "";
                    return;
                }



#pragma warning disable CS8604 // Posible argumento de referencia nulo
                FileInfo existingFile = new FileInfo(filePath);
#pragma warning restore CS8604 // Posible argumento de referencia nulo

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                ExcelPackage package = new ExcelPackage(existingFile);

                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int colCount = worksheet.Dimension.End.Column;

                if (colCount != 6)
                {
                    MessageBox.Show("Selecciona un archivo correcto");
                    _cancellationTokenSource = new CancellationTokenSource();
                    _cancellationTokenSource.Cancel();
                    panelSelectionArchive.Visible = false;
                    treeViewAdjustament.Visible = true;
                    textPath.Text = "";
                    nameAdjustament.Text = "";
                    return;
                }

                List<ProductAdjustament> listProducts = await this.CretaeProductAdjustament(worksheet);

                Adjustament adjustament = new Adjustament()
                {
                    Name = nameAdjustament.Text,
                    Date_created = DateTime.Now,
                    Products = listProducts
                };

                _dbContext.Adjustaments.Add(adjustament);
                _dbContext.SaveChanges();

                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationTokenSource.Cancel();
                panelSelectionArchive.Visible = false;
                treeViewAdjustament.Visible = true;
                textPath.Text = "";
                nameAdjustament.Text = "";

                await LoadNodesAdjustament();



            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                MessageBox.Show("Error al cargar el archivo");
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationTokenSource.Cancel();
                panelSelectionArchive.Visible = false;
                treeViewAdjustament.Visible = true;
                textPath.Text = "";
                throw;
            }

        }

        async private Task<List<ProductAdjustament>> CretaeProductAdjustament(ExcelWorksheet hoja)
        {
            try
            {
                var listCells = new List<string>();
                List<ProductAdjustament> listProducts = new List<ProductAdjustament>();

                await Task.Run(() =>
                {
                    for (int row = 2; row <= hoja.Dimension.End.Row; row++)
                    {
                        for (int col = 1; col <= hoja.Dimension.End.Column; col++)
                        {
                            var cell = hoja.Cells[row, col].Value;
                            Debug.WriteLine(cell.ToString());
                            listCells.Add(cell.ToString());
                            if (listCells.Count == 6)
                            {
                                var quantityHand = int.Parse(listCells[3]);
                                var quantityCounted = int.Parse(listCells[4]);
                                var difference = int.Parse(listCells[5]);

                                ProductAdjustament productAdjustament = new ProductAdjustament()
                                {
                                    ExternalId = listCells[0],
                                    Description = listCells[1],
                                    BarCode = listCells[2],
                                    QuantityHand = quantityHand,
                                    QuantityCounted = quantityCounted,
                                    Difference = difference
                                };

                                listProducts.Add(productAdjustament);
                                listCells.Clear();
                            }
                        }
                    }
                });
                return listProducts;

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                MessageBox.Show("Selecciona un archivo correcto");
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationTokenSource.Cancel();
                panelSelectionArchive.Visible = false;
                treeViewAdjustament.Visible = true;
                textPath.Text = "";
                throw;
            }
        }

        private void tsmNewAdjustament_Click(object sender, EventArgs e)
        {
            treeViewAdjustament.Hide();
            panelSelectionArchive.Visible = true;
            panelSelectionArchive.BackColor = Color.Silver;

        }


        async private void tsmDeleteAdjustament_Click(object sender, EventArgs e)
        {

            try
            {

                if (treeViewAdjustament.SelectedNode != null && treeViewAdjustament.SelectedNode.Tag != null)
                {
                    int index = (int)treeViewAdjustament.SelectedNode.Tag;

                    if (index.ToString() == null)
                    {
                        MessageBox.Show("Ocurrio un error");
                        _cancellationTokenSource?.Cancel();
                        return;
                    }

                    Adjustament adjustament = await _dbContext.Adjustaments.Include(a => a.Products)
                                                                           .FirstOrDefaultAsync(a => a.Id == index);

                    if (adjustament == null)
                    {
                        MessageBox.Show("Ocurrio un error");
                        return;
                    }


                    _dbContext.Adjustaments.Remove(adjustament);
                    await _dbContext.SaveChangesAsync();

                    await LoadNodesAdjustament();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error");
                    _cancellationTokenSource?.Cancel();
                    return;
                }



            }
            catch (Exception error)
            {
                Debug.WriteLine(error.Message);
                MessageBox.Show("Ocurrio un error");
                _cancellationTokenSource?.Cancel();
                throw;
            }
        }

        private void treeViewAdjustament_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tsmDeleteAdjustament.Enabled = true;
        }

        private void treeViewAdjustament_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = (int)treeViewAdjustament.SelectedNode.Tag;

                if (index.ToString() == null)
                {
                    MessageBox.Show("Ocurrio un error");
                    _cancellationTokenSource?.Cancel();
                    return;
                }

                this.Hide();
                Products = new Products(index);
                Products.Show();

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrio un error al querer ingresar ne los productos");
                _cancellationTokenSource?.Cancel();
                throw;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _dbContext?.Dispose();
            base.OnClosing(e);
        }

    }
}
