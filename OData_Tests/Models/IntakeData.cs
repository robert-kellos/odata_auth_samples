using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace OData_Tests.Models
{

    public enum DeployType
    {
        EXE,
        MSI,
        JAR,
        CAB,
        PAK,
        NUG,
        DOC,
        ZIP
    }

    public enum WorkItemType
    {
        Design,
        Gather,
        Document,
        Package,
        Approval,
        Deploy,
        Cleanup,
        Notify,
        Report
    }

    public class IntakeData
    {
        [KeyAttribute]
        public long WorkId { get; set; }//uniqueId
        public string ProjectName { get; set; }
        public string AssignedTo { get; set; }
        public string AssignedBy { get; set; }
        public string Stackholder { get; set; }
        public List<WorkItemType> WorkItem { get; set; }
        public DeployType DeploymentType { get; set; }
        public string Description { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? CompleteDate { get; set; }
        public string IntakePayload { get; set; }
    }
}