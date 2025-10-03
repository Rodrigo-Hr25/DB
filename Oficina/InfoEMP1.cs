namespace Oficina
{
    internal class InfoEMP
    {
        private string funcionarioID;
        private string nome;
        private string telefone;
        private string email;
        private string morada;
        private string cargo;
        private string salario;

        public InfoEMP(string funcionarioID, string nome, string telefone, string email, string morada, string cargo, string salario)
        {
            this.funcionarioID = funcionarioID;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
            this.morada = morada;
            this.cargo = cargo;
            this.salario = salario;
        }
    }
}