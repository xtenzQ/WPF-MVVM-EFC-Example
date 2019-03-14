using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ResearchersWPF.Service.IServices;

namespace ResearchersWPF.Service.Services
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "RequestService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы RequestService.svc или RequestService.svc.cs в обозревателе решений и начните отладку.
    public class RequestService : IRequestService
    {
        public int GetPresentationRequest(DateTime dateTime)
        {
            return new Business.Logic.Request().GetPresentationRequest(dateTime);
        }

        public int GetReportRequest(int departmentNumber)
        {
            return new Business.Logic.Request().GetReportRequest(departmentNumber);
        }
    }
}
