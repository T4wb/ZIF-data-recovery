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

        private List<FileBinary> _fileBinary;

        public DocumentManager()
        {
            _fileBinary = new List<FileBinary>();
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
                    _fileBinary.Add(new FileBinary(br.ReadBytes((int)stream.Length)));
                }
                return true;
            }
            return false; 
        }

        public bool RecoverDocument()
        {
            // fancy stuff
            return true; // testing
        }
    }
}
