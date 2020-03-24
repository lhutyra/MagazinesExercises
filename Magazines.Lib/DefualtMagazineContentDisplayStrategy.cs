using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Magazines.Lib
{
    public class DefualtMagazineContentDisplayStrategy : IMagazineContentDisplayStrategy
    {
        protected const string materialDisplayFormat = "{0}: {1}";
        public string DisplayContent(IReadOnlyCollection<IMagazine> magazines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var magazinesOrder = magazines.OrderByDescending(f => f.TotalInMagazine()).ThenByDescending(f => f.MagazineName);
            foreach (var magazine in magazinesOrder)
            {
                stringBuilder.Append($"{magazine.MagazineName} (total {magazine.TotalInMagazine()})" + Environment.NewLine);

                stringBuilder.Append(magazine.PrintContentOfMagazine(materialDisplayFormat));
                stringBuilder.Append(Environment.NewLine);

            }
            return stringBuilder.ToString();
        }
    }
}
