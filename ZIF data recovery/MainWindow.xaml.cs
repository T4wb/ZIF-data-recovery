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
            //
            ResetBoard();

            if (_documentManager.OpenDocument())
            {
                Status.Text = _documentManager.CurrentFile + " has been loaded";

                ShowDocument();

                btnSaveFile.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Ouch... I couldn't load the file.\r\nIs it in use or did you close the previous window?");
            }
        }

        private void ResetBoard()
        {
            // Reset Document
            _documentManager.ResetDocument();

            // Reset Bitmap Drawingboard
            drawingWindow.resetDrawBoard();

            // Reset Loaded Files
            Status.Text = "Nothing has been loaded.";

            // Reset Save button
            btnSaveFile.IsEnabled = false;
        }

        private void ShowDocument()
        {
            if (!drawingWindow.SetDrawing(_documentManager.fileBinary))
            {
                MessageBox.Show("Ouch... I couldn't recover the file :(."); // Doesn't work, yet
            }
        }

        private void SaveDocument(object sender, RoutedEventArgs e)
        {
            if (_documentManager.SaveDocument(drawingWindow.wbitmap))
            {
                MessageBox.Show("The image has been saved!");
                ResetBoard();
            }
            else
            {
                MessageBox.Show("Ouch... I couldn't save the file.\r\nDid you close the window :') ?");
            }
            
        }
    }
}
