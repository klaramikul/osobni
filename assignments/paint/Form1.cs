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
        // Inicializace promennych a nastaveni platna
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
        private Rectangle imageRect;
        private bool isResizingImage = false;
        private bool moveModeActive = false;
        private bool isMoving = false;
        private Point moveOffset;
        private const int handleSize = 10;

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

        // Sprava souboru: nacitani obrazku a cisteni platna
        #region File Management
        private void LoadImage(object sender, EventArgs e) //otevreni obrazku
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.bmp" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadedImage = Image.FromFile(openFileDialog.FileName);
                    int availableWidth = picBox.Width;
                    int availableHeight = picBox.Height;
                    double scaleX = (double)availableWidth / loadedImage.Width;
                    double scaleY = (double)availableHeight / loadedImage.Height;
                    double scale = Math.Min(scaleX, scaleY);
                    int newWidth = (int)(loadedImage.Width * scale);
                    int newHeight = (int)(loadedImage.Height * scale);
                    int x = (availableWidth - newWidth) / 2;
                    int y = (availableHeight - newHeight) / 2;
                    imageRect = new Rectangle(x, y, newWidth, newHeight);
                    picBox.Invalidate();
                }
            }
        }
        private void ClearCanvas(object sender, EventArgs e) //smazani
        {
            g.Clear(Color.White);
            loadedImage = null;
            imageRect = Rectangle.Empty;
            picBox.Invalidate();
        }
        #endregion

        // Sprava barev: volba barvy pomoci ColorDialog a nastaveni barvy pera
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

        // Volba rezimu kresleni: kresleni car, obdelniku, elipsy, apod.
        #region Draw Modes
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

        // Logika kresleni: obsluha MouseDown, MouseMove, MouseUp a vykreslovani vseho na platno
        #region Drawing Logic
        private void PicBox_Paint(object sender, PaintEventArgs e) // Vykresleni bitmapy a vlozeneho obrazku s handle
        {
            e.Graphics.DrawImage(bitmap, Point.Empty);
            if (loadedImage != null)
            {
                e.Graphics.DrawImage(loadedImage, imageRect);
                Rectangle handleRect = new Rectangle(imageRect.Right - handleSize, imageRect.Bottom - handleSize, handleSize, handleSize);
                e.Graphics.FillRectangle(Brushes.Red, handleRect);
            }
        }
        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (loadedImage != null && !moveModeActive)
            {
                Rectangle handleRect = new Rectangle(imageRect.Right - handleSize, imageRect.Bottom - handleSize, handleSize, handleSize);
                if (handleRect.Contains(e.Location))
                {
                    isResizingImage = true;
                    return;
                }
            }

            if (moveModeActive && imageRect.Contains(e.Location))
            {
                isMoving = true;
                moveOffset = new Point(e.X - imageRect.X, e.Y - imageRect.Y);
                return;
            }

            lastPoint = e.Location;
            isDrawing = true;
            isShapeDrawing = drawMode != "line";
        }

        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                imageRect = new Rectangle(e.X - moveOffset.X, e.Y - moveOffset.Y, imageRect.Width, imageRect.Height);
                picBox.Invalidate();
                return;
            }
            if (isResizingImage)
            {
                int newWidth = e.X - imageRect.X;
                int newHeight = e.Y - imageRect.Y;
                if (newWidth > 10 && newHeight > 10)
                {
                    imageRect.Size = new Size(newWidth, newHeight);
                    picBox.Invalidate();
                }
                return;
            }

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
            if (isMoving)//pokud hybal, ukoncime
            {
                isMoving = false;
                return;
            }
            if (isResizingImage) //pokud menil velikost, ukoncime
            {
                isResizingImage = false;
                return;
            }
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
        #endregion

        // Obsluha ovladacich prvku: tlacitka pro barvy, smazani, otevreni, ulozeni, posun, resize,...
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
        private void btnMove_Click(object sender, EventArgs e)
        {
            moveModeActive = !moveModeActive;
            btnMove.Text = moveModeActive ? "Move: ON" : "Move: OFF"; //zdroj Chat GPT
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
