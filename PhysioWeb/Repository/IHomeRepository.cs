using PhysioWeb.Models;

namespace PhysioWeb.Repository
{
    public interface IHomeRepository
    {
        Task<bool> RegisterUser(Users users);
    }
}
