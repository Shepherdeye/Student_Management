using System.Runtime.CompilerServices;

namespace students_management_system
{
    internal class Program
    {

        class Student
        {
            public string studentId;
            public string name;
            public int age;
            public List<Course> courses;

            public Student(string studentId, string name, int age)
            {
                this.studentId = studentId;
                this.name = name;
                this.age = age;
                this.courses = new List<Course>();
            }

            public bool Enroll(Course course)
            {
                if (course != null)
                {
                    this.courses.Add(course);
                    return true;

                }

                return false;
            }
            public string PrintDetails()
            {


                string CourseInfo = "";

                for (int i = 0; i < this.courses.Count; i++)
                {
                    CourseInfo += $"{this.courses[i].Title} ";
                }

                return $"Student ID: {this.studentId} \n" +
                    $"Student Name: {this.name}\n" +
                    $"Student Age: {this.age}\n" +
                    $"Student Courses: [ {CourseInfo}]";
            }
        };

        class Course
        {

            public string CourseId;
            public string Title;
            public string Instructor;

            public Course(string courseId, string title, string instructor)
            {
                CourseId = courseId;
                Title = title;
                Instructor = instructor;
            }
            public string PrintDetails()
            {

                return $"Course ID: {this.CourseId} \n" +
                    $"Course Title: {this.Title}\n" +
                    $"Course Instructor: {this.Instructor}\n";
            }
        }
        class Instructor
        {

            public string InstructorId;
            public string Name;
            public string Specialization;

            public Instructor(string instructorId, string name, string specialization)
            {
                InstructorId = instructorId;
                Name = name;
                Specialization = specialization;
            }

            public string PrintDetails()
            {

                return $"Instructor ID: {this.InstructorId} \n" +
                    $"Instructor Name: {this.Name}\n" +
                    $"Instructor Specialization: {this.Specialization}\n";
            }
        }

        class StudentManager
        {
            public List<Student> Students;
            public List<Course> Courses;
            public List<Instructor> Instructors;

            public StudentManager()
            {
                this.Students = new List<Student>();
                this.Courses = new List<Course>();
                this.Instructors = new List<Instructor>();
            }

            public bool AddStudent(Student student)
            {
                if (student != null)
                {
                    this.Students.Add(student);
                    return true;
                }
                return false;
            }
            public bool AddInstructor(Instructor instructor)
            {
                if (instructor != null)
                {
                    this.Instructors.Add(instructor);
                    return true;
                }
                return false;
            }
            public bool AddCourse(Course course)
            {
                if (course != null)
                {
                    this.Courses.Add(course);
                    return true;
                }
                return false;
            }
            public bool EnrollStudentInCourse(string studentId, string courseID)
            {
                Course selectedCourse = null;

                bool foundedCourse = false;
                bool foundedStudent = false;


                for (int i = 0; i < this.Courses.Count; i++)
                {
                    if (courseID == this.Courses[i].CourseId || courseID == this.Courses[i].Title)
                    {
                        foundedCourse = true;
                        selectedCourse = this.Courses[i];
                        break;
                    }
                    else
                    {
                        foundedCourse = false;
                    }
                }

                for (int i = 0; i < this.Students.Count; i++)
                {
                    if (studentId == this.Students[i].studentId || studentId == this.Students[i].name)
                    {
                        foundedStudent = true;
                        this.Students[i].Enroll(selectedCourse);
                        break;

                    }
                    else
                    {
                        foundedStudent = false;

                    }
                }
                if (foundedCourse && foundedStudent)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            public Student FindStudent(string studentId)
            {
                Student studentFound = null;

                for (int i = 0; i < this.Students.Count; i++)
                {
                    if (studentId == this.Students[i].name || studentId == this.Students[i].studentId)
                    {

                        studentFound = this.Students[i];
                        break;

                    }

                }

                return studentFound;

            }
            public Course FindCourse(string CourseId)
            {
                Course CourseFound = null;

                for (int i = 0; i < this.Courses.Count; i++)
                {
                    if (CourseId == this.Courses[i].Title || CourseId == this.Courses[i].CourseId)
                    {

                        CourseFound = this.Courses[i];
                        break;

                    }

                }

                return CourseFound;

            }

            public Student UpdateStudentInfo(string idOrName, string type, string newValue)
            {

                Student student = null;

                if (type == "name")
                {
                    for (int i = 0; i < this.Students.Count; i++)
                    {
                        if (idOrName == this.Students[i].name || idOrName == this.Students[i].studentId)
                        {
                            student = this.Students[i];
                            student.name = newValue;
                        }
                    }
                }
                else if (type == "age")
                {
                    int newValueconvert = Convert.ToInt32(newValue);

                    for (int i = 0; i < this.Students.Count; i++)
                    {
                        if (idOrName == this.Students[i].name || idOrName == this.Students[i].studentId)
                        {
                            student = this.Students[i];
                            student.age = newValueconvert;
                        }
                    }
                }
                else if (type == "courses")
                {

                    for (int i = 0; i < this.Students.Count; i++)
                    {
                        if (idOrName == this.Students[i].name || idOrName == this.Students[i].studentId)
                        {
                            //student = this.Students[i];
                            for (int j = 0; j < this.Courses.Count; j++)
                            {
                                if (newValue == this.Courses[j].Title)
                                {
                                    student = this.Students[i];

                                    student.courses[^1].Title = newValue;
                                    break;

                                }
                                else
                                {
                                    student = null;
                                }


                            }
                        }
                    }


                }

                return student;
            }

            public bool DeleteStudent(string id)
            {
                bool actionDone = false;
                for (int i = 0; i < this.Students.Count; i++)
                {
                    if (id == this.Students[i].studentId)
                    {
                        this.Students.RemoveAt(i);
                        actionDone = true;
                        break;
                    }
                }
                if (actionDone == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            public bool CheckStudentEnroll(string nameORID, string CoursTitle)
            {

                bool enrolled = false;

                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].name == nameORID || Students[i].studentId == nameORID)
                    {


                        for (int j = 0; j < Students[i].courses.Count; j++)
                        {
                            if (Students[i].courses[j].Title == CoursTitle)
                            {
                                enrolled = true;
                            }
                        }
                    }
                }

                if (enrolled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public string ReturnInstructorName(string courseName)
            {
                string InstructorName = "";

                for (int i = 0; i < Courses.Count; i++)
                {
                    if (courseName == Courses[i].Title)
                    {
                        InstructorName = Courses[i].Instructor;
                        break;
                    }
                }

                return InstructorName;

            }
        }




        static void PrintingMessage(string type, string message)
        {

            if (type == "selector")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n{message} \n");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (type == "success")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{message} \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (type == "error")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{message} \n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        static void Main(string[] args)
        {


            StudentManager school = new StudentManager();
            string? action;

            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine(@"

                    1. Add Student 
                    2. Add Instructor
                    3. Add Course 
                    4. Enroll Student in Course
                    5. Show All Students
                    6. Show All Courses
                    7. Show All Instructors
                    8. Find the student by id or name
                    9. Fine the course by id or name
                   10. Exit
                   11. Update Student Information
                   12. Delete Student      
                   13. Check if the student enrolled in specific course (Bouns)    
                   14. Return the instructor name by course name  (Bouns)  

                    ");

                ;
                Console.ForegroundColor = ConsoleColor.White;
                PrintingMessage("main", "Choose you action from  1 to 14 :");

                action = Console.ReadLine().Trim();

                switch (action)
                {

                    case "1":

                        PrintingMessage("selector", "Enter student name ");
                        string? inputName = Console.ReadLine().Trim().ToLower();
                        if (inputName == null || inputName == "" || inputName == " ")
                        {
                            PrintingMessage("error", "Name is required ..!");
                            break;
                        }

                        PrintingMessage("selector", "Enter student age ");

                        string? secondInput = Console.ReadLine().Trim();

                        if (secondInput == null || secondInput == "" || secondInput == " ")
                        {

                            PrintingMessage("error", "Age is required..!");
                            break;
                        }
                        int inputAge = Convert.ToInt32(secondInput);
                        school.AddStudent(new Student(Guid.NewGuid().ToString(), inputName, inputAge));
                        PrintingMessage("success", $"Student {inputName} has been successfully added");
                        break;

                    case "2":

                        PrintingMessage("selector", "Enter instructor name ");
                        string? instructorName = Console.ReadLine().Trim().ToLower();

                        if (instructorName == null || instructorName == "" || instructorName == " ")
                        {
                            PrintingMessage("error", "instructor name is required..!");
                            break;
                        }

                        PrintingMessage("selector", "Enter instructor Specialization");

                        string? instructorSpecialization = Console.ReadLine().Trim().ToLower();
                        if (instructorSpecialization == null || instructorSpecialization == "" || instructorSpecialization == " ")
                        {
                            PrintingMessage("error", "Specialization name is required..!");

                            break;

                        }
                        school.AddInstructor(new Instructor(Guid.NewGuid().ToString(), instructorName, instructorSpecialization));

                        Console.WriteLine();

                        PrintingMessage("success", $"Instructor {instructorName} has been successfully added");
                        break;

                    case "3":


                        PrintingMessage("selector", "Enter course Title");

                        string? CourseTitle = Console.ReadLine().Trim().ToLower();
                        if (CourseTitle == "" || CourseTitle == " " || CourseTitle == null)
                        {
                            PrintingMessage("error", "Course Title is required ...!");
                            break;
                        }

                        PrintingMessage("selector", "Enter Course Instructor");

                        string? CourseInstructor = Console.ReadLine().Trim().ToLower();
                        if (CourseInstructor == "" || CourseInstructor == " " || CourseInstructor == null)
                        {
                            PrintingMessage("error", "Course Instructor is required ...!");
                            break;
                        }
                        bool Founded = false;
                        for (int i = 0; i < school.Instructors.Count; i++)
                        {
                            if (school.Instructors[i].Name == CourseInstructor)
                            {
                                Founded = true;
                                school.AddCourse(new Course(Guid.NewGuid().ToString(), CourseTitle, CourseInstructor));
                                break;
                            }

                        }

                        if (Founded == true)
                        {
                            PrintingMessage("success", "Course Added Successfully");
                        }
                        else
                        {
                            PrintingMessage("error", "Instructor is not Found");

                        }


                        break;

                    case "4":

                        PrintingMessage("selector", "Enter the ID or Title of the Course");

                        string? CourseID = Console.ReadLine().Trim().ToLower();

                        if (CourseID == null || CourseID == " " || CourseID == "")
                        {
                            PrintingMessage("error", "course ID or title is required..!");
                            break;
                        }

                        PrintingMessage("selector", "Enter the ID or name of the Student");

                        string? EnStudentID = Console.ReadLine().Trim().ToLower();

                        if (EnStudentID == null || EnStudentID == " " || EnStudentID == "")
                        {
                            PrintingMessage("error", "Student ID or name is required..!");

                            break;
                        }

                        bool added = school.EnrollStudentInCourse(EnStudentID, CourseID);

                        if (added)

                            PrintingMessage("success", $"Student Enroll SuccessFully to '{CourseID}'");
                        else
                            PrintingMessage("error", $"Unfortunately Can't Enroll ");

                        break;

                    case "5":



                        if (school.Students.Count > 0)
                        {
                            PrintingMessage("cyan", "Students Info\n");

                            for (int i = 0; i < school.Students.Count; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(school.Students[i].PrintDetails());
                                Console.WriteLine("----------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                        }
                        else
                        {
                            PrintingMessage("error", "There is no student right now...! ");
                        }
                        break;

                    case "6":
                        if (school.Courses.Count > 0)
                        {
                            PrintingMessage("cyan", "Courses Info\n");

                            for (int i = 0; i < school.Courses.Count; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(school.Courses[i].PrintDetails());
                                Console.WriteLine("----------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            PrintingMessage("error", "There is no Courses right now...! ");
                        }
                        break;

                    case "7":
                        if (school.Instructors.Count > 0)
                        {
                            PrintingMessage("cyan", "Instructors Info\n");

                            for (int i = 0; i < school.Instructors.Count; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine(school.Instructors[i].PrintDetails());
                                Console.WriteLine("---------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                        }
                        else
                        {
                            PrintingMessage("error", "There is no Instructors right now");
                        }

                        break;

                    case "8":
                        PrintingMessage("selector", "Enter the name or id of the student");
                        string inputIDOrName = Console.ReadLine().Trim().ToLower();
                        if (inputIDOrName == "" || inputIDOrName == " " || inputIDOrName == null)
                        {
                            PrintingMessage("error", "Name or ID is required");
                            break;
                        }
                        //bool studentFound = false;

                        Student Finded = school.FindStudent(inputIDOrName);

                        if (Finded == null)
                        {
                            PrintingMessage("error", $"Can't find '{inputIDOrName}' ...!");
                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n" + Finded.PrintDetails());
                            Console.ForegroundColor = ConsoleColor.White;

                        }


                        break;

                    case "9":

                        PrintingMessage("selector", "Enter the name or id of Course");
                        string CourseIdOrTitle = Console.ReadLine().Trim().ToLower();
                        if (CourseIdOrTitle == "" || CourseIdOrTitle == " " || CourseIdOrTitle == null)
                        {
                            PrintingMessage("error", "Name or ID is required");
                            break;
                        }
                        //bool studentFound = false;

                        Course FindedCrs = school.FindCourse(CourseIdOrTitle);

                        if (FindedCrs == null)
                        {
                            PrintingMessage("error", $"Can't find '{CourseIdOrTitle}' ...!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(FindedCrs.PrintDetails());
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        break;

                    case "10":
                        PrintingMessage("success", "GoodBye");
                        break;

                    case "11":

                        PrintingMessage("selector", "Enter the name or id of the student");
                        string inputUpdate = Console.ReadLine().Trim().ToLower();
                        if (inputUpdate == "" || inputUpdate == " " || inputUpdate == null)
                        {
                            PrintingMessage("error", "Name or ID is required");
                            break;
                        }

                        PrintingMessage("selector", "enter a value of ('name' or 'age' or 'courses')");

                        string getEditValue = Console.ReadLine().Trim().ToLower();

                        if (getEditValue == null || getEditValue == "" || getEditValue == " ")
                        {
                            PrintingMessage("error", "values required ..!");
                            break;
                        }


                        PrintingMessage("selector", $"enter the new value of {getEditValue} ");


                        string newEditValue = Console.ReadLine().Trim().ToLower();

                        if (newEditValue == null || newEditValue == "" || newEditValue == " ")
                        {
                            PrintingMessage("error", $"values of {getEditValue} required ..!");
                            break;
                        }


                        Student updatedStu = school.UpdateStudentInfo(inputUpdate, getEditValue, newEditValue);

                        if (updatedStu == null)
                        {
                            PrintingMessage("error", "can't update the student info");
                        }
                        else
                        {
                            Console.WriteLine(updatedStu.PrintDetails());
                        }

                        break;
                    case "12":
                        PrintingMessage("selector", "Enter the id of the student that you need to remove");
                        string deletedId = Console.ReadLine().Trim().ToLower();
                        if (deletedId == null || deletedId == "" || deletedId == " ")
                        {
                            PrintingMessage("error", " Student Id is required ..!");
                            break;
                        }


                        bool deleteItem = school.DeleteStudent(deletedId);

                        if (deleteItem)
                        {
                            PrintingMessage("success", "Student Deleted Successfully ..!");

                        }
                        else
                        {
                            PrintingMessage("error", "Can't Delete the Student ..!");

                        }

                        break;
                    case "13":
                        PrintingMessage("selector", "Enter the  Student name or  ID");
                        string? nameORID = Console.ReadLine().Trim().ToLower();

                        if (string.IsNullOrEmpty(nameORID))
                        {
                            PrintingMessage("error", "name or id is required");
                            break;
                        }
                        PrintingMessage("selector", "Enter the  Course Title");
                        string? CourseTitlE = Console.ReadLine().Trim().ToLower();
                        if (string.IsNullOrEmpty(CourseTitlE))
                        {
                            PrintingMessage("error", "Course Title is required");
                            break;
                        }

                        bool enrolled = school.CheckStudentEnroll(nameORID, CourseTitlE);
                        if (enrolled)
                        {
                            PrintingMessage("success", "Student is Enrolled in this course");

                        }
                        else
                        {
                            PrintingMessage("error", "Student isn't Enrolled in this course");

                        }


                        break;
                    case "14":
                        PrintingMessage("selector", "Enter the  Course title");
                        string? CourseTitleForins = Console.ReadLine().Trim().ToLower();

                        if (string.IsNullOrEmpty(CourseTitleForins))
                        {
                            PrintingMessage("error", "name or id is required");
                            break;
                        }
                        string instructorNameReturn = school.ReturnInstructorName(CourseTitleForins);

                        if (instructorNameReturn.Length == 0)
                        {
                            PrintingMessage("error", "Cant find  the instructor");

                        }
                        else
                        {
                            PrintingMessage("success", $"The instructor is '{instructorNameReturn}'");

                        }

                        break;

                    default:

                        PrintingMessage("error", $"'{action}' is Unknown selection Please try again ..!");

                        break;


                }



            } while (action != "10");
        }
    }
}
