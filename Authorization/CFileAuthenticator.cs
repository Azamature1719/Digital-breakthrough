using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace SolveITMail.Models
{
    /********************************************************************\
    КЛАСС.....: CFileAuthenticator
    НАСЛЕДУЕТ.: IAuthenticator
    ОПИСАНИЕ..: Аутентификатор. Проверка подлинности логина
                и пароля производится на основе файла
    ПОЛЯ......: string m_path - путь до папки с данными о пользователях
    МЕТОДЫ....: CUser Find(CAuthorizationData data) - возвращает
                данные о пользователе по информации для входа
                public bool Connect() - проверка на существование файла
                с данными
    \********************************************************************/
    public class CFileAuthenticator : IAuthenticator
    {
        public string Path { get; private set; }

        public CFileAuthenticator(string path)
        {
            Path = path;
        }

        /********************************************************************\
        МЕТОД.....: Find
        ОПИСАНИЕ..: Возвращает данные о пользователе по информации для входа
        ПАРАМЕТРЫ.: CAuthorizationData data - данные для входа
        ВОЗВРАЩАЕТ: CUser - данные о пользователе
        ПРИМЕЧАНИЕ: Если в системе не зарегистрирован пользователь с
                    указанным логином и паролем, то возвращается null
        \********************************************************************/
        public CUser Find(CAuthorizationData data)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Path);
                FileInfo[] files = dir.GetFiles();
                foreach (var file in files)
                {
                    StreamReader reader = new StreamReader(file.FullName);
                    string curPassword = reader.ReadLine();
                    CUser curUser = JsonConvert.DeserializeObject<CUser>(reader.ReadLine());
                    if ((data.Login == curUser.Phone || data.Login == curUser.Mail) && curPassword == data.Password)
                        return curUser;
                }
            } catch { }
            return null;
        }

        /********************************************************************\
        МЕТОД.....: Handshake
        ОПИСАНИЕ..: Проверка доступа к папке с данными пользователей
        ПАРАМЕТРЫ.: нет
        ВОЗВРАЩАЕТ: bool - существует ли файл
        \********************************************************************/
        public bool Handshake()
        {
            try
            {
                PhysicalFileProvider provider = new PhysicalFileProvider(Path);
                return provider != null;
            } catch { }
            return false;
        }
    }
}
