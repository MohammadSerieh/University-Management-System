namespace Universities.Entities
{
    public class UniAppCoursesReserve
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

        public virtual UniversityApplicationReserve UniversityApplicationReserve_Appno_nav { get; set; }
        public virtual CommonZakat_MinorLookUpTable CommonZakat_MinorLookUpTable_CourseID_nav { get; set; }

    }
}
