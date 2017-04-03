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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZIF_data_recovery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        private DocumentManager _documentManager;
        private DrawingWindow drawingWindow;

        public MainWindow()
        {
            InitializeComponent();
            _documentManager = new DocumentManager();
            drawingWindow = new DrawingWindow();
            drawingWindow.Show();
        }

        private void OpenDocument(object sender, RoutedEventArgs e)
        {
            if (_documentManager.OpenDocument())
            {
                Status.AppendText(_documentManager.CurrentFile + "\r\n");

                ShowDocument();
            }
            else
            {
                MessageBox.Show("Ouch... I couldn't load the file. Is it in use or did you close the previous window?");
            }
        }

        private void ResetBoardClick(object sender, RoutedEventArgs e)
        {
            // Reset Bitmap Drawingboard
            drawingWindow.resetDrawBoard();

            // Reset Loaded Files
            Status.Clear();
        }

        private void ShowDocument()
        {
            if (!drawingWindow.SetDrawing(_documentManager.fileBinary))
            {
                MessageBox.Show("Ouch... I couldn't recover the file :(."); // Doesn't work, yet
            }
        }
    }
}
