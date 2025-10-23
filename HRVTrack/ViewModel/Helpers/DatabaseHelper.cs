using System.Data.SQLite;
using System.Linq.Expressions;
using System.Windows;
namespace HRVTrack.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        public static void InitializeDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source = AppData.db;Version=3;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = $"CREATE TABLE HrvData (\r\n    TimeStamp TEXT NOT NULL,              -- DateTime jako tekst w formacie ISO 8601\r\n    HrvValue REAL NOT NULL,               -- RMSSD\r\n    HeartRate INTEGER NOT NULL,           -- Tętno\r\n    Readiness REAL NOT NULL,              -- 0.00 - 100.0\r\n    PhysiologicalAge INTEGER NOT NULL,    -- Wiek fizjologiczny\r\n    MeanRR REAL NOT NULL                  -- Średni RR w ms\r\n);";
                    cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd inicjalizacji bazy daynch:\n{ex.Message}", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static bool ExecuteNonQuery(string query)
        {
            try
            {
                using (var connection = new SQLiteConnection("Data Source = AppData.db;Version=3;"))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisywania do bazy danych:\n{ex.Message}", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static List<Dictionary<string, object>> ExecuteQuery(string query)
        {
            var results = new List<Dictionary<string, object>>();
            try
            {
                using (var connection = new SQLiteConnection("Data Source = AppData.db;Version=3;"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row[reader.GetName(i)] = reader.GetValue(i);
                                }
                                results.Add(row);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd odczytu bazy danych:\n{ex.Message}", "Błąd!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return results;
        }
    }
}
