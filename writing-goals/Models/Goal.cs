using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace writing_goals.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public Sprint sprint { get; set; }
        public int SprintId { get; set; }
        public DateTime GoalDate { get; set; }
        public int TimeGoal { get; set; }
        public int TimeActual { get; set; }
        public int WordCountGoal { get; set; }
        public int WordCountActual { get; set; }
        public string OptionalGoal { get; set; }
    }
}
