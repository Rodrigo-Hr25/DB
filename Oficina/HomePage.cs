using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Oficina
{
    public partial class HomePage : Form
    {
        private readonly SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadComboBoxData("SELECT Nome FROM funcionarios;", comboBox3);
            LoadComboBoxData("SELECT Nome FROM clientes;", comboBox2);
        }

        private void LoadComboBoxData(string query, ComboBox comboBox)
        {
            try
            {
                CN.Open();
                using (SqlCommand cmd = new SqlCommand(query, CN))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    comboBox.Items.Clear();
                    while (reader.Read())
                    {
                        if (reader["Nome"] != DBNull.Value)
                        {
                            string nome = reader["Nome"].ToString();
                            if (!string.IsNullOrEmpty(nome))
                            {
                                comboBox.Items.Add(nome);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowErrorMessage($"Erro ao carregar os dados: {ex.Message}");
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro inesperado: {ex.Message}");
            }
            finally
            {
                if (CN.State == ConnectionState.Open)
                {
                    CN.Close();
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                JanelaServico janelaservico = new JanelaServico(comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString());
                janelaservico.Show();
                this.Hide();
            }
            else
            {
                ShowErrorMessage("Selecione um Cliente e um Empregado para continuar.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form3 = new Register();
            form3.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                InfoClient form3 = new InfoClient(comboBox2.SelectedItem.ToString());
                form3.Show();
                this.Hide();
            }
            else
            {
                ShowErrorMessage("Selecione um Cliente para obter a respetiva ficha técnica.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                InfoEmp infoEmp = new InfoEmp(comboBox3.SelectedItem.ToString());
                infoEmp.Show();
                this.Hide();
            }
            else
            {
                ShowErrorMessage("Selecione um Empregado para obter a respetiva ficha técnica.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateEMP createEMP = new CreateEMP();
            createEMP.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implement functionality if needed
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Implement functionality if needed
        }
    }
}
