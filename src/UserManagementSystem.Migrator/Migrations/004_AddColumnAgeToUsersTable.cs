using FluentMigrator;

namespace UserManagementSystem.Migrator.Migrations
{
    [Migration(4)]
    public class AddColumnAgeToUsersTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            const string sql = @"ALTER TABLE users_table ADD COLUMN IF NOT EXISTS AGE INTEGER NULL";

            Execute.Sql(sql);
        }
    }
}