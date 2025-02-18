namespace Universities.models.dto
{
    public class UniversityDataDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }

    public class ApplicationDataDto
    {
        public int? UniID { get; set; }
        public int? UniMajor { get; set; }
        public decimal? CommulativeRate { get; set; }
    }
}

