using System;
using System.Threading;
using TradeCategory.Categories;
using TradeCategory.Interfaces;
using TradeCategory.Model;

namespace TradeCategory.Utils
{
    public class ConsoleHandler
    {
        public bool HandleTradeReferenceDateInput(string inputDate)
        {
            var isValidDate = InputValidation.ValidateDate(inputDate);
            if (!isValidDate)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Inválid date. This App will be closed...");
                Thread.Sleep(2000);
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            return isValidDate;
        }

        public int HandleTradeQuantityInput(string tradesQty)
        {
            int quantity;
            try
            {
                quantity = int.Parse(tradesQty);
            }
            catch (FormatException ex)
            {
                throw new Exception($"Your number of trades is not in a correct format: ", ex);
            }
            return quantity;
        }

        public TradeInputDto HandleTradeDataInput(string inputDateReference, int inputTradesQty, string[] inputTradeData)
        {
            TradeInputDto tradeInputDtoObject = new TradeInputDto();
            try
            {
                tradeInputDtoObject.ReferenceDate = Convert.ToDateTime(inputDateReference);
                for (int i = 0; i < inputTradesQty; i++)
                {
                    var isValidInput = InputValidation.ValidateInput(inputTradeData[i]);
                    if (!isValidInput)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"This is a not valid input **{inputTradeData[i]}** and won't be considered");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        tradeInputDtoObject.TradeInputItems.Add(
                        new Trade(
                            Convert.ToDouble(inputTradeData[i].Split(" ")[0]),
                            inputTradeData[i].Split(" ")[1],
                            Convert.ToDateTime(inputTradeData[i].Split(" ")[2])
                            ));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace + ex.Message);
            }
            return tradeInputDtoObject;
        }

        public string GetCategory(ITrade inputTradeData, CategoryContext categoryContext, DateTime referenceDate)
        {
            var paymentDiffDays = referenceDate.NextPaymentDays(inputTradeData.NextPaymentDate);

            // Get EXPIRED Category
            if (paymentDiffDays > 30)
            {
                categoryContext.DefineCategory(new ExpiredCategory());
                return categoryContext.GetCategory(inputTradeData);
            }
            if (inputTradeData.ClientSector == "Private")
            {
                categoryContext.DefineCategory(new PrivateSectorCategory());
            }
            if (inputTradeData.ClientSector == "Public")
            {
                categoryContext.DefineCategory(new PublicSectorCategory());
            }
            return categoryContext.GetCategory(inputTradeData);
        }
    }
}
