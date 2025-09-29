namespace PhysioWeb.Repository
{
    public class ManagementRepository : IManagementRepository
    {
        public async Task<DataTableResult> ListServices(DataTablePara dataTablePara)
        {
            try
            {
                string[] parameterName = new string[]
                {
                    "DisplayLength", "DisplayStart", "SortCol", "SortDir", "Search",
                    "PropertyType", "Description", "IsActive", "CreatedBy", "AgencyId"
                };

                object[] parameterValue = new object[]
                {
                    dataTablePara.iDisplayLength,dataTablePara.iDisplayStart,dataTablePara.iSortCol_0,
                    dataTablePara.sSortDir_0,dataTablePara.sSearch,dataTablePara.sSearch_0,
                    dataTablePara.sSearch_1,dataTablePara.sSearch_2,dataTablePara.sSearch_3,dataTablePara.AgencyId
                };

                var reader = await _dbHelper.GetDataReaderAsync("[FMR_DataListPropertyType]", parameterName, parameterValue);

                var result = new DataTableResult();
                var list = new List<PropertyTypeMaster>();

                while (reader.Read())
                {
                    list.Add(new PropertyTypeMaster(reader));
                }

                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        result.iTotalRecords = Convert.ToInt32(reader[0]);
                    }
                }

                result.iTotalDisplayRecords = result.iTotalRecords;
                result.aaData = list;

                return result;
            }
            catch (Exception ex)
            {
                // Optional: log error here
                throw;
            }
        }
    }
}
