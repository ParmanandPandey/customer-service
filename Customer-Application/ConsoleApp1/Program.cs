using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new();
            stu.Name = "Parma";
            stu.Password=234;
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Password { get; set; }


    }
}
