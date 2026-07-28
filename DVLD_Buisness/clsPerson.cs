using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
namespace DVLD_Buisness
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }; 
        public enum enGender { Male = 0, Female = 1 };

        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            Mode = enMode.AddNew;
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = "";
            Email = "";
            Phone = "";
            NationalityCountryID = -1;
            ImagePath = "";
        }
        private clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, enGender Gender,
            string Address, string Email, string Phone, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gender = (int)enGender.Male;
            string Address = "";
            string Email = "";
            string Phone = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (clsPersonData.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address,
                ref Email, ref Phone, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, (enGender)Gender, Address, Email, Phone, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }
        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gender = (int)enGender.Male;
            string Address = "";
            string Email = "";
            string Phone = "";
            int NationalityCountryID = -1;
            string ImagePath = "";

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref PersonID, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address,
                ref Email, ref Phone, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, (enGender)Gender, Address, Email, Phone, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                (int)Gender, Address, Email, Phone, NationalityCountryID, ImagePath);
            return PersonID != -1;

        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                (int)Gender, Address, Email, Phone, NationalityCountryID, ImagePath);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();

            }
            return false;
        }

        public string GetFullName()
        {
            return $"{FirstName} {SecondName} {ThirdName} {LastName}";
        }
        public static bool Delete(int PersonID)
        {
            return clsPersonData.DeletePersonByID(PersonID);
        }
        public static bool Delete(string NationalNo)
        {
            return clsPersonData.DeletePersonByNationalNo(NationalNo);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
    }
}
