using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebRole1.Models;

namespace WebRole1.Services
{
    public class DBServices
    {
        public static Recipe GetRecipe(int id)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            conn = new SqlConnection();
            try
            {
                Recipe recipe = new Recipe();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlDataReader sqlReader = null;

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "SELECT * FROM [dbo].[recipes]" +
                                    "WHERE Id = @id";
               
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;

                sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    
                    recipe.Name = sqlReader.GetString(0);
                    recipe.Ingredients = sqlReader.GetString(1);
                    recipe.Process = sqlReader.GetString(2);
                    recipe.Date = sqlReader.GetDateTime(3);
                    recipe.Owner = sqlReader.GetString(4);
                    recipe.Cuisine = (EnumCuisine)Enum.Parse(typeof(EnumCuisine), sqlReader.GetString(5));
                    recipe.ImageUrl = sqlReader.GetString(6);
                    recipe.Description = sqlReader.GetString(7);
                    recipe.RecipeId = sqlReader.GetInt32(8);
                }

                return recipe;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}