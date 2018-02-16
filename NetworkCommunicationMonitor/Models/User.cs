using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Web.UI;

namespace NetworkCommunicationMonitor.Models
{
    public class User
    {
        //[Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        //[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        public int adminID;

        public bool isBlocked;


        public string answerProvided { get; set; }

        // This validates whether or not the password matches what the database has for the user
        // It will also retrieve the question IDs associated with the administrator's account.
        // The IDs will be put into the questionIDs array in a random order, so they only have to be
        // randomized initially. It will also set the values for the questions and correct answers.
        public string IsValid(string _username, string _password)
        {
            // Reset these everytime a login is attempted
            int[] questionIDs = new int[3];
            Stack<string> questions = new Stack<string>();
            Stack<string> correctAnswers = new Stack<string>();

            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"SELECT admin_id, admin_isBlocked, question_one_id, question_two_id, question_three_id FROM Administrator " +
                       "WHERE admin_username = \'" + _username + "\' AND admin_password = \'" + _password + "\'";
                var cmd = new SqlCommand(_sql, cn);

                cmd.Parameters
                    .Add(new SqlParameter(_username, SqlDbType.NVarChar))
                    .Value = _username;
                cmd.Parameters
                    .Add(new SqlParameter(_password, SqlDbType.NVarChar))
                    .Value = System.Web.Helpers.Crypto.SHA1(_password);
                cn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(reader);

                    DataRow row = table.Rows[0];
                    isBlocked = (bool)row["admin_isBlocked"];

                    // If the user is blocked, skip all the other work and immediately return false
                    if (isBlocked)
                        return "blocked";

                    adminID = Int32.Parse((string)row["admin_id"]);

                    // Collect the IDs
                    Global.questionIDs[0] = Int32.Parse((string)row["question_one_id"]);
                    Global.questionIDs[1] = Int32.Parse((string)row["question_two_id"]);
                    Global.questionIDs[2] = Int32.Parse((string)row["question_three_id"]);

                    reader.Dispose();
                    cmd.Dispose();

                    // Set values for the questions and correct answers
                    getQuestionsAndAnswers();
                    return "true";
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return "false";
                }
            }
        }

        // This will get the questions from the database and set the values for the corresponding
        // fields in the user object.
        public void getQuestionsAndAnswers()
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT question_question, answer FROM Question " +
                       "WHERE question_id IN (" + Global.questionIDs[0] + ", " + Global.questionIDs[1] + ", " + Global.questionIDs[2] + ")";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                List<string> questions = new List<string>();
                questions.Add(Convert.ToString(rows[0]["question_question"]));
                questions.Add(Convert.ToString(rows[1]["question_question"]));
                questions.Add(Convert.ToString(rows[2]["question_question"]));

                List<string> correctAnswers = new List<string>();
                correctAnswers.Add(Convert.ToString(rows[0]["answer"]));
                correctAnswers.Add(Convert.ToString(rows[1]["answer"]));
                correctAnswers.Add(Convert.ToString(rows[2]["answer"]));

                // Randomly choose the first question and assign it
                Random rand = new Random();
                int value = rand.Next(3);
                Global.questions.Push(questions[value]);
                Global.correctAnswers.Push(correctAnswers[value]);
                questions.Remove(questions[value]);
                correctAnswers.Remove(correctAnswers[value]);

                // Randomly choose the second question and assign it
                value = rand.Next(2);
                Global.questions.Push(questions[value]);
                Global.correctAnswers.Push(correctAnswers[value]);
                questions.Remove(questions[value]);
                correctAnswers.Remove(correctAnswers[value]);

                Global.questions.Push(questions[0]);
                Global.correctAnswers.Push(correctAnswers[0]);
            }
        }

        // This will flag the admin_isBlocked field in the database to true.
        public static void blockThisUser(int id)
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"UPDATE Administrator SET admin_isBlocked = '1' WHERE admin_id = '" + id + "'";
                var cmd = new SqlCommand(_sql, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public int getID()
        {
            int adminID = -1;
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable table = new DataTable();
                string _sql = @"SELECT admin_id FROM Administrator WHERE admin_username = '" + UserName + "'";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                table.Load(cmd.ExecuteReader());
                DataRow row = table.Rows[0];
                adminID = Convert.ToInt32(row["admin_id"]);
            }
            return adminID;
        }
    }
}