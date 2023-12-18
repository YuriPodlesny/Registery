using Registery.Domain.Entities;

namespace Registery.Models
{
    public class IndexViewModel<T>
        where T : class
    {
        public IEnumerable<T> Model { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
