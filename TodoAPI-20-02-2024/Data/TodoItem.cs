namespace TodoAPI_20_02_2024.Data
{
    public class TodoItem
    {
        public int Id { get; set; }
        
        public string Title  { get; set; } = string.Empty;

        public bool Done { get; set; }
    }
    
}
