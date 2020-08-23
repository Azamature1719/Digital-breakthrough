using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CFileSendDataReader
    НАСЛЕДУЕТ.: ISendDataReader
    ОПИСАНИЕ..: Проводит считывание данных о посылке, сохранённых в
                файлах
    ПОЛЯ......: string Path - путь до папки с данными об отправлениях
    МЕТОДЫ....: CUser Find(CAuthorizationData data) - возвращает
                данные о пользователе по информации для входа
                public bool Connect() - проверка на существование файла
                с данными
    ПРИМЕЧАНИЕ: Названием текстового файла является номер телефона
                пользователя
    \********************************************************************/
    public class CFileSendDataReader : ISendDataReader
    {
        private string Path; // Путь до каталога, содержащего рекламу для различных кластеров

        public CFileSendDataReader(string path) { Path = path; }

        /********************************************************************\
        МЕТОД.....: Read
        ОПИСАНИЕ..: Считывает данные о находящихся в пути посылках пользователя
        ПАРАМЕТРЫ.: CUser user - данные пользователя
        ВОЗВРАЩАЕТ: List<CSendData> - данные о посылках, находящихся в пути
        \********************************************************************/
        public List<CSendData> Read(CUser user)
        {
            List<CSendData> result = new List<CSendData>();
            try
            {
                PhysicalFileProvider provider = new PhysicalFileProvider(Path);
                if (provider.GetFileInfo(user.Phone + ".txt").Exists)
                {
                    StreamReader reader = new StreamReader(Path + "/" + user.Phone + ".txt");
                    while (!reader.EndOfStream)
                        result.Add(JsonConvert.DeserializeObject<CSendData>(reader.ReadLine()));
                    reader.Close();
                }
            } catch { }
            return result;
        }
    }
}
