using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class MarkToDoAsDoneCommand : Notifiable, ICommand
    {
        public MarkToDoAsDoneCommand()
        {
            
        }
        public MarkToDoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string? User { get; set; }

        public void Validate()
        {
        
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User,6,"User","Usúario Invalido")
                );

        }

    }
}
