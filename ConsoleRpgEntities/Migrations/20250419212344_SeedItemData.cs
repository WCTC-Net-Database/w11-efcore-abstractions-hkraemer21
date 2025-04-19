using ConsoleRpgEntities.Models.Equipment;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using static System.Net.Mime.MediaTypeNames;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    public partial class SeedItemData : BaseMigration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            RunSql(migrationBuilder);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            RunSqlRollback(migrationBuilder);
        }
    }
}
