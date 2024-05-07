﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IWorkoutData
    {
        List<Workout> GetWorkouts();
        void SendWorkouts(string workoutName);
    }
}
