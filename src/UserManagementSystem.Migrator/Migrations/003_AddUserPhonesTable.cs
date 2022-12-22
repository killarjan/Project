using FluentMigrator;

namespace UserManagementSystem.Migrator.Migrations
{
    [Migration(3)]
    public class AddUsersPhonesTable : ForwardOnlyMigration
    {
        public override void Up()
        {
            const string sql = @"
            CREATE TABLE IF NOT EXISTS users_phones_table
            (
                id bigserial NOT NULL PRIMARY KEY,
                user_id bigint NOT NULL,
                phone_number text NOT NULL,
                created_at timestamp WITH TIME ZONE NOT NULL,
                updated_at timestamp WITH TIME ZONE NULL
            );";

            Execute.Sql(sql);
        }
    }
}