namespace ToDoList.Models
{
    public class ModelResponse <T>
    {
        public T? Dados { get; set; }
        public bool Status { get; set; } = true;
        public string? Mensagem { get; set; }

    }
}
