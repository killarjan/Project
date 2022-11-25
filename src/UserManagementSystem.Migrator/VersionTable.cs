using FluentMigrator.Runner.VersionTableInfo;
#pragma warning disable 618

namespace UserManagementSystem.Migrator;

[VersionTableMetaData]
public class VersionTable : DefaultVersionTableMetaData
{
    public override string TableName => "version_info";

    public override string ColumnName => "version";

    public override string DescriptionColumnName => "description";

    public override string AppliedOnColumnName => "applied_on";

    public override string UniqueIndexName => "uc_version";
}
