using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using OData_Tests.Models;

namespace OData_Tests.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using OData_Tests.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<IntakeData>("IntakeData3");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class IntakeData3Controller : ODataController
    {
        private IntakeDataContext db = new IntakeDataContext();

        // GET: odata/IntakeData3
        [EnableQuery]
        public IQueryable<IntakeData> GetIntakeData3()
        {
            return db.IntakeDatas;
        }

        // GET: odata/IntakeData3(5)
        [EnableQuery]
        public SingleResult<IntakeData> GetIntakeData([FromODataUri] long key)
        {
            return SingleResult.Create(db.IntakeDatas.Where(intakeData => intakeData.WorkId == key));
        }

        // PUT: odata/IntakeData3(5)
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

        // POST: odata/IntakeData3
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

        // PATCH: odata/IntakeData3(5)
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

        // DELETE: odata/IntakeData3(5)
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
