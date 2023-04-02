using ITExpertWebAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace ITExpertWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IDataManipulation _dataManipulation;
        public DataController(ILogger<DataController> logger, IDataManipulation dataManipulation)
        {

            _logger = logger;
            _dataManipulation = dataManipulation;
        }

        /// <summary>
        /// Получает на вход json, который содержит массив объектов, и сохраняет его в БД
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// [
        /// 	{"1": "value1"},
        ///	    {"5": "value2"},
        ///     {"10": "value32"}
        /// ]
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] ICollection<IDictionary<string, string>> data)
        {
            await _dataManipulation.SetDataAsync(data);

            return Ok();
        }

        /// <summary>
        /// Возвращает данные клиенту из таблицы в виде json
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetDataAsync(string? value)
        {
            var data = await _dataManipulation.GetDataObjectsAsync(value);

            return Ok(data);
        }
    }
}
