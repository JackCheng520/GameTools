using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class Jc_IOMgr
{
    static string dir = "D:\\Jack\\";

    public static void Write(string fileName, string data)
    {
        string path = dir + fileName;
        FileStream fs = new FileStream(path, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        //开始写入
        sw.Write(data);
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
    }

    public static void Read(string path)
    {
        StreamReader sr = new StreamReader(path, Encoding.Default);
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line.ToString());
        }
    }

    public static void BufferedRead(string path)
    {
        byte[] bt = new byte[1024];
        BufferedStream s = new BufferedStream(File.Open(path,FileMode.OpenOrCreate));
        int offset = 0;

        string str = "";
        int readInt = 0;
        int len = 64;

        while ((readInt = s.Read(bt, offset, 1)) > 0)
        {
            offset += readInt;
            
        }
        
        s.Close();

        Debug.Log(System.Text.Encoding.Default.GetString(bt));
    }


}

