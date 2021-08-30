using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpactisTechnicalTestApi.Interfaces
{
    public interface IRepository
    {
        Task<List<T>> SelectAll<T>() where T : class;
    }
}
