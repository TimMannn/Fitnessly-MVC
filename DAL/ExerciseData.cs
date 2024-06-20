using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ExerciseData : IExerciseData
    {
        private string mysqlCon;

        public ExerciseData(string mysqlCon)
        {
            this.mysqlCon = mysqlCon;
        }

        public List<Exercise> GetExercises(int WorkoutID)
        {
            {
                List<Exercise> exercises = new List<Exercise>();

                using (var connection = new MySqlConnection(mysqlCon))
                {
                    connection.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM exercise WHERE exercise.exercise_id IN (SELECT workoutexercise.exercise_id FROM workoutexercise WHERE workoutexercise.workout_id = {WorkoutID})", connection);
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int exerciseID = reader.GetInt32("exercise_id");
                        string exerciseName = reader.GetString("exercise_name");
                        double exerciseGewicht = reader.GetDouble("exercise_gewicht");
                        int exerciseSets = reader.GetInt32("exercise_sets");
                        int exerciseReps = reader.GetInt32("exercise_reps");
                        string display = reader.GetString("exercise_display");

                        exercises.Add(new Exercise(id: exerciseID, name: exerciseName, gewicht: exerciseGewicht, sets: exerciseSets, reps: exerciseReps, display: display));
                    }

                    return exercises;
                }
            }
        }

        // verstuur naar database
        public void SendExerciseData(string exerciseName, double exerciseGewicht, int exerciseSets, int exerciseReps, string display, int WorkoutID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = $"INSERT INTO exercise (exercise_name, exercise_gewicht, exercise_sets, exercise_reps, exercise_display) VALUES (@exerciseName, @exerciseGewicht, @exerciseSets, @exerciseReps, @display);";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@exerciseName", exerciseName);
                        cmd.Parameters.AddWithValue("@exerciseGewicht", exerciseGewicht);
                        cmd.Parameters.AddWithValue("@exerciseSets", exerciseSets);
                        cmd.Parameters.AddWithValue("@exerciseReps", exerciseReps);
                        cmd.Parameters.AddWithValue("@display", display);
                        cmd.ExecuteNonQuery();

                        string query2 = "SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                        cmd2.Transaction = transaction;
                        int ExerciseID = Convert.ToInt32(cmd2.ExecuteScalar());

                        string query3 = $"INSERT INTO workoutexercise (workout_id, exercise_id) VALUES (@workoutID, @exerciseID);";
                        MySqlCommand cmd3 = new MySqlCommand(query3, connection);
                        cmd3.Transaction = transaction;
                        cmd3.Parameters.AddWithValue("@workoutID", WorkoutID);
                        cmd3.Parameters.AddWithValue("exerciseID", ExerciseID);
                        cmd3.ExecuteNonQuery();

                        transaction.Commit();
                    }

                    catch (MySqlException ex)
                    {
                        try
                        {
                            transaction.Rollback();
                            throw ex;
                        }

                        catch (MySqlException exRollback)
                        {
                            throw exRollback;
                        }
                    }
                }
            }
        }

        // verwijder uit database
        public void DeleteExercise(int ID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                using (var transcation = connection.BeginTransaction())
                {
                    try
                    {
                        string query = $"DELETE FROM exercise WHERE exercise_id = (@ID)";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Transaction = transcation;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();

                        string query2 = $"DELETE FROM workoutexercise WHERE exercise_id = (@ID)";
                        MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                        cmd2.Transaction = transcation;
                        cmd2.Parameters.AddWithValue("@ID", ID);
                        cmd2.ExecuteNonQuery();

                        transcation.Commit();
                    }

                    catch (MySqlException ex)
                    {
                        try
                        {
                            transcation.Rollback();
                            throw ex;
                        }

                        catch (MySqlException exRollback)
                        {
                            throw exRollback;
                        }
                    }
                }
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
            }
        }

        public Exercise GetExercise(int ExerciseID)
        {
            {
                using (var connection = new MySqlConnection(mysqlCon))
                {
                    var exercise = new Exercise(0, "", 0, 0, 0, "block");
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
                        string display = reader.GetString("exercise_display");
                        exercise = new Exercise(id: exerciseID, name: exerciseName, gewicht: exerciseGewicht, sets: exerciseSets, reps: exerciseReps, display: display);
                    }

                    return exercise;
                }
            }
        }

        public void DisplayTrueExercise()
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();

                string query = $"UPDATE exercise SET exercise_display = 'block';";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public void DisplayFalseExercise(int ExerciseID)
        {
            using (var connection = new MySqlConnection(mysqlCon))
            {
                connection.Open();
                string query = $"UPDATE exercise SET exercise_display = 'none' WHERE exercise_id = @ExerciseID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ExerciseID", ExerciseID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
