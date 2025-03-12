using AttendanceJournalApi.Models;
using AttendanceJournalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceJournalApi.Controllers;

[ApiController]
[Route("api/attendance")]
public class AttendanceController : ControllerBase
{
    private readonly AttendanceService _service;

    public AttendanceController(AttendanceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<AttendanceRecord>>> GetAll()
    {
        var records = await _service.GetAll();
        return Ok(records);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AttendanceRecord>> GetById(int id)
    {
        var record = await _service.GetById(id);
        return record != null ? Ok(record) : NotFound(new { message = "Record not found" });
    }

    [HttpPost]
    public async Task<ActionResult<AttendanceRecord>> Create([FromBody] AttendanceRecord record)
    {
        var newRecord = await _service.CreateRecord(record);
        return CreatedAtAction(nameof(GetById), new { id = newRecord.Id }, newRecord);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] AttendanceRecord updatedRecord)
    {
        if (!await _service.Update(id, updatedRecord))
            return NotFound(new { message = "Record not found" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (!await _service.Delete(id))
            return NotFound(new { message = "Record not found" });

        return NoContent();
    }
}
