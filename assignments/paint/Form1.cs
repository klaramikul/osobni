using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace paint
{
    public partial class PaintApp : Form
    {
        #region Initialization
        private Bitmap bitmap;
        private Graphics g;
        private Pen pen;
        private bool isDrawing = false;
        private Point lastPoint;
        private string drawMode = "line";
        private Image loadedImage;
        private Color selectedColor = Color.Black;
        private Rectangle tempShape;
        private bool isShapeDrawing = false;

        public PaintApp()
        {
            InitializeComponent();
            InitPainting();
        }

        public void InitPainting()
        {
            bitmap = new Bitmap(800, 500);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            pen = new Pen(selectedColor, 3)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round
            };

            picBox.Image = bitmap;
            picBox.BackColor = Color.White;
            picBox.Paint += PicBox_Paint;
            picBox.MouseDown += PicBox_MouseDown;
            picBox.MouseMove += PicBox_MouseMove;
            picBox.MouseUp += PicBox_MouseUp;
        }
        #endregion

        #region File Management
        private void LoadImage(object sender, EventArgs e) //otevreni obrazku
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.bmp" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedImage = Image.FromFile(openFileDialog.FileName);
                    using (Graphics gTemp = Graphics.FromImage(bitmap))
                    {
                        gTemp.DrawImage(loadedImage, new Point(0, 0)); 
                    }
                    picBox.Invalidate();
                }
            }
        }
        private void ClearCanvas(object sender, EventArgs e) //smazani
        {
            g.Clear(Color.White);
            picBox.Invalidate();
        }
        #endregion

        #region Color Management
        private void SelectColor(object sender, EventArgs e) //barevny dialog
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                    pen.Color = selectedColor;
                }
            }
        }
        private void SetColor(Color color)
        {
            selectedColor = color;
            pen.Color = selectedColor;
        }
        #endregion

        #region Draw Modes
        //druh malovani
        private void btnPencil_Click(object sender, EventArgs e)
        {
            drawMode = "line";
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            drawMode = "rectangle";
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            drawMode = "ellipse";
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            drawMode = "fill";
        }
        #endregion

        #region Drawing Logic
        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isDrawing = true;
            isShapeDrawing = drawMode != "line";
        }

        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            if (drawMode == "line")
            {
                using (Graphics gTemp = Graphics.FromImage(bitmap))
                {
                    gTemp.DrawLine(pen, lastPoint, e.Location);
                    lastPoint = e.Location;
                }
            }
            else
            {
                tempShape = new Rectangle(
                    Math.Min(lastPoint.X, e.X),
                    Math.Min(lastPoint.Y, e.Y),
                    Math.Abs(e.X - lastPoint.X),
                    Math.Abs(e.Y - lastPoint.Y)
                );
            }

            picBox.Invalidate();
        }

        private void PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;

            if (isShapeDrawing)
            {
                using (Graphics gTemp = Graphics.FromImage(bitmap))
                {
                    if (drawMode == "rectangle")
                    {
                        if (chckBxShps.Checked)
                            gTemp.FillRectangle(new SolidBrush(selectedColor), tempShape);
                        else
                            gTemp.DrawRectangle(pen, tempShape);
                    }
                    else if (drawMode == "ellipse")
                    {
                        if (chckBxShps.Checked)
                            gTemp.FillEllipse(new SolidBrush(selectedColor), tempShape);
                        else
                            gTemp.DrawEllipse(pen, tempShape);
                    }
                }
            }

            picBox.Invalidate();
        }
        private void PicBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, Point.Empty);
        }
        #endregion

        #region UI Event Handlers
        #region Color Buttons
        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            SelectColor(sender, e);
        }


        private void btnRed_Click(object sender, EventArgs e)
        {
            SetColor(Color.IndianRed);
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            SetColor(Color.SandyBrown);
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            SetColor(Color.Khaki);
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            SetColor(Color.Pink);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            SetColor(Color.DarkSeaGreen);
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            SetColor(Color.PowderBlue);
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            SetColor(Color.MediumPurple);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            SetColor(Color.Black);
        }
        #endregion
        private void btnBin_Click(object sender, EventArgs e)
        {
            ClearCanvas(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            LoadImage(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e) //ulozeni obrazku
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save an Image File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile())
                    {
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case 2:
                                bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                        }
                    }
                }
            }
        }

        private void trckB1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trckB1.Value;
        }

        private void btnErease_Click(object sender, EventArgs e)
        {
            SetColor(Color.White);
        }

        #endregion
    }
}
