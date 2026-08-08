using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Helpers
{
    internal class clsUtil
    {
        public static string GenrateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if(!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            FileInfo fi = new FileInfo(sourceFile);
            string extn = fi.Extension;
            return GenrateGUID() + extn;
        }
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if(!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }
            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, DestinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = DestinationFile;
            return true;
        }
    }
}
