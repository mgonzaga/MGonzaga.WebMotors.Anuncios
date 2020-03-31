using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.WebMotors.Anuncios.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntityBase> where TEntityBase : class
    {
        TEntityBase Adicionar(TEntityBase entity);
        TEntityBase Atualizar(TEntityBase entity);
        TEntityBase Consultar(int Id);
        List<TEntityBase> ListarTodos();
        void Remover(int id);
        IUnitOfWork UnitOfWork { get; }
    }
}
