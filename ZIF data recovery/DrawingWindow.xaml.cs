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

        // variables
        int width = 800;
        int height = 600;

        List<uint> pixels;
        WriteableBitmap bitmap;

        public DrawingWindow()
        {
            InitializeComponent();

            //
            pixels = new List<uint>();
            bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgra32, null);
        }

        public bool SetDrawing(FileBinary fileBinary)
        {
            // 
            byte[] bytesPixel = new byte[4];

            int count = 0;

            int red, green, blue, alpha;
            red = green = blue = alpha = 0;

            for (int i = 0; i < fileBinary.binary[0].Length; i++)
            {
                bytesPixel[count] = fileBinary.binary[0][i];

                if (count != 0 && count % 3 == 0)
                {
                    // write to bytesPixelEditted
                    if (BitConverter.ToInt32(bytesPixel, 0) != 0)
                    {
                        // zwart maken
                        blue = 255;

                        pixels.Add((uint)((blue << 24) + (green << 16) + (red << 8) + alpha));
                    }
                    else
                    {
                        // wit maken
                        blue = 0;

                        pixels.Add((uint)((blue << 24) + (green << 16) + (red << 8) + alpha));
                    }

                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            DrawBoard();
            return true; // testing
        }

        private void DrawBoard()
        {
            bitmap.WritePixels(new Int32Rect(0, 0, 800, 600), pixels.ToArray(), width * 4, 0);
            image.Source = bitmap;
        }
    }
}
