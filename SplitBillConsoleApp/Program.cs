// See https://aka.ms/new-console-template for more information

using SplitBillClassLibrary;

SplitBillClass obj1 = new SplitBillClass();
var splitAmount = obj1.AmountSummary();
foreach (var item in splitAmount)
{
    Console.WriteLine("Name : "+item);
    Console.WriteLine("Amount : " + item.Value);
}
