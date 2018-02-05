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
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
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
        public bool IsValid(string _username, string _password)
        {

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
                        return false;

                    adminID = Int32.Parse((string)row["admin_id"]);

                    // Collect the IDs
                    List<int> IDs = new List<int>();
                    IDs.Add(Int32.Parse((string)row["question_one_id"]));
                    IDs.Add(Int32.Parse((string)row["question_two_id"]));
                    IDs.Add(Int32.Parse((string)row["question_three_id"]));

                    // Randomly choose the first ID and assign it
                    Random rand = new Random((int)DateTime.Now.Ticks);
                    int value = rand.Next(0, 2);
                    Global.questionIDs[0] = IDs[value];
                    IDs.Remove(IDs[value]);

                    // Randomly choose the second ID and assign it
                    value = rand.Next(0, 1);
                    Global.questionIDs[1] = IDs[value];
                    IDs.Remove(IDs[value]);

                    // Assign the last ID remaining
                    Global.questionIDs[2] = IDs[0];

                    reader.Dispose();
                    cmd.Dispose();

                    // Set values for the questions and correct answers
                    getQuestions();
                    getCorrectAnswers();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }
        }

        // This will get the questions from the database and set the values for the corresponding
        // fields in the user object.
        public void getQuestions()
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT question_question FROM Question " +
                       "WHERE question_id IN (" + Global.questionIDs[0] + ", " + Global.questionIDs[1] + ", " + Global.questionIDs[2] + ")";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                Global.questions.Push(Convert.ToString(rows[0]["question_question"]));
                Global.questions.Push(Convert.ToString(rows[1]["question_question"]));
                Global.questions.Push(Convert.ToString(rows[2]["question_question"]));
            }
        }

        // This will get the answers for the user's questions from the database and set the values for the corresponding
        // fields in the user object.
        public void getCorrectAnswers()
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                DataTable questionTable = new DataTable();
                DataRowCollection rows;
                string _sql = @"SELECT answer FROM Question " +
                       "WHERE question_id IN (" + Global.questionIDs[0] + ", " + Global.questionIDs[1] + ", " + Global.questionIDs[2] + ")";
                var cmd = new SqlCommand(_sql, cn);

                cn.Open();

                questionTable.Load(cmd.ExecuteReader());
                rows = questionTable.Rows;

                Global.correctAnswers.Push(Convert.ToString(rows[0]["answer"]));
                Global.correctAnswers.Push(Convert.ToString(rows[1]["answer"]));
                Global.correctAnswers.Push(Convert.ToString(rows[2]["answer"]));
            }
        }

        // This will flag the admin_isBlocked field in the database to true.
        public void blockThisUser()
        {
            var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (cn)
            {
                string _sql = @"UPDATE Administrator SET admin_isBlocked = '1' WHERE dmin_id = '" + adminID + "'";
                var cmd = new SqlCommand(_sql, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}