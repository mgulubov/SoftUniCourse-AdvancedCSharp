using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncProgramm
{
    class FuncProgramm
    {
        private static List<Student> _students;

        static void Main(string[] args)
        {
            _students = new List<Student>();
            _students.Add(new Student("Aohn", "Doe", "022837372", "enjd@dfjfh.com", 18, 1, new List<int>(new int[]{2, 3, 4, 6}), 2));
            _students.Add(new Student("Kohn", "Moe", "+92837372", "enjd@abv.bg", 19, 1, new List<int>(new int[] { 2, 3, 4 }), 2));
            _students.Add(new Student("Pohn", "Toe3", "+359237372", "enjd@dfjfh.com", 25, 1, new List<int>(new int[] { 2, 6, 3, 4 }), 1));
            _students.Add(new Student("Sohn", "Soe4", "+92837372", "enjd@dfjfh.com", 30, 1, new List<int>(new int[] { 2, 3, 4 }), 2));
            _students.Add(new Student("Vohn", "Zoe5", "+359 27372", "enjd@abv.bg", 90, 1, new List<int>(new int[] { 2, 3, 4 }), 1));
            _students.Add(new Student("Qohn", "Yoe6", "+92837372", "enjd@abv.bg", 24, 1, new List<int>(new int[] { 2, 3, 6, 4 }), 2));
            _students.Add(new Student("Yohn", "Aoe7", "+92837372", "enjd@dfjfh.com", 23, 1, new List<int>(new int[] { 2, 3, 4 }), 1));


            Console.WriteLine("Students By Group:");
            PrintStudentsFromGroup(2);
            Console.WriteLine("\nStudents By First And Last Name:");
            PrintStudentsWithLastNameBeforeFirst();
            Console.WriteLine("\nStudents By Age:");
            PrintStudentsByAge();
            Console.WriteLine("\nSort Students:");
            PrintSortStudents();
            Console.WriteLine("\nFilter Email:");
            PrintFilterEmail();
            Console.WriteLine("\nFilterByPhone:");
            PrintFilterByPhone();
            Console.WriteLine("\nExcellentStudents:");
            PrintExellentStudents();
        }

        private static void PrintExellentStudents()
        {
            var query = from student in _students
                        where student.GetMarks().Contains(6)
                        select new AnonClass() {_fullName = student.GetFirstName() + " " + student.GetLastName(), _marks = student.GetMarks()};

            foreach (var anon in query)
            {
                Console.WriteLine(anon._fullName);
            }
        }

        private static void PrintFilterByPhone()
        {
            var query = from student in _students
                        where student.GetPhone().Substring(0, 2).Equals("02") ||
                                student.GetPhone().Substring(0, 5).Equals("+3592") ||
                                student.GetPhone().Substring(0, 6).Equals("+359 2")
                        select student;
            foreach (var student in query)
            {
                Console.WriteLine(student.GetFirstName() + " " + student.GetLastName() + " " + student.GetPhone());
            }
        }

        private static void PrintFilterEmail()
        {
            var query = from student in _students
                        where student.GetEmail().Contains("@abv.bg")
                        select student;

            foreach (var student in query)
            {
                Console.WriteLine(student.GetFirstName() + " " + student.GetLastName() + " " + student.GetEmail());
            }
        }

        private static void PrintSortStudents()
        {
            Console.WriteLine("Using OrderBy() and ThenBy():");
            var query = _students.OrderByDescending(student => student.GetFirstName()).ThenByDescending(student => student.GetLastName());
            foreach (var student in query)
            {
                Console.WriteLine(student.GetFirstName() + " " + student.GetLastName());
            }

            Console.WriteLine("Using LINQ query:");
            query = from student in _students
                    orderby student.GetFirstName() descending
                    orderby student.GetLastName() descending
                    select student;
            foreach (var student in query)
            {
                Console.WriteLine(student.GetFirstName() + " " + student.GetLastName());
            }
        }

        private static void PrintStudentsByAge()
        {
            var query = _students
                        .Where(x => x.GetAge() >= 18 && x.GetAge() <= 24)
                        .Select(x => new String[]{ x.GetFirstName(), x.GetLastName(), x.GetAge().ToString() });

            foreach (var student in query)
            {
                Console.WriteLine("{0} {1} {2}", student[0], student[1], student[2]);
            }
        }

        private static void PrintStudentsWithLastNameBeforeFirst()
        {
            var query = from student in _students
                        where string.Compare(student.GetFirstName(), student.GetLastName()) < 0
                        select student;

            foreach (var student in query)
            {
                Console.WriteLine(student.GetFirstName() + " " + student.GetLastName());
            }
        }

        private static void PrintStudentsFromGroup(int group)
        {
            var query = from student in _students
                        where student.GetGroupNumber() == 2
                        orderby student.GetLastName()
                        select student;

            foreach (var st in query)
            {
                Console.WriteLine(st.GetFirstName() + " " + st.GetLastName());
            }
        }

        private static String GenerateName()
        {
            String alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder bld = new StringBuilder();
            Random random = new Random();
            int length = (int)random.Next(3, 10);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(0, alphabet.Length);
                if (i == 0)
                {
                    bld.Append(alphabet[index].ToString());
                    continue;
                }
                bld.Append(char.ToLower(alphabet[index]).ToString());
            }

            return bld.ToString();
        }

        private static String GeneratePhone()
        {
            StringBuilder bld = new StringBuilder();
            bld.Append("+");
            Random random = new Random();
            int length = 7;

            for (int i = 0; i < length; i++)
            {
                bld.Append((int)random.Next(0, 10));
            }

            return bld.ToString();
        }

        private static String GenerateEmail()
        {
            return GenerateName() + "@" + GenerateName() + ".com";
        }

        private static int GenerateAge()
        {
            Random random = new Random();
            return (int)random.Next(18, 100);
        }

        private static int GenerateFacultyNum()
        {
            Random random = new Random();
            return (int)random.Next(1, int.MaxValue);
        }

        private static int GenerateGroupNum()
        {
            Random random = new Random();
            return (int)random.Next(1, 2);
        }

        private static IList<int> GenerateMarks()
        {
            Random random = new Random();
            IList<int> marks = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                marks.Add((int)random.Next(2, 7));
            }

            return marks;
        }

        private class AnonClass
        {
            public String _fullName { get; set; }
            public IList<int> _marks { get; set; }
        }
    }
}
