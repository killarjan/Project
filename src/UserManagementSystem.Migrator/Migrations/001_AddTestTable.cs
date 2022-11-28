using FluentMigrator;

namespace UserManagementSystem.Migrator.Migrations
{
    [Migration(1)]
    public class AddTestTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            const string sql = @"
            CREATE TABLE IF NOT EXISTS test_table
            (
                id bigserial NOT NULL PRIMARY KEY,
                name  text NOT NULL,
                created_at timestamp WITH TIME ZONE NOT NULL
            );";

            Execute.Sql(sql);
        }
    }
}
