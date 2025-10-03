using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace Oficina
{
    public partial class Relatorio : Form
    {
        SqlConnection CN = new SqlConnection("Data Source=RODRIGOMIGUEL\\SQLEXPRESS;Initial Catalog=Oficina;Integrated Security=True;Persist Security Info=True;Encrypt=True;Trust Server Certificate=True");

        public Relatorio()
        {
            InitializeComponent();

            // Load clients into comboBox1
            LoadClients();

            // Initialize listBox1 with all orders
            LoadAllOrders();
        }

        private void LoadClients()
        {
            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("select Nome from Clientes;", CN);
                SqlDataReader reader = cmd.ExecuteReader();

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
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the clients: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

        private void LoadAllOrders()
        {
            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("select * from ORDERSERVICE;", CN);
                SqlDataReader reader = cmd.ExecuteReader();

                listBox1.Items.Clear();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["OrdemServicoID"].ToString() + " - " + reader["VeiculosID"].ToString() + " - " + reader["PecaID"].ToString() + " - " + reader["Quantidade"].ToString() + " - " + reader["PrecoFinal"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the orders: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClient = comboBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedClient))
            {
                LoadOrdersForClient(selectedClient);
            }
        }

        private void LoadOrdersForClient(string clientName)
        {
            try
            {
                CN.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ORDERSERVICE OS INNER JOIN Clientes C ON OS.ClienteID = C.ClienteID WHERE C.Nome = @ClientName", CN);
                cmd.Parameters.AddWithValue("@ClientName", clientName);
                SqlDataReader reader = cmd.ExecuteReader();

                listBox1.Items.Clear();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["OrdemServicoID"].ToString() + " - " + reader["VeiculosID"].ToString() + " - " + reader["PecaID"].ToString() + " - " + reader["Quantidade"].ToString() + " - " + reader["PrecoFinal"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading the orders for the selected client: " + ex.Message);
            }
            finally
            {
                CN.Close();
            }
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
    }
}
