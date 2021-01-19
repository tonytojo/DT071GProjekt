using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data;
using System.Windows.Forms;

namespace Projekt
{
    public class DatabaseAPI
    {
        string connectionString;
        //SqlConnection connection;
        //SqlCommand command;

        /// <summary>
        /// C-tor get the connection string 
        /// </summary>
        public DatabaseAPI()
        {
            connectionString = ConfigurationManager.ConnectionStrings["KnightTour"].ConnectionString;
        }
 
        /// <summary>
        /// Get a SqlConnection object. If connection exist return existing connection or else create a new one
        /// </summary>
        //public SqlConnection Connection
        //{
        //    get
        //    {
        //        if (connection == null)
        //        {
        //            connection = new SqlConnection(connectionString);
        //        }
        //        return connection;
        //    }
        //}

        /// <summary>
        ///  Get SqlCommand object object. If command exist return existing command or else create a new one
        /// </summary>
        //public SqlCommand Command
        //{
        //    get
        //    {
        //        if (command == null)
        //        {
        //            command = new SqlCommand();
        //            command.Connection = connection;
        //        }
        //        return command;
        //    }
        //}

        /// <summary>
        /// Add a new row
        /// </summary>
        /// <param name="name"personens namn</param>
        /// <param name="chessMoves">All a64 dragen</param>
        public void InsertIntoDb(string name, List<ChessMove> chessMoves)
        {
            DateTime created = DateTime.Now;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT into Person(name, created) VALUES (@name, @created); SELECT SCOPE_IDENTITY() ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@created", DateTime.Now);
                    int insertedID = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (ChessMove item in chessMoves)
                    {
                        query = "INSERT into KnightTour " +
                                         "(row, col, personid) " +
                                         "VALUES " +
                                         "(@Row, @Col, @Personid)";

                        cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@Row", item.Rad);
                        cmd.Parameters.AddWithValue("@Col", item.Col);
                        cmd.Parameters.AddWithValue("@Personid", insertedID);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Error when savinf to database");
            }
        }

        /// <summary>
        /// Get all the persons that has run the knighttours
        /// </summary>
        /// <returns>An DataTable that contains the result</returns>
        public DataTable GetKnightTourPerson()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from Person";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable persons = new DataTable();
                    adapter.Fill(persons);
                    return persons;
                }
            }
            catch (SqlException e )
            {
                throw e;
            }
        }

        /// <summary>
        /// Get all the moves for specified id
        /// </summary>
        /// <param name="id">The id for all the moves</param>
        /// <returns>An DataTable that contains the result</returns>
        public DataTable GetKnightToursMoves(int id)
          {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from KnightTour where personid= " + id;
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable moves = new DataTable();
                    adapter.Fill(moves);
                    return moves;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
          }
    }
}
