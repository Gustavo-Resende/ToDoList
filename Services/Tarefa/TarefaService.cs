using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services.Tarefa
{
    public class TarefaService : ITarefaInterface
    {
        private readonly DbContext _dbContext;
        public TarefaService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ModelResponse<TarefaModel>> CreateTarefa(string titulo, string descricao)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();

            try
            {
                if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(descricao))
                {
                    response.Status = false;
                    response.Mensagem = "Título e descrição não podem ser nulos.";
                    return response;
                }

                TarefaModel tarefa = new TarefaModel { Titulo = titulo, Descricao = descricao };
                await _dbContext.Set<TarefaModel>().AddAsync(tarefa);
                await _dbContext.SaveChangesAsync();

                response.Dados = tarefa;
                response.Status = true;
                response.Mensagem = "Tarefa criada com sucesso.";
            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao criar tarefa: {ex.Message}";
                response.Status = false;
            }

            return response;
        }

        public Task<ModelResponse<TarefaModel>> DeleteTarefa(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelResponse<List<TarefaModel>>> GetAllTarefa()
        {
            throw new NotImplementedException();
        }

        public Task<ModelResponse<TarefaModel>> GetTarefaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelResponse<TarefaModel>> UpdateTarefa(int id, string nome, string descricao)
        {
            throw new NotImplementedException();
        }
    }
}
