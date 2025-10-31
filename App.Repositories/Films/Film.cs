using App.Repositories.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Films
{
    public class Film : BaseEntity
    { 
        public string Name { get; set; } = default!;
    }
}
