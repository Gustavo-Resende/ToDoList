using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Dto.Tarefa;
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
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> CreateTarefa(CreateTarefaDto createTarefaDto)
        {
            var response = await _tarefaInterface.CreateTarefa(createTarefaDto);
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
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> UpdateTarefa(EditTarefaDto editTarefaDto)
        {
            var response = await _tarefaInterface.UpdateTarefa(editTarefaDto);
            return Ok(response);
        }

        [HttpPut("CheckTarefa")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> CheckTarefa(CheckTarefaDto checkTarefaDto)
        {
            var response = await _tarefaInterface.CheckTarefa(checkTarefaDto);
            return Ok(response);
        }

        [HttpPut("UncheckTarefa")]
        public async Task<ActionResult<ModelResponse<List<TarefaModel>>>> UncheckTarefa(UnCheckTarefaDto unCheckTarefaDto)
        {
            var response = await _tarefaInterface.UncheckTarefa(unCheckTarefaDto);
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
