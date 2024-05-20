namespace AdoPractice1.Utils
{
    public static class ConnectionString
    {
        private static string cs= "Server=RAFI-ICT-MANIKG\\SQLEXPRESS;Database=adopractice1;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public static string dbcs {  get { return cs; } }   
    }
}
