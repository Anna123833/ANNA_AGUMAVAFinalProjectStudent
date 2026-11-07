namespace ANNA_AGUMAVAFinalProjectStudent.Models;

internal class Student : IStudents
{
    private string studentName { get; set; } = string.Empty;
    private static int nextRollNumber = 1;
    private int rollNumber;
    private string schoolName { get; set; } = string.Empty;
    private char grade { get; set; }
    private DateOnly birthDate { get; set; }
    private LearningCourse course;

    public string StudentName
    {
        get => studentName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Student name cannot be empty or contain only whitespace.");
            }
            studentName = value.Trim();
        }
    }
    public int RollNumber
    {
        get => rollNumber;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Roll number must be a positive integer.");
            }

            rollNumber = value;
        }
    }
    public char Grade
    {
        get => grade;
        set 
        {
            char g = char.ToUpper(value);
            if(g < 'A' || g > 'F')
            {
                throw new ArgumentException("Grade must be a letter between A and F.");
            }
            grade = g;
        }
    }
    public string SchoolName
    {
        get => schoolName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("School name cannot be empty or contain only whitespace.");
            }
            schoolName = value.Trim();
        }
    }
    public DateOnly BirthDate
    {
        get => birthDate;
        set
        {
            if (value > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("Birth date cannot be in the future.");
            }
            else if(value < DateOnly.FromDateTime(DateTime.Now.AddYears(-100)))
            {
                throw new ArgumentException("Birth date is not valid.");
            }
            else if(value > DateOnly.FromDateTime(DateTime.Now.AddYears(-18)))
            {
                throw new ArgumentException("Student must be at least 18 years old.");
            }
            birthDate = value;
        }
    }
    public LearningCourse Course { 
        get => course;
        set
        {
            if(!Enum.IsDefined(typeof(LearningCourse), value))
            {
                throw new ArgumentException("Invalid course selection.");
            }
            course = value;
        }
    }

    public string GetInfo()
    {
        Console.WriteLine($"Student Name: {StudentName}, Roll Number: {RollNumber}, Grade: {Grade}, School Name: {SchoolName}, Birth Date: {BirthDate}, Course: {Course}");
        return $"{StudentName}, {RollNumber}, {Grade}, {SchoolName}, {BirthDate}, {Course}";
    }
    public Student()
    {
        this.RollNumber = nextRollNumber++;
    }
    public Student(string studentName, char grade, string schoolName, DateOnly birthDate, LearningCourse studentCourse)
    {
        this.RollNumber = nextRollNumber++;
        this.StudentName = studentName;
        this.Grade = grade;
        this.SchoolName = schoolName;
        this.BirthDate = birthDate;
        this.Course = studentCourse;
    }
}