using AttendanceJournalApi.Models;

namespace AttendanceJournalApi.Services;

public class AttendanceService
{
    private readonly List<AttendanceRecord> _records = new()
    {
        new AttendanceRecord { Id = 1, Group = "CS101", Student = "John Doe", Discipline = "Mathematics", Teacher = "Dr. Smith", LessonDate = DateTime.UtcNow, WasPresent = true },
        new AttendanceRecord { Id = 2, Group = "CS102", Student = "Jane Smith", Discipline = "Physics", Teacher = "Dr. Brown", LessonDate = DateTime.UtcNow, WasPresent = false }
    };

    public List<AttendanceRecord> GetAll() => _records;

    public AttendanceRecord? GetById(int id) => _records.FirstOrDefault(r => r.Id == id);

    public AttendanceRecord CreateRecord(AttendanceRecord newRecord)
    {
        newRecord.Id = _records.Count > 0 ? _records.Max(r => r.Id) + 1 : 1;
        _records.Add(newRecord);
        Console.WriteLine($"[LOG] Додано запис: ID={newRecord.Id}, Student={newRecord.Student}");
        return newRecord;
    }



    public bool Update(int id, AttendanceRecord updatedRecord)
    {
        var record = _records.FirstOrDefault(r => r.Id == id);
        if (record == null) return false;

        record.Group = updatedRecord.Group;
        record.Student = updatedRecord.Student;
        record.Discipline = updatedRecord.Discipline;
        record.Teacher = updatedRecord.Teacher;
        record.LessonDate = updatedRecord.LessonDate;
        record.WasPresent = updatedRecord.WasPresent;

        Console.WriteLine($"[LOG] Оновлено запис: ID={id}, Student={record.Student}");
        return true;
    }


    public bool Delete(int id)
    {
        var record = _records.FirstOrDefault(r => r.Id == id);
        if (record == null) return false;
    
        _records.Remove(record);
        Console.WriteLine($"[LOG] Видалено запис: ID={id}");
        return true;
    }

}
