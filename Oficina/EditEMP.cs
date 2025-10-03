using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina
{
    public partial class EditEMP : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        private string funcionarioID;

        public EditEMP(string id, string nome, string telefone, string email, string morada, string cargo, string salario)
        {
            InitializeComponent();
            funcionarioID = id; // Store the clientID to identify the record to update
            textBox1.Text = nome;
            textBox2.Text = email;
            textBox3.Text = telefone;
            textBox4.Text = morada;
            textBox5.Text = cargo;
            textBox6.Text = salario;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("UPDATE FUNCIONARIOS SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Morada = @Morada, Cargo = @Cargo, Salario = @Salario WHERE funcionarioID = @funcionarioID;", CN);
                cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@Telefone", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                cmd.Parameters.AddWithValue("@Morada", textBox4.Text);
                cmd.Parameters.AddWithValue("@Cargo", textBox5.Text);
                cmd.Parameters.AddWithValue("@Salario", textBox6.Text);
                cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dados do funcionário atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhuma linha foi atualizada. Verifique se o funcionário existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao atualizar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (CN.State == ConnectionState.Open)
                {
                    CN.Close();
                }
            }

            var empData = GetUpdatedEmpData();
            InfoEmp infoClient = new InfoEmp(funcionarioID, empData.Nome, empData.Telefone, empData.Email, empData.Morada, empData.Cargo, empData.Salario);
            infoClient.Show();
            this.Close();
        }


        private (string Nome, string Telefone, string Email, string Morada, string Cargo, string Salario) GetUpdatedEmpData()
        {
            string nome = textBox1.Text;
            string telefone = textBox3.Text;
            string email = textBox2.Text;
            string morada = textBox4.Text;
            string cargo = textBox5.Text;
            string salario = textBox6.Text;

            return (nome, telefone, email, morada, cargo, salario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
