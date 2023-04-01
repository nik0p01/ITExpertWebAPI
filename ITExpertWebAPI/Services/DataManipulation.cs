using ITExpertWebAPI.Controllers;
using ITExpertWebAPI.DAL;
using ITExpertWebAPI.DAL.Entities;
using ITExpertWebAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ITExpertWebAPI.Services
{
    public class DataManipulation : IDataManipulation
    {
        private readonly ILogger<DataController> _logger;
        private readonly Context _context;
        public DataManipulation(ILogger<DataController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task SetDataAsync(ICollection<IDictionary<string, string>> data)
        {
            try
            {
                _context.DataObjects.RemoveRange(_context.DataObjects);
                await _context.SaveChangesAsync();
                var ordered = data.Select(p=>new KeyValuePair<int, string>(int.Parse(p.FirstOrDefault().Key),p.FirstOrDefault().Value)).OrderBy(p => p.Key);
                int count = 0;
                foreach (var dataObject in ordered)
                {
                    _context.DataObjects.Add(new DataObjectEntity { Number = count, Code = dataObject.Key, Value = dataObject.Value });
                    count++;
                }
                await _context.SaveChangesAsync();
            }

            catch (FormatException ex) 
            {
                _logger.LogError(ex, "Code is not number");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<ICollection<DataObject>> GetDataObjectsAsync(int? code, string? value)
        {
            var query = _context.DataObjects.AsQueryable();

            if (code.HasValue || (value != null))
            {
                query = query.Where(d => (!code.HasValue || (d.Code == code.Value)) && ((value == null) || (d.Value == value)));
            }

            var data = await query.Select(d => new DataObject { Number = d.Number, Code = d.Code, Value = d.Value }).ToListAsync();
            return data;
        }

    }
}
