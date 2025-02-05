namespace Universities.Entities
{
    public class CommonZakat_MinorLookUpTable
    {

        public int minorid { get; set; }
        public int majorid { get; set; }
        public string descs { get; set; }


        public virtual ICollection<UniversityApplicationReserve> UniversityApplicationReserve_UniID_nav { get; set; }
        public virtual ICollection<UniversityApplicationReserve> UniversityApplicationReserve_UniCollege_nav { get; set; }
        public virtual ICollection<UniversityApplicationReserve> UniversityApplicationReserve_UniMajor_nav { get; set; }
        public virtual ICollection<UniversityApplicationReserve> UniversityApplicationReserve_nationalCategory_nav { get; set; }
        public virtual ICollection<UniAppCoursesReserve> UniAppCoursesReserve_CourseID_nav { get; set; }



    }
}
