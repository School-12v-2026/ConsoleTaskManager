using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Core
{
    public class TaskManager
    {
        private const string FilePath = "tasks.txt";
        public List<TaskItem> Tasks { get; private set; }

        public TaskManager()
        {
            Tasks = new List<TaskItem>();
        }

        public void AddTask(string name)
        {
            Tasks.Add(new TaskItem(name));
        }

        public void CompleteTask(int index)
        {
            if (IsValidIndex(index))
            {
                Tasks[index].IsCompleted = true;
            }
        }

        public void RemoveTask(int index)
        {
            if (IsValidIndex(index))
            {
                Tasks.RemoveAt(index);
            }
        }

        public void SortByName()
        {
            Tasks = Tasks.OrderBy(t => t.Name).ToList();
        }

        public void SortByStatus()
        {
            Tasks = Tasks.OrderBy(t => t.IsCompleted).ToList();
        }

        public void SaveToFile()
        {
            List<string> lines = new List<string>();
            foreach (TaskItem task in Tasks)
            {
                lines.Add(task.ToString());
            }
            File.WriteAllLines(FilePath, lines);
        }

        public void LoadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(FilePath);
            Tasks = new List<TaskItem>();
            foreach (string line in lines)
            {
                Tasks.Add(TaskItem.FromFile(line));
            }
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < Tasks.Count;
        }
    }
}
