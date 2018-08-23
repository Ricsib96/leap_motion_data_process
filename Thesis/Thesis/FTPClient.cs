using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Thesis
{
    class FTPClient
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public FTPClient(string username, string password, string host, int port)
        {
            this.UserName = username;
            this.Password = password;
            this.Host = host;
            this.Port = port;
        }
        public void upload(string remoteFile, string localFile)
        {
            try
            {
                /* Create an FTP Request */
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(UserName, Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                Stream ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFile, FileMode.Open);
                /* Buffer for the Downloaded Data */
                int bufferSize = 2048;
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null; 
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        public void createDir(string dirName)
        {
            try
            {
                /* Create an FTP Request */
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(Host + "/" + dirName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(UserName, Password);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                using (var resp = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

    }
}
