namespace TodoApp.Api.Models
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
    }
}
