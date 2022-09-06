using System;
using System.Collections.Generic;
using TradeCategory.Interfaces;

namespace TradeCategory.Model
{
    public class TradeInputDto
    {
        public DateTime ReferenceDate { get; set; }      
        public IList<ITrade> TradeInputItems { get; set; } = new List<ITrade>();
    }
}
