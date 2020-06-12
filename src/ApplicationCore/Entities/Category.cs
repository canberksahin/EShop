using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    // abstract sınıf olunca newleyemezsin sadece miras alınır.
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }


    }
}
