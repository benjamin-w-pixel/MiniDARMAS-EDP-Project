using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MiniDARMAS
{
    public static class ThemeHelper
    {
        // Color Palette
        public static readonly Color PrimaryColor = Color.FromArgb(78, 115, 223); // #4E73DF (Nice Blue)
        public static readonly Color SecondaryColor = Color.FromArgb(133, 135, 150); // #858796 (Gray)
        public static readonly Color SuccessColor = Color.FromArgb(28, 200, 138); // #1CC88A (Green)
        public static readonly Color InfoColor = Color.FromArgb(54, 185, 204); // #36B9CC (Cyan)
        public static readonly Color WarningColor = Color.FromArgb(246, 194, 62); // #F6C23E (Yellow)
        public static readonly Color DangerColor = Color.FromArgb(231, 74, 59); // #E74A3B (Red)
        public static readonly Color LightColor = Color.FromArgb(248, 249, 252); // #F8F9FC (Light Background)
        public static readonly Color DarkColor = Color.FromArgb(90, 92, 105); // #5A5C69 (Dark Text)
        public static readonly Color SurfaceColor = Color.White;

        // Fonts
        public static readonly Font HeaderFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font NormalFont = new Font("Segoe UI", 10F, FontStyle.Regular);

        public static void ApplyTheme(Form form)
        {
            form.BackColor = LightColor;
            form.Font = NormalFont;
            form.StartPosition = FormStartPosition.CenterScreen;
            
            // MDI Containers cannot have AutoScroll = true. It will cause a crash.
            if (!form.IsMdiContainer)
            {
                form.AutoScroll = true;
                // Capture the initial/design size as the minimum scrollable area
                if (form.AutoScrollMinSize.Width == 0 && form.AutoScrollMinSize.Height == 0)
                {
                    form.AutoScrollMinSize = new Size(form.ClientSize.Width, form.ClientSize.Height);
                }
            }
            
            // Set a minimum size for resizable forms to ensure scrollbars appear
            if (form.FormBorderStyle != FormBorderStyle.FixedDialog && 
                form.FormBorderStyle != FormBorderStyle.FixedSingle &&
                form.MinimumSize.Width == 0 && form.MinimumSize.Height == 0)
            {
                // Use a reasonable minimum size, but don't force it if the form is small
                if (form.Size.Width > 400 || form.Size.Height > 300)
                {
                    form.MinimumSize = new Size(Math.Min(form.Width, 800), Math.Min(form.Height, 600));
                }
            }

            foreach (Control control in form.Controls)
            {
                ApplyThemeToControl(control);
            }

            // Automatically apply language when theme is applied
            MiniDARMAS.Business.LocalizationHelper.ApplyLanguage(form);
        }

        private static void ApplyThemeToControl(Control control)
        {
            if (control is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Size = new Size(btn.Width, 35); // slightly taller

                // simple logic to distinguish actions, default to Primary
                string originalText = (btn.Tag?.ToString() ?? btn.Text).ToLower();

                if (originalText.Contains("delete") || originalText.Contains("cancel"))
                {
                    btn.BackColor = DangerColor;
                    btn.ForeColor = Color.White;
                }
                else if (originalText.Contains("save") || originalText.Contains("login"))
                {
                    btn.BackColor = PrimaryColor;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = SecondaryColor;
                    btn.ForeColor = Color.White;
                }

                ApplyRoundedCorners(btn);
            }
            else if (control is Label lbl)
            {
                lbl.ForeColor = DarkColor;
                if (lbl.Font.Size >= 12) // Assuming title labels are larger
                {
                    lbl.ForeColor = PrimaryColor;
                    lbl.Font = HeaderFont;
                }
            }
            else if (control is TextBox txt)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = SurfaceColor;
                txt.Font = NormalFont;
            }
            else if (control is ComboBox cmb)
            {
                cmb.FlatStyle = FlatStyle.Flat;
                cmb.BackColor = SurfaceColor;
                cmb.Font = NormalFont;
            }
            else if (control is Panel pnl)
            {
                pnl.AutoScroll = true;
                pnl.BackColor = Color.Transparent; // Or SurfaceColor depending on design
                foreach (Control child in pnl.Controls)
                {
                    ApplyThemeToControl(child);
                }
            }
            else if (control is GroupBox grp)
            {
                grp.ForeColor = PrimaryColor;
                foreach (Control child in grp.Controls)
                {
                    ApplyThemeToControl(child);
                }
            }
            else if (control is DataGridView dgv)
            {
                StyleDataGridView(dgv);
            }
            else if (control is TabControl tab)
            {
                foreach (TabPage page in tab.TabPages)
                {
                    page.BackColor = LightColor;
                    foreach (Control child in page.Controls)
                    {
                        ApplyThemeToControl(child);
                    }
                }
            }
        }

        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = PrimaryColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.BackgroundColor = SurfaceColor;
            
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
        }

        public static void ApplyRoundedCorners(Button btn, int radius = 15)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);

            // Add hover effect if not already added
            btn.MouseEnter -= Button_MouseEnter;
            btn.MouseEnter += Button_MouseEnter;
            btn.MouseLeave -= Button_MouseLeave;
            btn.MouseLeave += Button_MouseLeave;
        }

        private static void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn)
                btn.BackColor = ControlPaint.Light(btn.BackColor, 0.2f);
        }

        private static void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                // Check original text from Tag for language-independent styling
                string originalText = (btn.Tag?.ToString() ?? btn.Text).ToLower();

                if (originalText.Contains("delete") || originalText.Contains("cancel"))
                    btn.BackColor = DangerColor;
                else if (originalText.Contains("save") || originalText.Contains("login"))
                    btn.BackColor = PrimaryColor;
                else
                    btn.BackColor = SecondaryColor;
            }
        }
    }
}
