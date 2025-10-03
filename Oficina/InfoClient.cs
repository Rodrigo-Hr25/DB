using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oficina
{
    public partial class InfoClient : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        public InfoClient()
        {
            InitializeComponent();
        }

        public InfoClient(string id, string nome, string telefone, string email, string morada)
        {
            InitializeComponent();
            PopulateListBox(id, nome, telefone, email, morada);
        }

        public InfoClient(string? selectedClientName)
        {
            InitializeComponent();

            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("SELECT clienteID, Nome, Telefone, Email, Morada FROM CLIENTES WHERE Nome = @Nome;", CN);
                cmd.Parameters.AddWithValue("@Nome", selectedClientName);
                SqlDataReader reader = cmd.ExecuteReader();

                listBox1.DataSource = null;

                while (reader.Read())
                {
                    PopulateListBox(reader["clienteID"].ToString(), reader["Nome"].ToString(), reader["Telefone"].ToString(), reader["Email"].ToString(), reader["Morada"].ToString());
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

        public InfoClient(string id, string nome, string telefone, string email, string morada, string cargo, string salario) : this(id, nome, telefone, email, morada)
        {
        }

        private void PopulateListBox(string id, string nome, string telefone, string email, string morada)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("ID: " + id);
            listBox1.Items.Add("Nome: " + nome);
            listBox1.Items.Add("Telefone: " + telefone);
            listBox1.Items.Add("Email: " + email);
            listBox1.Items.Add("Morada: " + morada);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
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

                EditClient edit = new EditClient(id, nome, telefone, email, morada);
                edit.Show();
            }
            else
            {
                MessageBox.Show("Nenhum cliente selecionado para editar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void InfoClient_Load(object sender, EventArgs e)
        {

        }
    }
}
