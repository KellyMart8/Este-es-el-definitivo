namespace pjDios_Mio_Que_Funcione
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        public double Cost_Of_Item()
        {
            double sum = 0;
            int i = 0;

            for(i = 0; i < (dataGridView1.Rows.Count); i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum;
        }

        private void AddCost()
        {
            Double tax, q;
            tax = 3.9;

            if(dataGridView1.Rows.Count > 0)
            {
                lblTax.Text = String.Format("{0 : C2}", (((Cost_Of_Item() * tax)/100)));
                lblSubtotal.Text = String.Format("{0 : C2}", (Cost_Of_Item() ));
                q = ((Cost_Of_Item() * tax) / 100);
                lblTotal.Text = String.Format("{0 : C2}", (Cost_Of_Item() + q));
                lblBarCode.Text = Convert.ToString(q + Cost_Of_Item());
            }
        }

        private void Change()
        {
            Double tax, q, c;
            tax = 3.9;

            if (dataGridView1.Rows.Count > 0)
            {
                q = ((Cost_Of_Item() * tax) / 100) + Cost_Of_Item();
                c = Convert.ToInt32(lblCosto.Text);
                lblCambio.Text = String.Format("{0 : C2}", c - q);
            }
        }

        Bitmap bitmap;
        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                lblBarCode.Text = " ";
                lblCosto.Text = "0";
                lblCambio.Text = " ";
                lblSubtotal.Text = " ";
                lblTax.Text = " ";
                lblTotal.Text = " ";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                cboMetodPago.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboMetodPago.Items.Add("Efectivo");
            cboMetodPago.Items.Add("Visa Card");
            cboMetodPago.Items.Add("Master Card");
        }

        private void SoloNumeros(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if(lblCosto.Text == "0")
            {
                lblCosto.Text = "";
                lblCosto.Text = b.Text;
            }
            else if(b.Text == ("."))
            {
                if(! b.Text.Contains("."))
                {
                    lblCosto.Text = lblCosto + b.Text;
                }
            }
            else
                lblCosto.Text = lblCosto + b.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblCosto.Text = "0";
        }

        private void btnpagar_Click(object sender, EventArgs e)
        {
            if(cboMetodPago.Text == "Efectivo")
            {
                Change();
            }
            else
            {
                lblCambio.Text = " ";
                lblCosto.Text = "0";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();

            if (cboMetodPago.Text == "Efectivo")
            {
                Change();
            }
            else
            {
                lblCambio.Text = " ";
                lblCosto.Text = "0";
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20.2;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Taco de carne"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Toaco de carne", "1", costOfItem);
            AddCost();
        }

        private void btnRed_Velvet_Click(object sender, EventArgs e)
        {
            Double costOfItem = 87.3;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Red Velvet"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Red Velvet", "1", costOfItem);
            AddCost();
        }

        private void btnTorta_Fresa_Click(object sender, EventArgs e)
        {
            Double costOfItem = 80.3;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Torta de fresa"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Torta de fresa", "1", costOfItem);
            AddCost();
        }
        //Cambiar nombres a partir de aqui
        private void btnCheeseCake_Click(object sender, EventArgs e)
        {
            Double costOfItem = 60.3;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Cheese Cake"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Cheese Cake", "1", costOfItem);
            AddCost();
        }

        private void btnTres_Lche_Click(object sender, EventArgs e)
        {
            Double costOfItem = 70.4;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Tres Leche"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Tres Leche", "1", costOfItem);
            AddCost();
        }

        private void btnBuddin_Click(object sender, EventArgs e)
        {
            Double costOfItem = 50.9;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Buddin de chocolate"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Buddin de chocolate", "1", costOfItem);
            AddCost();
        }

        private void btnCoca_Cola_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20.5;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Coca Cola"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Coca Cola", "1", costOfItem);
            AddCost();
        }

        private void btnJugo_Naranja_Click(object sender, EventArgs e)
        {
            Double costOfItem = 16.2;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Jugo de -naranja"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Jugo de Naranja", "1", costOfItem);
            AddCost();
        }

        private void btnAgua_Click(object sender, EventArgs e)
        {
            Double costOfItem = 17.3;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Botella con agua"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Botella con agua", "1", costOfItem);
            AddCost();
        }

        private void btnCafe_Click(object sender, EventArgs e)
        {
            Double costOfItem = 10.6;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Taza de Cafe"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Taza de Cafe", "1", costOfItem);
            AddCost();
        }

        private void btnPinolillo_Click(object sender, EventArgs e)
        {
            Double costOfItem = 20.7;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Pinolillo"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Pinolillo", "1", costOfItem);
            AddCost();
        }

        private void btnEnchilada_Click(object sender, EventArgs e)
        {
            Double costOfItem = 25.8;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Enchilada"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Enchilada", "1", costOfItem);
            AddCost();
        }

        private void btnSalchipapa_Click(object sender, EventArgs e)
        {
            Double costOfItem = 35.3;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Salchipapa"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Salchipapa", "1", costOfItem);
            AddCost();
        }

        private void btnTajadas_Con_Queso_Click(object sender, EventArgs e)
        {
            Double costOfItem = 30.9;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Tajada con queso"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Tajada con queso", "1", costOfItem);
            AddCost();
        }

        private void btnPanini_Click(object sender, EventArgs e)
        {
            Double costOfItem = 35.6;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Panini"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Panini", "1", costOfItem);
            AddCost();
        }

        private void btnBurguer_Click(object sender, EventArgs e)
        {
            Double costOfItem = 80.9;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Hamburguesa"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Hamburguesa", "1", costOfItem);
            AddCost();
        }

        private void btnTorta_Chocolate_Click(object sender, EventArgs e)
        {
            Double costOfItem = 55.2;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Torta de chocolate"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Torta de chocolate", "1", costOfItem);
            AddCost();
        }

        private void btnBatido_Fresa_Click(object sender, EventArgs e)
        {
            Double costOfItem = 40.2;

            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Batido de fresa"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * costOfItem;
                }
            }
            dataGridView1.Rows.Add("Batido de fresa", "1", costOfItem);
            AddCost();
        }
    }
}