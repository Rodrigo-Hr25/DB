using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oficina
{
    public partial class Servico : Form
    {
        private object servicoID;
        private object descricao;
        private object veiculoID;
        private string? funcionarioID;
        private decimal pecaPreco;

        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");
        Random rnd = new Random();

        private int GenerateUniqueID()
        {
            int id;
            bool isUnique;

            do
            {
                id = rnd.Next(1000, 10000000);
                isUnique = CheckUniquePECAID(id);
            } while (!isUnique);

            return id;
        }

        private bool CheckUniquePECAID(int id)
        {
            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PECAS WHERE PecaID = @pecaID", CN);
                cmd.Parameters.AddWithValue("@pecaID", id);
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking unique ID: " + ex.Message);
                return false;
            }
            finally
            {
                CN.Close();
            }
        }

        public Servico(int servicoID, object veiculoID, string? funcionarioID, string descricao)
        {
            InitializeComponent();

            this.servicoID = servicoID;
            this.veiculoID = veiculoID;
            this.funcionarioID = funcionarioID;
            this.descricao = descricao;

            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nome FROM Pecas;", CN);
                SqlDataReader reader = cmd.ExecuteReader();

                comboBox1.DataSource = null;
                comboBox1.Items.Clear();

                while (reader.Read())
                {
                    if (reader["Nome"] != DBNull.Value)
                    {
                        string? nome = reader["Nome"].ToString();

                        if (!string.IsNullOrEmpty(nome))
                        {
                            comboBox1.Items.Add(nome);
                        }
                    }
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

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
            button1.Click += button1_Click;
        }

        private void PopulateListBox(string nome, string preco, string quantidadeStock, string fornecedor)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Nome: " + nome);
            listBox1.Items.Add("Preço: " + preco);
            listBox1.Items.Add("Quantidade em Stock: " + quantidadeStock);
            listBox1.Items.Add("Fornecedor: " + fornecedor);
            UpdateFinalPrice();
        }

        private void UpdateFinalPrice()
        {
            if (decimal.TryParse(textBox1.Text, out decimal quantity) &&
                decimal.TryParse(textBox2.Text, out decimal multiplier) &&
                pecaPreco > 0)
            {
                decimal finalPrice = quantity * multiplier * pecaPreco;
                listBox1.Items.Add("Preço Final: " + finalPrice.ToString("C"));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                try
                {
                    CN.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Nome, Preco, QuantidadeStock, Fornecedores FROM Pecas WHERE Nome = @Nome", CN);
                    cmd.Parameters.AddWithValue("@Nome", comboBox1.SelectedItem.ToString());
                    SqlDataReader reader = cmd.ExecuteReader();

                    listBox1.DataSource = null;
                    listBox1.Items.Clear();

                    while (reader.Read())
                    {
                        string precoStr = reader["Preco"].ToString();
                        decimal.TryParse(precoStr, out pecaPreco); // Store the price of the selected piece
                        PopulateListBox(reader["Nome"].ToString(), precoStr, reader["QuantidadeStock"].ToString(), reader["Fornecedores"].ToString());
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
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {            

            int pecaID = -1;
            if (comboBox1.SelectedItem != null)
            {
                try
                {
                    CN.Open();
                    SqlCommand cmd = new SqlCommand("SELECT PecaID FROM Pecas WHERE Nome = @Nome", CN);
                    cmd.Parameters.AddWithValue("@Nome", comboBox1.SelectedItem.ToString());
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        if (int.TryParse(reader["PecaID"].ToString(), out int id))
                        {
                            pecaID = id;
                        }
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao obter PecaID: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    if (CN.State == ConnectionState.Open)
                    {
                        CN.Close();
                    }
                }
            }

            if (pecaID == -1)
            {
                MessageBox.Show("PecaID inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int orderID = GenerateUniqueID();

            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ORDERSERVICE (OrdemServicoID, PecaID, Quantidade, VeiculosID, PrecoFinal) VALUES (@ordemServicoID, @pecaID, @quantidade, @veiculoID, @precoFinal)", CN);
                cmd.Parameters.AddWithValue("@ordemServicoID", orderID);
                cmd.Parameters.AddWithValue("@pecaID", pecaID);
                cmd.Parameters.AddWithValue("@quantidade", textBox2.Text);
                cmd.Parameters.AddWithValue("@veiculoID", veiculoID);
                cmd.Parameters.AddWithValue("@precoFinal", listBox1.Items[listBox1.Items.Count - 1].ToString().Replace("Preço Final: ", "").Replace("€", "").Replace(",", "."));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dados inseridos com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Falha ao inserir os dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao inserir os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
    }
}
