using Newtonsoft.Json;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CUser
    ОПИСАНИЕ..: Информация о пользователе.
    ПОЛЯ......: string FIO - Фамилия, имя и отчество
                string Passport - Паспортные данные
                string Phone - Номер телефона
                string Mail - Электронная почта
                EClasterID Claster - Кластер, к которому пренадлежит
                пользователь
    \********************************************************************/
    public class CUser
    {
        public string     FIO      { get; set; } // ФИО
        public string     Passport { get; set; } // паспортные данные
        public string     Phone    { get; set; } // телефон
        public string     Mail     { get; set; } // почта
        public EClasterID Claster  { get; set; } // кластер

        [JsonConstructor]
        CUser(string fio, string passport, string phone, string mail, EClasterID claster)
        {
            FIO = fio;
            Passport = passport;
            Phone = phone;
            Mail = mail;
            Claster = claster;
        }
    }
}
