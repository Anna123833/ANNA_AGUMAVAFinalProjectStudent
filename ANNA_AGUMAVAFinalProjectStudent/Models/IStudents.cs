namespace ANNA_AGUMAVAFinalProjectStudent.Models;
internal enum LearningCourse
{
    ICTLiteracy,
    BasicsOfProgramming,
    ObjectOrientedProgramming,
    ComputerArchitectureAndOrganization,
    DataStructures,
    Database,
    DataAnalysisAndStatistics,
    OperatingSystems,
    ModelingAndSimulation,
    Algorithms,
    SoftwareEngineering,
    MathematicalProgramming,
    NetworkTechnologiesAndCommunications,
    WebProgramming,
    FunctionalProgramming,
    OperationsResearch,
    ProjectPreparation,
    ArtificialIntelligence,
    ComputerLawAndEthics,
    TeamProjects
}
internal interface IStudents
{
    public string StudentName { get; set; }
    public int RollNumber { get; set; }
    public char Grade { get; set; }
    public string SchoolName { get; set; }
    public DateOnly BirthDate { get; set; }
    public LearningCourse Course { get; set; }
    string GetInfo();
}