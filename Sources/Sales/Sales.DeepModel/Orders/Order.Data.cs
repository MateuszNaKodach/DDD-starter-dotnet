using System;
using System.Collections.Generic;
using System.Linq;
using MyCompany.Crm.Sales.Products;

namespace MyCompany.Crm.Sales.Orders;

public partial class Order
{
    private readonly Data _data;

    private Order(Data data) => _data = data;

    public static Order RestoreFrom(Data data) => new(data);

    public interface Data : IEquatable<Data>
    {
        OrderId Id { get; set; }
        bool IsPlaced { get; set; }
        List<Item> Items { get; }
        
        public bool TryGetItem(ProductUnit productUnit, out Item? item)
        {
            item = Items.SingleOrDefault(i => i.ProductAmount.ProductUnit.Equals(productUnit));
            return item != null;
        }

        bool IEquatable<Data>.Equals(Data? other) =>
            other is not null &&
            Id.Equals(other.Id) &&
            IsPlaced == other.IsPlaced &&
            Items.SequenceEqual(other.Items);
    }
}