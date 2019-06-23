using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandominta.Model
{
    //https://openweathermap.org/history api
    class OWMWeatherData
    {

        internal class WindData
        {
            double windspeed;
            double winddegree;

            public double WindSpeed { get { return windspeed; } set { windspeed = value; } }

            public double WindDegree { get { return winddegree; } set { winddegree = value; } }
        }
        internal class RainData
        {
            double rainvolume;
        }
        internal class SnowData
        {
            double snowvolume;
        }

        internal class MainData
        {
            double temperature;
            double pressure;
            double humidity;
        }

        internal class CloudData
        {

            double cloudliness;
        }
    }
}
