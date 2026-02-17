using System.Collections.Generic;
using Domain;
using Exceptions;
using System.Linq;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<BaseEntity>> _data
            = new SortedDictionary<int, List<BaseEntity>>();

        public void AddEntity(int key, BaseEntity entity)
        {
            entity.Validate();

            foreach (var list in _data.Values)
            {
                if (list.Any(e => e.Id == entity.Id))
                    throw new ScenarioException("Duplicate Medicine");
            }

            if (!_data.ContainsKey(key))
                _data[key] = new List<BaseEntity>();

            _data[key].Add(entity);
        }

        public void UpdateEntity(string id, int newPrice)
        {
            foreach (var list in _data.Values)
            {
                foreach (var entity in list)
                {
                    if (entity.Id == id)
                    {
                        Medicine med = entity as Medicine;
                        if (med == null)
                            throw new ScenarioException("Invalid Entity Type");

                        if (newPrice <= 0)
                            throw new ScenarioException("Invalid Price");

                        med.Price = newPrice;
                        return;
                    }
                }
            }

            throw new ScenarioException("Medicine Not Found");
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            foreach (var pair in _data)
            {
                foreach (var entity in pair.Value)
                {
                    yield return entity;
                }
            }
        }
    }
}
