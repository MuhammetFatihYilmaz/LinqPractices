﻿using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Find()
            Console.WriteLine("**** Find ****");
            var student = _context.Students.Where(student=> student.StudentId == 1).SingleOrDefault();
            student = _context.Students.Find(4);
            Console.WriteLine(student.Name);

            //FirstOrDefault()
            Console.WriteLine("**************");
            Console.WriteLine("**** FirstOrDefault ****");
            student = _context.Students.Where(student=> student.Surname == "Yıldız").FirstOrDefault();
            Console.WriteLine(student.Name);
            //
            student = _context.Students.FirstOrDefault(student=> student.Surname == "Yıldız");
            Console.WriteLine(student.Name);

            //SingleOrDefault()
            Console.WriteLine("**************");
            Console.WriteLine("**** SingleOrDefault ****");
            student = _context.Students.SingleOrDefault(student=> student.Name == "Enis");//There must be only single data
            Console.WriteLine(student.Name);

            //ToList()
            Console.WriteLine("**************");
            Console.WriteLine("**** ToList ****");
            var studentList = _context.Students.Where(student=> student.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);

            //OrderBy()
            Console.WriteLine("**************");
            Console.WriteLine("**** OrderBy ****");
            students = _context.Students.OrderBy(student=> student.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + "-" + st.Name + " " + st.Surname);
            }

            //OrderByDescending()
            Console.WriteLine("**************");
            Console.WriteLine("**** OrderByDescending ****");
            students = _context.Students.OrderByDescending(student=> student.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + "-" + st.Name + " " + st.Surname);
            }

            //Anonymous Object Result
            Console.WriteLine("**************");
            Console.WriteLine("**** Anonymous Object ResultsObject ****");
            var anonymousObj = _context.Students
                            .Where(x=> x.ClassId ==2)
                            .Select(x=> new 
                            {
                                ID = x.StudentId,
                                FullName = x.Name+ " " +x.Surname
                            });

            foreach (var obj in anonymousObj)
            {
                Console.WriteLine(obj.ID + " - " + obj.FullName);
            }
        }
    }
}
