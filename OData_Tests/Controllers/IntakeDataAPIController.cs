
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
using Microsoft.TeamFoundation.Client;
using sccmclictr.automation;
using TechTalk.JiraRestClient;

namespace OData_Tests.Models
{
    [RoutePrefix("api/IntakeData")]
    public class IntakeDataController : ApiController
    {
        public const string SERVER = "xxyyzz";

        private OData_Tests.Models.IntakeDataContext db = new OData_Tests.Models.IntakeDataContext();

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = false), Api]
        public IQueryable<IntakeDataDTO> GetIntakeDatas(int pageSize = 10
                )
        {
            var model = db.IntakeDatas.AsQueryable();

            TfsApi.Api.Refresh();
            var tfsUrl = new Uri("http://tfs.abc.com:8080/tfs");
            var cred = new CredentialCache();
            var projCol = new TfsTeamProjectCollection(tfsUrl);

            

            //var a1 = new SCCMAgent(@"\\xxyyzz");
            //var a2 = new SCCMAgent(@"\\xxyyzz\Win7Data");
            //var sccm = new SCCMAgent(@"xxyyzz");
            //var sccm = new SCCMAgent("xxyyzz.abc.com");
            //var sccm = new sccmclictr.automation.SCCMAgent("xxyyzz.abc.com");
            //sccm.connect();
            //if (sccm.isConnected)
            //{
            //    var ups = sccmclictr.automation.common.WMIDateToDateTime(DateTime.Now.ToString());
            //    //var uri = sccm.ConnectionInfo();
            //}
            //var con =
            //    new TfsWebClient(new TfsConnection(,
            //        new TfsClientCredentials(new WindowsCredential(true))));
                        
            return model.Select(IntakeDataDTO.SELECT).Take(pageSize);
        }

        [ResponseType(typeof(IntakeDataDTO))]
        [HttpGet]
        public async Task<IHttpActionResult> GetIntakeData(long id)
        {
            var model = await db.IntakeDatas.Select(IntakeDataDTO.SELECT).FirstOrDefaultAsync(x => x.WorkId == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutIntakeData(long id, IntakeData model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.WorkId)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntakeDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(IntakeDataDTO))]
        public async Task<IHttpActionResult> PostIntakeData(IntakeData model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IntakeDatas.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.IntakeDatas.Select(IntakeDataDTO.SELECT).FirstOrDefaultAsync(x => x.WorkId == model.WorkId);
            return CreatedAtRoute("DefaultApi", new { id = model.WorkId }, model);
        }

        [ResponseType(typeof(IntakeDataDTO))]
        public async Task<IHttpActionResult> DeleteIntakeData(long id)
        {
            IntakeData model = await db.IntakeDatas.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.IntakeDatas.Remove(model);
            await db.SaveChangesAsync();
            var ret = await db.IntakeDatas.Select(IntakeDataDTO.SELECT).FirstOrDefaultAsync(x => x.WorkId == model.WorkId);
            return Ok(ret);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntakeDataExists(long id)
        {
            return db.IntakeDatas.Count(e => e.WorkId == id) > 0;
        }
    }
}