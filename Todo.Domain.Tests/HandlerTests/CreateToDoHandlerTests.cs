using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Testes.Repositories;

namespace Todo.Domain.Testes.HandlerTests
{
    [TestClass]
    public class CreateToDoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da Tarefa", DateTime.Now, "Andrezinho");
        private readonly ToDoHandler _handler = new ToDoHandler(new FakeToDoRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_comando_Invalido_deve_interromper_execução()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Sucess, false);
        }
        
        [TestMethod]
        public void Dado_comandoValido_deve_criar_Tarefa()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Sucess, true);
        }

    }

}
