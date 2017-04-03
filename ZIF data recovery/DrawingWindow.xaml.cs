using System;
using System.Collections.Generic;
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
        private WriteableBitmap _wbitmap;

        public DrawingWindow()
        {
            InitializeComponent();
        }
        public void SetDrawing()
        {
            //image.Source = bitmap;
        }

        public bool RecoverDocument(FileBinary fileBinary)
        {
            // split into 4 bytes // Refactor: shift to FileBinary
            byte[] bytesPixel = new byte[4]; // Refactor: other data structure as you're Array writing action costs speed!

            int count = 0; // Refactor: use i%3 instead 
            int Xcount = 0; // Refactor: this is i
            int Ycount = 0;

            for (int i = 0; i < fileBinary.binary[0].Length; i++)
            {
                bytesPixel[count] = fileBinary.binary[0][i];

                if (i != 0 && i % 4 == 0)
                {
                    // check
                    if (BitConverter.ToInt32(bytesPixel, 0) != 0)
                    {
                        // SetPixel(Black)
                    }

                    // x,y coordinate of pixel
                    if (Xcount == 800 * 4) // Width
                    {
                        Ycount++; // May write out of bounce/picture as the max is 600
                        Xcount = 0;
                    }

                    // 
                    count = 0;
                }
                Xcount++;
            }

            return true; // testing
        }

        private void DrawPixel(int Xcount, int Ycount) // Refactor: shift to DrawPicture.cs
        {
            // draw Bitmap
        }

    }
}
