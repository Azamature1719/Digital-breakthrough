using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CAdvertising
    ОПИСАНИЕ..: Рекламная запись
    ПОЛЯ......: string ImgPath - путь до выводимого изображения
                string Name - название предложения
                string Description - описание предложения
    \********************************************************************/
    public class CAdvertising
    {
        public string ImgPath     { get; private set; } // Путь до файла с изображением
        public string Name        { get; private set; } // Название предложения, сервиса, рекомендации и т.п.
        public string Description { get; private set; } // Описание предложения, сервиса, рекомендации и т.п.

        [JsonConstructor]
        public CAdvertising(string imgpath, string name, string description)
        {
            ImgPath = imgpath;
            Name = name;
            Description = description;
        }
    }
}
