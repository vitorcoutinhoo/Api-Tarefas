using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Tarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Tarefas.Context {
    public class ListaTarefasContext(DbContextOptions<ListaTarefasContext> options) : DbContext(options) {
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}