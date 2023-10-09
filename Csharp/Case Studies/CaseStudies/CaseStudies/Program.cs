using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Study
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public Student(int id, string name, DateTime dob)
        {
            Id = id;
            Name = name;
            DOB = dob;
        }
    }
    public interface IUserInterface
    {
        void ShowFirstScreen();
        void ShowStudentScreen();
        void ShowAdminScreen();
        void ShowAllStudentsScreen();
        void ShowStudentRegistrationScreen();
        void IntroduceNewCourseScreen();
        void ShowAllCoursesScreen();
    }

    public class UserInterface : IUserInterface
    {
        private AppEngine appEngine = new AppEngine();

        public void ShowFirstScreen()
        {
            Console.WriteLine("Role: \n1. Student\n2. AdminTeacher \n3. Exit");
            Console.Write("Enter your choice (1, 2, or 3): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowStudentScreen();
                    break;
                case 2:
                    ShowAdminScreen();
                    break;
                case 3:
                    Console.WriteLine("Logging out.....");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    ShowFirstScreen();
                    break;
            }
        }

        public void ShowStudentScreen()
        {
            Console.WriteLine("Student Menu:");
            Console.WriteLine("1. View All Courses");
            Console.WriteLine("2. Register for a Course");
            Console.WriteLine("3. Log Out");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ShowAllCoursesScreen();
                    break;
                case 2:
                    ShowStudentRegistrationScreen();
                    break;
                case 3:
                    Console.WriteLine("Logging out Student Menu.");
                    ShowFirstScreen();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    ShowStudentScreen();
                    break;
            }
        }

        public void ShowAdminScreen()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Introduce New Course");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    IntroduceNewCourseScreen();
                    break;
                case 2:
                    ShowAllStudentsScreen();
                    break;
                case 3:
                    Console.WriteLine("Exiting Admin Menu.");
                    ShowFirstScreen();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option (1-3).");
                    ShowAdminScreen();
                    break;
            }
        }

        public void ShowAllStudentsScreen()
        {
            Console.WriteLine("List of Students:");
            foreach (Student student in appEngine.ListOfStudents())
            {
                Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}, Date of Birth: {student.DOB.ToShortDateString()}");
            }
            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowAdminScreen();
        }

        public void ShowStudentRegistrationScreen()
        {
            Console.Write("Enter Student ID: ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter Student Date of Birth (yyyy-MM-dd): ");
            DateTime studentDob = Convert.ToDateTime(Console.ReadLine());

            appEngine.Register(new Student(studentId, studentName, studentDob));
            Console.WriteLine("Student registered successfully.");

            Console.ReadLine();
            ShowStudentScreen();
        }

        public void IntroduceNewCourseScreen()
        {
            Console.Write("Enter Course ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Course Name: ");
            string courseName = Console.ReadLine();

            appEngine.Introduce(new Course(courseId, courseName));
            Console.WriteLine("Course introduced successfully.");
            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowAdminScreen();
        }

        public void ShowAllCoursesScreen()
        {
            Console.WriteLine("List of Courses:");
            foreach (Course course in appEngine.ListOfCourses())
            {
                Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.CourseName}");
            }
            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowStudentScreen();
        }
    }

    public class App
    {
        static void Main(string[] args)
        {
            UserInterface userInterface = new UserInterface();
            userInterface.ShowFirstScreen();
            AppEngine appEngine = new AppEngine();
            Console.WriteLine("Do you want to Introduce a course, Register , Enroll then Press 'Y' if not Press 'N' ");
            string answer = Console.ReadLine();
            if(answer == "Y")
            {
                while (true)
                {
                    Console.WriteLine("Options :");
                    Console.WriteLine("1. Introduce a new course");
                    Console.WriteLine("2. Student Registration");
                    Console.WriteLine("3. Enrollment of Student in Course");
                    Console.WriteLine("4. List of Students which are available ");
                    Console.WriteLine("5. List of Courses which are available");
                    Console.WriteLine("6. List of Enrollments of a Student");
                    Console.WriteLine("7. Logout");
                    Console.Write("Enter the choice which is between 1 to 7: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter Course ID: ");
                                int courseId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Course Name: ");
                                string courseName = Console.ReadLine();
                                appEngine.Introduce(new Course(courseId, courseName));
                                Console.WriteLine("Course introduced successfully.");
                                break;

                            case 2:
                                Console.WriteLine("\nChoose a scenario for student registration:");
                                Console.WriteLine("1. Scenario 1");
                                Console.WriteLine("2. Scenario 2 ");
                                Console.Write("Enter your choice (1-2): ");

                                if (int.TryParse(Console.ReadLine(), out int scenarioChoice))
                                {
                                    if (scenarioChoice == 1 || scenarioChoice == 2)
                                    {
                                        if (scenarioChoice == 1)
                                        {
                                            Scenario1();
                                            Console.WriteLine("Student registered successfully using Scenario 1.");
                                        }
                                        else if (scenarioChoice == 2)
                                        {
                                            Scenario2();
                                            Console.WriteLine("Student registered successfully using Scenario 2.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid choice.");
                                    }
                                }
                                else
                                {
                                }
                                break;

                            case 3:
                                Console.Write("Enter Student ID: ");
                                int enrolledStudentId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Course ID: ");
                                int enrolledCourseId = int.Parse(Console.ReadLine());
                                Student enrolledStudent = appEngine.ListOfStudents().FirstOrDefault(s => s.Id == enrolledStudentId);
                                Course enrolledCourse = appEngine.ListOfCourses().FirstOrDefault(c => c.CourseId == enrolledCourseId);
                                if (enrolledStudent != null && enrolledCourse != null)
                                {
                                    appEngine.Enroll(enrolledStudent, enrolledCourse);
                                    Console.WriteLine("Student enrolled in the course successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Student or course not found. Please register them first.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("\nList of Students:");
                                foreach (var student in appEngine.ListOfStudents())
                                {
                                    Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                                }
                                break;
                            case 5:
                                Console.WriteLine("\nList of Courses:");
                                foreach (var course in appEngine.ListOfCourses())
                                {
                                    Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.CourseName}");
                                }
                                break;
                            case 6:
                                Console.WriteLine("\nList of Enrollments:");
                                foreach (var enrollment in appEngine.ListOfEnrollments())
                                {
                                    Console.WriteLine($"Student ID: {enrollment.Student.Id}, Course ID: {enrollment.Course.CourseId}, Enrollment Date: {enrollment.EnrollmentDate}");
                                }
                                break;
                            case 7:
                                Console.WriteLine("Bye");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("okay, Thank you for using the Student Management System. Bye!");
            }
        }
            

        public static void Scenario1()
        {
            Console.WriteLine("Scenario 1:");

            Console.Write("Enter the total number of students to be accepted and give the details: ");
            int total = int.Parse(Console.ReadLine());

            Student[] students = new Student[total];
            Info info = new Info();

            for (int i = 0; i < total; i++)
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student DOB in the format (yyyy-MM-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());
                students[i] = new Student(id, name, dob);
            }

            Console.WriteLine("Student Details:");
            foreach (Student student in students)
            {
                info.Display(student);
            }
        }

        public static void Scenario2()
        {
            Console.WriteLine("\nScenario 2:");
            Console.Write("Enter the total number of students for giving details: ");
            int total = int.Parse(Console.ReadLine());

            Student[] students = new Student[total];
            Info info = new Info();

            for (int i = 0; i < total; i++)
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student DOB (yyyy-MM-dd): ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                students[i] = new Student(id, name, dob);
            }

            Console.WriteLine("Student Details:");
            foreach (Student student in students)
            {
                info.Display(student);
            }
        }
    }

    public class Enroll
    {
        private Student student { get; set; }
        private Course course { get; set; }
        private DateTime enrollmentDate { get; set; }

        public Enroll(Student stud, Course couse, DateTime enrollmentDate)
        {
            this.student = stud;
            this.course = couse;
            this.enrollmentDate = enrollmentDate;
        }
        public Student Student
        {
            get { return student; }
        }
        public Course Course
        {
            get { return course; }
        }
        public DateTime EnrollmentDate
        {
            get { return enrollmentDate; }
        }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Course(int courseId, string courseName)
        {
            CourseId = courseId;
            CourseName = courseName;
        }
    }

    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();

        public void Introduce(Course course)
        {
            courses.Add(course);
        }

        public void Register(Student student)
        {
            students.Add(student);
        }

        public Student[] ListOfStudents()
        {
            return students.ToArray();
        }

        public Course[] ListOfCourses()
        {
            return courses.ToArray();
        }

        public void Enroll(Student student, Course course)
        {
            DateTime enrollmentDate = DateTime.Now;
            enrollments.Add(new Enroll(student, course, enrollmentDate));
        }

        public Enroll[] ListOfEnrollments()
        {
            return enrollments.ToArray();
        }
    }

    public class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine($"Student ID: {student.Id}");
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student DOB: {student.DOB.ToShortDateString()}");
        }
    }
}
