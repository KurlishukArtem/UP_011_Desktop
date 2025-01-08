using master_pol.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YP01MasterFloor.Models;

namespace master_pol.Config
{
    public class DataContext: DbContext
    {
        public DbSet<TypeCompanies> typeCompanies { get; set; }
        public DbSet<Partners> partners { get; set; }
        public DbSet<ProcGetHistPartner> procGetHistPartner { get; set; }
        public DbSet<TypeMaterial> typeMaterials { get; set; }
        public DbSet<TypeProduct> typeProducts { get; set; }

        public void DataContex() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(ConnectionDataBase.connectionString, new MySqlServerVersion(new Version(8, 0, 1)));
    }
}
