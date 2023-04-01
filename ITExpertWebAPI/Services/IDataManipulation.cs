using ITExpertWebAPI.DTO;

namespace ITExpertWebAPI.Services
{
    public interface IDataManipulation
    {
        Task<ICollection<DataObject>> GetDataObjectsAsync(int? code, string? value);
        Task SetDataAsync(ICollection<IDictionary<string, string>> data);
    }
}