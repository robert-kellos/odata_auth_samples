using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using OData_Tests.Models;
using Microsoft.OData.Core;

namespace OData_Tests.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using OData_Tests.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<IntakeData>("IntakeData4");
    config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class IntakeData4Controller : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/IntakeData4
        public IHttpActionResult GetIntakeData4(ODataQueryOptions<IntakeData> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<IntakeData>>(intakeDatas);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/IntakeData4(5)
        public IHttpActionResult GetIntakeData([FromODataUri] long key, ODataQueryOptions<IntakeData> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IntakeData>(intakeData);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/IntakeData4(5)
        public IHttpActionResult Put([FromODataUri] long key, Delta<IntakeData> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(intakeData);

            // TODO: Save the patched entity.

            // return Updated(intakeData);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/IntakeData4
        public IHttpActionResult Post(IntakeData intakeData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(intakeData);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/IntakeData4(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<IntakeData> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(intakeData);

            // TODO: Save the patched entity.

            // return Updated(intakeData);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/IntakeData4(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
