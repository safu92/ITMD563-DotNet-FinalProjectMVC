namespace Final_Project_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        Price = c.String(),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Carts", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Products", new[] { "Order_OrderID" });
            DropIndex("dbo.Carts", new[] { "Product_ProductID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
