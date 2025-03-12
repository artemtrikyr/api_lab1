using AttendanceJournalApi.Data;
using AttendanceJournalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceJournalApi.Services
{
    public class AttendanceService
    {
        private readonly ApplicationDbContext _context;

        public AttendanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AttendanceRecord>> GetAll()
        {
            return await _context.AttendanceRecords.ToListAsync();
        }

        public async Task<AttendanceRecord?> GetById(int id)
        {
            return await _context.AttendanceRecords.FindAsync(id);
        }

        public async Task<AttendanceRecord> CreateRecord(AttendanceRecord newRecord)
        {
            _context.AttendanceRecords.Add(newRecord);
            await _context.SaveChangesAsync();
            return newRecord;
        }

        public async Task<bool> Update(int id, AttendanceRecord updatedRecord)
        {
            var record = await _context.AttendanceRecords.FindAsync(id);
            if (record == null) return false;

            record.Group = updatedRecord.Group;
            record.Student = updatedRecord.Student;
            record.Discipline = updatedRecord.Discipline;
            record.Teacher = updatedRecord.Teacher;
            record.LessonDate = updatedRecord.LessonDate;
            record.WasPresent = updatedRecord.WasPresent;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var record = await _context.AttendanceRecords.FindAsync(id);
            if (record == null) return false;

            _context.AttendanceRecords.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
