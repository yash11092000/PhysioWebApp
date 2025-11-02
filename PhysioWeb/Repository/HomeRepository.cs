using PhysioWeb.Data;
using PhysioWeb.Models;

namespace PhysioWeb.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly DbHelper _dbHelper;

        public HomeRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<bool> RegisterUser(Users users)
        {
            try
            {
              
                // ✅ Prepare parameters
                string[] parametersName = {
                "UserId",
                "UserName",
                "EmailId",
                "Password",
                "UserRole"
            };

                object[] values = {
                users.UserId,
                users.UserName,
                users.EmailId,
                users.Password,
                users.UserRole
                
            };
                string spName = "AddUsers";

                var rowsAffected = await _dbHelper.ExecuteNonQueryAsync(spName, parametersName, values);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                // Log or handle exception as needed
                throw;
            }
        }
    }
}
