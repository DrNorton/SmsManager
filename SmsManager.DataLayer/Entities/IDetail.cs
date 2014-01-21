using System.Data.Linq.Mapping;

namespace SmsManager.DataLayer.Entities
{
    public interface IDetail
    {
        [Column(IsPrimaryKey = true)]
        long Id { get; set; }
    }
}