/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MixERP.Net.DbFactory;
using MixERP.Net.EntityParser;
using MixERP.Net.Framework;
using Npgsql;
using PetaPoco;
using Serilog;

namespace MixERP.Net.Core.Modules.HRM.Data
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "hrm.salary_frequencies".
    /// </summary>
    public class SalaryFrequency : DbAccess
    {
        /// <summary>
        /// The schema of this table. Returns literal "hrm".
        /// </summary>
	    public override string ObjectNamespace => "hrm";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "salary_frequencies".
        /// </summary>
	    public override string ObjectName => "salary_frequencies";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
		public long LoginId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string Catalog { get; set; }

		/// <summary>
		/// Performs SQL count on the table "hrm.salary_frequencies".
		/// </summary>
		/// <returns>Returns the number of rows of the table "hrm.salary_frequencies".</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public long Count()
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return 0;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT COUNT(*) FROM hrm.salary_frequencies;";
			return Factory.Scalar<long>(this.Catalog, sql);
		}

		/// <summary>
		/// Executes a select query on the table "hrm.salary_frequencies" with a where filter on the column "salary_frequency_id" to return a single instance of the "SalaryFrequency" class. 
		/// </summary>
		/// <param name="salaryFrequencyId">The column "salary_frequency_id" parameter used on where filter.</param>
		/// <returns>Returns a non-live, non-mapped instance of "SalaryFrequency" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public MixERP.Net.Entities.HRM.SalaryFrequency Get(int salaryFrequencyId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"SalaryFrequency\" filtered by \"SalaryFrequencyId\" with value {SalaryFrequencyId} was denied to the user with Login ID {LoginId}", salaryFrequencyId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM hrm.salary_frequencies WHERE salary_frequency_id=@0;";
			return Factory.Get<MixERP.Net.Entities.HRM.SalaryFrequency>(this.Catalog, sql, salaryFrequencyId).FirstOrDefault();
		}

        /// <summary>
        /// Custom fields are user defined form elements for hrm.salary_frequencies.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table hrm.salary_frequencies</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get custom fields for entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
			if (string.IsNullOrWhiteSpace(resourceId))
            {
				sql = "SELECT * FROM core.custom_field_definition_view WHERE table_name='hrm.salary_frequencies' ORDER BY field_order;";
				return Factory.Get<PetaPoco.CustomField>(this.Catalog, sql);
            }

            sql = "SELECT * from core.get_custom_field_definition('hrm.salary_frequencies'::text, @0::text) ORDER BY field_order;";
			return Factory.Get<PetaPoco.CustomField>(this.Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of hrm.salary_frequencies.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table hrm.salary_frequencies</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public IEnumerable<DisplayField> GetDisplayFields()
		{
			List<DisplayField> displayFields = new List<DisplayField>();

			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return displayFields;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT salary_frequency_id AS key, salary_frequency_name as value FROM hrm.salary_frequencies;";
			using (NpgsqlCommand command = new NpgsqlCommand(sql))
			{
				using (DataTable table = DbOperation.GetDataTable(this.Catalog, command))
				{
					if (table?.Rows == null || table.Rows.Count == 0)
					{
						return displayFields;
					}

					foreach (DataRow row in table.Rows)
					{
						if (row != null)
						{
							DisplayField displayField = new DisplayField
							{
								Key = row["key"].ToString(),
								Value = row["value"].ToString()
							};

							displayFields.Add(displayField);
						}
					}
				}
			}

			return displayFields;
		}

		/// <summary>
		/// Inserts or updates the instance of SalaryFrequency class on the database table "hrm.salary_frequencies".
		/// </summary>
		/// <param name="salaryFrequency">The instance of "SalaryFrequency" class to insert or update.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public void AddOrEdit(MixERP.Net.Entities.HRM.SalaryFrequency salaryFrequency)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

			if(salaryFrequency.SalaryFrequencyId > 0){
				this.Update(salaryFrequency, salaryFrequency.SalaryFrequencyId);
				return;
			}
	
			this.Add(salaryFrequency);
		}

		/// <summary>
		/// Inserts the instance of SalaryFrequency class on the database table "hrm.salary_frequencies".
		/// </summary>
		/// <param name="salaryFrequency">The instance of "SalaryFrequency" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public void Add(MixERP.Net.Entities.HRM.SalaryFrequency salaryFrequency)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}. {SalaryFrequency}", this.LoginId, salaryFrequency);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Insert(this.Catalog, salaryFrequency);
		}

		/// <summary>
		/// Updates the row of the table "hrm.salary_frequencies" with an instance of "SalaryFrequency" class against the primary key value.
		/// </summary>
		/// <param name="salaryFrequency">The instance of "SalaryFrequency" class to update.</param>
		/// <param name="salaryFrequencyId">The value of the column "salary_frequency_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public void Update(MixERP.Net.Entities.HRM.SalaryFrequency salaryFrequency, int salaryFrequencyId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"SalaryFrequency\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {SalaryFrequency}", salaryFrequencyId, this.LoginId, salaryFrequency);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			Factory.Update(this.Catalog, salaryFrequency, salaryFrequencyId);
		}

		/// <summary>
		/// Deletes the row of the table "hrm.salary_frequencies" against the primary key value.
		/// </summary>
		/// <param name="salaryFrequencyId">The value of the column "salary_frequency_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public void Delete(int salaryFrequencyId)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"SalaryFrequency\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", salaryFrequencyId, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "DELETE FROM hrm.salary_frequencies WHERE salary_frequency_id=@0;";
			Factory.NonQuery(this.Catalog, sql, salaryFrequencyId);
		}

		/// <summary>
		/// Performs a select statement on table "hrm.salary_frequencies" producing a paged result of 25.
		/// </summary>
		/// <returns>Returns the first page of collection of "SalaryFrequency" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public IEnumerable<MixERP.Net.Entities.HRM.SalaryFrequency> GetPagedResult()
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}.", this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			const string sql = "SELECT * FROM hrm.salary_frequencies ORDER BY salary_frequency_id LIMIT 25 OFFSET 0;";
			return Factory.Get<MixERP.Net.Entities.HRM.SalaryFrequency>(this.Catalog, sql);
		}

		/// <summary>
		/// Performs a select statement on table "hrm.salary_frequencies" producing a paged result of 25.
		/// </summary>
		/// <param name="pageNumber">Enter the page number to produce the paged result.</param>
		/// <returns>Returns collection of "SalaryFrequency" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
		public IEnumerable<MixERP.Net.Entities.HRM.SalaryFrequency> GetPagedResult(long pageNumber)
		{
			if(string.IsNullOrWhiteSpace(this.Catalog))
			{
				return null;
			}

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}.", pageNumber, this.LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
	
			long offset = (pageNumber -1) * 25;
			const string sql = "SELECT * FROM hrm.salary_frequencies ORDER BY salary_frequency_id LIMIT 25 OFFSET @0;";
				
			return Factory.Get<MixERP.Net.Entities.HRM.SalaryFrequency>(this.Catalog, sql, offset);
		}

        /// <summary>
		/// Performs a filtered select statement on table "hrm.salary_frequencies" producing a paged result of 25.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paged result.</param>
        /// <param name="filters">The list of filter conditions.</param>
		/// <returns>Returns collection of "SalaryFrequency" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<MixERP.Net.Entities.HRM.SalaryFrequency> GetWhere(long pageNumber, List<EntityParser.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this.Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this.LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 25;
            Sql sql = Sql.Builder.Append("SELECT * FROM hrm.salary_frequencies WHERE 1 = 1");

            MixERP.Net.EntityParser.Data.Service.AddFilters(ref sql, new MixERP.Net.Entities.HRM.SalaryFrequency(), filters);

            sql.OrderBy("salary_frequency_id");
            sql.Append("LIMIT @0", 25);
            sql.Append("OFFSET @0", offset);

            return Factory.Get<MixERP.Net.Entities.HRM.SalaryFrequency>(this.Catalog, sql);
        }

        public IEnumerable<MixERP.Net.Entities.HRM.SalaryFrequency> Get(int[] salaryFrequencyIds)
        {
            if (string.IsNullOrWhiteSpace(this.Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this.LoginId, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to entity \"SalaryFrequency\" was denied to the user with Login ID {LoginId}. salaryFrequencyIds: {salaryFrequencyIds}.", this.LoginId, salaryFrequencyIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

			const string sql = "SELECT * FROM hrm.salary_frequencies WHERE salary_frequency_id IN (@0);";

            return Factory.Get<MixERP.Net.Entities.HRM.SalaryFrequency>(this.Catalog, sql, salaryFrequencyIds);
        }

	}
}