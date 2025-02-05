using System;

namespace Universities.Entities
{
    public class UniversityApplicationReserve
    {
        public decimal Appno { get; set; }
        public bool ApplicationCategory { get; set; }
        public string StudentName { get; set; }
        public string StudentNameEn { get; set; }
        public string ApplicationID { get; set; }
        public int? UniID { get; set; }
        public string? UniNumber { get; set; }
        public int? UniCollege { get; set; }
        public int? UniMajor { get; set; }
        public  decimal? SemesterRate { get; set; }
        public decimal?  CommulativeRate { get; set; }
        public decimal? HighSchoolGrade { get; set; }
        public DateTime HighSchoolGraduate { get; set; }
        public string? UniGrantID  { get; set; }
        public DateTime? UniGrantDate { get; set; }
        public decimal UniGrantRateLimit { get; set; }
        public int? nationalityCategory { get; set; }




        public virtual CommonZakat_MinorLookUpTable CommonZakat_MinorLookUpTable_UniID_nav {  get; set; }
        public virtual CommonZakat_MinorLookUpTable CommonZakat_MinorLookUpTable_UniCollege_nav { get; set; }
        public virtual CommonZakat_MinorLookUpTable CommonZakat_MinorLookUpTable_UniMajor_nav { get; set; }
        public virtual CommonZakat_MinorLookUpTable CommonZakat_MinorLookUpTable_nationalCategory_nav { get; set; }


        public virtual ICollection<UniAppCoursesReserve> UniAppCoursesReserve_Appno_nav { get; set; }



    }
}
