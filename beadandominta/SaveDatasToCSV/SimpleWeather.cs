using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beadandominta.Model;

namespace beadandominta.SaveDatasToCSV
{
    class SimpleWeather
    {
        //Current_Condition current_ConditionWeather;
        Weather weather;
        public SimpleWeather(Weather weather)
        {
           // this.current_ConditionWeather = current_Condition;
            this.weather = weather;
        }

        public DateTime Date { get { return weather.date; } }

        //public int? Temp_C { get { return current_ConditionWeather.temp_C; } }

        //public int? WindSpeedKmph { get { return current_ConditionWeather.windspeedKmph; } }

        //public float? PrecipMM { get { return current_ConditionWeather.precipMM; } }

        //public float? Humidity { get { return current_ConditionWeather.humidity; } }

        //public int? CloudCover { get { return current_ConditionWeather.cloudcover; } }

        public float? Humidity { get { return weather.hourly.Average(x => x.humidity); } }

        public double? CloudCover { get { return weather.hourly.Average(x => x.cloudcover); } }
        public double? windSpeedKmh { get { return weather.hourly.Average(x => x.windspeedKmph); } }

        public float? PrecipitationMM { get { return weather.hourly.Sum(x => x.precipMM); } }

        public int? UVIndex { get { return weather.uvIndex; } }

        public float? TotalSnow_cm { get { return weather.totalSnow_cm; } }

        public float? SunHour { get { return weather.sunHour; } }

        public int? MinTemp { get { return weather.mintempC; } }

        public int? MaxTemp { get { return weather.maxtempC; } }

        public string CSVFormat()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};\n", Date, MinTemp, MaxTemp,PrecipitationMM,Humidity,CloudCover,windSpeedKmh,UVIndex,TotalSnow_cm,SunHour);
        }

        public string CSVHeader()
        {
            return "DateTime;MinTemperatureC;MaxTemperature;PrecipitationMM;Humidity;CloudCover;WindSpeedKmh;UVIndex;TotalSnowfallcm;TotalSunHour;" + Environment.NewLine;
        }
    }
}
