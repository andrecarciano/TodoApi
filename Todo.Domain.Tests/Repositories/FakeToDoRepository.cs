using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Testes.Repositories
{
    public class FakeToDoRepository : IToDoRepository
    {
        public void Create(TodoItem todo)
        {
        }

        public void Update(TodoItem todo)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("", DateTime.Now, "");
        }

        public IEnumerable<TodoItem> GetAll(string User)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string User)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUnDone(string User)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetByPeriod(string User, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }
    }
}
