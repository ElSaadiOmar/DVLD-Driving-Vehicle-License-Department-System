using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        private clsTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }
        public clsTestType()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
        }
        public static clsTestType Find(int TestTypeID)
        {
            string TestTypeTitle = string.Empty;
            string TestTypeDescription = string.Empty;
            float TestTypeFees = 0;
            if (clsTestTypeData.GetTestTypeByID(TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        public bool Save()
        {
            return _UpdateTestType();
        }
    }
}
