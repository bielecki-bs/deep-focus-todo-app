namespace DeepFocus.Modules.Tasks.Core.Entities
{
    internal class TemplateTask: Task
    {
        public IEnumerable<Task> ChildTasks { get; set; }
    }
}
