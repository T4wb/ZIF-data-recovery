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
        int dpi = 96;

        List<uint> pixels;
        public WriteableBitmap wbitmap { get; set; }

        public DrawingWindow()
        {
            InitializeComponent();
            pixels = new List<uint>();
            wbitmap = new WriteableBitmap(width, height, dpi, dpi, PixelFormats.Bgra32, null);
        }

        /// <summary>
        /// Sets DrawingBoard
        /// </summary>
        /// <param name="fileBinary"></param>
        /// <returns>Returns statusvalue of drawing process</returns>
        public bool SetDrawing(FileBinary fileBinary)
        {
            //
            resetDrawBoard();

            // variables
            byte[] bytesPixel = new byte[4];

            int count = 0;
            int red, green, blue, alpha;
            red = green = blue = alpha = 0;

            for (int i = 0; i < fileBinary.binary[0].Length; i++)
            {
                bytesPixel[count] = fileBinary.binary[0][i];

                if (count != 0 && count % 3 == 0)
                {
                    blue = BitConverter.ToInt32(bytesPixel, 0) != 0
                        ? 255 // zwarte pixel
                        : 0; // witte pixel

                    pixels.Add((uint)((blue << 24) + (green << 16) + (red << 8) + alpha));
                    count = 0;
                }
                else { count++; }
            }

            pixels.Add(pixels[0]);
            //
            DrawBoard();
            return true; // testing
        }

        /// <summary>
        /// Resets the Drawboard window.
        /// </summary>
        public void resetDrawBoard()
        {
            image.Source = null;
            pixels.Clear();
            wbitmap = new WriteableBitmap(width, height, dpi, dpi, PixelFormats.Bgra32, null);
        }

        private void DrawBoard()
        {
            wbitmap.WritePixels(new Int32Rect(0, 0, width, 600), pixels.ToArray(), width * 4, 0);
            image.Source = wbitmap;
        }
    }
}
