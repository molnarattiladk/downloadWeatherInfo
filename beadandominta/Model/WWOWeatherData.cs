using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace beadandominta.Model
{
    // https://www.worldweatheronline.com API https://www.worldweatheronline.com/developer/api/historical-weather-api.aspx
    public class WWOWeatherData
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }
        public Data data;
        //public WeatherContext context;
    }

    //public class WeatherDB
    //{
    //    public WeatherContext weatherContextData { get; set; }
    //}

    public class PastWeatherInput
    {
        public string query { get; set; }
        public string format { get; set; }
        public string extra { get; set; }
        public string date { get; set; }
        public string enddate { get; set; }
        public string includelocation { get; set; }
        public string callback { get; set; }
    }

    //Database part--------------------------------

    //public class WeatherContext : DbContext
    //{

    //    public DbSet<WWOWeatherData> dataDB { get; set; }
    //    //public DbSet<Data> dataDB { get; set; }
    //    public DbSet<Current_Condition> current_Conditions { get; set; }
    //    public DbSet<Weather> weathers { get; set; }
       

    //}

    //-------------------------------------------

    //innen vajon meget?
    public class Data
    {
        public List<Current_Condition> current_condition;
        public List<Request> request;
        public List<Weather> weather;
    }

    public class Current_Condition
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }
        public DateTime observation_time { get; set; }
        public DateTime pastObsDateTime { get; set; }
        public int temp_C { get; set; }
        public int windspeedMiles { get; set; }
        public int windspeedKmph { get; set; }
        public int winddirDegree { get; set; }
        public string winddir16Point { get; set; }
        public string weatherCode { get; set; }
        public List<WeatherDesc> weatherDesc { get; set; }
        public List<WeatherIconUrl> weatherIconUrl { get; set; }
        public float precipMM { get; set; }
        public float humidity { get; set; }
        public int visibility { get; set; }
        public int pressure { get; set; }
        public int cloudcover { get; set; }
    }

    public class Request
    {
        //[Key]
        public string query { get; set; }
        public string type { get; set; }
    }
    
    public class Weather
    {
        public List<Hourly> hourly { get; set; }

        //[Key]
        public DateTime date { get; set; }
        public int maxtempC { get; set; }
        public int maxtempF { get; set; }
        public int mintempC { get; set; }
        public int mintempF { get; set; }

        public int uvIndex { get; set; }
        public float totalSnow_cm { get; set; }
        public float sunHour { get; set; }
    }

    public class Hourly
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }
        public string time { get; set; }
        public int tempC { get; set; }
        public int tempF { get; set; }
        public int windspeedMiles { get; set; }
        public int windspeedKmph { get; set; }
        public int windspeedKnots { get; set; }
        public int windspeedMeterSec { get; set; }
        public int winddirDegree { get; set; }
        public string winddir16Point { get; set; }
        public int weatherCode { get; set; }
        public List<WeatherDesc> weatherDesc { get; set; }
        public List<WeatherIconUrl> weatherIconUrl { get; set; }
        public float precipMM { get; set; }
        public float precipInches { get; set; }
        public float humidity { get; set; }
        public int visibility { get; set; }
        public int visibilityMiles { get; set; }
        public int pressure { get; set; }
        public float pressureInches { get; set; }
        public int cloudcover { get; set; }
    }

    public class WeatherDesc
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }
        public string value { get; set; }
    }

    public class WeatherIconUrl
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }
        public string value { get; set; }
    }
}
