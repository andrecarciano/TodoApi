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
    }
}
