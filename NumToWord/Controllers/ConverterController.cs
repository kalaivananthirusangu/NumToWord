using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : ControllerBase
    {
        // Dictionary that maps numbers to words
        private static readonly Dictionary<int, string> numberWords = new Dictionary<int, string>()
        {
            { 0, "zero" },
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" },
            { 5, "five" },
            { 6, "six" },
            { 7, "seven" },
            { 8, "eight" },
            { 9, "nine" },
            { 10, "ten" },
            { 11, "eleven" },
            { 12, "twelve" },
            { 13, "thirteen" },
            { 14, "fourteen" },
            { 15, "fifteen" },
            { 16, "sixteen" },
            { 17, "seventeen" },
            { 18, "eighteen" },
            { 19, "nineteen" },
            { 20, "twenty" },
            { 30, "thirty" },
            { 40, "forty" },
            { 50, "fifty" },
            { 60, "sixty" },
            { 70, "seventy" },
            { 80, "eighty" },
            { 90, "ninety" },
            { 100, "hundred" },
            { 1000, "thousand" },
            { 1000000, "million" },
        };

        // Method to convert a number to words
        private static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";
            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if (number >= 1000000)
            {
                int millions = number / 1000000;
                words += NumberToWords(millions) + " million ";
                number %= 1000000;
            }
            if (number >= 1000)
            {
                int thousands = number / 1000;
                words += NumberToWords(thousands) + " thousand ";
                number %= 1000;
            }
            if (number >= 100)
            {
                int hundreds = number / 100;
                words += NumberToWords(hundreds) + " hundred ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                {
                    words += "and ";
                }

                if (number < 20)
                {
                    words += numberWords[number];
                }
                else
                {
                    int tens = number / 10 * 10;
                    int units = number % 10;
                    words += numberWords[tens];
                    if (units > 0)
                    {
                        words += "-" + numberWords[units];
                    }
                }
            }
            return words;
        }

        private static string DecimalToWords(decimal number)
        {
            // Split the number into integer and fractional parts
            int integerPart = (int)number;
            int fractionalPart = (int)((number - integerPart) * 100);

            string integerWords = NumberToWords(integerPart);
            //Check if there is no fraction part then no need to display cents
            if (number == integerPart)
            {
                return $"{integerWords} {(integerWords == "one" ? "dollar" : "dollars")}";
            }
            else
            {
                string fractionalWords = NumberToWords(fractionalPart);
                return $"{integerWords} {(integerWords == "one" ? "dollar" : "dollars")} and {fractionalWords} {(fractionalWords == "one" ? "cent" : "cents")}";
            }
        }

        // GET method
        [HttpGet]
        public string Get(decimal number)
        {
            return DecimalToWords(number);
        }
    }
}
