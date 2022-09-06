using System.Collections.Generic;
using TradeCategory.Utils;
using Xunit;

namespace TradeCategory.UnitTest
{
    public class UnitTestCategory
    {
        [Fact]
        public void Should_Return_Expired()
        {
            var handler = new ConsoleHandler();
            CategoryContext categoryContext = new CategoryContext();

            //trade data input
            var InputDate = "12/11/2020";
            var trades = 1;
            string[] tradeData = new string[] { "400000 Public 07/01/2020" };

            handler.HandleTradeReferenceDateInput(InputDate);
            int tradesQuantity = handler.HandleTradeQuantityInput(trades.ToString());
            var inputTradeDataResult = handler.HandleTradeDataInput(InputDate, tradesQuantity, tradeData);
            var result = new List<string>();
            foreach (var trade in inputTradeDataResult.TradeInputItems)
            {
                result.Add(handler.GetCategory(trade, categoryContext, inputTradeDataResult.ReferenceDate));
            }
            Assert.Equal("EXPIRED", result[0]);
        }

        [Fact]
        public void Should_Return_High_Risk()
        {
            var handler = new ConsoleHandler();
            CategoryContext categoryContext = new CategoryContext();

            //trade data input
            var InputDate = "12/11/2020";
            var trades = 1;
            string[] tradeData = new string[] { "2000000 Private 12/29/2025" };

            handler.HandleTradeReferenceDateInput(InputDate);
            int tradesQuantity = handler.HandleTradeQuantityInput(trades.ToString());
            var inputTradeDataResult = handler.HandleTradeDataInput(InputDate, tradesQuantity, tradeData);
            var result = new List<string>();
            foreach (var trade in inputTradeDataResult.TradeInputItems)
            {
                result.Add(handler.GetCategory(trade, categoryContext, inputTradeDataResult.ReferenceDate));
            }
            Assert.Equal("HIGHRISK", result[0]);
        }

        [Fact]
        public void Should_Return_Medium_Risk()
        {
            var handler = new ConsoleHandler();
            CategoryContext categoryContext = new CategoryContext();

            //trade data input
            var InputDate = "12/11/2020";
            var trades = 1;
            string[] tradeData = new string[] { "5000000 Public 01/02/2024" };

            handler.HandleTradeReferenceDateInput(InputDate);
            int tradesQuantity = handler.HandleTradeQuantityInput(trades.ToString());
            var inputTradeDataResult = handler.HandleTradeDataInput(InputDate, tradesQuantity, tradeData);
            var result = new List<string>();
            foreach (var trade in inputTradeDataResult.TradeInputItems)
            {
                result.Add(handler.GetCategory(trade, categoryContext, inputTradeDataResult.ReferenceDate));
            }
            Assert.Equal("MEDIUMRISK", result[0]);
        }

        [Fact]
        public void Should_Return_Not_Defined()
        {
            var handler = new ConsoleHandler();
            CategoryContext categoryContext = new CategoryContext();

            //trade data input
            var InputDate = "12/11/2020";
            var trades = 1;
            string[] tradeData = new string[] { "40000 Public 07/01/2022" };

            handler.HandleTradeReferenceDateInput(InputDate);
            int tradesQuantity = handler.HandleTradeQuantityInput(trades.ToString());
            var inputTradeDataResult = handler.HandleTradeDataInput(InputDate, tradesQuantity, tradeData);
            var result = new List<string>();
            foreach (var trade in inputTradeDataResult.TradeInputItems)
            {
                result.Add(handler.GetCategory(trade, categoryContext, inputTradeDataResult.ReferenceDate));
            }
            Assert.Equal("Not Defined", result[0]);
        }
 
        [Fact]
        public void Should_Return_Matched_List()
        {
            var handler = new ConsoleHandler();
            CategoryContext categoryContext = new CategoryContext();

            //trade data input
            var InputDate = "12/11/2020";
            var trades = 4;
            string[] tradeData = new string[]
            {
                "2000000 Private 12/29/2025",
                "400000 Public 07/01/2020",
                "5000000 Public 01/02/2024",
                "3000000 Public 10/26/2023"
            };

            handler.HandleTradeReferenceDateInput(InputDate);
            int tradesQuantity = handler.HandleTradeQuantityInput(trades.ToString());
            var inputTradeDataResult = handler.HandleTradeDataInput(InputDate, tradesQuantity, tradeData);
            var result = new List<string>();
            foreach (var trade in inputTradeDataResult.TradeInputItems)
            {
                result.Add(handler.GetCategory(trade, categoryContext, inputTradeDataResult.ReferenceDate));
            }
            Assert.Equal("HIGHRISK", result[0]);
            Assert.Equal("EXPIRED", result[1]);
            Assert.Equal("MEDIUMRISK", result[2]);
            Assert.Equal("MEDIUMRISK", result[3]);
        }

        [Fact]
        public void Should_Return_False_Invalid_Trade_Input()
        {
            //trade data input
            string[] tradeData = new string[] { "40000Public 07/01/2022" };
            var isValidInput = InputValidation.ValidateInput(tradeData[0]);

            Assert.False(isValidInput);
        }

        [Fact]
        public void Should_Return_False_Invalid_Reference_Date_Input()
        {
            //trade data input
            var InputDate = "12/11/20201";
            var isValidInput = InputValidation.ValidateDate(InputDate);

            Assert.False(isValidInput);
        }
    }
}

