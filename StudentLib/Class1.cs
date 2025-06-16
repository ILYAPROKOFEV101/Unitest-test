
using System;
namespace StudentLib
{
    public class Student
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthday { get; private set; }
        public short Course { get; set; }
        public string Specialty { get; private set; }

        public Student(string name, string surname, DateTime birthday, short course, string specialty)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Course = course;
            Specialty = specialty;
        }
        

        

        public bool CheckName()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (Name.Length < 2 || Name.Length > 15)
                return false;
            
            if(!char.IsUpper(Name[0]))
                return false;

            int digitCount = 0;
            foreach (char c in Name)
            {
               
                if (!char.IsLetterOrDigit(c))
                    return false;
                
                if( char.IsDigit(c))
                    digitCount++;
                
                if(!char.IsAsciiLetterLower(c) && !char.IsAsciiLetterUpper(c) && !char.IsDigit(c))
                    return false;
            }
                
            return digitCount == 1;
        }
       

        public string TransformSpecialty()
        {
            Specialty = Specialty.Trim();
            while(Specialty.Contains("  "))
                Specialty = Specialty.Replace("  ", " ");
            Specialty = Specialty.ToUpper();
            return Specialty;
        }
        

        public int CheckBirthday()
        {
            if (Birthday > DateTime.Now)
            {
                return -1;
            }

            int age = CalculateAge(Birthday);

            if (age < 16)
                return 0;
            else if ( age < 18)
                return 1;
            else if (  age <= 22)
                return 2;
            else 
                return 3;

        }

        

        private int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age))
                age--;

            return age;
        }
        
    }
}