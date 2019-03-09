using System.Collections.Generic;
using System.ServiceModel;
using ResearchersWPF.Service.DataContracts;

namespace ResearchersWPF.Service.IServices
{
    [ServiceContract]
    public interface IReportService
    {
        [OperationContract]
        List<Report> GetReportByResearcher(int researcherId);

        [OperationContract]
        int AddReport(int researcherId, Report report);

        [OperationContract]
        void UpdateReport(Report report);

        [OperationContract]
        void DeleteReport(int reportId);

        [OperationContract]
        Report GetReport(int reportId);
    }
}