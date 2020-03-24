
using Magazines.Lib;
using Moq;
using System;
using Xunit;
namespace Magazines.Tests
{
    public class MaterialQuantityTests
    {

        [Fact]
        public void InstiatingNewMaterialEntity_NegativeQuantityProvided_ExceptionThrown()
        {
            Assert.Throws<InvalidOperationException>(() => MaterialQuantity.From(It.IsAny<Material>(), -10));
        }

        [Fact]
        public void InstiatingNewMaterialEntity_NonNegativeQuantityProvided_NonExceptionThrown()
        {
            var createdMaterialQuantity = MaterialQuantity.From(It.IsAny<Material>(), 10);
            Assert.NotNull(createdMaterialQuantity);
        }

       
    }
}
