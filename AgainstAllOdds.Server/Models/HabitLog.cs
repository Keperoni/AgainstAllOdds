namespace AgainstAllOdds.Server.Models
{
	public class HabitLog
	{
		public int Id { get; set; }
		public int HabitId { get; set; }
		public Habit Habit { get; set; } = null!;
		public DateOnly Date { get; set; }
		public bool IsCompleted { get; set; }
	}
}
