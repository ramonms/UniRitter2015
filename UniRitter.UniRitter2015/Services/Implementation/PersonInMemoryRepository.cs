﻿using System;
using System.Collections.Generic;
using UniRitter.UniRitter2015.Models;

namespace UniRitter.UniRitter2015.Services.Implementation
{
    public class PersonInMemoryRepository : IRepository<PersonModel>
    {
        private static readonly Dictionary<Guid, PersonModel> Data = new Dictionary<Guid, PersonModel>();

        public PersonModel Add(PersonModel model)
        {
            var id = Guid.NewGuid();
            model.id = id;
            // TODO: this is __NOT__ thread safe!
            Data[id] = model;
            return model;
        }

        public bool Delete(Guid modelId)
        {
            Data.Remove(modelId);
            return true;
        }

        public PersonModel Update(Guid id, PersonModel model)
        {
            // TODO: this is __NOT__ thread safe!
            // TODO: id should be checked against model.id
            Data[id] = model;
            return model;
        }

        public IEnumerable<PersonModel> GetAll()
        {
            return Data.Values;
        }

        public PersonModel GetById(Guid id)
        {
            return Data.ContainsKey(id) ? Data[id] : null;
        }
    }
}