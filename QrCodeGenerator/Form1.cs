using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace QrCodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodeQrBarcodeDraw brcode = BarcodeDrawFactory.CodeQr;
            QrImage.Image = brcode.Draw(QrTextBox.Text, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            };
            save.ShowDialog();

            FileStream fs = (FileStream)save.OpenFile();

            if (save.FileName != "")
            {
                switch (save.FilterIndex)
                {
                    case 1:
                        QrImage.Image.Save(fs,
                           ImageFormat.Jpeg);
                        break;

                    case 2:
                        QrImage.Image.Save(fs,
                           ImageFormat.Bmp);
                        break;

                    case 3:
                        QrImage.Image.Save(fs,
                           ImageFormat.Gif);
                        break;
                }
            }
            fs.Close();
        }
    }
}
