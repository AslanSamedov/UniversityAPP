using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Core.Entities
{
    public class Corpus : BaseEntity
    {
        public string Name { get; set; }
        public int CorpusNo { get; set; }
    }
}
