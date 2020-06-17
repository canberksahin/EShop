using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class BasketWithItemsSpecifications : BaseSpecification<Basket>
    {
        public BasketWithItemsSpecifications(int basketId) :base(x=>x.Id==basketId)
        {
            AddInclude(x => x.Items);
        }        
        
        public BasketWithItemsSpecifications(string buyerId) :base(x=>x.BuyerId==buyerId)
        {
            AddInclude(x => x.Items);
        }


    }
}
