using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADO_ReadFromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectString = @"Data Source = ASPIRE-5560G\ZLSQL; Initial Catalog = DBSlides; Integrated Security = True";

            try
            {
                SqlConnection db = new SqlConnection();
                db.ConnectionString = connectString;
                string selectQuery = "SELECT se.section_name AS section, st.first_name + ' ' + st.last_name AS 'délégué' FROM section se JOIN student st ON se.delegate_id = st.student_id";

                SqlCommand cmd = db.CreateCommand();
                cmd.CommandText = selectQuery;

                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("{0} | {1}", reader["section"], reader["délégué"]);
                }

                reader.Close();
                db.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
