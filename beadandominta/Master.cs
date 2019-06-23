using beadandominta.Model;
using beadandominta.SaveDatasToCSV;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace beadandominta
{
    class Master
    {
        Worker worker;
        YearsInDictionary dictionary = new YearsInDictionary();
        const string CITY = "Budapest";
        const string FORMAT = "JSON";
        static object lockObject = new object(); 
        List<Task> tasks = new List<Task>();
        ConcurrentBag<SimpleWeather> importantWeatherDatas = new ConcurrentBag<SimpleWeather>();

        string weatherPath = @"C:\Users\Molnár Attila\source\repos\Perprog_ECJU2I\"; //ezt configba szebb lenne tenni.:)

        public Master()
        {
            this.worker = new Worker(); 
        }

        public void GetData()
        {
            foreach (var dictionary in dictionary.dictionaryList) 
            {
                Task task = new Task(() => { Crawl(dictionary); }, TaskCreationOptions.LongRunning);
                tasks.Add(task);
            }

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks.ToArray(), CancellationToken.None);


            SaveAll();
        }

        private void SaveAll()
        {
            ListToCSV.SaveCollectionToCSV(importantWeatherDatas, weatherPath + "weather.csv");
        }

        List<WWOWeatherData> weatherDatas = new List<WWOWeatherData>();
        private void Crawl(Dictionary<string, string> dictionary)
        {
            PastWeatherInput pastWeatherInput = new PastWeatherInput();
            pastWeatherInput.query = CITY;
            pastWeatherInput.format = FORMAT;
            
            foreach (var item in dictionary)
            {
                pastWeatherInput.date = item.Key;
                pastWeatherInput.enddate = item.Value;
                WWOWeatherData weatherData = worker.GetPastWeather(pastWeatherInput);
                weatherDatas.Add(weatherData);
                lock (lockObject)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Az alábbi év, hónap időjárási adata le lett töltve: " + item.Key);
                }

                //ImportantWeatherData important = new ImportantWeatherData(weatherData);
                foreach (var i in weatherData.data.weather)
                {
                    SimpleWeather simple = new SimpleWeather(i);
                    importantWeatherDatas.Add(simple);
                }
                
            }

            //ImportantWeatherData important;
            //foreach (var item in weatherDatas)
            //{
                
            //    important = new ImportantWeatherData(item);
            //    importantWeatherDatas.Add(important);
            //}
        }
    }
}
