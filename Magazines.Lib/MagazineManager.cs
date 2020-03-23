using Magazines.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
public class MagazineManager : IMagazineManager
{

    public Dictionary<string, List<Material>> magazines = new Dictionary<string, List<Material>>();

    protected List<IMagazine> magazineList = new List<IMagazine>();

    public IReadOnlyCollection<IMagazine> List()
    {
        return magazineList;
    }

    public void RegisterMaterialWithinMagazine(IMagazine mag, MaterialQuantity quantity)
    {
        if (!magazineList.Any(f => f.MagazineName == mag.MagazineName))
        {
            magazineList.Add(mag);
            mag.AddMaterialToStock(quantity);
        }
        else
        {
            var magazine = FindMagazine(mag.MagazineName);
            magazine.AddMaterialToStock(quantity);
        }
    }

    public IMagazine FindMagazine(string magazineName)
    {
        return magazineList.FirstOrDefault(f => f.MagazineName == magazineName);
    }


    public string DisplayContentOfMagazines(IMagazineContentDisplayStrategy displayStrategy)
    {
        return displayStrategy.DisplayContent(this.magazineList);
    }
 
}