using Magazines.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

public class Magazine : IMagazine, IEquatable<Magazine>
{
    public string MagazineName { get; }
    public Dictionary<Material, int> _materialInMagazine = new Dictionary<Material, int>();
    protected Magazine(string magazineName)
    {
        MagazineName = magazineName;
    }
    public static Magazine From(string magazineName)
    {
        if (string.IsNullOrEmpty(magazineName))
        {
            throw new InvalidOperationException("Magazine name cannot be null");
        }
        return new Magazine(magazineName.Trim());
    }

    public void AddMaterialToStock(MaterialQuantity materialQuantity)
    {
        if (_materialInMagazine.ContainsKey(materialQuantity.Material))
        {
            _materialInMagazine[materialQuantity.Material] += materialQuantity.Quantity;
        }
        else
        {
            _materialInMagazine.Add(materialQuantity.Material, materialQuantity.Quantity);
        }

    }
    public int TotalInMagazine()
    {
        return _materialInMagazine.Values.Sum();
    }
  
    public bool Equals([AllowNull] Magazine other)
    {
        return other.MagazineName == this.MagazineName;
    }

    public string PrintContentOfMagazine(string materialFormat)
    {
        StringBuilder stringBuilder = new StringBuilder();
        var sortedStockInMagazine = _materialInMagazine.OrderBy(f => f.Key.MaterialId);
        foreach (var item in sortedStockInMagazine)
        {
            stringBuilder.Append(string.Format(materialFormat, item.Key.MaterialId, item.Value));
            stringBuilder.Append(Environment.NewLine);
        }
        return stringBuilder.ToString();
    }
}