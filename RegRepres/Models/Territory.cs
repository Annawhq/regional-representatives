using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace RegRepres.Models
{
    public class Territory : Model
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set; }
        public string Discription { get; set; }
		public static List<Territory> GetList()
		{
			var list = new List<Territory>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT id, (SELECT regiondiscription FROM region WHERE id = regionId), discription FROM territory";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string regionId = reader.GetString(1);
						string discription = reader.GetString(2);
						var territory = new Territory
						{
							Id = id,
							Region = regionId,
							Discription = discription
						};
						list.Add(territory);
					}

				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(Territory territory)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO territory (regionId, discription) VALUES(@regionId, @discription)");
					command.Parameters.AddWithValue("regionId", territory.RegionId);
					command.Parameters.AddWithValue("discription", territory.Discription);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(Territory territory)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE territory SET regionId=@regionId,discription=@discription WHERE id=@id");
					command.Parameters.AddWithValue("regionId", territory.RegionId);
					command.Parameters.AddWithValue("discription", territory.Discription);
					command.Parameters.AddWithValue("id", territory.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(Territory territory)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM territory WHERE id = @id");
					command.Parameters.AddWithValue("id", territory.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public Territory() { }
    }
}
