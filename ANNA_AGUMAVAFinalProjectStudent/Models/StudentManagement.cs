namespace ANNA_AGUMAVAFinalProjectStudent.Models;

internal class StudentManagement
{
    private readonly List<Student> students;

    public StudentManagement(List<Student> students)
    {
        this.students = students;
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public IReadOnlyList<Student> GetAllStudents()
    {
        return students.AsReadOnly();
    }
    public bool UpdateStudentGarde(int rollNumber, char newGrade)
    {
        Student? student = GetStudentByRollNumber(rollNumber);
        if (student == null)
        {
            return false;
        }
        student.Grade = newGrade;
        return true;
    }
    public Student? GetStudentByGrade(char grade)
    {
        Student? result = null;
        foreach (Student item in students)
        {
            if (item.Grade == grade)
            {
                result = item;
                break;
            }
        }
        return result;
    }
    public Student? GetStudentByName(string studentName)
    {
        Student? result = null;
        foreach (Student item in students)
        {
            if (item.StudentName == studentName)
            {
                result = item;
                break;
            }
        }
        return result;
    }
    public Student? GetStudentBySchoolName(string schoolName)
    {
        Student? result = null;
        foreach (Student item in students)
        {
            if (item.SchoolName == schoolName)
            {
                result = item;
                break;
            }
        }
        return result;
    }
    public Student? GetStudentByRollNumber(int rollNumber)
    {
        Student? result = null;
        foreach (Student item in students)
        {
            if (item.RollNumber == rollNumber)
            {
                result = item;
                break;
            }
        }
        return result;
    }

    public Student? GetStudentByBirthDate(DateOnly birthdateDate)
    {
        Student? result = null;
        foreach (Student item in students)
        {
            if (item.BirthDate == birthdateDate)
            {
                result = item;
                break;
            }
        }
        return result;
    }
    public Student? GetStudentByCourse(LearningCourse course)
    {
        Student? result = null;
        foreach (Student item in students)
        {
            if (item.Course == course)
            {
                result = item;
                break;
            }
        }
        return result;
    }

    public LearningCourse ReadCourse()
    {
        LearningCourse[] courses = Enum.GetValues<LearningCourse>();
        for(int i = 0; i < courses.Length; i++)
        {
            Console.WriteLine($"{i + 1}.{courses[i]}");
        }
        Console.WriteLine("Select Course: 1 ICTLiteracy,  2 BasicsOfProgramming,  3 ObjectOrientedProgramming,  4 ComputerArchitectureAndOrganization,  5 DataStructures,  6 Database,  7 DataAnalysisAndStatistics,  8 OperatingSystems,  9 ModelingAndSimulation,  10 Algorithms,  11 SoftwareEngineering,  12 MathematicalProgramming,  13 NetworkTechnologiesAndCommunications,  14 WebProgramming,  15 FunctionalProgramming,  16 OperationsResearch,  17 ProjectPreparation,  18 ArtificialIntelligence,  19 ComputerLawAndEthics,  20 TeamProjects ");
        Console.WriteLine("Select Course: ");
        int choice;
        while(!int.TryParse(Console.ReadLine(), out choice) || choice<1 || choice>courses.Length)
        {
            Console.WriteLine($"Wrong Choice, select a number again from 1 to {courses.Length}");
        }
        return courses[choice - 1];
    }

}