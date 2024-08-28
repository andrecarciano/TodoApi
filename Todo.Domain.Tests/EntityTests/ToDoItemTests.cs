using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Testes.EntityTests
{
    [TestClass]
    public class ToDoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo Aqui", DateTime.Now, "Usuario" );
        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_estar_concluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}
