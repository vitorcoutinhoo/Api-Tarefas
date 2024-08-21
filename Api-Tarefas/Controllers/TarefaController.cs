using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Tarefas.Context;
using Api_Tarefas.Entities;
using Api_Tarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_Tarefas.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase {
        private readonly ListaTarefasContext _context;

        public TarefaController(ListaTarefasContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa) {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpGet("ObterTodasTarefas")]
        public IActionResult Get() {
            return Ok(_context.Tarefas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("ObterTarefasPorStatus")]
        public IActionResult GetByStatus(string status) {
            var statusEnum = Enum.Parse<Status>(status);
            var tarefas = _context.Tarefas.Where(t => t.Status == statusEnum).ToList();
            if (tarefas.Count == 0) {
                return NotFound();
            }
            return Ok(tarefas);
        }

        [HttpGet("ObterTarefasPorData")]
        public IActionResult GetByDate(DateTime data) {
            var tarefas = _context.Tarefas.Where(t => t.Data >= data && t.Data < data.AddDays(1)).ToList();
            if (tarefas.Count == 0) {
                return NotFound();
            }
            return Ok(tarefas);
        }

        [HttpGet("ObterTarefasPorTitulo")]
        public IActionResult GetByTitle(string titulo) {
            var tarefas = _context.Tarefas.Where(t => t.Titulo.Contains(titulo)).ToList();
            if (tarefas.Count == 0) {
                return NotFound();
            }
            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tarefa tarefa) {
            var tarefaExistente = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefaExistente == null) {
                return NotFound();
            }
            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Data = tarefa.Data;
            tarefaExistente.Status = tarefa.Status;
            _context.SaveChanges();
            return Ok(tarefaExistente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa == null) {
                return NotFound();
            }
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return Ok();
        }

    }
}