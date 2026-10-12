using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            Mode = enMode.AddNew;
            LicenseClassID = -1;
            ClassName = "";
            ClassDescription = "";
            MinimumAllowedAge = 18;
            DefaultValidityLength = 0;
            ClassFees = 0;
        }
        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            Mode = enMode.Update;
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByID(LicenseClassID, ref ClassName,
                ref ClassDescription, ref MinimumAllowedAge,
                ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }

        }

        public static clsLicenseClass FindByName(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            float ClassFees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByName(ClassName, ref LicenseClassID, 
                ref ClassDescription, ref MinimumAllowedAge, 
                ref DefaultValidityLength, ref ClassFees))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            return null;
        }

        private bool _AddNew()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees);

            return (this.LicenseClassID != -1);
        }

        private bool _Update()
        {
            return clsLicenseClassData.UpdateLicenseClass(
                this.LicenseClassID,
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        public static bool Delete(int LicenseClassID)
        {
            return clsLicenseClassData.DeleteLicenseClass(LicenseClassID);
        }


        public static bool IsLicenseClassExist(int LicenseClassID)
        {
            return clsLicenseClassData.IsLicenseClassExist(LicenseClassID);
        }

        public static bool IsLicenseClassExist(string ClassName)
        {
            return clsLicenseClassData.IsLicenseClassExist(ClassName);
        }
    }
}
