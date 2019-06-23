using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandominta
{
    interface IApiWeatherInterface
    {

        string City { get; set; }
        string Format { get; set; }

    }
}
