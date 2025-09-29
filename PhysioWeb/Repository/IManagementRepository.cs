namespace PhysioWeb.Repository
{
    public interface IManagementRepository
    {
        Task<DataTableResult> ListServices(DataTablePara dataTablePara);
    }
}
