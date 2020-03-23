using System;
namespace Magazines.Lib
{
    public class InputProcessorHelper
    {
        private const string ignoreLineSign= "#";
        private IMagazineManager magazineManager;
        public InputProcessorHelper(IMagazineManager manager)
        {
            magazineManager = manager;
        }
        public static (Magazine, int) ParseMaterialWithQuantity(string input)
        {
            var magazineStorage = input.Split(",");
            return (Magazine.From(magazineStorage[0]), int.Parse(magazineStorage[1]));
        }

        public void ParseLine(string line)
        {
            if (line.StartsWith(ignoreLineSign))
            {
                return;
            }
            else
            {
                var materialContent = line.Split(';');
                var materialName = materialContent[0];
                var materialId = materialContent[1];
                var material = new Material(materialId, materialName);
                var warehouseStock = materialContent[2].Split('|');
                foreach (var materialData in warehouseStock)
                {
                    var materialOne = ParseMaterialWithQuantity(materialData);
                    var materialQuantity = MaterialQuantity.From(material, materialOne.Item2);
                    magazineManager.RegisterMaterialWithinMagazine(materialOne.Item1, materialQuantity);
                }
            }
        }


        public void ReadAllTextAndProcess(string inputText)
        {
            foreach (var line in inputText.Split(Environment.NewLine))
            {
                if (!line.StartsWith("#"))
                {
                    ParseLine(line);
                }
            }
        }
    }
}
