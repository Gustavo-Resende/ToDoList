using ToDoList.Models;

namespace ToDoList.Services.Tarefa
{
    public interface ITarefaInterface
    {
        Task<ModelResponse<TarefaModel>> CreateTarefa(string titulo, string descricao);
        Task<ModelResponse<List<TarefaModel>>> GetAllTarefa();
        Task<ModelResponse<TarefaModel>> GetTarefaById(int id);
        Task<ModelResponse<TarefaModel>> UpdateTarefa(int id, string titulo, string descricao);
        Task<ModelResponse<TarefaModel>> DeleteTarefa(int id);
        Task<ModelResponse<TarefaModel>> CheckTarefa(int id);
        Task<ModelResponse<TarefaModel>> UncheckTarefa(int id);
    }
}
