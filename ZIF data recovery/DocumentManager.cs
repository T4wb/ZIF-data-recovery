﻿using Microsoft.Win32;
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

        public FileBinary fileBinary { get; set; }

        //public DocumentManager()
        //{
        //    // create Bitmap
        //    createBitmap();
        //}

        //private void createBitmap()
        //{
        //    // To Do
        //}

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
    }
}
