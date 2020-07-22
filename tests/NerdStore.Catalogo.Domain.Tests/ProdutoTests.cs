using NerdStore.Core.DomainObjects;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NerdStore.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.Throws<ArgumentNullException>(() =>
                new Produto(null,"bla", true, 0, Guid.NewGuid(), DateTime.Now, "blabla", new Dimensoes(0,0,0))
            );

            Assert.Contains("nome", ex.Message);
        }
    }
}
