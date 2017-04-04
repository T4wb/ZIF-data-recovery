using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZIF_data_recovery
{
    public class DocumentManager
    {
        // variables
        public string CurrentFile { get; set; }

        public FileBinary fileBinary { get; set; }

        /// <summary>
        /// This method opens the ZIF-file.
        /// </summary>
        /// <returns>Returns a status boolean value of the file opening proces </returns>
        public bool OpenDocument()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "ZuydImage Format | *.zif"
            };

            if (dlg.ShowDialog() == true)
            {

                if (Path.GetExtension(dlg.FileName) != ".zif")
                {
                    return false;
                }

                CurrentFile = Path.GetFileName(dlg.FileName);

                using (Stream stream = dlg.OpenFile())
                {
                    // Read stream
                    BinaryReader br = new BinaryReader(stream);

                    // add to fileList
                    fileBinary = new FileBinary(br.ReadBytes((int)stream.Length));
                }

                return true;
            }

            return false; 
        }

        public bool SaveDocument(WriteableBitmap bitmap)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "Portable Network Graphics | *.png"
            };

            if (dlg.ShowDialog() == true)
            {
                CurrentFile = dlg.FileName;

                // save file
                using (FileStream stream = new FileStream(CurrentFile, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmap));
                    encoder.Save(stream);
                }

                return true;
            }

            return false;
        }

        public void ResetDocument()
        {
            // resets
            fileBinary = null;
            CurrentFile = null;
        }
    }
}
