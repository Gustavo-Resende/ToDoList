using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.Tarefa;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface _tarefaInterface;
        public TarefaController(ITarefaInterface tarefaInterface)
        {
            _tarefaInterface = tarefaInterface;
        }

        

        [HttpPost("CreateTarefa")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> CreateTarefa(string titulo, string descricao)
        {
            var response = await _tarefaInterface.CreateTarefa(titulo, descricao);
            return Ok(response);
        }

        [HttpGet("GetAllTarefa")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> GetAllTarefa()
        {
            var response = await _tarefaInterface.GetAllTarefa();
            return Ok(response);
        }

        [HttpGet("GetTarefaById")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> GetTarefaById(int id)
        {
            var response = await _tarefaInterface.GetTarefaById(id);
            return Ok(response);
        }

        [HttpPut("UpdateTarefa")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> UpdateTarefa(int id, string titulo, string descricao)
        {
            var response = await _tarefaInterface.UpdateTarefa(id, titulo, descricao);
            return Ok(response);
        }

        [HttpDelete("DeleteTarefa")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> DeleteTarefa(int id)
        {
            var response = await _tarefaInterface.DeleteTarefa(id);
            return Ok(response);
        }
    }


}
