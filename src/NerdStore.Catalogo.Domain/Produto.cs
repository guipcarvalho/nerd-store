using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
    class Produto : Entity, IAgregateRoot
    {
        public Guid IdCategoria { get; private set; }
        public DateTime DataCadastro { get; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCastro { get; private set; }
        public string Imagem { get; private set; }
        public int QtdEstoque { get; private set; }

        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid idCategoria, DateTime dataCadastro, string imagem)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Ativo = ativo;
            Valor = valor;
            IdCategoria = idCategoria;
            DataCadastro = dataCadastro;
            Imagem = imagem;
        }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            IdCategoria = categoria.Id;
        }

        public void AlterarDescricao(string descricao) => Descricao = descricao;

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;

            QtdEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade) => QtdEstoque += quantidade;

        public bool PossuiEstoque(int quantidade) => QtdEstoque >= quantidade;

    }
}
