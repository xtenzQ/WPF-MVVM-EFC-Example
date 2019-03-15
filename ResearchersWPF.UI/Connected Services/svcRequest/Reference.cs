﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResearchersWPF.UI.svcRequest {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="svcRequest.IRequestService")]
    public interface IRequestService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestService/GetPresentationRequest", ReplyAction="http://tempuri.org/IRequestService/GetPresentationRequestResponse")]
        int GetPresentationRequest(System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestService/GetPresentationRequest", ReplyAction="http://tempuri.org/IRequestService/GetPresentationRequestResponse")]
        System.Threading.Tasks.Task<int> GetPresentationRequestAsync(System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestService/GetReportRequest", ReplyAction="http://tempuri.org/IRequestService/GetReportRequestResponse")]
        int GetReportRequest(int departmentNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRequestService/GetReportRequest", ReplyAction="http://tempuri.org/IRequestService/GetReportRequestResponse")]
        System.Threading.Tasks.Task<int> GetReportRequestAsync(int departmentNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRequestServiceChannel : ResearchersWPF.UI.svcRequest.IRequestService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RequestServiceClient : System.ServiceModel.ClientBase<ResearchersWPF.UI.svcRequest.IRequestService>, ResearchersWPF.UI.svcRequest.IRequestService {
        
        public RequestServiceClient() {
        }
        
        public RequestServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RequestServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RequestServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RequestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetPresentationRequest(System.DateTime dateTime) {
            return base.Channel.GetPresentationRequest(dateTime);
        }
        
        public System.Threading.Tasks.Task<int> GetPresentationRequestAsync(System.DateTime dateTime) {
            return base.Channel.GetPresentationRequestAsync(dateTime);
        }
        
        public int GetReportRequest(int departmentNumber) {
            return base.Channel.GetReportRequest(departmentNumber);
        }
        
        public System.Threading.Tasks.Task<int> GetReportRequestAsync(int departmentNumber) {
            return base.Channel.GetReportRequestAsync(departmentNumber);
        }
    }
}