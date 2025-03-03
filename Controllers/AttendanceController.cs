using AttendanceJournalApi.Models;
using AttendanceJournalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceJournalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _service;

        public AttendanceController(AttendanceService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = _service.GetById(id);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        
        public IActionResult Create([FromBody] AttendanceRecord record)
        {
            var newRecord = _service.CreateRecord(record);
            return CreatedAtAction(nameof(GetById), new { id = newRecord.Id }, newRecord);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AttendanceRecord updatedRecord)
        {
            return _service.Update(id, updatedRecord) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? NoContent() : NotFound();
        }
    }
}
