using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandominta
{
    //Only for test

    class SerialSolution
    {
        const string CITY = "Budapest";
        const string FORMAT = "JSON";
        PastWeatherInput input;
        List<WWOWeatherData> WeatherDatas;
        
        public SerialSolution()
        {
            input = new PastWeatherInput();
            input.query = CITY;
            input.format = FORMAT;
            WeatherDatas = new List<WWOWeatherData>();
        }
        Stopwatch stopwatch;

        public Stopwatch GetDatas()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            APIEngine api = new APIEngine();
            InputGenerator inputGenerator = new InputGenerator();
            YearsInDictionary yearsInDictionary = new YearsInDictionary();
            /*szekvenciálishoz*/
            for (int i = 0; i < inputGenerator.startdates.Length; i++)
            {
                input.date = inputGenerator.startdates[i];
                input.enddate = inputGenerator.enddates[i];
                WWOWeatherData pastweather = api.GetPastWeather(input);
                WeatherDatas.Add(pastweather);
            }


            /*párhuzamos*/
            //foreach (var item in yearsInDictionary.dictionaryList)
            //{
            //    foreach (var years in item)
            //    {
            //        input.date = years.Key;
            //        input.enddate = years.Value;
            //        WWOWeatherData pastweather = api.GetPastWeather(input);
            //        WeatherDatas.Add(pastweather);
            //    }

            //}

            stopwatch.Stop();
            return stopwatch;
            //string watch = stopwatch.ToString();
            //return watch;
        }
    }
}
