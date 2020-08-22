using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolveITMail.Models
{
    /********************************************************************\
    ИНТЕРФЕЙС.: IAdvertisingFinder
    ОПИСАНИЕ..: Интерфейс классов, определяющих набор рекламы для
                пользователя.
    МЕТОДЫ....: List<CAdvertising> Find(EClasterID claster) - кластер, для
                которого ведётся поиск рекламы.
    \********************************************************************/
    public interface IAdvertisingFinder
    {
        List<CAdvertising> Find(EClasterID claster);
    }
}
