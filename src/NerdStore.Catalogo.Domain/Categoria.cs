﻿using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        public IEnumerable<Produto> Produtos { get; set; }

        protected Categoria() { }

        public Categoria(string nome, int codigo)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Codigo = codigo;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode ser vazio.");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Código da categoria não pode ser igual a 0");
        }

        public override string ToString() => $"{Codigo} - {Nome}";
    }
}
