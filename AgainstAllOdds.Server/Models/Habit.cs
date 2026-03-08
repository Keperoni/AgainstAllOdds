namespace AgainstAllOdds.Server.Models
{
	public class Habit
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
		public HabitType Type { get; set; }
		public bool IsActive { get; set; } = true;
		public DateTime InsDate { get; set; } = DateTime.UtcNow;
	}

	public enum HabitType
	{
		Good,
		Bad
	}
}
