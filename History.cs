using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace MobileInventory
{
    public partial class History : UserControl
    {
        public History()
        {
            InitializeComponent();
            LoadHistory();
        }
        private void LoadHistory()
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True"))
            {
                connect.Open();
                string query = "SELECT * FROM ProductHistory ORDER BY Timestamp DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable historyTable = new DataTable();
                adapter.Fill(historyTable);
                HistoryGridView.DataSource = historyTable;
                HistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                HistoryGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
        }
        private void btnExportTOExcel_Click(object sender, EventArgs e)
        {
            // Check if there is any data to export
            if (HistoryGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Prompt user to select the file format
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx|PDF Files|*.pdf",
                Title = "Export Data",
                FileName = "TechVaultLog"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileExtension = Path.GetExtension(saveFileDialog.FileName).ToLower();

                if (fileExtension == ".xlsx")
                {
                    // Export to Excel
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        // Add a worksheet to the workbook
                        var worksheet = workbook.Worksheets.Add("Product History");

                        // Add column headers
                        for (int col = 0; col < HistoryGridView.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = HistoryGridView.Columns[col].HeaderText;
                        }

                        // Add rows
                        for (int row = 0; row < HistoryGridView.Rows.Count; row++)
                        {
                            for (int col = 0; col < HistoryGridView.Columns.Count; col++)
                            {
                                worksheet.Cell(row + 2, col + 1).Value = HistoryGridView.Rows[row].Cells[col].Value?.ToString() ?? string.Empty;
                            }
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Data exported successfully to Excel!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else if (fileExtension == ".pdf")
                {
                    // Export to PDF
                    using (var stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        var document = new iTextSharp.text.Document();
                        PdfWriter.GetInstance(document, stream);

                        document.Open();

                        // Add Title
                        var titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
                        var title = new iTextSharp.text.Paragraph("TechVault Log", titleFont)
                        {
                            Alignment = iTextSharp.text.Element.ALIGN_CENTER,
                            SpacingAfter = 20
                        };
                        document.Add(title);

                        // Add Table
                        var table = new iTextSharp.text.pdf.PdfPTable(HistoryGridView.Columns.Count)
                        {
                            WidthPercentage = 100
                        };

                        // Add headers
                        foreach (DataGridViewColumn column in HistoryGridView.Columns)
                        {
                            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(column.HeaderText))
                            {
                                HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER,
                                BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220)
                            });
                        }

                        // Add rows
                        foreach (DataGridViewRow row in HistoryGridView.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(cell.Value?.ToString() ?? string.Empty);
                            }
                        }

                        document.Add(table);
                        document.Close();
                    }

                    MessageBox.Show("Data exported successfully to PDF!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBar.Text.Trim();

            int selectedMonth = GetSelectedMonth();

            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True"))
            {
                connect.Open();

                string query = @"
            SELECT h.*, p.ProductName 
            FROM ProductHistory h
            LEFT JOIN Products p ON h.ProductID = p.ProductID 
            WHERE 
                (CAST(h.HistoryID AS VARCHAR) LIKE @SearchText OR
                CAST(h.ProductID AS VARCHAR) LIKE @SearchText OR
                h.Action LIKE @SearchText OR
                p.ProductName LIKE @SearchText) 
                AND (@Month IS NULL OR MONTH(h.Timestamp) = @Month)
                AND (@Day IS NULL OR DAY(h.Timestamp) = @Day)
                AND (@Year IS NULL OR YEAR(h.Timestamp) = @Year)
            ORDER BY h.Timestamp DESC";

                SqlCommand command = new SqlCommand(query, connect);

                command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                object monthParam = DBNull.Value;
                object dayParam = DBNull.Value;
                object yearParam = DBNull.Value;

                if (int.TryParse(searchText, out int numericValue))
                {
                    if (numericValue >= 1 && numericValue <= 12)
                    {
                        monthParam = numericValue;
                    }

                    if (numericValue >= 1 && numericValue <= 31)
                    {
                        dayParam = numericValue;
                    }

                    if (numericValue >= 1000 && numericValue <= 9999)
                    {
                        yearParam = numericValue;
                    }
                }

                if (selectedMonth > 0)
                {
                    monthParam = selectedMonth;
                }

                command.Parameters.AddWithValue("@Month", monthParam);
                command.Parameters.AddWithValue("@Day", dayParam);
                command.Parameters.AddWithValue("@Year", yearParam);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable searchTable = new DataTable();
                adapter.Fill(searchTable);

                HistoryGridView.DataSource = searchTable;
            }
        }
        private int GetSelectedMonth()
        {
            switch (cbCategoryFilter.Text)
            {
                case "January": return 1;
                case "February": return 2;
                case "March": return 3;
                case "April": return 4;
                case "May": return 5;
                case "June": return 6;
                case "July": return 7;
                case "August": return 8;
                case "September": return 9;
                case "October": return 10;
                case "November": return 11;
                case "December": return 12;
                default: return 0;
            }
        }

        private void History_Load(object sender, EventArgs e)
        {
            cbCategoryFilter.Items.Add("All");
            cbCategoryFilter.Items.Add("January");
            cbCategoryFilter.Items.Add("February");
            cbCategoryFilter.Items.Add("March");
            cbCategoryFilter.Items.Add("April");
            cbCategoryFilter.Items.Add("May");
            cbCategoryFilter.Items.Add("June");
            cbCategoryFilter.Items.Add("July");
            cbCategoryFilter.Items.Add("August");
            cbCategoryFilter.Items.Add("September");
            cbCategoryFilter.Items.Add("October");
            cbCategoryFilter.Items.Add("November");
            cbCategoryFilter.Items.Add("December");
        }

        private void cbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMonth = cbCategoryFilter.Text;

            if (selectedMonth == "All")
            {
                LoadHistory();
            }
            else
            {
                int monthNumber = GetMonthNumber(selectedMonth);
                FilterHistoryByMonth(monthNumber);
            }
        }
        private void FilterHistoryByMonth(int month)
        {
            using (SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MobileMart;Initial Catalog=MobileMart;Integrated Security=True"))
            {
                connect.Open();
                string query = "SELECT * FROM ProductHistory WHERE MONTH(Timestamp) = @Month ORDER BY Timestamp DESC";

                using (SqlCommand command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@Month", month);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable historyTable = new DataTable();
                    adapter.Fill(historyTable);
                    HistoryGridView.DataSource = historyTable;

                    HistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    HistoryGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
        }
        private int GetMonthNumber(string monthName)
        {
            switch (monthName)
            {
                case "January": return 1;
                case "February": return 2;
                case "March": return 3;
                case "April": return 4;
                case "May": return 5;
                case "June": return 6;
                case "July": return 7;
                case "August": return 8;
                case "September": return 9;
                case "October": return 10;
                case "November": return 11;
                case "December": return 12;
                default: return 0;
            }
        }
    }
}
