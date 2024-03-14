namespace DeepFocus.Modules.Tasks.Core.Entities
{
    internal abstract class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
    }
}
