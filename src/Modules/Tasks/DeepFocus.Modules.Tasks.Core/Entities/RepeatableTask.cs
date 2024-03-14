namespace DeepFocus.Modules.Tasks.Core.Entities
{
    internal class RepeatableTask : Task
    {
        public TimeOnly PlannedExecutionTime { get; set; }
        public string FrequencyUnit { get; set; }
        public IEnumerable<string> WeekDays { get; private set; }
        public IEnumerable<int> MonthDays { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
