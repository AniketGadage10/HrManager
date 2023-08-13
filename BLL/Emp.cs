using BOL;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BLL
{
    public class Emp
    {

        public static String s = @"server=localhost;port=3306;user=root;password=root123;database=emp";

        public static void insertEmp(BOL.Emp e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = s;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                String str = "insert into emp(eid,name,email,psw,department,date) values('" + e.eid + "','" + e.name + "','" + e.email + "','" + e.psw + "','" + e.department + "','" + e.date.ToString("yyyy-MM-dd") + "')";
                Console.WriteLine(str);
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
        }
        //eid  | name          | email            | psw       | department | date   
        public static List<BOL.Emp> getList()
        {
            List<BOL.Emp> emplist = new List<BOL.Emp>();

            MySqlConnection conn = new MySqlConnection(s);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                String str = "select * from emp";
                cmd.CommandText = str;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = int.Parse(reader["eid"].ToString());
                    String nm = reader["name"].ToString();
                    String em = reader["email"].ToString();
                    String psw = reader["psw"].ToString();
                    Department d = Enum.Parse<Department>(reader["department"].ToString());
                    DateOnly date = DateOnly.FromDateTime(DateTime.Parse(reader["date"].ToString()));
                    BOL.Emp emp = new BOL.Emp(id, nm, em, psw, d, date);
                    emplist.Add(emp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

            return emplist;
        }


        public static BOL.Emp Getbyid(int id)
        {
            BOL.Emp emp = new BOL.Emp();
            MySqlConnection conn = new MySqlConnection(s);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(); 
                cmd.Connection = conn;

                String str = "Select * from Emp where eid= " +id;
                cmd.CommandText = str;
                Console.WriteLine(str);
                MySqlDataReader reader=cmd.ExecuteReader();
                if (reader.Read())
                {
                    int i = int.Parse(reader["eid"].ToString());
                    String name = reader["name"].ToString();
                    String email = reader["email"].ToString();
                    String psw = reader["psw"].ToString();
                    Department department = Enum.Parse<Department>(reader["department"].ToString());
                    DateOnly date = DateOnly.FromDateTime(DateTime.Parse(reader["date"].ToString()));
                    Console.WriteLine(i + " " + name + " " + email + " " + department + " " + date);
                    emp.eid = i;
                    emp.name = name;
                    emp.email = email;
                    emp.psw = psw;
                    emp.date = date;
                    emp.department = department;
                    Console.WriteLine(emp);
                }
              }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return emp;
        }



        public static void UpdateEmp(BOL.Emp e)
        {

            MySqlConnection m = new MySqlConnection(s);

            try {
                m.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = m;
                String s = "update EMP SET name ='" + e.name + "',email='" + e.email + "',psw='" + e.psw + "',department='" + e.department + "',date='" + e.date.ToString("yyyy-MM-dd") + "' where eid="+e.eid;

                Console.WriteLine(s);
                cmd.CommandText = s;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally { m.Close(); }
                       
        }



        public static void deleteemp(int id)
        {

            MySqlConnection m = new MySqlConnection(s);

            try
            {
                m.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = m;
                String s = " delete from emp where eid=" + id;

                Console.WriteLine(s);
                cmd.CommandText = s;

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally { m.Close(); }

        }

        public static BOL.Emp validate(string e, string p)
        {

            BOL.Emp emp = new BOL.Emp();
            MySqlConnection con=new MySqlConnection(s);
            try
            {
                con.Open();
                String str = "select * from emp where email ='" + e + "' AND psw='" + p + "'";
              
                MySqlCommand c = new MySqlCommand();
              
                c.Connection = con;
                c.CommandText = str;

                MySqlDataReader reader = c.ExecuteReader();

                if(reader.Read())
                {
                    int i = int.Parse(reader["eid"].ToString());
                    String name = reader["name"].ToString();
                    String email = reader["email"].ToString();
                    String psw = reader["psw"].ToString();
                    Department department = Enum.Parse<Department>(reader["department"].ToString());
                    DateOnly date = DateOnly.FromDateTime(DateTime.Parse(reader["date"].ToString()));
                    Console.WriteLine(i + " " + name + " " + email + " " + department + " " + date);
                    emp.eid = i;
                    emp.name = name;
                    emp.email = email;
                    emp.psw = psw;
                    emp.date = date;
                    emp.department = department;
                    Console.WriteLine(emp);

                }

            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }    
            return emp;
        }
    }
}