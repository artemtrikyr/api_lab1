namespace AttendanceJournalApi.Models
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public string Group { get; set; } = string.Empty;
        public string Student { get; set; } = string.Empty;
        public string Discipline { get; set; } = string.Empty;
        public string Teacher { get; set; } = string.Empty;
        public DateTime LessonDate { get; set; }
        public bool WasPresent { get; set; }
    }
}
