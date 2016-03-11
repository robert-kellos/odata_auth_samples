
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace OData_Tests.Models
{
	public class IntakeDataDTO
	{
		public System.Int64 WorkId { get; set; }
		public System.String ProjectName { get; set; }
		public System.String AssignedTo { get; set; }
		public System.String AssignedBy { get; set; }
		public System.String Stackholder { get; set; }
		public OData_Tests.Models.DeployType DeploymentType { get; set; }
		public System.String Description { get; set; }
		public System.DateTime? BeginDate { get; set; }
		public System.DateTime? LastModified { get; set; }
		public System.DateTime? CompleteDate { get; set; }
		public System.String IntakePayload { get; set; }

		public static System.Linq.Expressions.Expression<Func< IntakeData,  IntakeDataDTO>> SELECT =
			x => new  IntakeDataDTO
			{
				WorkId = x.WorkId,
				ProjectName = x.ProjectName,
				AssignedTo = x.AssignedTo,
				AssignedBy = x.AssignedBy,
				Stackholder = x.Stackholder,
				DeploymentType = x.DeploymentType,
				Description = x.Description,
				BeginDate = x.BeginDate,
				LastModified = x.LastModified,
				CompleteDate = x.CompleteDate,
				IntakePayload = x.IntakePayload,
			};

	}
}