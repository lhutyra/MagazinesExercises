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
    public override bool Equals(object right)
    {
        if (object.ReferenceEquals(right, null))
        {
            return false;
        }
        if (object.ReferenceEquals(this, right))
        {
            return true;
        }
        Material other = right as Material;
        if (other == null)
        {
            return false;
        }
        return this.Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (MaterialId ?? "").GetHashCode();
            hash = hash * 23 + (MaterialName ?? "").GetHashCode();
            return hash;
        }
    }

    public bool Equals([AllowNull] Material other)
    {
        return other.MaterialId == this.MaterialId && other.MaterialName == this.MaterialName;
    }
}