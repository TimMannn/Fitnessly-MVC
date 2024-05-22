using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ExerciseData : IExerciseData
    {
        //connectie string database
        string mysqlCon = "server=localhost; user=root; database=fitnessly;";

        public List<Exercise> GetExercises()
        {
            {
                List<Exercise> exercises = new List<Exercise>();

                using (var connection = new MySqlConnection(mysqlCon))
                {
                    try
                    {
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("select * from exercise", connection);
                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int exerciseID = reader.GetInt32("exercise_id");
                            string exerciseName = reader.GetString("exercise_name");
                            double exerciseGewicht = reader.GetDouble("exercise_gewicht");
                            int exerciseSets = reader.GetInt32("exercise_sets");
                            int exerciseReps = reader.GetInt32("exercise_reps");

                            exercises.Add(new Exercise(id: exerciseID, name: exerciseName, gewicht:exerciseGewicht, sets: exerciseSets, reps: exerciseReps));
                        }

                        return exercises;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        // verstuur naar database
        public void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"INSERT INTO exercise (exercise_name, exercise_gewicht, exercise_sets, exercise_reps) VALUES (@exerciseName, @exerciseGewicht, @exerciseSets, @exerciseReps);";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@exerciseName", exerciseName);
                cmd.Parameters.AddWithValue("@exerciseGewicht", exerciseGewicht);
                cmd.Parameters.AddWithValue("@exerciseSets", exerciseSets);
                cmd.Parameters.AddWithValue("@exerciseReps", exerciseReps);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // verwijder uit database
        public void DeleteExercise(int ID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"DELETE FROM exercise WHERE exercise_id = (@ID)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        // bewerk uit database
        public void EditExercise(string NewExerciseName, double NewExerciseGewicht, int NewExerciseSets, int NewExerciseReps, int ExerciseID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"UPDATE exercise SET exercise_name = @NewExerciseName, exercise_gewicht = @NewExerciseGewicht, exercise_sets = @NewExerciseSets, exercise_reps = @NewExerciseReps WHERE exercise_id = @ExerciseID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NewExerciseName", NewExerciseName);
                cmd.Parameters.AddWithValue("@NewExerciseGewicht", NewExerciseGewicht);
                cmd.Parameters.AddWithValue("@NewExerciseSets", NewExerciseSets);
                cmd.Parameters.AddWithValue("@NewExerciseReps", NewExerciseReps);
                cmd.Parameters.AddWithValue("@ExerciseID", ExerciseID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Exercise GetExercise(int ExerciseID)
        {
            {
                using (var connection = new MySqlConnection(mysqlCon))
                {
                    try
                    {
                        var exercise = new Exercise(0, "", 0, 0, 0);
                        connection.Open();
                        MySqlCommand mySqlCommand = new MySqlCommand("select * from exercise WHERE exercise_id = @ExerciseID", connection);
                        mySqlCommand.Parameters.AddWithValue("@ExerciseID", ExerciseID);
                        MySqlDataReader reader = mySqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            int exerciseID = reader.GetInt32("exercise_id");
                            string exerciseName = reader.GetString("exercise_name");
                            double exerciseGewicht = reader.GetDouble("exercise_gewicht");
                            int exerciseSets = reader.GetInt32("exercise_sets");
                            int exerciseReps = reader.GetInt32("exercise_reps");
                            exercise = new Exercise(id: exerciseID, name: exerciseName, gewicht: exerciseGewicht, sets: exerciseSets, reps: exerciseReps);
                        }

                        return exercise;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
