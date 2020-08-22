using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveITMail.Models
{
    public class CAdvertising
    {
        public string ImgPath     { get; private set; } // Путь до файла с изображением
        public string Name        { get; private set; } // Название (предложения, сервиса, рекомендации и т.п.)
        public string Description { get; private set; } // Описание рекламы

        [JsonConstructor]
        public CAdvertising(string imgpath, string name, string description)
        {
            ImgPath = imgpath;
            Name = name;
            Description = description;
        }
    }
}
