using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.EntityParser;
using Newtonsoft.Json;
using PetaPoco;

namespace MixERP.Net.Api.Core
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Recurring Invoice Setups.
    /// </summary>
    [RoutePrefix("api/v1.5/core/recurring-invoice-setup")]
    public class RecurringInvoiceSetupController : ApiController
    {
        /// <summary>
        ///     The RecurringInvoiceSetup data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Core.Data.RecurringInvoiceSetup RecurringInvoiceSetupContext;

        public RecurringInvoiceSetupController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.RecurringInvoiceSetupContext = new MixERP.Net.Schemas.Core.Data.RecurringInvoiceSetup
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of recurring invoice setups.
        /// </summary>
        /// <returns>Returns the count of the recurring invoice setups.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/core/recurring-invoice-setup/count")]
        public long Count()
        {
            try
            {
                return this.RecurringInvoiceSetupContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of recurring invoice setup.
        /// </summary>
        /// <param name="recurringInvoiceSetupId">Enter RecurringInvoiceSetupId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{recurringInvoiceSetupId}")]
        [Route("~/api/core/recurring-invoice-setup/{recurringInvoiceSetupId}")]
        public MixERP.Net.Entities.Core.RecurringInvoiceSetup Get(int recurringInvoiceSetupId)
        {
            try
            {
                return this.RecurringInvoiceSetupContext.Get(recurringInvoiceSetupId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 recurring invoice setups on each page, sorted by the property RecurringInvoiceSetupId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/core/recurring-invoice-setup")]
        public IEnumerable<MixERP.Net.Entities.Core.RecurringInvoiceSetup> GetPagedResult()
        {
            try
            {
                return this.RecurringInvoiceSetupContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 recurring invoice setups on each page, sorted by the property RecurringInvoiceSetupId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/core/recurring-invoice-setup/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Core.RecurringInvoiceSetup> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.RecurringInvoiceSetupContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a filtered and paginated collection containing 25 recurring invoice setups on each page, sorted by the property RecurringInvoiceSetupId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/core/recurring-invoice-setup/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Core.RecurringInvoiceSetup> GetWhere(long pageNumber, [FromBody]dynamic filters)
        {
            try
            {
                List<EntityParser.Filter> f = JsonConvert.DeserializeObject<List<EntityParser.Filter>>(filters);
                return this.RecurringInvoiceSetupContext.GetWhere(pageNumber, f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfield is a lightweight key/value collection of recurring invoice setups.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of recurring invoice setups.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/core/recurring-invoice-setup/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.RecurringInvoiceSetupContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     A custom field is a user defined field for recurring invoice setups.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of recurring invoice setups.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/core/recurring-invoice-setup/custom-fields")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            try
            {
                return this.RecurringInvoiceSetupContext.GetCustomFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of Account class.
        /// </summary>
        /// <param name="recurringInvoiceSetup">Your instance of recurring invoice setups class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{recurringInvoiceSetup}")]
        [Route("~/api/core/recurring-invoice-setup/add/{recurringInvoiceSetup}")]
        public void Add(MixERP.Net.Entities.Core.RecurringInvoiceSetup recurringInvoiceSetup)
        {
            if (recurringInvoiceSetup == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.RecurringInvoiceSetupContext.Add(recurringInvoiceSetup);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of Account class.
        /// </summary>
        /// <param name="recurringInvoiceSetup">Your instance of Account class to edit.</param>
        /// <param name="recurringInvoiceSetupId">Enter the value for RecurringInvoiceSetupId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{recurringInvoiceSetupId}/{recurringInvoiceSetup}")]
        [Route("~/api/core/recurring-invoice-setup/edit/{recurringInvoiceSetupId}/{recurringInvoiceSetup}")]
        public void Edit(int recurringInvoiceSetupId, MixERP.Net.Entities.Core.RecurringInvoiceSetup recurringInvoiceSetup)
        {
            if (recurringInvoiceSetup == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.RecurringInvoiceSetupContext.Update(recurringInvoiceSetup, recurringInvoiceSetupId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of Account class via RecurringInvoiceSetupId.
        /// </summary>
        /// <param name="recurringInvoiceSetupId">Enter the value for RecurringInvoiceSetupId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{recurringInvoiceSetupId}")]
        [Route("~/api/core/recurring-invoice-setup/delete/{recurringInvoiceSetupId}")]
        public void Delete(int recurringInvoiceSetupId)
        {
            try
            {
                this.RecurringInvoiceSetupContext.Delete(recurringInvoiceSetupId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }


    }
}