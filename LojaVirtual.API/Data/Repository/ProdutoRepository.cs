using Ci.Calcados.API.Models;
using Ci.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ci.Calcados.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutoContext _context;

        public ProdutoRepository(ProdutoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarMarca(Marca marca)
        {
            _context.Marca.Add(marca);
        }

        public void AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void AdicionarTipoProduto(TipoProduto tipoProduto)
        {
            _context.TipoProduto.Add(tipoProduto);
        }

        public void AtualizarMarca(Marca marca)
        {
            _context.Marca.Update(marca);
        }

        public void AtualizarProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void AtualizarTipoProduto(TipoProduto tipoProduto)
        {
            _context.TipoProduto.Update(tipoProduto);
        }        

        public async Task<Marca> ObterMarcaPorId(Guid id)
        {
            return await _context.Marca.FindAsync(id);
        }

        public async Task<Produto> ObterProdutoPorId(Guid id)
        {
            return await _context.Produtos
                 .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<TipoProduto> ObterTipoProdutoPorId(Guid id)
        {
            return await _context.TipoProduto.FindAsync(id);
        }

        public async Task<List<Marca>> ObterTodasMarcas()
        {
            return await _context.Marca.Where(c => c.removido == false).OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<List<Produto>> ObterTodosProdutos()
        {
            return await _context.Produtos
                .AsNoTracking()
                .Include(m => m.Marca)
                .Include(t => t.TipoProduto)
                .Include(c => c.Cor)
                .Include(c => c.Tamanho)
                .Where(c => c.removido == false).ToListAsync();
        }

        public async Task<List<TipoProduto>> ObterTodosTipoProduto()
        {
            return await _context.TipoProduto.Where(c => c.removido == false).OrderBy(c => c.Nome).ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Cor>> ObterTodasCores()
        {
            return await _context.Cor.Where(c => c.removido == false).OrderBy(c => c.Nome).ToListAsync();
        }

        public Task<Cor> ObterCorPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AdicionarCor(Cor tipoProduto)
        {
            throw new NotImplementedException();
        }

        public void AtualizarCor(Cor tipoProduto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tamanho>> ObterTodosTamanhos()
        {
            return await _context.Tamanho.Where(t => t.removido == false).OrderBy(c => c.Nome).ToListAsync();
        }

        public Task<Tamanho> ObterTamanhoPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AdicionarTamanho(Tamanho tamanho)
        {
            throw new NotImplementedException();
        }

        public void AtualizarTamanho(Tamanho tamanho)
        {
            throw new NotImplementedException();
        }
    }
}
