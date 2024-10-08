﻿using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class ToDoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkToDoAsDoneCommand>, IHandler<MarkToDoAsUndoneCommand>
    {
        private readonly IToDoRepository _repository;

        public ToDoHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var toDo = new TodoItem(command.Title, command.Date, command.User);

            _repository.Create(toDo);

            return new GenericCommandResult(true,"Tarefa Salva", toDo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var toDo = _repository.GetById(command.Id, command.User);

            toDo.UpdateTitle(command.Title);

            _repository.Update(toDo);

            return new GenericCommandResult(true, "Tarefa Salva", toDo);
        }

        public ICommandResult Handle(MarkToDoAsDoneCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var toDo = _repository.GetById(command.Id, command.User);

            toDo.MarkAsDone();

            _repository.Update(toDo);

            return new GenericCommandResult(true, "Tarefa Salva", toDo);
        }

        public ICommandResult Handle(MarkToDoAsUndoneCommand command)
        {
            //Fail Fast Validate
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var toDo = _repository.GetById(command.Id, command.User);

            toDo.MarkAsUnDone();

            _repository.Update(toDo);

            return new GenericCommandResult(true, "Tarefa Salva", toDo);
        }
    }
}

