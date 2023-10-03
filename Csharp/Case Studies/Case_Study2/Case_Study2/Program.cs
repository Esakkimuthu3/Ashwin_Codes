using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case_Study1;

namespace Case_Study2
{
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

    public class App
    {
        static void Main(string[] args)
        {
            AppEngine appEngine = new AppEngine();



            while (true)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Introduce a new course");
                Console.WriteLine("2. Student Registration");
                Console.WriteLine("3. Enrollment of Student in Course");
                Console.WriteLine("4. List of Students which are available ");
                Console.WriteLine("5. List of Courses which are available");
                Console.WriteLine("6. List of Enrollments of an Student");
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
                                        Case_Study1.App.Scenario1();
                                        Console.WriteLine("Student registered successfully using Scenario 1.");
                                    }
                                    else if (scenarioChoice == 2)
                                    {
                                        Case_Study1.App.Scenario2();
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
    }
}
