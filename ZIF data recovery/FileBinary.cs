using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIF_data_recovery
{
    public class FileBinary
    {
        // ZIF structure: "ZIF1", WIDTH, HEIGHT, REMAINING-SIZE,"COLR", PALETTE-SIZE, PALETTE-DATA, "DATA", DATA-SIZE, DATA
        
        public List<byte[]> binary = new List<byte[]>(); // To Do: sla ook ZIF1 t/m DATA-SIZE op

        public FileBinary(byte[] bytes)
        {
            SplitBinary(bytes);
        }

        private void SplitBinary(byte[] bytes)
        {
            bool found = false;
            int startIndex = 0;
            string stringToFind = "DATA";
            byte testingbyte = Encoding.ASCII.GetBytes(stringToFind)[2];

            while (!found)
            {
                if (bytes[startIndex] == Encoding.ASCII.GetBytes(stringToFind)[0]) // refactor!
                {
                    if (bytes[startIndex+1] == Encoding.ASCII.GetBytes(stringToFind)[1])
                    {
                        if (bytes[startIndex+2] == Encoding.ASCII.GetBytes(stringToFind)[2])
                        {
                            if (bytes[startIndex+3] == Encoding.ASCII.GetBytes(stringToFind)[3])
                            {
                                startIndex += 7; // skips "DATA" and DATA-SIZE
                                found = true;
                            }
                        }
                    }
                }

                startIndex++;
            }

            binary.Add(bytes.Skip(startIndex).Take((bytes.Length - startIndex)).ToArray()); // neemt alles wat na DATA-Size komt in bytes = RAW pixel Data
        }
    }
}
