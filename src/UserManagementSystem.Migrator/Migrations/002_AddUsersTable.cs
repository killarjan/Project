using FluentMigrator;

namespace UserManagementSystem.Migrator.Migrations
{
    [Migration(2)]
    public class AddUsersTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            const string sql = @"
            CREATE TABLE IF NOT EXISTS users_table
            (
                id bigserial NOT NULL PRIMARY KEY,
                name  text NOT NULL,
                email text NOT NULL,
                created_at timestamp WITH TIME ZONE NOT NULL
            );";

            Execute.Sql(sql);
        }
    }
}