using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using OData_Tests.Models;
using Microsoft.Data.OData;

namespace OData_Tests.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using OData_Tests.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<IntakeData>("IntakeData2");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class IntakeData2Controller : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/IntakeData2
        public IHttpActionResult GetIntakeData2(ODataQueryOptions<IntakeData> queryOptions)
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

        // GET: odata/IntakeData2(5)
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

        // PUT: odata/IntakeData2(5)
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

        // POST: odata/IntakeData2
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

        // PATCH: odata/IntakeData2(5)
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

        // DELETE: odata/IntakeData2(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
