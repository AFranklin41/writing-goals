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
        public string DateOnly
        {
            get
            {
                return GoalDate.ToShortDateString();
            }
            set { }
        }

        public string TimeOnly
        {
            get
            {
                return GoalDate.ToShortTimeString();
            }
            set { }
        }

        //TODO, update from int to something timey
        public double TimeGoal { get; set; }
        public int TimeActual { get; set; }
        public int WordCountGoal { get; set; }
        public int WordCountActual { get; set; }
        public string OptionalGoal { get; set; }
    }
}
