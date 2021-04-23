namespace JobPortal.Services.Data.Interfaces
{
    using JobPortal.Data.Models;

    public interface IWorkersService
    {
        public Worker FindById(string workerId);

        public T FindById<T>(string workerId);
    }
}
