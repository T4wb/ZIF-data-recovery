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

        private FileBinary fileBinary;

        public DocumentManager()
        {
            // create Bitmap
            createBitmap();
        }

        private void createBitmap()
        {
            // To Do
        }

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
                _currentFile = dlg.FileName;

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

        public bool RecoverDocument()
        {
            // split into 4 bytes // Refactor: shift to FileBinary
            byte[] bytesPixel = new byte[4]; // Refactor: other data structure as you're Array writing action costs speed!

            int count = 0; // Refactor: use i%3 instead 
            int Xcount = 0; // Refactor: this is i
            int Ycount = 0;

            for (int i = 0; i < fileBinary.binary[0].Length; i++)
            {
                bytesPixel[count] = fileBinary.binary[0][i];

                if (i != 0 && i % 4 == 0 )
                {
                    // check
                    if (BitConverter.ToInt32(bytesPixel, 0) != 0)
                    {
                        // SetPixel(Black)
                    }
                    else
                    {
                        // SetPixel(White)
                        
                    }

                    // x,y coordinate of pixel
                    if (Xcount == 800*4) // Width
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
