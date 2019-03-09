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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ReportService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ReportService.svc или ReportService.svc.cs в обозревателе решений и начните отладку.
    public class ReportService : IReportService
    {
        public List<Report> GetReportByResearcher(int researcherId)
        {
            var result = new List<Report>();
            foreach (var report in Business.Logic.ResearcherManager.Instance().GetResearcher(researcherId).Reports)
            {
                result.Add(new Report(report));
            }

            return result;
        }

        public int AddReport(int researcherId, Report report)
        {
            return Business.Logic.ResearcherManager.Instance().GetResearcher(researcherId).AddReport(report.Name,
                report.RegisterNumber, report.ReleaseYear, report.PageCount);
        }

        public void UpdateReport(Report report)
        {
            new Business.Logic.Report(report.Id).Researcher.UpdateReport(new Business.Logic.Report(report.Id,
                report.Name, report.RegisterNumber, report.ReleaseYear, report.PageCount));
        }

        public void DeleteReport(int reportId)
        {
            new Business.Logic.Report(reportId).Researcher.DeleteReport(reportId);
        }

        public Report GetReport(int reportId)
        {
            var report = new Business.Logic.Report(reportId);
            report.Refresh();
            return new Report(report);
        }
    }
}
