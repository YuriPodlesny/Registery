using Registry.Domain.Entities.Base;

namespace Registry.Domain.Entities
{
    public class RosreestrStatus : BaseEntity
    {
        public string? Value { get; set; }
        public bool Delete { get; set; } = false;


        public IList<Form> Forms { get; set; } = new List<Form>();
    }
}
