using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using OData_Tests.Models;

namespace OData_Tests.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using OData_Tests.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<IntakeData>("IntakeData");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */

    [RoutePrefix("api/IntakeData")]
    public class IntakeDataController : ODataController
    {
        private IntakeDataContext db = new IntakeDataContext();

        // GET: odata/IntakeData
        [EnableQuery]
        [HttpGet]
        public IQueryable<IntakeData> GetIntakeData()
        {
            return db.IntakeDatas;
        }

        // GET: odata/IntakeData(5)
        [EnableQuery]
        [HttpGet]
        public SingleResult<IntakeData> GetIntakeData([FromODataUri] long key)
        {
            return SingleResult.Create(db.IntakeDatas.Where(intakeData => intakeData.WorkId == key));
        }

        // PUT: odata/IntakeData(5)
        public IHttpActionResult Put([FromODataUri] long key, Delta<IntakeData> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IntakeData intakeData = db.IntakeDatas.Find(key);
            if (intakeData == null)
            {
                return NotFound();
            }

            patch.Put(intakeData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntakeDataExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(intakeData);
        }

        // POST: odata/IntakeData
        public IHttpActionResult Post(IntakeData intakeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IntakeDatas.Add(intakeData);
            db.SaveChanges();

            return Created(intakeData);
        }

        // PATCH: odata/IntakeData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<IntakeData> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IntakeData intakeData = db.IntakeDatas.Find(key);
            if (intakeData == null)
            {
                return NotFound();
            }

            patch.Patch(intakeData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntakeDataExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(intakeData);
        }

        // DELETE: odata/IntakeData(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            IntakeData intakeData = db.IntakeDatas.Find(key);
            if (intakeData == null)
            {
                return NotFound();
            }

            db.IntakeDatas.Remove(intakeData);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IntakeDataExists(long key)
        {
            return db.IntakeDatas.Count(e => e.WorkId == key) > 0;
        }
    }
}
