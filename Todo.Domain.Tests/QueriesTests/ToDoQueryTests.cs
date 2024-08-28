using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Testes.QueriesTests
{
    [TestClass]
    public class ToDoQueryTests
    {
        private List<TodoItem> _items;

        public ToDoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa1",DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa2",DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa3",DateTime.Now, "andrezinho"));
            _items.Add(new TodoItem("Tarefa4",DateTime.Now, "Usuario1"));
            _items.Add(new TodoItem("Tarefa5",DateTime.Now, "andrezinho"));
        }

        [TestMethod]
        public void Deve_retornar_tarefas_apenas_de_um_usuario() 
        {
            var result = _items.AsQueryable().Where(ToDoQueries.GetAll("andrezinho"));
            Assert.AreEqual(2, result.Count());
        }
    }
}
