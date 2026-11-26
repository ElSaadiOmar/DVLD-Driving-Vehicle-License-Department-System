using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 }
        public enum enApplicationType {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public int ApplicationID { get; protected set; }
        public int ApplicantPersonID { get; set; }
        public string ApplicantFullName { get { return clsPerson.Find(ApplicantPersonID).FullName; } }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        
        public clsApplicationType ApplicationTypeInfo { get; protected set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo { get;protected set; }
        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.Find(CreatedByUserID);
            Mode = enMode.Update;
        }
        static public clsApplication FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = (byte)enApplicationStatus.New;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            if (clsApplicationData.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                    (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null; // No application found for the given ApplicationID
            }
        }
        static public clsApplication FindByApplicantPersonIDAndLicenseClassID(int ApplicantPersonID, int LicenseClassID)
        {
            int ApplicationID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = (byte)enApplicationStatus.New;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;
            if (clsApplicationData.GetApplicationInfoByApplicantPersonIDAndLicenseClassID(ApplicantPersonID, LicenseClassID, ref ApplicationID,
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,
                    (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null; // No application found for the given ApplicantPersonID and LicenseClassID
            }
        }
     

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, CreatedByUserID);
            return this.ApplicationID != -1;
        }
        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update; // Change mode to Update after successful addition
                        return true;
                    }
                    else
                    {
                        // If the ApplicationID is not -1, it means the application already exists, so we should update it instead of adding a new one.
                        return false; // Application already exists, cannot add new
                    }
                case enMode.Update:
                    return _UpdateApplication();

            }
            return false; // Invalid mode
        }
        public  bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }
        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (int)enApplicationStatus.Cancelled);
        }
        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (int)enApplicationStatus.Completed);
        }
    }
}
