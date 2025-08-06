using MySql.Data.MySqlClient;

namespace TCC_SENAI_CAUE_GUEDES
{
    public static class Database
    {
        #region cabeçalho e campos iniciais

        // string de conexão com o banco de dados local //
        private const string connectionString = "server=localhost;database=transporte_curitiba;uid=root;pwd=;";

        #endregion

        // retorna uma conexão aberta com o banco de dados //
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString); // instancia a conexão //
            conn.Open(); // abre a conexão //
            return conn; // retorna a conexão aberta //
        }
    }
}
