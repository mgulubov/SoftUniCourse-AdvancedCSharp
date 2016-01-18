using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuncProgramm
{
    class Student
    {
        private String _firstName;
        private String _lastName;
        private String _phone;
        private String _email;
        private int _age;
        private int _facultyNumber;
        private IList<int> _marks;
        private int _groupNumber;

        public Student(String firstName, String lastName, String phone, String email,
                        int age, int facultyNumber, IList<int> marks, int groupNumber)
        {
            this.SetFirstName(firstName);
            this.SetLastName(lastName);
            this.SetPhone(phone);
            this.SetEmail(email);
            this.SetAge(age);
            this.SetFacultyNumber(facultyNumber);
            this.SetMarks(marks);
            this.SetGroupNumber(groupNumber);
        }

        public void SetFirstName(String name)
        {
            if (name == null)
            {
                throw new ArgumentException("First Name can't be null");
            }

            this._firstName = name;
        }

        public void SetLastName(String name)
        {
            if (name == null)
            {
                throw new ArgumentException("Last Name can't be null");
            }

            this._lastName = name;
        }

        public void SetPhone(String phone)
        {
            if (phone == null)
            {
                throw new ArgumentException("Phone can't be null");
            }

            if (!PhoneIsValid(phone))
            {
                throw new ArgumentException("Invalid phone provided");
            }

            this._phone = phone;
        }

        public void SetEmail(String email)
        {
            if (email == null)
            {
                throw new ArgumentException("Email can't be null");
            }

            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid Email provided");
            }

            this._email = email;
        }

        public void SetAge(int age)
        {
            if (!IsValidAge(age))
            {
                throw new ArgumentException("Invalid Age provided");
            }

            this._age = age;
        }

        public void SetFacultyNumber(int facultyNumber)
        {
            if (!IsValidFacultyNumber(facultyNumber))
            {
                throw new ArgumentException("Invalid Faculty Number provided");
            }

            this._facultyNumber = facultyNumber;
        }

        public void SetMarks(IList<int> marks)
        {
            if (marks == null)
            {
                throw new ArgumentException("Marks List can't be null");
            }

            this._marks = marks;
        }

        public void SetGroupNumber(int groupNumber)
        {
            if (!IsValidGroupNumber(groupNumber))
            {
                throw new ArgumentException("Invalid Group Number provided");
            }

            this._groupNumber = groupNumber;
        }

        public String GetFirstName()
        {
            return this._firstName;
        }

        public String GetLastName()
        {
            return this._lastName;
        }

        public String GetPhone()
        {
            return this._phone;
        }

        public String GetEmail()
        {
            return this._email;
        }

        public int GetAge()
        {
            return this._age;
        }

        public int GetFacultyNumber()
        {
            return this._facultyNumber;
        }

        public IList<int> GetMarks()
        {
            return this._marks;
        }

        public int GetGroupNumber()
        {
            return this._groupNumber;
        }

        private bool PhoneIsValid(String phone)
        {
            String pattern = @"([0-9+])([0-9]+(?:[\.\s])*)";
            Regex rex = new Regex(pattern);

            Match match = rex.Match(phone);
            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private bool IsValidEmail(String email)
        {
            String pattern = @"([a-zA-Z]+[a-zA-Z._\-0-9]*)(@)([a-zA-Z]*)(\.)([a-zA-Z]+(?:[.a-zA-Z])*)";
            Regex rex = new Regex(pattern);

            Match match = rex.Match(email);
            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private bool IsValidAge(int age)
        {
            return (age >= 18) && (age < 100);
        }

        private bool IsValidFacultyNumber(int facultyNumber)
        {
            return (facultyNumber > 0);
        }

        private bool IsValidGroupNumber(int groupNumber)
        {
            return (groupNumber > 0);
        }
    }
}
