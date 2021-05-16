using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LowKeyPaintOnWinForms
{
    public partial class LowKeyPaint : Form
    {
        public LowKeyPaint()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            bitmap = new Bitmap(canvas.Width, canvas.Height);

        }

        private enum instrument
        {
            pen,
            line,
            rect,
            ellipse,
            erase,
            none
        }

        private float thickness = 5;
        private Point startpoint;
        private Bitmap bitmap;
        private instrument selected_instrument = instrument.pen;
        private Rectangle windowsize;
        private Color selectedColor;
        private List<Point> linePoints = new List<Point>();
        private int pictureboxheight;
        private int pictureboxwidth;
        private double sensitivity = 50;

        private bool isinbounds(int a, int b)
        {
            bool ok = false;
            if (a > 0 && b > 0 && a < pictureboxwidth-1 && b < pictureboxheight-1)
                ok = true;
            return ok;
        }

        private bool colorcmp (Color A, Color B)
        {
            if ( Math.Abs(A.R - B.R) < sensitivity && Math.Abs(A.G - B.G) < sensitivity && Math.Abs(A.B - B.B) < sensitivity)
            {
                if (Math.Abs(A.A - B.A) < sensitivity)
                { return true; }
                else return false;
            }
            else return false;
        }

        private void pen_Click(object sender, EventArgs e)
        {   selected_instrument = instrument.pen;       }

        private void line_Click(object sender, EventArgs e)
        {   selected_instrument = instrument.line;      }

        private void square_Click(object sender, EventArgs e)
        {   selected_instrument = instrument.rect;      }

        private void circle_Click(object sender, EventArgs e)
        {   selected_instrument = instrument.ellipse;   }

        private void eraser_Click(object sender, EventArgs e)
        {   selected_instrument = instrument.erase;     }

        private void LowKeyPaint_Load(object sender, EventArgs e)
        {
            int widthOfCanvas = 1200;
            int heightOfCanvas = 600;
            pictureboxwidth = Convert.ToInt32(widthOfCanvas);
            pictureboxheight = Convert.ToInt32(heightOfCanvas);
            bitmap = new Bitmap(pictureboxwidth, pictureboxheight);
            windowsize = new Rectangle(0, 0, pictureboxwidth, pictureboxheight);
            selectedColor = Color.Black;
        }

        private void color_Click(object sender, EventArgs e)
        {
                ColorDialog MyDialog = new ColorDialog();
   
                MyDialog.AllowFullOpen = false;
                MyDialog.ShowHelp = true;
                if (MyDialog.ShowDialog() == DialogResult.OK)
                selectedColor = MyDialog.Color;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (selected_instrument == instrument.pen || selected_instrument == instrument.line)
            {
                if (linePoints.Count > 1)
                using (var pen = new Pen(selectedColor, thickness) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                        e.Graphics.DrawLines(pen, linePoints.ToArray());
            }
            else if (selected_instrument == instrument.erase)
            {
                if (linePoints.Count > 1)
                    using (var pen = new Pen( Color.White , thickness) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                        e.Graphics.DrawLines(pen, linePoints.ToArray());
            }
            else if (selected_instrument == instrument.rect || selected_instrument == instrument.ellipse)
            {
                if (linePoints.Count > 1)
                {
                    Point[] pointlist = linePoints.ToArray();
                    Point A = pointlist[0];
                    Point B = pointlist[1];
                    int xmin;
                    int xmax;
                    int ymin;
                    int ymax;

                    if (A.X > B.X)
                    { xmin = B.X; xmax = A.X; }
                    else
                    { xmin = A.X; xmax = B.X; }

                    if (A.Y > B.Y)
                    { ymin = B.Y; ymax = A.Y; }
                    else
                    { ymin = A.Y; ymax = B.Y; }
                    if (selected_instrument == instrument.rect)
                    {
                        Rectangle rect_todraw = new Rectangle();

                        rect_todraw = new Rectangle(xmin, ymin, Math.Abs(A.X - B.X), Math.Abs(A.Y - B.Y));

                        using (var pen = new Pen(selectedColor, thickness) )
                                e.Graphics.DrawRectangle (pen, rect_todraw);
                    }
                    else
                        if (selected_instrument == instrument.ellipse)
                        {
                            Rectangle rect_todraw = new Rectangle();

                            rect_todraw = new Rectangle(xmin, ymin, Math.Abs(A.X - B.X), Math.Abs(A.Y - B.Y));

                            using (var pen = new Pen(selectedColor, thickness))
                                e.Graphics.DrawEllipse (pen, rect_todraw);
                        }

                }
            }

            if (selected_instrument == instrument.line || selected_instrument == instrument.rect || selected_instrument == instrument.ellipse)
            {
                linePoints.Clear();
                linePoints.Add(startpoint);
            }

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            linePoints.Clear();

            if (selected_instrument == instrument.line || selected_instrument == instrument.rect
                || selected_instrument == instrument.ellipse || selected_instrument == instrument.pen
                || selected_instrument == instrument.erase)
            {
                if (e.Button == MouseButtons.Left)
                {
                    linePoints.Add(e.Location);
                    startpoint = e.Location;
                }
            }

        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected_instrument == instrument.pen || selected_instrument == instrument.erase
                || selected_instrument == instrument.line
                || selected_instrument == instrument.rect || selected_instrument == instrument.ellipse)
            {
                if (e.Button == MouseButtons.Left)
                {
                    linePoints.Add(e.Location);
                    canvas.Invalidate();
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (selected_instrument == instrument.pen || selected_instrument == instrument.erase)
            {
                canvas.Invalidate();
            }
            else if (selected_instrument == instrument.line)
            {
                if (e.Button == MouseButtons.Left)
                {
                    canvas.DrawToBitmap(bitmap, windowsize);
                    linePoints.Add(e.Location);
                }
            }
            else if (selected_instrument == instrument.rect || selected_instrument == instrument.ellipse)
            {
                linePoints.Add(e.Location);
            }
            canvas.DrawToBitmap(bitmap, windowsize);
            canvas.Image = bitmap;
        }


        private void thicknessScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            thickness = thicknessScrollBar.Value;
            thicknessValue.Text = Convert.ToString(thickness);
        }

        private void widthOfCanvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void heightOfCanvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if (canvas.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Save image as...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (savedialog.Filter.Contains("BMP"))
                        {
                            canvas.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                        else if (savedialog.Filter.Contains("JPG"))
                        {
                            canvas.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        }
                        else if (savedialog.Filter.Contains("PNG"))
                        {
                            canvas.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Can't save file", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            Bitmap image; 

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    this.canvas.Size = image.Size;
                    canvas.Image = image;
                    canvas.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Can't open choosen file",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cleanCanvas_Click(object sender, EventArgs e)
        {
            canvas.Image = null;
        }


    }
}
