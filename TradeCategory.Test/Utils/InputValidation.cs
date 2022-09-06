using System;

namespace TradeCategory.Utils
{
    public class InputValidation
    {
        public static bool ValidateInput(string input)
        {
            var splittedInput = input.Split(" ");
            if (splittedInput.Length != 3) return false;
            if (!ValidateInputTradeAmount(splittedInput[0])) return false;
            if(!Enum.IsDefined(typeof(Sector), splittedInput[1])) return false;
            if (!ValidateDate(splittedInput[2])) return false;
            return true;
        }

        public static bool ValidateInputTradeAmount(string input)
        {
            var tradeAmount = double.TryParse(input, out _);
            return tradeAmount;
        }

        public static bool ValidateDate(string dateTime)
        {
            var validDate = DateTime.TryParseExact(
                dateTime, 
                "MM/dd/yyyy", 
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
            return validDate;
        }
    }
}
