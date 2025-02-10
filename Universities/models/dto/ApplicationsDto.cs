namespace Universities.models.dto
{
    public class ApplicationsDto
    {
        public decimal ApplicationNumber { get; set; }  
        public bool ApplicationType { get; set; }  
        public string FullName { get; set; }  
        public string FullNameEn { get; set; }  
        public string AppID { get; set; } 
        public int? UniversityId { get; set; }  
        public string? UniversityNumber { get; set; }  
        public int? CollegeId { get; set; }  
        public int? MajorId { get; set; }  
        public decimal? SemesterGPA { get; set; }  
        public decimal? OverallGPA { get; set; }  
        public decimal? HighSchoolScore { get; set; }  
        public DateTime HighSchoolGraduationDate { get; set; }  
        public string? UniversityGrantID { get; set; }  
        public DateTime? UniversityGrantDate { get; set; }  
        public decimal GrantRateLimit { get; set; }  
        public int? NationalityCategory { get; set; }  
    }
}
