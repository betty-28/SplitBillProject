using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitBillClassLibrary
{
    public class SplitBillClass
    {
        public int noOfPersons { get; set; }
        public int totalMealCost { get; set; }
        public float Tip { get; set; }

        public Dictionary<string, decimal> AmountSummary()
        {
            Console.WriteLine("Please enter the no:of persons : ");
            noOfPersons = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the total amount : ");
            var totalMealCost = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, decimal> amountDict = new Dictionary<string, decimal>();
            string name = "";
            decimal amount = 0;
            Console.WriteLine("Please enter the name and cost of each persons : ");
            for (int i = 0; i < noOfPersons; i++)
            {
                name = Console.ReadLine();
                amount = Convert.ToInt32(Console.ReadLine());
                amountDict.Add(name, amount);
            }
            Console.WriteLine("Please enter the amount for tip : ");
            Tip = Convert.ToInt32(Console.ReadLine());
            var result = CalculateAmount(amountDict, Tip);
            return result;
        }
        public Dictionary<string, decimal> CalculateAmount(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            Dictionary<string, decimal> amountPayableDict = new Dictionary<string, decimal>();
            var amountForPerson = AmountDetails();
            foreach (var mealCost in mealCosts)
            {
                string name = mealCost.Key;
                decimal cost = mealCost.Value;
                var tipPayable = (cost * Convert.ToDecimal(tipPercentage)) / 100;
                var amountPayable = tipPayable + amountForPerson;
                amountPayableDict.Add(name, amountPayable);
            }
            return amountPayableDict;
            //Calculate here the weighted average
        }

        public int AmountDetails() 
        {
            var amountForPerson = totalMealCost / noOfPersons;
            return amountForPerson;
        }
    }


    public class Tips
    {
        public float? Tip { get; set; }
        public PersonDetails PersonName { get; set; }
    }

    public class PersonDetails
    {
        public string Name { get; set; }
        public int MealCost { get; set; }
    }
}
