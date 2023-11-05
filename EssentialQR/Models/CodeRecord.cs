using SQLite;

namespace EssentialQR.Models
{
    public class CodeRecord
    {
        [PrimaryKey, Column("_id")]
        public string Id { get; set; }
        public string Value { get; set; }
        public DateTime Time { get; private set; } = DateTime.Now;
    }
}
