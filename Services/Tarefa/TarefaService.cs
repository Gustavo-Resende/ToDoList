﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ToDoList.Data;
using ToDoList.Dto.Tarefa;
using ToDoList.Models;

namespace ToDoList.Services.Tarefa
{
    public class TarefaService : ITarefaInterface
    {
        private readonly AppDbContext _dbContext;
        public TarefaService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ModelResponse<TarefaModel>> CheckTarefa(CheckTarefaDto checkTarefaDto)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();
            try
            {
                if (checkTarefaDto.Id <= 0)
                {
                    response.Status = false;
                    response.Mensagem = "ID inválido.";
                    return response;
                }

                var findTarefa = _dbContext.Set<TarefaModel>().FindAsync(checkTarefaDto.Id);

                if (findTarefa == null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }

                findTarefa.Result.Status = true;
                await _dbContext.SaveChangesAsync();
                response.Status = true;
                response.Mensagem = "Tarefa marcada com sucesso.";
                response.Dados = findTarefa.Result;

            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao marcar tarefa: {ex.Message}";
                response.Status = false;
                return response;
            }

            return response;
        }
            
        public async Task<ModelResponse<TarefaModel>> UncheckTarefa(UnCheckTarefaDto unCheckTarefaDto)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();
            try
            {
                if (unCheckTarefaDto.Id <= 0)
                {
                    response.Status = false;
                    response.Mensagem = "ID inválido.";
                    return response;
                }

                var findTarefa = _dbContext.Set<TarefaModel>().FindAsync(unCheckTarefaDto.Id);

                if (findTarefa == null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }

                findTarefa.Result.Status = false;
                await _dbContext.SaveChangesAsync();
                response.Status = true;
                response.Mensagem = "Tarefa desmarcada com sucesso.";
                response.Dados = findTarefa.Result;

            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao desmarcar tarefa: {ex.Message}";
                response.Status = false;
                return response;
            }

            return response;
        }

        public async Task<ModelResponse<TarefaModel>> CreateTarefa(CreateTarefaDto createTarefaDto)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();

            try
            {
                var findTarefa = await _dbContext.Set<TarefaModel>().FirstOrDefaultAsync(t => t.Titulo == createTarefaDto.Titulo);

                if (findTarefa != null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa com este título já existe.";
                    return response;
                }

                var tarefa = new TarefaModel
                {

                    Descricao = createTarefaDto.Descricao,
                    Titulo = createTarefaDto.Titulo
                };

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

        public async Task<ModelResponse<TarefaModel>> DeleteTarefa(int id)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();

            try
            {
                if(id <= 0)
                {
                    response.Status = false;
                    response.Mensagem = "ID inválido.";
                    return response;
                }

                var findTarefa = _dbContext.Set<TarefaModel>().FindAsync(id);

                if (findTarefa == null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }

                _dbContext.Set<TarefaModel>().Remove(findTarefa.Result);
                await _dbContext.SaveChangesAsync();

                response.Dados = findTarefa.Result;
                response.Status = true;
                response.Mensagem = "Tarefa deletada com sucesso.";
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao criar tarefa: {ex.Message}";
                response.Status = false;
            }
            
            return response;
        }

        public async Task<ModelResponse<List<TarefaModel>>> GetAllTarefa()
        {
            ModelResponse <List<TarefaModel>> response = new ModelResponse<List<TarefaModel>>();

            try
            {
                var findAllTarefas = _dbContext.Set<TarefaModel>().ToListAsync();

                if (findAllTarefas == null)
                {
                    response.Status = false;
                    response.Mensagem = "Nenhuma tarefa encontrada.";
                    return response;
                }

                response.Dados = await findAllTarefas;
                response.Status = true;
                response.Mensagem = "Tarefas encontradas com sucesso.";

            }
            catch(Exception ex)
            {
                response.Mensagem = $"Erro ao buscar tarefas: {ex.Message}";
                response.Status = false;
                return response;
            }

            return response;
        }

        public async Task<ModelResponse<TarefaModel>> GetTarefaById(int id)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();

            try
            {
                if (id <= 0)
                {
                    response.Status = false;
                    response.Mensagem = "ID inválido.";
                    return response;
                }

                var findTarefa = await _dbContext.Set<TarefaModel>().FindAsync(id);

                if (findTarefa == null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }

                response.Dados = findTarefa;
                response.Status = true;
                response.Mensagem = "Tarefa encontrada com sucesso.";
                return response;
            }

            catch (Exception ex)
            {
                response.Mensagem = $"Erro ao buscar tarefa: {ex.Message}";
                response.Status = false;
                return response;
            }

        }

        public async Task<ModelResponse<TarefaModel>> UpdateTarefa(EditTarefaDto editTarefaDto)
        {
            ModelResponse<TarefaModel> response = new ModelResponse<TarefaModel>();

            try
            {
                if (editTarefaDto.Id <= 0)
                {
                    response.Status = false;
                    response.Mensagem = "ID inválido.";
                    return response;
                }

                var findTarefa = await _dbContext.Set<TarefaModel>().FindAsync(editTarefaDto.Id);

                if (findTarefa == null)
                {
                    response.Status = false;
                    response.Mensagem = "Tarefa não encontrada.";
                    return response;
                }


                findTarefa.Titulo = editTarefaDto.Titulo;
                findTarefa.Descricao = editTarefaDto.Descricao;
                _dbContext.Set<TarefaModel>().Update(findTarefa);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Mensagem = "Tarefa atualizada com sucesso.";
                response.Dados = findTarefa;

                return response;

            }
            catch (Exception ex) {
                response.Mensagem = $"Erro ao atualizar tarefa: {ex.Message}";
                response.Status = false;
            }

            return response;
        }
    }
}
