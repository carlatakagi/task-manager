using System;

namespace TaskManager.Models
{
    public enum Priority { Baixa, Media, Alta }
    public enum Status { Aguardando, EmAndamento, Concluida }

    public class TaskModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime LimitDate { get; set; }
        public Status Status { get; set; }
    }
}
