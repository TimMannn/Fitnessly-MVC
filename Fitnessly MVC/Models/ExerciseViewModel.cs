﻿using BLL;

namespace Fitnessly_MVC.Models
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Gewicht { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public List<ExerciseDetails> Exercises { get; set; }
        public int WorkoutID { get; set; }
        public string Display { get; set; }
    }
}
