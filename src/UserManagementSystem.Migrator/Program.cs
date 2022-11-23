public class Program 
{ 
    static void Main(string[] args) 
    {
        RunMigrator.WithParameters(DbKind.Postgres, "Host=localhost:5432;Database=UserManagementSystem;Username=postgres;Password=mysecretpassword", typeof(Program).Assembly, args) ; 
    } 
}