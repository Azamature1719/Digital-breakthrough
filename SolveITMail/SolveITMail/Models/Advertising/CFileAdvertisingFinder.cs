using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CFileAdvertisingFinder
    НАСЛЕДУЕТ.: IAdvertisingFinder
    ОПИСАНИЕ..: Проводит выбор случайной рекламы из записей, хранящихся в
                файлах.
    ПОЛЯ......: string Path - путь до папки с рекламой для кластеров
    МЕТОДЫ....: List<CAdvertising> Find(EClasterID claster) - генерирует
                набор рекламы для пользователя, принадлежащего заданному
                кластеру
    \********************************************************************/
    public class CFileAdvertisingFinder : IAdvertisingFinder
    {
        private string Path; // Путь до каталога, содержащего рекламу для различных кластеров

        public CFileAdvertisingFinder(string path) { Path = path; }

        /********************************************************************\
        МЕТОД.....: Find
        ОПИСАНИЕ..: Генерирует набор рекламы для пользователя, принадлежащего
                    заданному кластеру
        ПАРАМЕТРЫ.: EClasterID claster - кластер, для которого ведётся поиск
                    рекламы
        ВОЗВРАЩАЕТ: List<CAdvertising> - сгенерированный набор рекламы
        \********************************************************************/
        public List<CAdvertising> Find(EClasterID claster)
        {
            try
            {
                PhysicalFileProvider provider = new PhysicalFileProvider(Path);
                List<CAdvertising> result = new List<CAdvertising>();
                if (provider.GetFileInfo("Claster_" + claster + ".txt").Exists)
                {
                    StreamReader reader = new StreamReader(Path + "/Claster_" + claster + ".txt");
                    while (!reader.EndOfStream)
                        result.Add(JsonConvert.DeserializeObject<CAdvertising>(reader.ReadLine()));
                    while (result.Count > 2)
                        result.RemoveAt(Program.random_generator.Next(result.Count));
                }
                return result;
            }
            catch { }
            return new List<CAdvertising>();
        }
    }
}
