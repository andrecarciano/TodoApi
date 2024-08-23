﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface IToDoRepository
    {
        void Update(TodoItem todo);
        void Create(TodoItem todo);
    }
}
