using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace writing_goals.Models.ViewModels
{
    public class SprintGoalsViewModel
    {
        public Sprint sprint { get; set; }
        public Goal goalOne { get; set; }
        public Goal goalTwo { get; set; }
        public Goal goalThree { get; set; }
        public Goal goalFour { get; set; }
        public Goal goalFive { get; set; }

    }
}
