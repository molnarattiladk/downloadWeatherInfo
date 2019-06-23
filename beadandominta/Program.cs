using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace beadandominta
{
    class Program
    {
        static string start;
        static string end;
        static void Main(string[] args)
        {

            #region Szekvencialis
            ////Szekvenciális megoldás-----------------------------------------------------------
            //SerialSolution serialSolution = new SerialSolution();

            //Console.WriteLine("Adatok lekérése folyamatban, Szekvenciális megoldás...");
            //Stopwatch result = serialSolution.GetDatas();

            //Console.WriteLine("Adatok lekérése befejeződött, ennyi ideig tartott: " + result.Elapsed.ToString());
            //--------------------------------------------------------------------------------
            #endregion

            //WWOWeatherData weatherData = api.GetPastWeather(input);
            //ez idáig működik, 
            //van egy szekvenciálisan működő program  ami leszedi a számomra a az időjárási adatokat.
            //majd párhuzamosítás
            InputGenerator inputGenerator = new InputGenerator();

            ////new Thread(() => { new SemaphoreSolution(inputGenerator.startdates.First(), inputGenerator.enddates.First(), "2010").Download(); }).Start();
            ////new Thread(() => { new SemaphoreSolution(inputGenerator.secondYearStart.First(), inputGenerator.secondYearEnd.First(), "2011").Download(); }).Start();
            ////new Thread(() => { new SemaphoreSolution(inputGenerator.thirdYearStart.First(), inputGenerator.thirdYearEnd.First(), "2012").Download(); }).Start();
            YearsInDictionary yearsInDictionary = new YearsInDictionary();

            #region Semaphore
            /*Semaphore megoldás*/
            /*
            new Thread(() => { new SemaphoreSolution(inputGenerator.startdates, inputGenerator.enddates, "2010").Download(); }).Start();
            new Thread(() => { new SemaphoreSolution(inputGenerator.firstYearStart, inputGenerator.firstYearEnd, "2011").Download(); }).Start();

            new Thread(() => { new SemaphoreSolution(inputGenerator.secondYearStart, inputGenerator.secondYearEnd, "2012").Download(); }).Start();
            new Thread(() => { new SemaphoreSolution(inputGenerator.thirdYearStart, inputGenerator.thirdYearEnd, "2013").Download(); }).Start();
            new Thread(() => { new SemaphoreSolution(inputGenerator.fourthYearStart, inputGenerator.fourthYearEnd, "2014").Download(); }).Start();
            new Thread(() => { new SemaphoreSolution(inputGenerator.fifthYearStart, inputGenerator.fifthYearEnd, "2015").Download(); }).Start();
            new Thread(() => { new SemaphoreSolution(inputGenerator.sixthYearStart, inputGenerator.sixthYearEnd, "2016").Download(); }).Start();
            */
            /*-------------------------------------------------------------------------------------------*/
            #endregion

            #region MasterWorker
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Environment.ProcessorCount);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Master master = new Master();
            master.GetData();
            //Console.WriteLine("Kész a szemaform");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stopwatch.Elapsed.ToString());
            #endregion

            //InputConsole();
            //Console.WriteLine(start);
            //Console.WriteLine(end);
            //MasterWorker class
            Console.ReadLine();
        }

        static void InputConsole()
        {
            Console.WriteLine("Add meg a kezdő évszámot: ");
            start = Console.ReadLine();
            Console.WriteLine("Add meg a végét: ");
            end = Console.ReadLine();
        }
    }
}
