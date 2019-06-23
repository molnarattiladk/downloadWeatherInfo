using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace beadandominta
{
    class SemaphoreSolution
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);

        string[] dataStart;
        string[] dataEnd;
        const string CITY = "Budapest";
        const string FORMAT = "JSON";
        PastWeatherInput inputWeather;
        List<WWOWeatherData> WeatherDatas;
        string Ev { get; }
        InputGenerator inputGenerator;
      

        public SemaphoreSolution(string inputStart,string inputEnd, string ev)
        {
            //this.data = input;
            this.Ev = ev;
            inputWeather = new PastWeatherInput();
            inputWeather.query = CITY;
            inputWeather.format = FORMAT;
            inputWeather.date = inputStart;
            inputWeather.enddate = inputEnd;
            WeatherDatas = new List<WWOWeatherData>();
        }
        public SemaphoreSolution(string[] yearDataStart,string[] YearDataEnd, string yearName)
        {
            this.Ev = yearName;
            this.dataStart = yearDataStart;
            this.dataEnd = YearDataEnd;
            inputWeather = new PastWeatherInput();
            inputWeather.query = CITY;
            inputWeather.format = FORMAT;
            WeatherDatas = new List<WWOWeatherData>();
        }
        public SemaphoreSolution(string ev)
        {
            this.Ev = ev;
        }

        public void Download()
        {
            Console.WriteLine("Letöltésre kész: " + Ev);
            semaphoreSlim.Wait();
            Console.WriteLine("Letöltés megkezdve: "+ Ev);
            APIEngine api = new APIEngine();
            for (int i = 0; i < dataStart.Length; i++)
            {
                WWOWeatherData pastWeather = api.GetPastWeather(inputWeather);
                WeatherDatas.Add(pastWeather);
            }
            Thread.Sleep(1000);
            Console.WriteLine("Befejezte: "+ Ev);           
            semaphoreSlim.Release();

        }

        public List<WWOWeatherData> GetYearWeatherData()
        {
            Console.WriteLine("Letöltésre kész: " + Ev);
            semaphoreSlim.Wait();
            Console.WriteLine("Letöltés megkezdve: " + Ev);
            APIEngine api = new APIEngine();
            for (int i = 0; i < dataStart.Length; i++)
            {
                WWOWeatherData pastWeather = api.GetPastWeather(inputWeather);
                WeatherDatas.Add(pastWeather);
                Thread.Sleep(1000);
            }         
            Console.WriteLine("Befejezte: " + Ev);
            semaphoreSlim.Release();

            return WeatherDatas;
        }
    }
}
