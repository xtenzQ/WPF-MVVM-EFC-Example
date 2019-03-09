using System.Collections.Generic;
using System.ServiceModel;
using ResearchersWPF.Service.DataContracts;

namespace ResearchersWPF.Service.IServices
{
    [ServiceContract]
    public interface IMonographService
    {
        [OperationContract]
        List<Monograph> GetMonographByResearcher(int researcherId);

        [OperationContract]
        int AddMonograph(int researcherId, Monograph monograph);

        [OperationContract]
        void UpdateMonograph(Monograph monograph);

        [OperationContract]
        void DeleteMonograph(int monographId);

        [OperationContract]
        Monograph GetMonograph(int monographId);
    }
}