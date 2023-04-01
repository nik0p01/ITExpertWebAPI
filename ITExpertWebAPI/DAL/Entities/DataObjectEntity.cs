using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITExpertWebAPI.DAL.Entities
{
    public class DataObjectEntity
    {
        //    public int Id { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Number { get; set; }
        [Required]
        public int Code { get; set; }
        public string Value { get; set; }
    }

}
