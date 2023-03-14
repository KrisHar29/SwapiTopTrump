using SWAPI_TOP_TRUMPSUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_TOP_TRUMPSUI
{
    public class MethodsLogic
    {
        public static double CalculateWinHeight(List<PersonModelLinq> itemList, string itemValue)
        {
            // get all heights from list sorted desc
            var createList = (from item in itemList select item.Height).OrderByDescending(h => h).ToList();
            // calculate win% based on number of items v itemValue
            // list.length - [i]/list.length = %
            // find [i] from itemValue
            int index = createList.IndexOf(itemValue);
            double listCount = createList.Count;
            Console.WriteLine(listCount);
            double output = (listCount - index) / listCount * 100;
            return output;
        }

        public static double CalculateWin(List<PersonModelLinq> itemList, string itemValue, string propertyValue)
        {
            // get all heights from list sorted desc
            var createList = (from item in itemList
                              select double.Parse(item.GetType().GetProperty(propertyValue).GetValue(item).ToString()))
                              .OrderByDescending(h => h)
                              .ToList();

            // calculate win% based on number of items v itemValue
            // list.length - [i]/list.length-1= %
            // find [i] from itemValue
            // added if/else because of 0/x to relay no chance as
            // im not currently returning a string possibility
            // of removing the CW when further done with logic/menus

            double itemValueDouble = Convert.ToDouble(itemValue);
            int index = createList.IndexOf(itemValueDouble);
            double listCount = createList.Count;
            if (listCount - 1 == index)
            {
                double output = 0;
                //Console.WriteLine($"You have no chance of winning with {propertyValue} of {itemValue}.");
                return output;
            }
            else
            {
                double output = (listCount - 1) / (listCount - 1) * 100;
                //Console.WriteLine($"You have test2 {output}% of winning with {propertyValue} of {itemValue}.");
                return output;
            }
        }
    }
}
