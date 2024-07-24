namespace LibraryApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddressModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Addresses", "District", c => c.String());
            AddColumn("public.Addresses", "Neighborhood", c => c.String());
            AddColumn("public.Addresses", "AddressText", c => c.String());
            DropColumn("public.Addresses", "Street");
            DropColumn("public.Addresses", "State");
        }
        
        public override void Down()
        {
            AddColumn("public.Addresses", "State", c => c.String());
            AddColumn("public.Addresses", "Street", c => c.String());
            DropColumn("public.Addresses", "AddressText");
            DropColumn("public.Addresses", "Neighborhood");
            DropColumn("public.Addresses", "District");
        }
    }
}
