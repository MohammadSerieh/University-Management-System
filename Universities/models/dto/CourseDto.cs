namespace Universities.models.dto
{
    public class CourseDto
    {
        public int UniAppCoursesID { get; set; }
        public decimal Appno { get; set; }
        public int CourseID { get; set; }
        public string CourseCenterID { get; set; }
        public string CourseLocation { get; set; }
        public DateTime CourseDate { get; set; }
        public byte[] CourseAtt { get; set; }
        public string DocumentName { get; set; }
        public string? MimeType { get; set; }
        public long? Size { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
