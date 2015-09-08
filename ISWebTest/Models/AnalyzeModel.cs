using System;
using System.Collections.Generic;
using System.Linq;

namespace ISWebTest.Models
{
    public class AnalyzeModel
    {
        public AnalyzeModel(List<Pizza> pizzaList)
        {
            // Get a list of all available sizes to iterate through.
            var sizes = Enum.GetValues(typeof (Pizza.SizeOptions)).Cast<Pizza.SizeOptions>();

            // Iterate through the sizes, generating statistics objects based off the counts of pizzas.
            // Dump the result to the internal variable.
            PizzaSizeStatistics =
                sizes.Select(size => new PizzaStatistic(size.ToString(), pizzaList.Count(pizza => pizza.Size == size)))
                    .ToList().AsReadOnly();


        }
        
        /// <summary>
        ///  Container class for a count of pizza sizes.
        /// </summary>
        public class PizzaStatistic
        {
            /// <summary>
            /// Creates a new instance of the <see cref="PizzaStatistic"/> class.
            /// </summary>
            /// <param name="name">Name for the statistic</param>
            /// <param name="count">Count of the statistic</param>
            public PizzaStatistic(string name, int count)
            {
                StatisticName = name;
                Count = count;
            }

            /// <summary>
            /// Gets the pizza size of this statistic.
            /// </summary>
            public string StatisticName { get; }

            /// <summary>
            ///  Gets the count of pizzas matching this size.
            /// </summary>
            public int Count { get; }
        }
        
        /// <summary>
        /// Gets a list of size statistics for pizzas.
        /// </summary>
        public IReadOnlyList<PizzaStatistic> PizzaSizeStatistics { get; private set; }
    }
}