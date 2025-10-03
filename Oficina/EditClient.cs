using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oficina
{
    public partial class EditClient : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        private string clientID;

        public EditClient()
        {
            InitializeComponent();
        }

        public EditClient(string id, string nome, string telefone, string email, string morada)
        {
            InitializeComponent();
            clientID = id; // Store the clientID to identify the record to update
            textBox1.Text = nome;
            textBox2.Text = email;
            textBox3.Text = telefone;
            textBox4.Text = morada;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("UPDATE CLIENTES SET Nome = @Nome, Telefone = @Telefone, Email = @Email, Morada = @Morada WHERE clienteID = @clientID;", CN);
                cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@Telefone", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                cmd.Parameters.AddWithValue("@Morada", textBox4.Text);
                cmd.Parameters.AddWithValue("@clientID", clientID);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dados do cliente atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhuma linha foi atualizada. Verifique se o cliente existe.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            var clientData = GetUpdatedClientData();
            InfoClient infoClient = new InfoClient(clientID, clientData.Nome, clientData.Telefone, clientData.Email, clientData.Morada);
            infoClient.Show();
            this.Close();
        }

        private (string Nome, string Telefone, string Email, string Morada) GetUpdatedClientData()
        {
            string nome = textBox1.Text;
            string telefone = textBox3.Text;
            string email = textBox2.Text;
            string morada = textBox4.Text;

            return (nome, telefone, email, morada);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage home = new HomePage();
            home.Show();
            this.Close();
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
    }
}
