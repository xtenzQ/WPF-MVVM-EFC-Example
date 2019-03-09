using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ResearchersWPF.Service.DataContracts;
using ResearchersWPF.Service.IServices;

namespace ResearchersWPF.Service.Services
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "PresentationService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы PresentationService.svc или PresentationService.svc.cs в обозревателе решений и начните отладку.
    public class PresentationService : IPresentationService
    {
        public List<Presentation> GetPresentationByResearcher(int researcherId)
        {
            var result = new List<Presentation>();
            foreach (var presentation in Business.Logic.ResearcherManager.Instance().GetResearcher(researcherId).Presentations)
            {
                result.Add(new Presentation(presentation));
            }

            return result;
        }

        public int AddPresentation(int researcherId, Presentation presentation)
        {
            return Business.Logic.ResearcherManager.Instance().GetResearcher(researcherId)
                .AddPresentation(presentation.Name, presentation.ConferenceName, presentation.PresentationDate);
        }

        public void UpdatePresentation(Presentation presentation)
        {
            new Business.Logic.Presentation(presentation.Id).Researcher.UpdatePresentation(
                new Business.Logic.Presentation(presentation.Id, presentation.Name, presentation.ConferenceName, presentation.PresentationDate));
        }

        public void DeletePresentation(int presentationId)
        {
            new Business.Logic.Presentation(presentationId).Researcher.DeletePresentation(presentationId);
        }

        public Presentation GetPresentation(int presentationId)
        {
            var presentation = new Business.Logic.Presentation(presentationId);
            presentation.Refresh();
            return new Presentation(presentation);
        }
    }
}
