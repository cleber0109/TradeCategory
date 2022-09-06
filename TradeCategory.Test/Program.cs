using System;
using TradeCategory.Utils;

namespace TradeCategory
{
    public class Program
    {
        static void Main(string[] args)
        {
            CategoryContext categoryContext = new CategoryContext();
            ConsoleHandler handler = new ConsoleHandler();

            Console.WriteLine("Please input a date in a correct format (mm/dd/yyyy)");
            var inputDate = Console.ReadLine();
            
            handler.HandleTradeReferenceDateInput(inputDate);

            Console.WriteLine("\nPlease input number of trades you would calculate");
            var inputTradesQty = Console.ReadLine();
            var inputTradesQtyResult = handler.HandleTradeQuantityInput(inputTradesQty);

            Console.WriteLine("\nPlease input trade information. (Exemple: 2000000 Private 12/29/2025) and press enter");
            string[] inputTradeData = new string[inputTradesQtyResult];

            for (int i = 0; i <= inputTradesQtyResult -1; i++)
            {
                inputTradeData[i] = Console.ReadLine();
            }
            var inputTradeDataResult = handler.HandleTradeDataInput(inputDate, inputTradesQtyResult, inputTradeData);

            Console.WriteLine("\n--------- RESULT:\n");

            foreach (var trade in inputTradeDataResult.TradeInputItems)
            {
                var result = handler.GetCategory(trade, categoryContext, inputTradeDataResult.ReferenceDate);
                Console.WriteLine(result);
            }
        }
    }
}
