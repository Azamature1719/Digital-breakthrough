using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SolveITMail.Models
{
    public class CFileAdvertisingFinder : IAdvertisingFinder
    {
        private string Path;
        public CFileAdvertisingFinder(string path) { Path = path; }

        public List<CAdvertising> Find(EClasterID claster)
        {
            try
            {
                PhysicalFileProvider provider = new PhysicalFileProvider(Path);
                List<CAdvertising> result = new List<CAdvertising>();
                string test = "Claster_" + claster + ".txt";
                if (provider.GetFileInfo("Claster_" + claster + ".txt").Exists)
                {
                    StreamReader reader = new StreamReader(Path + "/" + "Claster_" + claster + ".txt");
                    while (!reader.EndOfStream)
                        result.Add(JsonConvert.DeserializeObject<CAdvertising>(reader.ReadLine()));
                    while (result.Count > 2)
                        result.RemoveAt(Program.random_generator.Next(result.Count));
                }
                return result;
            } catch { }
            return new List<CAdvertising>();
        }
    }
}
