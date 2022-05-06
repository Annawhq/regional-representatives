using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Windows;

namespace RegRepres.Models
{
    public class Region : Model
    {
        public int Id { get; set; }
        public string RegionDiscription { get; set; }
		public static List<Region> GetList()
		{
			var list = new List<Region>();
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = "SELECT * FROM region";
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						int id = reader.GetInt32(0);
						string regiondiscription = reader.GetString(1);
						var region = new Region
						{
							Id = id,
							RegionDiscription = regiondiscription
						};
						list.Add(region);
					}
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			return list;
		}
		public static void Add(Region region)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"INSERT INTO region (regiondiscription) VALUES(@regiondiscription)");
					command.Parameters.AddWithValue("regiondiscription", region.RegionDiscription);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Update(Region region)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"UPDATE region SET regiondiscription=@regiondiscription WHERE id=@id");
					command.Parameters.AddWithValue("regiondiscription", region.RegionDiscription);
					command.Parameters.AddWithValue("id", region.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public static void Delete(Region region)
		{
			try
			{
				using (var connect = new SQLiteConnection(_ConnectionString))
				{
					connect.Open();
					var command = connect.CreateCommand();
					command.CommandText = String.Format(@"DELETE FROM region WHERE id = @id");
					command.Parameters.AddWithValue("id", region.Id);
					command.ExecuteNonQuery();
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public Region(int id, string regionDiscription)
        {
            Id = id;
            RegionDiscription = regionDiscription;
        }
		public Region(string regionDiscription)
		{
			RegionDiscription = regionDiscription;
		}
		public Region() 
        {

        }
    }
}
