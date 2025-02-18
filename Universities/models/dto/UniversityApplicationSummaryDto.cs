namespace Universities.models.dto
{
    public class UniversityApplicationSummaryDto
    {
        public string University { get; set; }
        public string Major { get; set; }
        public decimal? HighestCommulativeRate { get; set; }
        public decimal? LowestCommulativeRate { get; set; }
    }
}
