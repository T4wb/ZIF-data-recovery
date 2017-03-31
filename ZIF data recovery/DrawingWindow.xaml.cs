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

        public DrawingWindow()
        {
            InitializeComponent();
        }
        public void SetDrawing(byte[] fileBinary)
        {

            var width = 800;
            var height = 600; 
            var dpiX = 96d;
            var dpiY = 96d;
            var pixelFormat = PixelFormats.Bgra32;
            var bytesPerPixel = 4;
            var stride = bytesPerPixel * width;


            var bitmap = BitmapSource.Create(width, height, dpiX, dpiY,
                                             pixelFormat, null, fileBinary, stride);
            image.Source = bitmap;
            
        }

    }
}
