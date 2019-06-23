using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace beadandominta
{
    class Worker
    {
        //ugyanaz mint a APIENGINE
        public string ApiBaseURL = "http://api.worldweatheronline.com/premium/v1/";
        public string PremiumAPIKey = ""; //Az api kulcs helye
        
        public WWOWeatherData GetPastWeather(PastWeatherInput input)
        {
            // create URL based on input paramters
            string apiURL = ApiBaseURL + "past-weather.ashx?q=" + input.query + "&format=" + input.format + "&extra=" + input.extra + "&enddate=" + input.enddate + "&date=" + input.date + "&includelocation=" + input.includelocation + "&callback=" + input.callback + "&key=" + PremiumAPIKey;

            string result = RequestHandler.Process(apiURL);
            //itt a json sorokból tesszük át a normál formátumba
            WWOWeatherData pastweather = (WWOWeatherData)new JavaScriptSerializer().Deserialize(result, typeof(WWOWeatherData));

            return pastweather;          
        }
    }
}
