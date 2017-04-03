using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZIF_data_recovery
{
    /// <summary>
    /// Interaction logic for DrawingWindow.xaml
    /// </summary>
    public partial class DrawingWindow : Window
    {

        //
        private List<byte> bytesPixelEditted;

        public DrawingWindow()
        {
            InitializeComponent();
            bytesPixelEditted = new List<byte>();
        }

        public bool SetDrawing(FileBinary fileBinary)
        {
            // split into 4 bytes // Refactor: shift to FileBinary
            byte[] bytesPixel = new byte[4];

            int count = 0;

            for (int i = 0; i < fileBinary.binary[0].Length; i++)
            {
                bytesPixel[count] = fileBinary.binary[0][i];

                if (count != 0 && count % 3 == 0)
                {
                    // write to bytesPixelEditted
                    if (BitConverter.ToInt32(bytesPixel, 0) != 0)
                    {
                        // zwart maken = 0
                        for (int j = 0; j < 4; j++)
                        {
                            bytesPixelEditted.Add((byte)0);
                        }
                    }
                    else
                    {
                        // wit maken = 255
                        for (int j = 0; j < 4; j++)
                        {
                            bytesPixelEditted.Add((byte)255);
                        }
                    }

                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            DrawBoard(bytesPixelEditted.ToArray<byte>());
            return true; // testing
        }

        //private void DrawPixel(int Xcount, int Ycount, Color color) // Refactor: shift to DrawPicture.cs
        //{
        //    // draw Bitmap


        //}

        private void DrawBoard(byte[] pixelData)
        {
            double dpi = 96;
            int width = 800;
            int height = 600;

            BitmapSource bmpSource = BitmapSource.Create(width, height, dpi, dpi,
                PixelFormats.Gray8, null, pixelData, width);

            image.Source = bmpSource;
        }
    }
}
