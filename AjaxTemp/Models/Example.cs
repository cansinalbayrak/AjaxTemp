namespace AjaxTemp.Models
{
    public class Example
    {
        public Example()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}
