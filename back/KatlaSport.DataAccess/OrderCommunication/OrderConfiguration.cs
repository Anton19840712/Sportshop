﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.OrderCommunication
{
    internal sealed class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("order");
            HasKey(i => i.Id);
            HasRequired(i => i.Customer).WithMany(i => i.Orders).HasForeignKey(i => i.CustomerId);
            HasRequired(i => i.Transport).WithMany(i => i.Orders).HasForeignKey(i => i.TransportId);
            Property(i => i.Id).HasColumnName("order_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.CustomerId).HasColumnName("customer_id").IsRequired();
            Property(i => i.TransportId).HasColumnName("transport_id").IsRequired();
            Property(i => i.OrderAcceptanceDate).HasColumnName("order_acceptance_date").IsRequired();
            Property(i => i.OrderDispatchDate).HasColumnName("order_dispatch_date").IsRequired();
        }
    }
}
