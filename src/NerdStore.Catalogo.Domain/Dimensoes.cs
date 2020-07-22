using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalogo.Domain
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeIgual(Altura, 0, "O campo Altura não pode ser igual a zero.");
            Validacoes.ValidarSeIgual(Largura, 0, "O campo Largura não pode ser igual a zero.");
            Validacoes.ValidarSeIgual(Profundidade, 0, "O campo Profundidade não pode ser igual a zero.");
        }

        public override string ToString()
        {
            return $"LxAxP {Largura} x {Altura} x {Profundidade}";
        }
    }
}
