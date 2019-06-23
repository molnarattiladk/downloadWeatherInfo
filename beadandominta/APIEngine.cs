using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace beadandominta
{
    public class APIEngine
    {
        public string ApiBaseURL = "http://api.worldweatheronline.com/premium/v1/";
        public string PremiumAPIKey = ""; //az api kulcs helye
        public WWOWeatherData GetPastWeather(PastWeatherInput input)
        {
            // create URL based on input paramters
            string apiURL = ApiBaseURL + "past-weather.ashx?q=" + input.query + "&format=" + input.format + "&extra=" + input.extra + "&enddate=" + input.enddate + "&date=" + input.date + "&includelocation=" + input.includelocation + "&callback=" + input.callback + "&key=" + PremiumAPIKey;

            // get the web response, egy streamet ad vissza, magát a json sorokat
            string result = RequestHandler.Process(apiURL);
            //itt a json sorokból tesszük át a normál formátumba
            WWOWeatherData pastweather = (WWOWeatherData)new JavaScriptSerializer().Deserialize(result, typeof(WWOWeatherData));
            return pastweather;          
        }
    }
}
