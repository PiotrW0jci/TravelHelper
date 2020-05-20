using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace TravelHelper.Core.Domain
{
    public class BudgetPlanItem
    {
        [Key]
        public Guid Id {get;protected set;}
        public Guid BudgetPlanId {get;protected set;}
        public int Price {get;protected set;}
        public string Name {get;protected set;}
        public int Value {get;protected set;}

         protected BudgetPlanItem()
        {
        }
        public BudgetPlanItem  (string budgetplanId,string name,int price,int value)
        {
            Id = Guid.NewGuid();
            BudgetPlanId = Guid.Parse(budgetplanId);
            Price = price;
            Name = name;
            Value = value;
        }
    }
}