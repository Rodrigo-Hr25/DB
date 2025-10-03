using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oficina
{
    public partial class CriarVeiculo : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");
        private string clienteID;

        public CriarVeiculo(string selectedClienteID)
        {
            InitializeComponent();
            this.clienteID = selectedClienteID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string matricula = textBox1.Text;
            string marca = textBox2.Text;
            string VIN = textBox3.Text;
            string modelo = textBox4.Text;
            string data = textBox5.Text;
            string TipoVeiculo = textBox6.Text;

            if (string.IsNullOrWhiteSpace(matricula) || string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(VIN) || string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(TipoVeiculo))
            {
                MessageBox.Show("Por favor preencha todos os campos.");
                return;
            }
            if (!DateTime.TryParse(data, out DateTime dataVeiculo))
            {
                MessageBox.Show("A data de registro do veículo não é válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                CN.Open();
                SqlCommand command = new SqlCommand("dbo.InsertVehicle", CN);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@Placa", matricula);
                command.Parameters.AddWithValue("@Marca", marca);
                command.Parameters.AddWithValue("@VIN", VIN);
                command.Parameters.AddWithValue("@Modelo", modelo);
                command.Parameters.AddWithValue("@DataVeiculo", dataVeiculo);
                command.Parameters.AddWithValue("@TipoVeiculo", TipoVeiculo);
                command.Parameters.AddWithValue("@clienteID", clienteID); // Pass as string

                SqlParameter outputIdParam = new SqlParameter("@VeiculoID", SqlDbType.VarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

                command.ExecuteNonQuery();

                string newVeiculoID = outputIdParam.Value.ToString();
                MessageBox.Show($"Veículo criado com sucesso. ID: {newVeiculoID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao criar veículo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void textBox6_TextChanged(object sender, EventArgs e) { }
    }
}
