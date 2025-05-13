using CoresModel;
using System.Collections.Generic;
using System.Linq;

namespace CoresBusiness;
public class CorService
{
    public static readonly List<CorModel> _cores = new();
    public static int _nextId = 1;

    public List<CorModel> ListarTodos() => _cores;
    public CorModel? ObterPorId(int id) => _cores.FirstOrDefault(c => c.Id == id);

    public CorModel Criar(CorModel cor)
    {
        cor.Id = _nextId++;
        _cores.Add(cor);
        return cor;
    }
  
    public bool Atualizar(CorModel cor)
    {
        var existente = ObterPorId(cor.Id);
        if (existente == null) return false;
        existente.Cor = cor.Cor;
        existente.Natureza = cor.Natureza;
        existente.Intensidade = cor.Intensidade;
        return true;
    }

    public bool Remover(int id)
    {
        var cor = ObterPorId(id);
        if (cor == null) return false;
        _cores.Remove(cor);
        return true;
    }
}