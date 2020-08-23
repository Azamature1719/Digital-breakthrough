using Newtonsoft.Json;
using System;
using System.IO;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CFileSendDataReader
    НАСЛЕДУЕТ.: ISendDataReader
    ОПИСАНИЕ..: Проводит считывание данных о посылке, сохранённых в
                файлах
    ПОЛЯ......: string Path - путь до папки с данными об отправлениях
    МЕТОДЫ....: Write(CUser user, CSendData data) - записывает данные о
                новой посылке пользователя.
    ПРИМЕЧАНИЕ: Названием текстового файла является номер телефона
                пользователя
    \********************************************************************/
    public class CFileSendDataWriter : ISendDataWriter
    {
        private string Path; // Путь до каталога, содержащего рекламу для различных кластеров

        public CFileSendDataWriter(string path) { Path = path; }

        /********************************************************************\
        МЕТОД.....: Write
        ОПИСАНИЕ..: Записывает данные о новой посылке
        ПАРАМЕТРЫ.: CUser user - данные отправителя
                    CSendData data - информация об отправлении
        \********************************************************************/
        public void Write(CUser user, CSendData data)
        {
            try
            {
                File.AppendAllText(Path + "/" + user.Phone + ".txt", "\n" + JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                int i = 1;
            }
        }
    }
}
