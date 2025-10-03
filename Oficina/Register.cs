using Microsoft.Data.SqlClient;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oficina
{
    public partial class Register : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String email = textBox2.Text;
            String telefone = textBox3.Text;
            String morada = textBox4.Text;

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            if (!IsValidTelefone(telefone))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return;
            }

            if (string.IsNullOrWhiteSpace(morada))
            {
                MessageBox.Show("Please enter a valid address.");
                return;
            }

            try
            {
                   
                CN.Open();
                SqlCommand command = new SqlCommand("dbo.InsertClient", CN);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nome", name);
                command.Parameters.AddWithValue("@Telefone", telefone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Morada", morada);

                SqlParameter outputIdParam = new SqlParameter("@ClienteID", System.Data.SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();

                string newClientId = outputIdParam.Value.ToString();
                MessageBox.Show($"Client inserted successfully with ID: {newClientId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\d{9,15}$");
        }
    }
}
