using ANNA_AGUMAVAFinalProjectStudent.Models;

StudentManagement studentManagement = new StudentManagement(new List<Student>());
studentManagement.AddStudent(new Student
{
    StudentName = "Lara Johnson",
    Grade = 'A',
    SchoolName = "ABC High School",
    BirthDate = new DateOnly(2000, 1, 1),
    Course = LearningCourse.BasicsOfProgramming
});
while (true)
{
    Console.WriteLine("---Student management---");
    Console.WriteLine("1. Add new student");
    Console.WriteLine("2. See all students");
    Console.WriteLine("3. Search student with Name");
    Console.WriteLine("4. Search student with Roll Number");
    Console.WriteLine("5. Search student by Grade");
    Console.WriteLine("6. Search student by School Name");
    Console.WriteLine("7. Update students Grade");
    Console.WriteLine("8. Search student by Birth Date");
    Console.WriteLine("9. Exit");

    Console.WriteLine();
    Console.WriteLine("------------------------");
    Console.WriteLine();

    Console.WriteLine();
    Console.Write("Select: ");

    string Choice = Console.ReadLine() ?? "";
    if (Choice == "1")
    {
        Student student = new Student();
        Console.WriteLine("---- Add new Student ----");
        Console.Write("Name: ");
        student.StudentName = Console.ReadLine() ?? "";
        Console.Write("Grade: ");
        student.Grade = Console.ReadLine()?.FirstOrDefault() ?? '\0';
        Console.Write("School Name: ");
        student.SchoolName = Console.ReadLine() ?? "";
        Console.Write("Birth Date (yyyy-MM-dd): ");
        DateOnly birthDate;
        while (!DateOnly.TryParse(Console.ReadLine(), out birthDate))
        {
            Console.Write("Invalid date, try again (yyyy-MM-dd): ");
        }
        student.BirthDate = birthDate;
        student.Course = studentManagement.ReadCourse();
        bool isValid = !string.IsNullOrWhiteSpace(student.StudentName) && !string.IsNullOrWhiteSpace(student.SchoolName);
        if (isValid)
        {
            studentManagement.AddStudent(student);
            Console.WriteLine($"'{student.StudentName}' was added to the List of Students");
        }
        else
        {
            Console.WriteLine("Something went Wrong!");
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }
    Console.WriteLine();

    if (Choice == "2")
    {
        Console.WriteLine("---- See all Students ----");
        IReadOnlyList<Student> allStudents = studentManagement.GetAllStudents();
        if (allStudents.Count == 0)
        {
            Console.WriteLine("No Students found!");
        }
        else
        {
            foreach (Student student in allStudents)
            {
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Roll Number: {student.RollNumber}");
                Console.WriteLine($"Grade: {student.Grade}");
                Console.WriteLine($"School Name: {student.SchoolName}");
                Console.WriteLine($"Birth Date: {student.BirthDate}");
                Console.WriteLine($"Course: {student.Course}");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
    Console.WriteLine();

    if (Choice == "3")
    {
        Console.WriteLine("---- Search Student with Name ----");
        Console.WriteLine("Title: ");
        string searchTitle = Console.ReadLine() ?? "";
        Student? found = studentManagement.GetStudentByName(searchTitle);
        if (found == null)
        {
            Console.WriteLine("No Student found!");
        }
        else
        {
            Console.WriteLine($"Name: {found.StudentName}");
            Console.WriteLine($"Roll Number: {found.RollNumber}");
            Console.WriteLine($"Grade: {found.Grade}");
            Console.WriteLine($"School Name: {found.SchoolName}");
            Console.WriteLine($"Birth Date: {found.BirthDate}");
            Console.WriteLine($"Course: {found.Course}");
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }
    Console.WriteLine();

    if (Choice == "4")
    {
        Console.WriteLine("---- Search Student with RollNumber ----");
        Console.WriteLine("Roll Number: ");
        int searchId;
        int.TryParse(Console.ReadLine(), out searchId);
        Student? foundds = studentManagement.GetStudentByRollNumber(searchId);
        if (foundds == null)
        {
            Console.WriteLine("No Student found!");
        }
        else
        {
            Console.WriteLine($"Name: {foundds.StudentName}");
            Console.WriteLine($"Roll Number: {foundds.RollNumber}");
            Console.WriteLine($"Grade: {foundds.Grade}");
            Console.WriteLine($"School Name: {foundds.SchoolName}");
            Console.WriteLine($"Birth Date: {foundds.BirthDate}");
            Console.WriteLine($"Course: {foundds.Course}");
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }
    Console.WriteLine();

    if (Choice == "5")
    {
        Console.WriteLine("---- Search student by Grade ----");
        Console.WriteLine("Grade: ");
        string gradeInput = Console.ReadLine() ?? "";
        if (gradeInput.Length == 0)
        {
            Console.WriteLine("Grade can not be Empty!");
        }
        else
        {
            char searchGrade = gradeInput[0];

            Student? founde = studentManagement.GetStudentByGrade(searchGrade);
            if (founde == null)
            {
                Console.WriteLine("No Student found!");
            }
            else
            {
                Console.WriteLine($"Name: {founde.StudentName}");
                Console.WriteLine($"Roll Number: {founde.RollNumber}");
                Console.WriteLine($"Grade: {founde.Grade}");
                Console.WriteLine($"School Name: {founde.SchoolName}");
                Console.WriteLine($"Birth Date: {founde.BirthDate}");
                Console.WriteLine($"Course: {founde.Course}");
            }
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }
    Console.WriteLine();
    
    if (Choice == "6")
    {
        Console.WriteLine("---- Search student by School Name ----");
        Console.WriteLine("School Name: ");
        string searchSchoolName = Console.ReadLine() ?? "";
        Student? found = studentManagement.GetStudentBySchoolName(searchSchoolName);
        if (found == null)
        {
            Console.WriteLine("No Student found!");
        }
        else
        {
            Console.WriteLine($"Name: {found.StudentName}");
            Console.WriteLine($"Roll Number: {found.RollNumber}");
            Console.WriteLine($"Grade: {found.Grade}");
            Console.WriteLine($"School Name: {found.SchoolName}");
            Console.WriteLine($"Birth Date: {found.BirthDate}");
            Console.WriteLine($"Course: {found.Course}");
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }

    if (Choice == "7")
    {
        Console.WriteLine("---- Update Grade ----");
        Console.WriteLine("Grade: ");
        char searchRollNumber;
        char.TryParse(Console.ReadLine(), out searchRollNumber);
        Student? founddss = studentManagement.GetStudentByRollNumber(searchRollNumber);
        if (founddss == null)
        {
            Console.WriteLine("No Student found, try again!");
            Console.WriteLine("Roll Number: ");
        }
        else
        {
            Console.WriteLine("New Grade: ");
            char newGrade;
            char.TryParse(Console.ReadLine(), out newGrade);
            studentManagement.UpdateStudentGarde(founddss.RollNumber, newGrade);
            Console.WriteLine($"Grade: {founddss.Grade}");
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }
    Console.WriteLine();

    if (Choice == "8")
    {
        Console.WriteLine("---- Search Student with Birth Date ----");
        Console.WriteLine("Birth Date: ");
        DateOnly searchBirthDate;
        Console.WriteLine("(yyyy-MM-dd): ");
        DateOnly.TryParse(Console.ReadLine(), out searchBirthDate);
        Student? foundd = studentManagement.GetStudentByBirthDate(searchBirthDate);
        if (foundd == null)
        {
            Console.WriteLine("No Student found!");
        }
        else
        {
            Console.WriteLine($"Name: {foundd.StudentName}");
            Console.WriteLine($"Roll Number: {foundd.RollNumber}");
            Console.WriteLine($"Grade: {foundd.Grade}");
            Console.WriteLine($"School Name: {foundd.SchoolName}");
            Console.WriteLine($"Birth Date: {foundd.BirthDate}");
            Console.WriteLine($"Course: {foundd.Course}");
        }
        Console.WriteLine("Press Enter To Continue");
        Console.ReadLine();
    }
    Console.WriteLine();

    if (Choice == "9")
    {
        Console.WriteLine("Thanks for using our website!");
        break;
    }
}