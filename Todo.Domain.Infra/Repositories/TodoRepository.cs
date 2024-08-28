using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : IToDoRepository
    {
        private readonly DataContext _ctx;

        public TodoRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(TodoItem todo)
        {
            _ctx.Add(todo);
            _ctx.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _ctx.ToDos.AsNoTracking().Where(ToDoQueries.GetAll(user)).OrderBy(x=>x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _ctx.ToDos.AsNoTracking().Where(ToDoQueries.GetAllDone(user)).OrderBy(x=>x.Date);
        }

        public IEnumerable<TodoItem> GetAllUnDone(string user)
        {
            return _ctx.ToDos.AsNoTracking().Where(ToDoQueries.GetAllUnDone(user)).OrderBy(x => x.Date);
        }

        //colocar query na lista e nos testes
        public TodoItem GetById(Guid id, string user)
        {
            return _ctx.ToDos.AsNoTracking().FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _ctx.ToDos.AsNoTracking().Where(ToDoQueries.GetByPeriod(user,date,done)).OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _ctx.Entry(todo).State = EntityState.Modified;
            _ctx.SaveChanges();

        }
    }
}
