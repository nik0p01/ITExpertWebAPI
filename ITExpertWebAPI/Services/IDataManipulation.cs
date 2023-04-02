using ITExpertWebAPI.DTO;

namespace ITExpertWebAPI.Services
{
    public interface IDataManipulation
    {
        Task<ICollection<DataObject>> GetDataObjectsAsync(string? value);
        Task SetDataAsync(ICollection<IDictionary<string, string>> data);
    }
}