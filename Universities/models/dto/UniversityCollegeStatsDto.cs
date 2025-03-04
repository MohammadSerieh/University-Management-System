namespace Universities.models.dto
{
    public class UniversityCollegeStatsDto
    {
        public string University { get; set; }  // University Name
        public string College { get; set; }     // College Name
        public int NumberOfStudents { get; set; }  // Total students in the college
        public decimal? AvgCommulativeRate { get; set; }  // Average GPA
    }
}
