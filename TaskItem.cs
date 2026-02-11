using System;

namespace TaskManager.Models
{
    public class TaskItem
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string name)
        {
            Name = name;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return string.Format("{0}|{1}", Name, IsCompleted);
        }

        public static TaskItem FromFile(string line)
        {
            string[] parts = line.Split('|');
            return new TaskItem(parts[0])
            {
                IsCompleted = bool.Parse(parts[1])
            };
        }
    }
}
