using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto) => _context.Produtos.Add(produto);

        public void Adicionar(Categoria categoria) => _context.Categorias.Add(categoria);

        public void Atualizar(Produto produto) => _context.Produtos.Update(produto);

        public void Atualizar(Categoria categoria) => _context.Categorias.Update(categoria);

        public void Dispose() => _context.Dispose();

        public async Task<IEnumerable<Categoria>> ObterCategorias() => await _context.Categorias.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo) => await _context.Produtos.AsNoTracking().Where(x => x.Categoria.Codigo == codigo).ToListAsync();

        public async Task<Produto> ObterPorId(Guid id) => await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);

        public async Task<IEnumerable<Produto>> ObterTodos() => await _context.Produtos.AsNoTracking().ToListAsync();
    }
}
