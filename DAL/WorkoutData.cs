using BLL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class WorkoutData : IWorkoutData
    {

        public List<Workout> GetWorkouts()
        {
            {
                // haal op uit database komt hier
                string mysqlCon = "server=localhost; user=root; database=fitnessly;";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
                try
                {
                    mySqlConnection.Open();

                    return
                    [
                        new(id: 9, name: "test"),
                        new(id: 10, name: "Testen")
                    ];
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    mySqlConnection.Close();
                }
                //

                //dit hoort niet meer bij database
                return
                [
                    new(id: 1, name: "Push day"),
                    new(id: 2, name: "Pull day"),
                    new(id: 3, name: "Leg day"),
                    new(id: 4, name: "Chest day"),
                    new(id: 5, name: "Back day"),
                    new(id: 6, name: "Shoulder day"),
                    new(id: 7, name: "Arm day"),
                    new(id: 8, name: "Cardio day")
                ];
                //
            }
        }
    }
}
