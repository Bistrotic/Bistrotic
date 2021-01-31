namespace Fiveforty.Module.Units.Domain
{
    using System;

    using Fiveforty.Domain;

    public class Unit : IEntity, IAggregateRoot
    {
        private readonly IRepository<UnitState> _repository;

        public Unit(IRepository<UnitState> repository)
        {
            _repository = repository;
        }

        public string AggregateName => nameof(Unit);

        public static void AddNew(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}