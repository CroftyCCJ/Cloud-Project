using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebJobRecipes
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessCreateRecipe([QueueTrigger("putrecipe")] string message, [Queue("outrecipe")] out string output)
        {
            Recipe recipe = JsonConvert.DeserializeObject<Recipe>(message);

            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            output = "fail";

            conn = new SqlConnection();
            try
            {

                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlDataReader sqlReader = null;

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "INSERT INTO [dbo].[recipes]" +
                    "([Name]," +
                    "[Ingredients]," +
                    "[Description]," +
                    "[Date]," +
                    "[Owner]," +
                    "[Cuisine]," +
                    "[Img_Path]," +
                    "[Short_Description]) " +
                    "OUTPUT Inserted.ID " +
                    "VALUES " +
                    "(@name, @ingredients , @process, @date, @userid, @cuisine, @url, @desc)";


                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.Text, 150)).Value = recipe.Name;
                cmd.Parameters.Add(new SqlParameter("@ingredients", SqlDbType.VarChar)).Value = recipe.Ingredients; 
                cmd.Parameters.Add(new SqlParameter("@process", SqlDbType.VarChar)).Value = recipe.Process;
                cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = recipe.Date;
                cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.NVarChar, 128)).Value = recipe.Owner;
                cmd.Parameters.Add(new SqlParameter("@cuisine", SqlDbType.VarChar, 150)).Value = recipe.Cuisine.ToString();
                cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar)).Value = recipe.ImageUrl;
                cmd.Parameters.Add(new SqlParameter("@desc", SqlDbType.VarChar, 140)).Value = recipe.Description;
             
               
                Console.WriteLine("parameter values: " + recipe.Name + "|" + recipe.Ingredients + "|" + recipe.Process + "|" + recipe.Date + "|" + recipe.Owner + "|" + recipe.Cuisine.ToString() + "|" + recipe.ImageUrl + "|" + recipe.Description + "|");



                Console.WriteLine("EXE: console");

                sqlReader = cmd.ExecuteReader();

                int insertedId = -1;

                while (sqlReader.Read())
                {
                    Console.WriteLine("In WHILE");
                    insertedId = sqlReader.GetInt32(0);
                }

                output = insertedId.ToString();
                Console.WriteLine("OUPUT WEB JOB RECIPES: " + output);
               
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

        public static void ProcessEditRecipe([QueueTrigger("updaterecipe")] string message, [Queue("outrecipe")] out string output)
        {

            Recipe recipe = JsonConvert.DeserializeObject<Recipe>(message);

            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            output = "fail";

            conn = new SqlConnection();
            try
            {

                conn.ConnectionString = myConnectionString;
                conn.Open();



                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "UPDATE [dbo].[recipes]" +
                    "SET [Name] = @name," +
                    "[Ingredients] = @ingredients," +
                    "[Description] = @process," +
                    "[Date] = @date," +
                    "[Owner] = @userid," +
                    "[Cuisine] = @cuisine," +
                    "[Img_Path] = @url," +
                    "[Short_Description] = @desc " +
                    "WHERE ID = @recipeid ";


                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.Text, 150)).Value = recipe.Name;
                cmd.Parameters.Add(new SqlParameter("@ingredients", SqlDbType.VarChar)).Value = recipe.Ingredients;
                cmd.Parameters.Add(new SqlParameter("@process", SqlDbType.VarChar)).Value = recipe.Process;
                cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime)).Value = recipe.Date;
                cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.NVarChar, 128)).Value = recipe.Owner;
                cmd.Parameters.Add(new SqlParameter("@cuisine", SqlDbType.VarChar, 150)).Value = recipe.Cuisine.ToString();
                cmd.Parameters.Add(new SqlParameter("@url", SqlDbType.VarChar)).Value = recipe.ImageUrl;
                cmd.Parameters.Add(new SqlParameter("@desc", SqlDbType.VarChar, 140)).Value = recipe.Description;
                cmd.Parameters.Add(new SqlParameter("@recipeid", SqlDbType.Int)).Value = recipe.RecipeId;


                Console.WriteLine("parameter values: " + recipe.Name + "|" + recipe.Ingredients + "|" + recipe.Process + "|" + recipe.Date + "|" + recipe.Owner + "|" + recipe.Cuisine.ToString() + "|" + recipe.ImageUrl + "|" + recipe.Description + "|");



                Console.WriteLine("EXE: console");

                cmd.ExecuteNonQuery();


                output = recipe.RecipeId.ToString();
                Console.WriteLine("OUPUT WEB JOB RECIPES: " + output);

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

        public static void ProcessDeleteRecipe([QueueTrigger("deleterecipe")] string message, [Queue("outrecipe")] out string output)
        {

            int recipeid = Int32.Parse(message);

            SqlConnection conn;
            string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //string myConnectionString = Configuration.GetConnectionString("AzureSQLServerDB");

            output = "fail";

            conn = new SqlConnection();
            try
            {

                conn.ConnectionString = myConnectionString;
                conn.Open();

                SqlCommand cmd = new SqlCommand(null, conn);

                cmd.CommandText = "DELETE FROM [dbo].[recipes] WHERE ID = @recipeid";

                cmd.Parameters.Add(new SqlParameter("@recipeid", SqlDbType.Int)).Value = recipeid;


                Console.WriteLine("EXE: console");

                cmd.ExecuteNonQuery();


                output = "Delete successful";
                Console.WriteLine("OUPUT WEB JOB RECIPES: " + output);

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
