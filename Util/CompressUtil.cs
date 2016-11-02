using UnityEngine;
using System.Collections;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using System;
namespace Game.Util {
    public class CompressUtil{

        public static string Zip(string value)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(value);
            byte[] tmpArray;

            MemoryStream ms = new MemoryStream();

            GZipOutputStream sw = new GZipOutputStream(ms);

            sw.Write(byteArray, 0, byteArray.Length);
            sw.Flush();

            tmpArray = ms.ToArray();
            return Convert.ToBase64String(tmpArray);
        }

        public static byte[] Decompress(byte[] bytInput)  
        {

            byte[] writeData = new byte[4096];
            GZipInputStream s2 = new GZipInputStream(new MemoryStream(bytInput));
            MemoryStream outStream = new MemoryStream();

            while (true)
            {
                int size = s2.Read(writeData, 0, writeData.Length);
                if (size > 0)
                {
                    outStream.Write(writeData, 0, size);
                }
                else
                {
                    break;
                }
            }
            s2.Close();
            byte[] outArr = outStream.ToArray();
            outStream.Close();
            return outArr;
        }     
    }  
    
}
