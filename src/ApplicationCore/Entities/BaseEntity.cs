using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class BaseEntity
    {
        //virtual vermek override edilebilirlik kazandırıyor.
        public virtual int Id { get; set; }
    }
}
