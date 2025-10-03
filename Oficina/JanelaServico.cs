using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Oficina
{
    public partial class JanelaServico : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");
        Random rnd = new Random();
        private string? selectedCliente;
        private string? selectedEmp;
        private int veiculoID;

        public JanelaServico(string? selectedClient, string? selectedEmp)
        {
            InitializeComponent();

            this.selectedCliente = selectedClient;
            this.selectedEmp = selectedEmp;

        }

        private int GenerateUniqueVeicID()
        {
            int id;
            bool isUnique;

            do
            {
                id = rnd.Next(100000, 10000000);
                isUnique = CheckUniqueVeicID(id);
            } while (!isUnique);

            return id;
        }

        private bool CheckUniqueVeicID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM VEICULOS WHERE veiculoID = @veiculoID", CN);
                cmd.Parameters.AddWithValue("@veiculoID", id);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking unique ID: " + ex.Message);
                return false;
            }

        }

        private void JanelaServico_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Pintura");
            comboBox1.Items.Add("Limpeza");
            comboBox1.Items.Add("Reparo");
            comboBox1.Items.Add("Revisão");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Validate VIN length
                /*if (textBox2.Text.Length != 17)
                {
                    MessageBox.Show("O VIN deve ter 17 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (textBox1.Text.Length != 8)
                {
                    MessageBox.Show("A placa deve ter 7 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }*/

                // Validate DataVeiculo as a valid date
                if (!DateTime.TryParse(textBox5.Text, out DateTime dataVeiculo))
                {
                    MessageBox.Show("A data de registro do veículo não é válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CN.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT clienteID FROM clientes WHERE Nome = @Nome", CN);
                cmd2.Parameters.AddWithValue("@Nome", selectedCliente);
                int IDClient = Convert.ToInt32(cmd2.ExecuteScalar());

                veiculoID = GenerateUniqueVeicID();

                SqlCommand cmd3 = new SqlCommand("INSERT INTO VEICULOS (VeiculoID, clienteID, Marca, VIN, TipoVeiculo, Modelo, DataVeiculo, Placa) VALUES (@veiculoID, @clienteID, @marca, @vin, @tipoveiculo, @modelo, @dataVeiculo, @placa)", CN);
                
                cmd3.Parameters.AddWithValue("@clienteID", IDClient);
                cmd3.Parameters.AddWithValue("@veiculoID", veiculoID);
                cmd3.Parameters.AddWithValue("@placa", textBox1.Text);
                cmd3.Parameters.AddWithValue("@vin", textBox2.Text);
                cmd3.Parameters.AddWithValue("@tipoveiculo", textBox6.Text);
                cmd3.Parameters.AddWithValue("@marca", textBox3.Text);
                cmd3.Parameters.AddWithValue("@modelo", textBox4.Text);
                cmd3.Parameters.AddWithValue("@dataVeiculo", textBox5.Text); // Use the parsed DateTime value

                cmd3.ExecuteNonQuery();
                MessageBox.Show("Veículo adicionado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar veículo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }

            try
            {
                if (string.IsNullOrWhiteSpace(richTextBox1.Text))
                {
                    MessageBox.Show("Todos os campos são obrigatórios. Por favor, preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CN.Open();

                SqlCommand cmdIDfunc = new SqlCommand("SELECT funcionarioID FROM funcionarios WHERE Nome = @Nome", CN);
                cmdIDfunc.Parameters.AddWithValue("@Nome", selectedEmp);

                string? IDfunc = cmdIDfunc.ExecuteScalar().ToString();

                SqlCommand cmdService = new SqlCommand("INSERT INTO SERVICOS (servicoID, veiculoID, funcionarioID, descricao) VALUES (@servicoID, @veiculoID, @funcionarioID, @descricao)", CN);
                cmdService.Parameters.AddWithValue("@servicoID", rnd.Next(1000, 100000));
                cmdService.Parameters.AddWithValue("@veiculoID", veiculoID);
                cmdService.Parameters.AddWithValue("@funcionarioID", IDfunc);
                cmdService.Parameters.AddWithValue("@descricao", richTextBox1.Text);
                cmdService.ExecuteNonQuery();

                int servicoID = rnd.Next(1000, 100000);
                string? funcionarioID = selectedEmp;
                string descricao = richTextBox1.Text;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar serviço: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CN.Close();
            }


            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Selecione um serviço", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int servicoID = rnd.Next(1000, 100000);
                string? funcionarioID = selectedEmp;
                string descricao = richTextBox1.Text;

                Servico servico = new Servico(servicoID, veiculoID ,funcionarioID, descricao);
                servico.Show();
                this.Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}