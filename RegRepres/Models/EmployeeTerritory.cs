using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace RegRepres.Models
{
    public class EmployeeTerritory : Model
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int TerritoryId { get; set; }
        public string Territory { get; set; }
		public static List<EmployeeTerritory> GetList()
		{
			var list = new List<EmployeeTerritory>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT id, (SELECT lastname FROM employee WHERE id = employeeId),(SELECT discription FROM territory WHERE id = territoryId) FROM employeeTerritory";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string employeeId = reader.GetString(1);
						string territoryId = reader.GetString(2);
						var employeeTerritory = new EmployeeTerritory
						{
							Id = id,
							Employee = employeeId,
							Territory = territoryId,
						};
						list.Add(employeeTerritory);
					}

				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(EmployeeTerritory employeeTerritory)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO employeeTerritory (employeeId, territoryId) VALUES (@employeeId, @territoryId)");
					command.Parameters.AddWithValue("employeeId", employeeTerritory.EmployeeId);
					command.Parameters.AddWithValue("territoryId", employeeTerritory.TerritoryId);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(EmployeeTerritory employeeTerritory)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE employeeTerritory SET employeeId=@employeeId,territoryId=@territoryId WHERE id=@id");
					command.Parameters.AddWithValue("employeeId", employeeTerritory.EmployeeId);
					command.Parameters.AddWithValue("territoryId", employeeTerritory.TerritoryId);
					command.Parameters.AddWithValue("id", employeeTerritory.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(EmployeeTerritory employeeTerritory)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM employeeTerritory WHERE id = @id");
					command.Parameters.AddWithValue("id", employeeTerritory.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public EmployeeTerritory() { }
    }
}
