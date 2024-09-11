using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/ToDos")]
    public class ToDoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
           [FromServices]IToDoRepository repository
        ) 
        {
            return repository.GetAll("andrezinho");
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] ToDoHandler handler
        )
        {
            command.User = "andrezinho";
            return (GenericCommandResult)handler.Handle(command);

        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateTodoCommand command,
           [FromServices] ToDoHandler handler
       )
        {
            command.User = "andrezinho";
            return (GenericCommandResult)handler.Handle(command);

        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
           [FromServices] IToDoRepository repository
        )
        {
            return repository.GetAllDone("andrezinho");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone(
           [FromServices] IToDoRepository repository
        )
        {
            return repository.GetAllUnDone("andrezinho");
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday(
           [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod("andrezinho", DateTime.Now.Date, false);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
           [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod("andrezinho",DateTime.Now.Date,true);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
           [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod("andrezinho", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow(
           [FromServices] IToDoRepository repository
        )
        {
            return repository.GetByPeriod("andrezinho", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
           [FromBody] MarkToDoAsDoneCommand command,
           [FromServices] ToDoHandler handler
       )
        {
            command.User = "andrezinho";
            return (GenericCommandResult)handler.Handle(command);

        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
           [FromBody] MarkToDoAsUndoneCommand command,
           [FromServices] ToDoHandler handler
       )
        {
            command.User = "andrezinho";
            return (GenericCommandResult)handler.Handle(command);

        }
    }
}
