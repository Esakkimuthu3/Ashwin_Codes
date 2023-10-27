

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Case_Study
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

        public int CourseId { get; set; }
        public Student(int id, string name, DateTime dob, int courseid)
        {
            Id = id;
            Name = name;
            DOB = dob;
            CourseId = courseid;
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
        //void ListOfStudents();
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
            Console.WriteLine("2. Register as Student and for Course");
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
            //Console.WriteLine("3. List of Students in a specific course");
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
                //case 3:
                //    ListOfStudents();
                //    break;
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

            string cs = ConfigurationManager.ConnectionStrings["a"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    string query = "select * from student";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader d = cmd.ExecuteReader();
                    while (d.Read())
                    {
                        Console.WriteLine("Student Id: " + d[0]);
                        Console.WriteLine("Student Name: " + d[1]);
                        Console.WriteLine("Student dob: " + d[2]);
                        Console.WriteLine("Student course Id: " + d[3]);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            //foreach (Student student in appEngine.ListOfStudents())
            //{
            //    Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}, Date of Birth: {student.DOB.ToShortDateString()}");
            //}
            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowAdminScreen();
        }

        public void ShowStudentRegistrationScreen()
        {
            string cs = ConfigurationManager.ConnectionStrings["a"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    Console.Write("Enter Student ID: ");
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Student Name: ");
                    string studentName = Console.ReadLine();
                    Console.Write("Enter Student Date of Birth (yyyy-MM-dd): ");
                    DateTime studentDob = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter Course ID: ");
                    int courseid = Convert.ToInt32(Console.ReadLine());

                    appEngine.Register(new Student(studentId, studentName, studentDob, courseid));
                    Console.WriteLine("Student registered successfully.");

                    Console.ReadLine();
                    string query = "insert into student values(@id,@name,@dob,@cid)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", studentId);
                    cmd.Parameters.AddWithValue("@name", studentName);
                    cmd.Parameters.AddWithValue("@dob", studentDob);
                    cmd.Parameters.AddWithValue("@cid", courseid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //ShowStudentScreen();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);

            }

        }

        public void IntroduceNewCourseScreen()
        {
            string cs = ConfigurationManager.ConnectionStrings["a"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {

                    Console.Write("Enter Course ID: ");
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Course Name: ");
                    string courseName = Console.ReadLine();

                    string query = "insert into course values(@id,@name)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", courseId);
                    cmd.Parameters.AddWithValue("@name", courseName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }


            //appEngine.Introduce(new Course(courseId, courseName));
            Console.WriteLine("Course introduced successfully.");
            Console.WriteLine("Press Enter to return to the previous menu...");
            Console.ReadLine();
            ShowAdminScreen();
        }

        public void ShowAllCoursesScreen()
        {
            Console.WriteLine("List of Courses:");
            string cs = ConfigurationManager.ConnectionStrings["a"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    string query = "select * from course";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader d = cmd.ExecuteReader();
                    while (d.Read())
                    {
                        Console.WriteLine("Course Id: " + d[0]);
                        Console.WriteLine("Course Name: " + d[1]);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            //foreach (Course course in appEngine.ListOfCourses())
            //{
            //    Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.CourseName}");
            //}
            //Console.WriteLine("Press Enter to return to the previous menu...");
            //Console.ReadLine();
            //ShowStudentScreen();
        }

        //public void ListOfStudents()
        //{
        //    Console.WriteLine("Enter the course Id to list the students details belonged in the course:");
        //    int courseId = Convert.ToInt32(Console.ReadLine());
        //    string cs = ConfigurationManager.ConnectionStrings["a"].ConnectionString;
        //    SqlConnection con = null;
        //    try
        //    {
        //        using (con = new SqlConnection(cs))
        //        {
        //            string query = "select* from student s ,course c where c.id = @c.id and c.id = s.cid;  ";
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            cmd.Parameters.AddWithValue("@c.id",courseId);
        //             cmd.ExecuteNonQuery();
        //            con.Open();
        //            SqlDataReader d = cmd.ExecuteReader();
        //            while(d.Read())
        //            {
        //                Console.WriteLine("Student Id: " + d[0]);
        //                Console.WriteLine("Student Name: " + d[1]);
        //                Console.WriteLine("Student Dob: " + d[2]);
        //                Console.WriteLine("Course Id of Student: " + d[3]);
        //                Console.WriteLine("Course Id: " + d[4]);
        //                Console.WriteLine("Course Name: " + d[5]);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        public class App
        {
            //public static SqlConnection con;
            //public static SqlCommand cmd;
            //public static SqlDataReader dr;

            static void Main(string[] args)
            {

                UserInterface userInterface = new UserInterface();
                userInterface.ShowFirstScreen();
                AppEngine appEngine = new AppEngine();
                Console.WriteLine("Do you want to Introduce a course, Register , Enroll then Press 'Y' if not Press 'N' ");
                string answer = Console.ReadLine();
                if (answer == "Y")
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
                    Console.Write("Enter course ID: ");
                    int cId = Convert.ToInt32(Console.ReadLine());
                    students[i] = new Student(id, name, dob, cId);
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
                    Console.Write("Enter Course ID: ");
                    int cId = Convert.ToInt32(Console.ReadLine());

                    students[i] = new Student(id, name, dob, cId);
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
                Console.WriteLine($"Course ID: {student.CourseId}");
            }
        }
    }
}
