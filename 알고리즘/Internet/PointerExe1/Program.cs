using System;

//unsafe code는 허락받아야댐
namespace PointerExe1
{
    // Defining a struct Student 
    struct Student
    {
        // With members 
        // roll number and marks 
        public int rno;
        public double marks;

        // Constructor to initialize values 
        public Student(int r, double m)
        {
            rno = r;
            marks = m;
        }

        // unsafe so as to use pointers          
    }; // end of struct Student 

    public class MyClass
    {
        public unsafe void Method()
        {
            // Declaring two Student Variables 
            Student S1 = new Student(1, 95.0);
            Student S2 = new Student(2, 79.5);

            // Declaring two Student pointers 
            // and initializing them with addresses 
            // of S1 and S2 
            Student* S1_ptr = &S1;
            Student* S2_ptr = &S2;

            // Displaying details of Student using pointers 
            // Using  the arrow ( -> ) operator 
            Console.WriteLine("Details of Student 1");

            Console.WriteLine("Roll Number: {0} Marks: {1}",
                            S1_ptr->rno, S1_ptr->marks);

            Console.WriteLine("Details of Student 2");
            Console.WriteLine("Roll Number: {0} Marks: {1}",
                            S2_ptr->rno, S2_ptr->marks);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            MyClass myClass = new MyClass();
            myClass.Method();

            Console.ReadKey();
        }
    }
}
