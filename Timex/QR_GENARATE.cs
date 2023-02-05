using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;


namespace Timex
{
    public partial class QR_GENARATE : MetroFramework.Forms.MetroForm
    {
        
        public QR_GENARATE()
        {
            InitializeComponent();
        }

        private void QR_GENARATE_Load(object sender, EventArgs e)
        {
            input.Text = Form1.id;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            BarcodeWriter qrWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width =300 , Height =300 , Margin = 0 , PureBarcode = false};
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            qrWriter.Renderer = new BitmapRenderer();
            qrWriter.Options = encodingOptions;
            qrWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = qrWriter.Write(input.Text);
            OLD_QR.Image = bitmap;

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            SaveFileDialog imagesave = new SaveFileDialog();
            imagesave.Filter = "JPG(*.JPG)|*.jpg";

            if (imagesave.ShowDialog() == DialogResult.OK)
            {
                OLD_QR.Image.Save(imagesave.FileName);
            }
        }
    }
}
