using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Helpers
{
    internal class clsUtil
    {
        public static string GenrateGUID()
        {
            return Guid.NewGuid().ToString();
        }
        //public static bool CreateFolderIfDoesNotExist(string FolderPath)
        //{

        //}
        //public static string ReplaceFileNameWithGUID(string sourceFile)
        //{

        //}
        //public static bool CopyImageToProjectImagesFolder(string FolderPath)
        //{

        //}
    }
}
