using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.EntityParser;
using Newtonsoft.Json;
using PetaPoco;

namespace MixERP.Net.Api.Transactions
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Non Gl Stock Tax Details.
    /// </summary>
    [RoutePrefix("api/v1.5/transactions/non-gl-stock-tax-detail")]
    public class NonGlStockTaxDetailController : ApiController
    {
        /// <summary>
        ///     The NonGlStockTaxDetail data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Transactions.Data.NonGlStockTaxDetail NonGlStockTaxDetailContext;

        public NonGlStockTaxDetailController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.NonGlStockTaxDetailContext = new MixERP.Net.Schemas.Transactions.Data.NonGlStockTaxDetail
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
        ///     Counts the number of non gl stock tax details.
        /// </summary>
        /// <returns>Returns the count of the non gl stock tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/count")]
        public long Count()
        {
            try
            {
                return this.NonGlStockTaxDetailContext.Count();
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
        ///     Returns an instance of non gl stock tax detail.
        /// </summary>
        /// <param name="nonGlStockTaxDetailId">Enter NonGlStockTaxDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{nonGlStockTaxDetailId}")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/{nonGlStockTaxDetailId}")]
        public MixERP.Net.Entities.Transactions.NonGlStockTaxDetail Get(long nonGlStockTaxDetailId)
        {
            try
            {
                return this.NonGlStockTaxDetailContext.Get(nonGlStockTaxDetailId);
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
        ///     Creates a paginated collection containing 25 non gl stock tax details on each page, sorted by the property NonGlStockTaxDetailId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/transactions/non-gl-stock-tax-detail")]
        public IEnumerable<MixERP.Net.Entities.Transactions.NonGlStockTaxDetail> GetPagedResult()
        {
            try
            {
                return this.NonGlStockTaxDetailContext.GetPagedResult();
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
        ///     Creates a paginated collection containing 25 non gl stock tax details on each page, sorted by the property NonGlStockTaxDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Transactions.NonGlStockTaxDetail> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.NonGlStockTaxDetailContext.GetPagedResult(pageNumber);
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
        ///     Creates a filtered and paginated collection containing 25 non gl stock tax details on each page, sorted by the property NonGlStockTaxDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Transactions.NonGlStockTaxDetail> GetWhere(long pageNumber, [FromBody]dynamic filters)
        {
            try
            {
                List<EntityParser.Filter> f = JsonConvert.DeserializeObject<List<EntityParser.Filter>>(filters);
                return this.NonGlStockTaxDetailContext.GetWhere(pageNumber, f);
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
        ///     Displayfield is a lightweight key/value collection of non gl stock tax details.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of non gl stock tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.NonGlStockTaxDetailContext.GetDisplayFields();
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
        ///     A custom field is a user defined field for non gl stock tax details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of non gl stock tax details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/custom-fields")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            try
            {
                return this.NonGlStockTaxDetailContext.GetCustomFields();
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
        /// <param name="nonGlStockTaxDetail">Your instance of non gl stock tax details class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{nonGlStockTaxDetail}")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/add/{nonGlStockTaxDetail}")]
        public void Add(MixERP.Net.Entities.Transactions.NonGlStockTaxDetail nonGlStockTaxDetail)
        {
            if (nonGlStockTaxDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.NonGlStockTaxDetailContext.Add(nonGlStockTaxDetail);
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
        /// <param name="nonGlStockTaxDetail">Your instance of Account class to edit.</param>
        /// <param name="nonGlStockTaxDetailId">Enter the value for NonGlStockTaxDetailId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{nonGlStockTaxDetailId}/{nonGlStockTaxDetail}")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/edit/{nonGlStockTaxDetailId}/{nonGlStockTaxDetail}")]
        public void Edit(long nonGlStockTaxDetailId, MixERP.Net.Entities.Transactions.NonGlStockTaxDetail nonGlStockTaxDetail)
        {
            if (nonGlStockTaxDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.NonGlStockTaxDetailContext.Update(nonGlStockTaxDetail, nonGlStockTaxDetailId);
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
        ///     Deletes an existing instance of Account class via NonGlStockTaxDetailId.
        /// </summary>
        /// <param name="nonGlStockTaxDetailId">Enter the value for NonGlStockTaxDetailId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{nonGlStockTaxDetailId}")]
        [Route("~/api/transactions/non-gl-stock-tax-detail/delete/{nonGlStockTaxDetailId}")]
        public void Delete(long nonGlStockTaxDetailId)
        {
            try
            {
                this.NonGlStockTaxDetailContext.Delete(nonGlStockTaxDetailId);
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