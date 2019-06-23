using beadandominta.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beadandominta.SaveDatasToCSV
{
    class ListToCSV
    {
        public static void SaveCollectionToCSV(IEnumerable<SimpleWeather> list, string path)
        {
            string text = "";
            if (!File.Exists(path))
            {
                text = list.FirstOrDefault().CSVHeader();
            }

            foreach (SimpleWeather data in list)
            {
                text += data.CSVFormat();
            }

            File.AppendAllText(path, text, Encoding.UTF8);
        }

    }
}
