using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIF_data_recovery
{
    public class DocumentManager
    {
        //variables
        private string _currentFile;

        private List<byte[]> _fileBinary; // testing

        public DocumentManager()
        {
            //_fileBinary = new List<FileBinary>();
            _fileBinary = new List<byte[]>(); // testing
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool OpenDocument()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "ZuydImage Format | *.zif"
            };

            if (dlg.ShowDialog() == true)
            {
                _currentFile = dlg.FileName;

                using (Stream stream = dlg.OpenFile())
                {
                    // Read stream
                    BinaryReader br = new BinaryReader(stream);

                    // add to fileList
                    _fileBinary.Clear(); // testing
                    _fileBinary.Add(br.ReadBytes((int)stream.Length)); // testing
                }
                return true;
            }
            return false; 
        }

        public bool RecoverDocument()
        {
            // To Do: Start this from AFTER DATA-SIZE

            // fancy stuff
            int width = 800; // To Do: read from file.
            int height = 600; // To Do: read from file.
            byte[] tempBytes = new byte[4];

            // Read bytes
            for (int Ycount = 0; Ycount < height; Ycount++)
            {
                for (int Xcount = 0; Xcount < width; Xcount++)
                {
                    tempBytes[Xcount % 3] = _fileBinary[0][];

                    if (Xcount != 0 && Xcount % 3 == 0)
                    {
                        // controleer of gelijk is aan 0? Zo niet dan teken zwarte pixel
                        if (BitConverter.ToInt32(tempBytes, 0) != 0)
                        {
                            DrawPixel(); // To Do
                        }
                    }
                  
                }
            }

            // raw bitmap

            return true; // testing
        }

        private void DrawPixel()
        {

        }
    }
}
