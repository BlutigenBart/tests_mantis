//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Net.FtpClient;

//namespace tests_mantis
//{
    //public class FtpHelper : HelperBase
    //{
        //private FtpClient client;
        //public FtpHelper(ApplicationManager manager) : base(manager) 
        //{ 
        //    client = new FtpClient();
        //    client.Host = "localhost";
        //    client.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
        //    client.Connect();
        //}

        //public void BackUpFile(String path)
        //{
        //    String backupPath = path + ".bak";
        //    if (client.FileExists(backupPath)) 
        //    {
        //        return; 
        //    }
        //    client.Rename(path, backupPath);
        //}

        //public void RestoreBackupFile(String path)
        //{
        //    string backupPath = path + ".bak";
        //    //если бэкап не существует то ничего не восстановить
        //    if (! client.FileExists(backupPath))
        //    {
        //        return;
        //    }
        //    //если бэкап существует то нужно удалить имеющийся файл и сделать восстановление
        //    if (client.FileExists(path))
        //    {
        //        client.DeleteFile(path);
        //    }
        //    client.Rename(backupPath, path);
        //}

        //public void Upload(String path, Stream localFile)
        //{
        //    //если бэкап существует то нужно удалить имеющийся файл
        //    if (client.FileExists(path))
        //    {
        //        client.DeleteFile(path);
        //    }

        //    using (Stream FtpStream = client.OpenWrite(path))
        //    {
        //        byte[] buffer = new byte[8 * 1024];
        //        int count = localFile.Read(buffer, 0, buffer.Length);
        //        while (count > 0)
        //        {
        //            FtpStream.Write(buffer, 0, count);
        //            count = localFile.Read(buffer, 0, buffer.Length);
        //        }
        //    }
        //}
    //}
//}
