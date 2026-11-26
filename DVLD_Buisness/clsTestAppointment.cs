
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode;
        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }
        public clsTestType TestTypeInfo { get; private set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplicationInfo { get; private set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsLocked { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get; private set; }
        public int? RetakeTestApplicationID { get; set; }
        public int TestID { get { return _GetTestID(); } }
        public clsApplication RetakeTestApplicationInfo { get; set; }

        public clsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = clsTestType.enTestType.VisionTest;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            IsLocked = false;
            PaidFees = 0.0f;
            CreatedByUserID = -1;
            RetakeTestApplicationID = null;
            Mode = enMode.AddNew;
        }
        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, bool IsLocked, float PaidFees, int CreatedByUserID, int? RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.TestTypeInfo = clsTestType.Find(TestTypeID);
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LocalDrivingLicenseApplicationInfo = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            this.AppointmentDate = AppointmentDate;
            this.IsLocked = IsLocked;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = RetakeTestApplicationID != null ? clsApplication.FindBaseApplication((int)RetakeTestApplicationID) : null;
            Mode = enMode.Update;
        }

        public static clsTestAppointment FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int TestAppointmentID = -1;
            int TestTypeID = (int)clsTestType.enTestType.VisionTest;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;
            float PaidFees = 0.0f;
            int CreatedByUserID = -1;
            int? RetakeTestApplicationID = null;
            if (clsTestAppointmentData.GetTestAppointmentByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID, ref TestAppointmentID, ref TestTypeID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    IsLocked, PaidFees, CreatedByUserID, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }
        public static clsTestAppointment FindByAppointmentID(int AppointmentID)
        {
            int TestTypeID = (int)clsTestType.enTestType.VisionTest;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            bool IsLocked = false;
            float PaidFees = 0.0f;
            int CreatedByUserID = -1;
            int? RetakeTestApplicationID = null;

            if (clsTestAppointmentData.GetTestAppointmentByAppointmentID(AppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(AppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                    IsLocked, PaidFees, CreatedByUserID, RetakeTestApplicationID);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestType)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestType);
        }

        public static bool DeleteTestAppoinment(int TestAppointmentID)
        {
            return clsTestAppointmentData.DeleteTestAppointment(TestAppointmentID);
        }

        private bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment((int)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            return TestAppointmentID != -1;
        }
        private bool _Update()
        {
            return clsTestAppointmentData.UpdateTestAppointment(TestAppointmentID, (int)TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
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
            }
            return false;
        }
        private int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }
    }
}
