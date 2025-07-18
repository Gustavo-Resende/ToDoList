using ToDoList.Dto.Tarefa;
using ToDoList.Models;

namespace ToDoList.Services.Tarefa
{
    public interface ITarefaInterface
    {
        Task<ModelResponse<TarefaModel>> CreateTarefa(CreateTarefaDto createTarefaDto);
        Task<ModelResponse<List<TarefaModel>>> GetAllTarefa();
        Task<ModelResponse<TarefaModel>> GetTarefaById(int id);
        Task<ModelResponse<TarefaModel>> UpdateTarefa(EditTarefaDto editTarefaDto);
        Task<ModelResponse<TarefaModel>> DeleteTarefa(int id);
        Task<ModelResponse<TarefaModel>> CheckTarefa(CheckTarefaDto checkTarefaDto);
        Task<ModelResponse<TarefaModel>> UncheckTarefa(UnCheckTarefaDto unCheckTarefaDto);
    }
}
