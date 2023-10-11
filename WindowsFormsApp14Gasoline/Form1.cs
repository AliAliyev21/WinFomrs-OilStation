using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text; 
using iTextSharp.text.pdf;
using System.Drawing.Text;
namespace WindowsFormsApp14Gasoline
{

    public partial class Form1 : Form
    {
        #region ListGasoline
        List<Gasoline> gasolines = new List<Gasoline>
        {
            new Gasoline
            {
                Name="Ai-92",
                Price=1,
            },
            new Gasoline
            {
                Name="Ai-95",
                Price=2,
            },
            new Gasoline
            {
                Name="Ai-98",
                Price=2.30,
            },
            new Gasoline
            {
                Name="Diesel",
                Price=0.80,
            },
        };
        #endregion

        #region ListProduct 
        List<Product> products = new List<Product>
        {
            new Product
            {
                Name="Coco-Cola",
                Price=4,
            },
            new Product
            {
                Name="Hot-Dog",
                Price=2,
            },
            new Product
            {
                Name="Red-Bull",
                Price=5,
            },
            new Product
            {
                Name="Chipsim",
                Price=3.5,
            }
        };
        #endregion


        public Form1()
        {
            InitializeComponent();
            comboBoxFuelName.DataSource= gasolines;
            comboBoxFuelName.DisplayMember=(nameof(Gasoline.Name));
            comboBoxFuelName.SelectedIndex = 0;

            SetProductPriceColaToTextBox();
            SetProductPriceHotDogToTextBox();
            SetProductPriceRedBullToTextBox();
            SetProductPriceChipsimToTextBox();


        }

        public static void CultureDot()
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        #region Cafe Works
        private void SetProductPriceColaToTextBox()
        {
            var cola = products.FirstOrDefault(p => p.Name == "Coco-Cola");
            if (cola != null)
            {
                textBoxCola.Text = cola.Price.ToString();
            }
        }

        private void SetProductPriceHotDogToTextBox()
        {
            var hotDog = products.FirstOrDefault(p => p.Name == "Hot-Dog");
            if(hotDog != null)
            {
                textBoxHotDog.Text= hotDog.Price.ToString();
            }
        }

        private void SetProductPriceRedBullToTextBox()
        {
            var redBull = products.FirstOrDefault(p => p.Name == "Red-Bull");
            if (redBull != null)
            {
                textBoxRedBull.Text = redBull.Price.ToString();
            }
        }

        private void SetProductPriceChipsimToTextBox()
        {
            var chipsim = products.FirstOrDefault(p => p.Name == "Chipsim");
            if (chipsim != null)
            {
                textBoxChipsim.Text = chipsim.Price.ToString();
            }
        }


        private void checkBoxCola_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCola.Checked)
            {
                maskedTextBoxCola.Enabled = true;
            }
            else
            {
                maskedTextBoxCola.Enabled = false;
                maskedTextBoxCola.Text= String.Empty;
            }           
        }

       
        private void checkBoxHotDog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHotDog.Checked)
            {
                maskedTextBoxHotDog.Enabled = true;
            }
            else
            {
                maskedTextBoxHotDog.Enabled = false;
                maskedTextBoxHotDog.Text= String.Empty;
            }
        }

        private void checkBoxRedBull_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRedBull.Checked)
            {
                maskedTextBoxRedBull.Enabled = true;
            }
            else
            {
                maskedTextBoxRedBull.Enabled = false;
                maskedTextBoxRedBull.Text= String.Empty;
            }     
        }


        private void checkBoxChipsim_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChipsim.Checked)
            {
                maskedTextBoxChipsim.Enabled = true;
            }
            else
            {
                maskedTextBoxChipsim.Enabled = false;
                maskedTextBoxChipsim.Text= String.Empty;
            }      
        }

        private void maskedTextBoxCola_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalProductPrice();
        }


        private void maskedTextBoxHotDog_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalProductPrice();
        }


        private void maskedTextBoxRedBull_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalProductPrice();
        }


        private void maskedTextBoxChipsim_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalProductPrice();
        }


        private void CalculateTotalProductPrice()
        {
            double totalProductPrice = 0;

            if (checkBoxCola.Checked)
            {
                if (double.TryParse(maskedTextBoxCola.Text, out double colaQuantity))
                {
                    totalProductPrice += colaQuantity * double.Parse(textBoxCola.Text);
                    
                }
            }

            if (checkBoxHotDog.Checked)
            {
                if (double.TryParse(maskedTextBoxHotDog.Text, out double hotDogQuantity))
                {
                    totalProductPrice += hotDogQuantity * double.Parse(textBoxHotDog.Text);
                }
            }

            if (checkBoxRedBull.Checked)
            {
                if (double.TryParse(maskedTextBoxRedBull.Text, out double redBullQuantity))
                {
                    totalProductPrice += redBullQuantity * double.Parse(textBoxRedBull.Text);
                }
            }

            if (checkBoxChipsim.Checked)
            {
                if (double.TryParse(maskedTextBoxChipsim.Text, out double chipsimQuantity))
                {
                    totalProductPrice += chipsimQuantity * double.Parse(textBoxChipsim.Text);
                }
            }

            labelProductPrice.Text = totalProductPrice.ToString("F2") + " Azn";
        }
        #endregion

        #region Gasoline Works
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var item=comboBoxFuelName.SelectedItem as Gasoline;
            if(item != null)
            {
                textBoxFuelPrice.Text = item.Price.ToString();
            }
        }

        private void radioButtonLiter_Click(object sender, EventArgs e)
        {
            if (radioButtonLiter.Checked)
            {
                maskedTextBoxBuyLiter.Enabled = true;
                maskedTextBoxBuyAzn.Enabled = false;
                maskedTextBoxBuyAzn.Text = String.Empty;
                CalculateTotalPriceFuel();
            }
        }

       
        private void maskedTextBoxBuyLiter_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPriceFuel();
            if (radioButtonLiter.Checked)
            {
                maskedTextBoxBuyAzn.Text = String.Empty;
            }
        }


        private void radioButtonAzn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAzn.Checked)
            {
                maskedTextBoxBuyAzn.Enabled = true;
                maskedTextBoxBuyLiter.Enabled = false;
                maskedTextBoxBuyLiter.Text = String.Empty;
                CalculateTotalPriceFuel();
            }
        }
        private void maskedTextBoxBuyAzn_TextChanged(object sender, EventArgs e)
        {           
            CalculateTotalPriceFuel();
            if (radioButtonAzn.Checked)
            {
                maskedTextBoxBuyLiter.Text = String.Empty;
            }
        }


        private void CalculateTotalPriceFuel()
        {
            var selectedFuel = comboBoxFuelName.SelectedItem as Gasoline;

            if (selectedFuel != null)
            {
                double priceLiter = selectedFuel.Price;
                double totalPrice = 0;

                if (radioButtonLiter.Checked)
                {
                    if (double.TryParse(maskedTextBoxBuyLiter.Text, out double liters))
                    {
                        totalPrice = priceLiter * liters;
                        maskedTextBoxBuyAzn.Text = totalPrice.ToString("F2") + " Azn";
                        labelFuelPrice.Text = totalPrice.ToString("F2") + " Azn";
                    }
                }
                else if (radioButtonAzn.Checked)
                {
                    if (double.TryParse(maskedTextBoxBuyAzn.Text, out double azn))
                    {
                        totalPrice = azn;
                        maskedTextBoxBuyLiter.Text = (azn / priceLiter).ToString("F2") + " L";
                        labelFuelPrice.Text = totalPrice.ToString("F2") + " Azn";
                    }
                }
            }
        }
        #endregion

        #region Totals End
 
        private void CalculateTotalAmount()
        {
            double totalProductPrice = 0;
            double totalFuelPrice = 0;

            if (checkBoxCola.Checked)
            {
                if (double.TryParse(maskedTextBoxCola.Text, out double colaQuantity))
                {
                    totalProductPrice += colaQuantity * double.Parse(textBoxCola.Text);
                }
            }

            if (checkBoxHotDog.Checked)
            {
                if (double.TryParse(maskedTextBoxHotDog.Text, out double hotDogQuantity))
                {
                    totalProductPrice += hotDogQuantity * double.Parse(textBoxHotDog.Text);
                }
            }

            if (checkBoxRedBull.Checked)
            {
                if (double.TryParse(maskedTextBoxRedBull.Text, out double redBullQuantity))
                {
                    totalProductPrice += redBullQuantity * double.Parse(textBoxRedBull.Text);
                }
            }

            if (checkBoxChipsim.Checked)
            {
                if (double.TryParse(maskedTextBoxChipsim.Text, out double chipsimQuantity))
                {
                    totalProductPrice += chipsimQuantity * double.Parse(textBoxChipsim.Text);
                }
            }

            var selectedFuel = comboBoxFuelName.SelectedItem as Gasoline;
            if (selectedFuel != null)
            {
                double priceLiter = selectedFuel.Price;

                if (radioButtonLiter.Checked)
                {
                    if (double.TryParse(maskedTextBoxBuyLiter.Text, out double liters))
                    {
                        totalFuelPrice = priceLiter * liters;
                    }
                }
                else if (radioButtonAzn.Checked)
                {
                    if (double.TryParse(maskedTextBoxBuyAzn.Text, out double azn))
                    {
                        totalFuelPrice = azn;
                    }
                }
            }

            double totalAmount = totalProductPrice + totalFuelPrice;
            lblTotals.Text = totalAmount.ToString("F2") + " Azn";
        }

        #endregion

        #region WritePDF

        private void GeneratePDF(string fileName)
        {
            Document doc = new Document();
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                doc.Open();

                
                iTextSharp.text.Font titleFont = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED, 18);
                Paragraph title = new Paragraph("Invoice details");
                title.Font = titleFont; 
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

              
                PdfPTable table = new PdfPTable(3);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                float[] widths = new float[] { 2f, 1f, 1f };
                table.SetWidths(widths);

                
                PdfPCell cell = new PdfPCell(new Phrase("Name", FontFactory.GetFont(BaseFont.HELVETICA, 12, BaseColor.BLACK)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Quantity", FontFactory.GetFont(BaseFont.HELVETICA, 12, BaseColor.BLACK)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Price (Azn)", FontFactory.GetFont(BaseFont.HELVETICA, 12, BaseColor.BLACK)));
                table.AddCell(cell);

                Gasoline selectedGasoline = comboBoxFuelName.SelectedItem as Gasoline;
                AddRowToTable(table, selectedGasoline.Name, "", selectedGasoline.Price.ToString("F2"));
                AddRowToTable(table, "Coca-Cola", maskedTextBoxCola.Text, textBoxCola.Text);
                AddRowToTable(table, "Hot-Dog", maskedTextBoxHotDog.Text, textBoxHotDog.Text);
                AddRowToTable(table, "Red-Bull", maskedTextBoxRedBull.Text, textBoxRedBull.Text);
                AddRowToTable(table, "Chipsim", maskedTextBoxChipsim.Text, textBoxChipsim.Text);

                AddTotalRowToTable(table, lblTotals.Text);

                DateTime now = DateTime.Now;
                Paragraph dateParagraph = new Paragraph("\r\nHistory : " + now.ToString("dd.MM.yyyy HH:mm:ss"));
                dateParagraph.Alignment = Element.ALIGN_RIGHT;

                doc.Add(table);
                doc.Add(dateParagraph);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eror: {ex.Message}");
            }
            finally
            {
                doc.Close();
            }
        }

        private void AddRowToTable(PdfPTable table, string productName, string quantity, string price)
        {
            table.AddCell(productName);
            table.AddCell(quantity);
            table.AddCell(price);
        }

        private void AddTotalRowToTable(PdfPTable table, string totalAmount)
        {
            PdfPCell cell = new PdfPCell(new Phrase("Total Amount", FontFactory.GetFont(BaseFont.HELVETICA, 12, BaseColor.BLACK)));
            cell.Colspan = 2;
            table.AddCell(cell);
            table.AddCell(totalAmount);
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            CalculateTotalAmount();

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Receip.pdf");

            GeneratePDF(fileName);

            MessageBox.Show("PDF generated successfully!");
        }
        #endregion

    }
}
