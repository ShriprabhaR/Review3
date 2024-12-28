using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Review3
{
    internal class Student
    {
        public static List<Student> studentsList = new List<Student>();
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Mandatory field")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only alphabets are allowed.")]
        public string StudentName { get; set; }

        [Range(5, 25, ErrorMessage = "Age should be between {1} and {2}")]
        public int Age { get; set; }

        [RegularExpression(@"^[A-F]$", ErrorMessage = "Enter grades between A and F")]
        public char Grade { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid EmailAddress")]
        public string Email { get; set; }


        public static void InputValidation()
        {
            Console.WriteLine("Enter StudentId");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter StudentName");
            String studentName = Console.ReadLine();

            Console.WriteLine("Enter your Age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter StudentGrade");
            char grade = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Email");
            String email = Console.ReadLine();


            var student = new Student()
            {
                StudentId = studentId,
                StudentName = studentName,
                Email = email,
                Age = age,
                Grade = grade

            };

            var context = new ValidationContext(student);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(student, context, results, true);

            if (isValid)
            {
                studentsList.Add(student);

            }
            else
            {
                Console.WriteLine("Validation errors:-");
                foreach (var errors in results)
                {
                    Console.WriteLine(errors.ErrorMessage);
                }
            }

        }

        public static void Display()
        {
            if (studentsList.Count == 0)
            {
                Console.WriteLine("No records in list");
            }
            else
            {
                foreach (var student in studentsList)
                {
                    Console.Write(student.StudentId + " " + student.StudentName + " " + student.Age + " " + student.Email + " " + student.Grade);
                }
            }
        }

        public static void SearchForName()
        {
            Console.WriteLine("/nEnter Student Name to search");
            String Name = Console.ReadLine();

            var st = studentsList.FindAll(x => x.StudentName == Name);
            if (st != null)
            {
                foreach (var student in st)
                {
                    Console.Write($"{student.StudentId}, {student.StudentName}, {student.Age}, {student.Grade}, {student.Email}");
                }
            }
            else
            {
                Console.WriteLine("Can't found details for this name");
            }
        }

        public static void UpdateDetails()
        {
            Console.WriteLine("Enter Student Id");
            int id = int.Parse(Console.ReadLine());

            var Sid = studentsList.FindAll(x => x.StudentId == id);

            Console.WriteLine("Enter Student Name for update");
            String studentName = Console.ReadLine();

            Console.WriteLine("Enter your Age for update");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Grade to update");
            char grade = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Email to update");
            String email = Console.ReadLine();

            Console.WriteLine("Updated");

        }

        public static void Delete()
        {
            Console.WriteLine("Enter StudentId");
            int id = int.Parse(Console.ReadLine());

            var DeleteStudent = studentsList.Find(x => x.StudentId == id);
            studentsList.Remove(DeleteStudent);

            Console.WriteLine("Deleted");
        }


    }
}
