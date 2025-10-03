using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina
{
    public partial class CreateEMP : Form
    {

        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");
        Random rnd = new Random();

        public CreateEMP()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String telefone = textBox4.Text;
            String email = textBox5.Text;
            String morada = textBox6.Text;
            String salario = textBox3.Text;
            String cargo = textBox2.Text;

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
                SqlCommand command = new SqlCommand("dbo.InsertEmployee", CN);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nome", name);
                command.Parameters.AddWithValue("@Telefone", telefone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Morada",morada);
                command.Parameters.AddWithValue("@Cargo", cargo);
                command.Parameters.AddWithValue("@Salario", salario);

                SqlParameter outputIdParam = new SqlParameter("@FuncionarioID", System.Data.SqlDbType.VarChar, 50)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();

                string newFuncionarioID = outputIdParam.Value.ToString();
                MessageBox.Show($"Employee added successfully  with ID: {newFuncionarioID} ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\d{9,15}$");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
    }
}
