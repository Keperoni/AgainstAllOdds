using AgainstAllOdds.Server.Data;
using AgainstAllOdds.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgaintsAllOdds.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HabitLogsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public HabitLogsController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetByDate([FromQuery] DateOnly date)
		{
			var logs = await _context.HabitLogs
				.Where(hl => hl.Date == date)
				.ToListAsync();

			return Ok(logs);
		}

		[HttpPost]
		public async Task<IActionResult> UpsertLog([FromBody] HabitLog habitLog)
		{
			var existing = await _context.HabitLogs
				.FirstOrDefaultAsync(hl => hl.Date == habitLog.Date && hl.HabitId == habitLog.HabitId);

			if (existing == null)
			{
				_context.HabitLogs.Add(habitLog);
			}
			else
			{
				existing.IsCompleted = habitLog.IsCompleted;
			}

			await _context.SaveChangesAsync();
			return Ok(existing ?? habitLog);
		}
	}
}