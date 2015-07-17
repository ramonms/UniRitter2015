﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using UniRitter.UniRitter2015.Models;

namespace UniRitter.UniRitter2015.Services.Implementation
{
    public class PostInMemoryRepository : IRepository<PostModel>
    {
        private static readonly Dictionary<Guid, PostModel> Data = new Dictionary<Guid, PostModel>();

        public PostModel Add(PostModel model)
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

        public PostModel Update(Guid id, PostModel model)
        {
            // TODO: this is __NOT__ thread safe!
            // TODO: id should be checked against model.id
            Data[id] = model;
            return model;
        }

        public IEnumerable<PostModel> GetAll()
        {
            return Data.Values;
        }

        public PostModel GetById(Guid id)
        {
            return Data.ContainsKey(id) ? Data[id] : null;
        }
    }
}