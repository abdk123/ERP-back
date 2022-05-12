using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Bwire.Authorization.Roles;
using Bwire.Authorization.Users;
using Bwire.MultiTenancy;
using Bwire.Inventory.MaterialSection.Materials;
using Bwire.Inventory.MaterialSection.Categories;
using Bwire.Inventory.MaterialSection.Attributes;
using Bwire.Inventory.Indexes;
using Bwire.Inventory.MaterialSection.Suppliers;
using Bwire.Inventory.WarehouseSection.Warehouses;
using Bwire.Inventory.WarehouseSection.Categories;
using Bwire.Inventory.RequestSection.MaterialRequests;
using Bwire.Inventory.MaterialSection.Materials.MaterialActions;
using Bwire.Inventory.WarehouseSection.Places;

namespace Bwire.EntityFrameworkCore
{
    public class BwireDbContext : AbpZeroDbContext<Tenant, Role, User, BwireDbContext>
    {
        public BwireDbContext(DbContextOptions<BwireDbContext> options)
            : base(options)
        {
        }

        /* Define a DbSet for each entity of the application */

        public DbSet<Unit> Units { get; set; }
        DbSet<Warehouse> Warehouses { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<AttributeValue> AttributeValues { get; set; }
        DbSet<CorrespondingMaterial> CorrespondingMaterials { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<MaterialUnit> MaterialUnits { get; set; }
        DbSet<MaterialCategory> MaterialCategories { get; set; }
        DbSet<Attribute> Attributes { get; set; }
        DbSet<AttributeOption> AttributeOptions { get; set; }
        DbSet<Manufacturer> Manufacturers { get; set; }
        DbSet<MaterialType> MaterialTypes { get; set; }
        DbSet<WarehouseType> WarehouseTypes { get; set; }
        DbSet<Area> Areas { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Street> Streets { get; set; }
        DbSet<Place> Places { get; set; }
        DbSet<WarehouseCategory> WarehouseCategories { get; set; }
        DbSet<MaterialRequest> MaterialRequests { get; set; }
        DbSet<MaterialRequestDetail> MaterialRequestDetails { get; set; }
        DbSet<MaterialPlace> MaterialPlaces { get; set; }
        DbSet<MaterialQuantity> MaterialQuantities { get; set; }
        DbSet<MaterialAction> MaterialActions { get; set; }
    }
}
