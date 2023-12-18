namespace Registery.Application.Mapping
{
    public class IndexPagination<T>
        where T : class
    {
        public IEnumerable<T> Model { get; set; }
        public PageModel PageViewModel { get; set; }
    }
}
