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
        
        public MainWindow()
        {
            InitializeComponent();
            _documentManager = new DocumentManager();
        }

        private void OpenDocument(object sender, RoutedEventArgs e)
        {
            if (_documentManager.OpenDocument())
            {
                // verander status.Text
                // Toon afbeelding:
                RecoverDocument();
            }
            else
            {
                // verander Status.Text in bestand niet geladen
                MessageBox.Show("Ouch... I couldn't load the file. Is it in use or did you close the previous window?");
            }
            // Load file
            // Add status: File X loaded in Status Textbox: misschien een andere type control gebruiken?
        }

        private void ResetBoardClick(object sender, RoutedEventArgs e)
        {
            // Reset Bitmap Drawingboard
            // Reset Loaded Files
            // Reset Status Textbox
        }

        private void RecoverDocument()
        {
            // To Do: RecoverDocument
            if (_documentManager.RecoverDocument())
            {
                // return true;
            }
            else
            {
                // return false;
            }
        }
    }
}
