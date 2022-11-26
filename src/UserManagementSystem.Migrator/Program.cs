namespace UserManagementSystem.Migrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MigrateDatabase();
        }

        private static void MigrateDatabase()
        {
            var connectionString = "Host=localhost;Port=5432;Database=UserManagementSystem;Username=postgres;Password=mysecretpassword";
            var migrationRunner = new MigratorRunner(connectionString);
            migrationRunner.Migrate();
        }
    }
}
