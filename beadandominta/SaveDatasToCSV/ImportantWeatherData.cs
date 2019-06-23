using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandominta.SaveDatasToCSV
{
    class ImportantWeatherData
    {
       
        
        //Current_Condition current_ConditionWeather;
        //Weather weather;
        WWOWeatherData weatherData;
        public ImportantWeatherData(WWOWeatherData weatherData)
        {
            this.weatherData = weatherData;
            CallSimple();
        }

        SimpleWeather simpleWeather;

        public void CallSimple()
        {
            foreach (var item in weatherData.data.weather)
            {
                simpleWeather = new SimpleWeather(item);
            }
        }

       
    }
   
}
