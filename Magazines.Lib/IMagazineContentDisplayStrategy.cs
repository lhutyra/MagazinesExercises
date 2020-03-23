using System;
using System.Collections.Generic;
using System.Text;

namespace Magazines.Lib
{
    public interface IMagazineContentDisplayStrategy
    {
        string DisplayContent(IEnumerable<IMagazine> magazine);
    }
}
