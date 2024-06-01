using GscareApiAspNetCore.Domain.Entities;

namespace GscareApiAspNetCore.Domain.Repositories;
public interface IWarningWriteOnlyRepository
{
    Task Add(Warning warning);
    /// <summary>
    /// This function returns TRUE if the deletion was successful otherwise returns FALSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}
