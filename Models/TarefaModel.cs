﻿namespace ToDoList.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Status { get; set; } = false;
    }
}