using AppFeriados.Domain.Models;
using AppFeriados.Persistence;
using System;

namespace AppFeriados.Seed
{
    public class ModelBuilderSeed
    {
        private readonly DataContext _context;

        public ModelBuilderSeed(DataContext context)
        {
            _context = context;
        }

        public void AddSeed()
        {
            AddUser1();

            AddTipoFeriado1();
            AddTipoFeriado2();
            AddTipoFeriado3();

            AddFeriado1();
            AddFeriado2();
            AddFeriado3();
            AddFeriado4();

            _context.SaveChanges();
        }


        public void AddUser1()
        {
            var user = new User
            {
                Id = "admin",
                Password = "admin"
            };
            _context.Add(user);
        }


        public void AddTipoFeriado1()
        {
            var tipoFeriado = new TipoFeriado
            {
                TipoFeriadoId = 1,
                Descricao = "Nacional"
            };
            _context.Add(tipoFeriado);
        }
        public void AddTipoFeriado2()
        {
            var tipoFeriado = new TipoFeriado
            {
                TipoFeriadoId = 2,
                Descricao = "Estadual"
            };
            _context.Add(tipoFeriado);
        }
        public void AddTipoFeriado3()
        {
            var tipoFeriado = new TipoFeriado
            {
                TipoFeriadoId = 3,
                Descricao = "Municipal"
            };
            _context.Add(tipoFeriado);
        }


        public void AddFeriado1()
        {
            var feriado = new Feriado
            {
                FeriadoId = 1,
                TipoFeriadoId = 1,
                FeriadoNome = "Dia do Trabalho",
                DataFeriado = DateTime.Parse("01/05/2021")
            };
            _context.Add(feriado);
        }
        public void AddFeriado2()
        {
            var feriado = new Feriado
            {
                FeriadoId = 2,
                TipoFeriadoId = 1,
                FeriadoNome = "Independência do Brasil",
                DataFeriado = DateTime.Parse("07/09/2021")
            };
            _context.Add(feriado);
        }
        public void AddFeriado3()
        {
            var feriado = new Feriado
            {
                FeriadoId = 3,
                TipoFeriadoId = 2,
                FeriadoNome = "Revolução Constitucionalista de 1932",
                DataFeriado = DateTime.Parse("09/07/2021")
            };
            _context.Add(feriado);
        }
        public void AddFeriado4()
        {
            var feriado = new Feriado
            {
                FeriadoId = 4,
                TipoFeriadoId = 3,
                FeriadoNome = "Aniversário de São Paulo",
                DataFeriado = DateTime.Parse("25/01/2021")
            };
            _context.Add(feriado);
        }

    }
}