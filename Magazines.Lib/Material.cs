using System;
using System.Diagnostics.CodeAnalysis;

public class Material : IEquatable<Material>
{
    public string MaterialId { get; }
    public string MaterialName { get; }

    public Material(string materialId, string materialName)
    {
        MaterialId = materialId;
        MaterialName = materialName;
    }
    public override string ToString()
    {
        return $"{MaterialName} #{MaterialId}";
    }

    public bool Equals([AllowNull] Material other)
    {
        return other.MaterialId == this.MaterialId && other.MaterialName == this.MaterialId;
    }
}