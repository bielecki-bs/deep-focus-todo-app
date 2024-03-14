namespace DeepFocus.Modules.Tasks.Core.Entities
{
    internal class RegularTask : Task
    {
        public bool Completed { get; set; }
        public DateTime CompletedDateTime { get; set; }
        public TimeSpan ActualDuration { get; set; }
    }
}
