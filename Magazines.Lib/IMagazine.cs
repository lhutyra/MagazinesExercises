using System;
using System.Collections.Generic;
using System.Text;

namespace Magazines.Lib
{
   public interface IMagazine
    {
        string MagazineName { get; }
        int TotalInMagazine();
        void AddMaterialToStock(MaterialQuantity materialQuantity);
        string PrintContentOfMagazine(string displayFormat);
    }
}
