using System;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using Microsoft.Identity.Client;

namespace PhysioWeb.Models
{
    public class ServiceMaster : CommanProp
    {
        
        public string Title { get; set; }  
        public bool IsActive { get; set; } 
        public ServiceMaster() {

        }
        public ServiceMaster(IDataReader reader, int flag = 0)
        {
            if (flag == 0)
            {
                TotalCount = reader["TotalCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalCount"]) : 0;
                UniquId = Convert.ToInt32(reader["UniquId"]);
                Title = reader["Title"].ToString();
                InActiveText = reader["IsActive"].ToString();
                CreatedBy = reader["CreatedBy"].ToString();
            }
            else if (flag == 1)
            {
                populateObject(this, reader);
            }
        }
        private void populateObject(ServiceMaster obj, IDataReader rdr)
        {
            if (!rdr.IsDBNull(rdr.GetOrdinal("UniqueID")))
            {
                obj.UniquId = rdr.GetInt32(rdr.GetOrdinal("UniqueID"));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal("Title")))
            {
                obj.Title = rdr.GetString(rdr.GetOrdinal("Title"));
            }
            if (!rdr.IsDBNull(rdr.GetOrdinal("IsActive")))
            {
                obj.IsActive = rdr.GetBoolean(rdr.GetOrdinal("IsActive"));
            }

        }
    }
}
