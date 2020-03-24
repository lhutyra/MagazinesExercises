using Magazines.Lib;
using System;
using Xunit;

namespace Magazines.Tests
{
    public class MagazineMangerTests
    {
        protected IMagazineManager magazineManager;
        public MagazineMangerTests()
        {
            magazineManager = new MagazineManager();
        }

        [Fact]
        public void AddingMaterialToMagazine_PropertyCongiguredData_MagazineStateUpdated()
        {
            magazineManager.ClearMagazines();
            magazineManager.RegisterMaterialWithinMagazine(Magazine.From("Test Magazine"), MaterialQuantity.From(new Material("MaterialID", "Test Material"), 50));
            var contentOfMagazines = magazineManager.List();
            Assert.NotEmpty(contentOfMagazines);
        }

        [Fact]
        public void AddingMaterialToMagazine_ClearingMagazineCalled_EmptyListRetunred()
        {
            magazineManager.ClearMagazines();
            magazineManager.RegisterMaterialWithinMagazine(Magazine.From("Test Magazine"), MaterialQuantity.From(new Material("MaterialID", "Test Material"), 50));
            var contentOfMagazines = magazineManager.List();
            magazineManager.ClearMagazines();
            Assert.Empty(contentOfMagazines);
        }

        [Fact]
        public void InstiatingMaterialTwice_NonNegativeQuantityProvided_SumOfMaterialCorrect()
        {
            var material = new Material("MaterialId", "MaterialName");
            var magazineOne = Magazine.From("MagazineName1");
            var createdMaterialQuantity10 = MaterialQuantity.From(material, 10);
            magazineManager.ClearMagazines();
            magazineManager.RegisterMaterialWithinMagazine(magazineOne, createdMaterialQuantity10);
            var createdMaterialQuantity90 = MaterialQuantity.From(material, 90);
            magazineManager.RegisterMaterialWithinMagazine(magazineOne, createdMaterialQuantity90);
            Assert.Equal(100,magazineOne.TotalInMagazine());
        }
    }
}
