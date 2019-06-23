using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace beadandominta
{
    class RequestHandler
    {
        public RequestHandler()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string Process(string url)
        {
            //kell itt aszinkornitás?
            var request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
            Stream streamResponse = HttpWResp.GetResponseStream();

            // And read it out
            StreamReader reader = new StreamReader(streamResponse);
            string response = reader.ReadToEnd();

            reader.Close();
            reader.Dispose();

            return response;
        }
    }
}
