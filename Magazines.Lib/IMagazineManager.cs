using System;
using System.Collections.Generic;
using System.Text;

namespace Magazines.Lib
{
    public interface IMagazineManager
    {
        void RegisterMaterialWithinMagazine(IMagazine mag, MaterialQuantity quantity);
        string DisplayContentOfMagazines(IMagazineContentDisplayStrategy displayStrategy);
    }
}
