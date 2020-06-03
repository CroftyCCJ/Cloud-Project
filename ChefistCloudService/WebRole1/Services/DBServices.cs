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

        public static List<Recipe> GetAllRecipes()
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            conn = new SqlConnection();
            try
            {
                
                List<Recipe> recipes = new List<Recipe>();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlDataReader sqlReader = null;

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "SELECT * FROM [dbo].[recipes]";

                sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.Name = sqlReader.GetString(0);
                    recipe.Ingredients = sqlReader.GetString(1);
                    recipe.Process = sqlReader.GetString(2);
                    recipe.Date = sqlReader.GetDateTime(3);
                    recipe.Owner = sqlReader.GetString(4);
                    recipe.Cuisine = (EnumCuisine)Enum.Parse(typeof(EnumCuisine), sqlReader.GetString(5));
                    recipe.ImageUrl = sqlReader.GetString(6);
                    recipe.Description = sqlReader.GetString(7);
                    recipe.RecipeId = sqlReader.GetInt32(8);
                    recipes.Add(recipe);
                }

                return recipes;

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

        public static List<Recipe> SearchRecipes(string search)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            conn = new SqlConnection();
            try
            {

                List<Recipe> recipes = new List<Recipe>();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlDataReader sqlReader = null;

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "SELECT * FROM [dbo].[recipes] WHERE FREETEXT(Short_Description, @searchword);";
                cmd.Parameters.Add(new SqlParameter("@searchword", SqlDbType.VarChar, 2000)).Value = search;

                sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.Name = sqlReader.GetString(0);
                    recipe.Ingredients = sqlReader.GetString(1);
                    recipe.Process = sqlReader.GetString(2);
                    recipe.Date = sqlReader.GetDateTime(3);
                    recipe.Owner = sqlReader.GetString(4);
                    recipe.Cuisine = (EnumCuisine)Enum.Parse(typeof(EnumCuisine), sqlReader.GetString(5));
                    recipe.ImageUrl = sqlReader.GetString(6);
                    recipe.Description = sqlReader.GetString(7);
                    recipe.RecipeId = sqlReader.GetInt32(8);
                    recipes.Add(recipe);
                }

                return recipes;

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


        public static List<Recipe> FilterRecipes(string filter)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            conn = new SqlConnection();
            try
            {

                List<Recipe> recipes = new List<Recipe>();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlDataReader sqlReader = null;

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "SELECT * FROM [dbo].[recipes] WHERE Cuisine = @filter";
                cmd.Parameters.Add(new SqlParameter("@filter", SqlDbType.VarChar, 200)).Value = filter;

                sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    Recipe recipe = new Recipe
                    {
                        Name = sqlReader.GetString(0),
                        Ingredients = sqlReader.GetString(1),
                        Process = sqlReader.GetString(2),
                        Date = sqlReader.GetDateTime(3),
                        Owner = sqlReader.GetString(4),
                        Cuisine = (EnumCuisine)Enum.Parse(typeof(EnumCuisine), sqlReader.GetString(5)),
                        ImageUrl = sqlReader.GetString(6),
                        Description = sqlReader.GetString(7),
                        RecipeId = sqlReader.GetInt32(8)
                    };
                    recipes.Add(recipe);
                }

                return recipes;

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
        public static List<Recipe> GetUserRecipes(string userid)
        {
            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            conn = new SqlConnection();
            try
            {
               
                List<Recipe> userRecipes = new List<Recipe>();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlDataReader sqlReader = null;

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "SELECT * FROM [dbo].[recipes]" +
                                    "WHERE Owner = @userid";

                cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.NVarChar, 128)).Value = userid;

                sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.Name = sqlReader.GetString(0);
                    recipe.Ingredients = sqlReader.GetString(1);
                    recipe.Process = sqlReader.GetString(2);
                    recipe.Date = sqlReader.GetDateTime(3);
                    recipe.Owner = sqlReader.GetString(4);
                    recipe.Cuisine = (EnumCuisine)Enum.Parse(typeof(EnumCuisine), sqlReader.GetString(5));
                    recipe.ImageUrl = sqlReader.GetString(6);
                    recipe.Description = sqlReader.GetString(7);
                    recipe.RecipeId = sqlReader.GetInt32(8);
                    userRecipes.Add(recipe);
                }

                return userRecipes;

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