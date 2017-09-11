using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS669GevandBalayanHomework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string fileName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\test.jpg");
            if (System.IO.File.Exists(fileName))
            {
                pictInput.Image = new Bitmap(fileName);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {

                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        pictInput.Image = new Bitmap(dlg.FileName);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Error! Couldn't load image.");
            }
        }

        private void pictInput_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
        }
        float boxSize = 8;
        private void pictInput_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            Point local = this.PointToClient(Cursor.Position);
            e.Graphics.DrawRectangle(Pens.Black, local.X - 15, local.Y - 65, boxSize, boxSize);
            btnUpload.Refresh();
            pictInput.Invalidate();

        }

        private void pictInput_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void pictInput_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void pictInput_MouseUp(object sender, MouseEventArgs e)
        {
            var bitMap = new Bitmap(pictInput.Image);
            try
            {
                Color?[,] pixels = new Color?[8, 8];
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        var myX = 0;
                        var myY = 0;

                        if (i > 4)
                            myX = e.X + (i - 4);
                        if (i <= 4)
                            myX = e.X - (-1 * i + 4);
                        if (j > 4)
                            myY = e.Y + (j - 4);
                        if (j <= 4)
                            myY = e.Y - (-1 * j + 4);

                        if (myX > 0 && myY > 0 && myX < bitMap.Width && myY < bitMap.Height)
                        {
                            var pixel = bitMap.GetPixel(myX, myY);
                            pixels[i, j] = Color.FromArgb(pixel.R, pixel.G, pixel.B);


                        }
                        else
                        {
                            pixels[i, j] = null;
                        }
                    }
                GenerateNewForm(pixels, "Red");
                GenerateNewForm(pixels, "Green");
                GenerateNewForm(pixels, "Blue");
                Form tempForm = new Form();
                tempForm.Height = 200;
                tempForm.Width = 200;
                tempForm.Text = "Image";
                PictureBox tempBox = new PictureBox();
                tempBox.Height = 200;
                tempBox.Width = 200;
                Bitmap tempBitMap = new Bitmap(8, 8);
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (pixels[i, j].HasValue)
                            tempBitMap.SetPixel(i, j, pixels[i, j].Value);
                    }
                }
                tempBox.Image = tempBitMap;
                tempBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                tempForm.Controls.Add(tempBox);
                tempForm.Show();
            }
            catch { MessageBox.Show("Could not get pixel information"); }
        }
        private void GenerateNewForm(Color?[,] pixels, string title)
        {

            Form tempForm = new Form();
            tempForm.Height = 200;
            tempForm.Width = 200;
            tempForm.Text = title;
            Label myView = new Label();
            myView.Height = tempForm.Height;
            myView.Width = tempForm.Width;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pixels[i, j].HasValue)
                        if (title == "Red")
                            myView.Text += pixels[i, j].Value.R + " ";
                        else if (title == "Green")
                            myView.Text += pixels[i, j].Value.G + " ";
                        else
                            myView.Text += pixels[i, j].Value.B + " ";
                    else
                        myView.Text += "N";
                }
                myView.Text += Environment.NewLine;
            }
            tempForm.Controls.Add(myView);
            tempForm.Show();

        }
    }
}
