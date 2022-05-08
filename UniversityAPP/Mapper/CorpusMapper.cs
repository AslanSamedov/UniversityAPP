using Ejournall.Core.Entities;
using Ejournall.Entities;
using Ejournall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ejournall.Mapper
{
    public class CorpusMapper : BaseMapper<Corpus, CorpusModel>
    {
        public override Corpus Map(CorpusModel model)
        {
            return new Corpus()
            {
                Id = model.Id,
                Name = model.Name,
                CorpusNo = model.CorpusNo
            };
        }

        public override CorpusModel Map(Corpus entity)
        {
            return new CorpusModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                CorpusNo = entity.CorpusNo
            };
        }
    }
}
