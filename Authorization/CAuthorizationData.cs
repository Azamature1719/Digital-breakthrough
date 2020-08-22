namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CAuthorizationData
    ОПИСАНИЕ..: Логин и пароль пользователя
    ПОЛЯ......: string Login - логин пользователя
                string Password - пароль пользователя
    \********************************************************************/
    public class CAuthorizationData
    {
        public string Login    { get; set; } // Логин пользователя
        public string Password { get; set; } // Пароль пользователя
    }
}
