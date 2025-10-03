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
    public partial class InfoEmp : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        public InfoEmp()
        {
        }

        public InfoEmp(string id, string nome, string telefone, string email, string morada, string cargo, string salario)
        {
            InitializeComponent();
            PopulateListBox(id, nome, telefone, email, morada, cargo, salario);
        }

        public InfoEmp(string? selectedClientName)
        {
            InitializeComponent();

            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("SELECT funcionarioID, Nome, Telefone, Email, Morada, Cargo, Salario FROM FUNCIONARIOS WHERE Nome = @Nome;", CN);
                cmd.Parameters.AddWithValue("@Nome", selectedClientName);
                SqlDataReader reader = cmd.ExecuteReader();

                listBox1.DataSource = null;

                while (reader.Read())
                {
                    PopulateListBox(reader["funcionarioID"].ToString(), reader["Nome"].ToString(), reader["Telefone"].ToString(), reader["Email"].ToString(), reader["Morada"].ToString(), reader["Cargo"].ToString(), reader["Salario"].ToString());
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void PopulateListBox(string id, string nome, string telefone, string email, string morada, string cargo, string salario)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("ID: " + id);
            listBox1.Items.Add("Nome: " + nome);
            listBox1.Items.Add("Telefone: " + telefone);
            listBox1.Items.Add("Email: " + email);
            listBox1.Items.Add("Morada: " + morada);
            listBox1.Items.Add("Cargo: " + cargo);
            listBox1.Items.Add("Salario: " + salario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InfoEmp_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                string id = listBox1.Items[0].ToString().Replace("ID: ", "");
                string nome = listBox1.Items[1].ToString().Replace("Nome: ", "");
                string telefone = listBox1.Items[2].ToString().Replace("Telefone: ", "");
                string email = listBox1.Items[3].ToString().Replace("Email: ", "");
                string morada = listBox1.Items[4].ToString().Replace("Morada: ", "");
                string cargo = listBox1.Items[5].ToString().Replace("Cargo: ", "");
                string salario = listBox1.Items[6].ToString().Replace("Salario: ", "");

                EditEMP edit = new EditEMP(id, nome, telefone, email, morada, cargo, salario);
                edit.Show();
            }
            else
            {
                MessageBox.Show("Nenhum cliente selecionado para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
