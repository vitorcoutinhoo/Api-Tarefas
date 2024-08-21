using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Tarefas.Models;

namespace Api_Tarefas.Entities {
    public class Tarefa {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }
    }
}