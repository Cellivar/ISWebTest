using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ISWebTest.Models
{
    [Serializable]
    public class Pizza
    {
        /// <summary>
        /// Enum listing the available size options for pizzas.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SizeOptions
        {
            Slice,
            Medium,
            Large,
            Sheet
        }

        /// <summary>
        /// Enum listing the available toppings for pizzas.
        /// </summary>
        /// <remarks>
        /// This is obviously missing Ham and Pineapple, the superior pizza toppings.
        /// </remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ToppingOptions
        {
            Mushrooms,
            Peppers,
            Peperoni,
            Sausage,
            Onions,
        }

        /// <summary>
        /// Gets or sets the size of the pizza.
        /// </summary>
        public SizeOptions Size { get; set; }

        /// <summary>
        /// Gets or sets a list of toppings on the pizza.
        /// </summary>
        public List<ToppingOptions> Toppings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the pizza is a delivery.
        /// </summary>
        public bool IsDelivery { get; set; }
    }
}