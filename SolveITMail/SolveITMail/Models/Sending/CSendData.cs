using Newtonsoft.Json;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CSendData
    ОПИСАНИЕ..: Рекламная запись
    ПОЛЯ......: string From - точка отправления
                string To - точка прибытия
                string CurPos - текущее местоположение
                string Recipient - ФИО получателя
                string Address - адрес доставки
                double Mass - масса посылки (в кг)
    \********************************************************************/
    public class CSendData
    {
        public string From      { get; private set; } // Путь до файла с изображением
        public string To        { get; private set; } // Название предложения, сервиса, рекомендации и т.п.
        public string CurPos    { get; private set; } // Описание предложения, сервиса, рекомендации и т.п.
        public string Recipient { get; private set; } // ФИО получателя
        public string Address   { get; private set; } // Адрес доставки
        public double Mass      { get; private set; } // Масса посылки (в кг)

        [JsonConstructor]
        public CSendData(string from, string to, string curpos, string recipient, string address, double mass)
        {
            From = from;
            To = to;
            CurPos = curpos;
            Recipient = recipient;
            Address = address;
            Mass = mass;
        }
    }
}
