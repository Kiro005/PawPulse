using System.Drawing;
using System.Windows.Forms;

namespace PawPulse
{
    public static class UIThemeManager
    {
        public static void ApplyTheme(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(41, 53, 65);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.White;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 53, 65);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                }

                if (c.HasChildren)
                {
                    ApplyTheme(c);
                }
            }
        }
    }
}