using Ejournall.Core.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Mapper
{
    public abstract class BaseMapper <TEntity,TModel> where TEntity : BaseEntity where TModel : BaseModel<TModel>
    {
        public abstract TEntity Map(TModel model);
        public abstract TModel Map(TEntity entity);
    }
}
