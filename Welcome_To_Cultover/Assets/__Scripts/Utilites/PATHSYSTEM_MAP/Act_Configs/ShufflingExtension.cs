using System;
using System.Collections.Generic;
using System.Linq;

namespace Map
{
    /// <summary>
    /// Provides extension methods for shuffling, selecting random elements, and retrieving the last element from a list.
    /// </summary>
    public static class ShufflingExtension
    {
        // A single instance of System.Random to ensure better randomness across method calls.
        private static System.Random rng = new System.Random();

        /// <summary>
        /// Shuffles the elements of a given list in-place using the Fisher-Yates shuffle algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to shuffle.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--; // Decrease the range for the next swap
                int k = rng.Next(n + 1); // Select a random index within the range
                T value = list[k]; // Swap elements
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Returns a random element from the given list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to pick from.</param>
        /// <returns>A randomly selected element from the list.</returns>
        public static T Random<T>(this IList<T> list)
        {
            return list[rng.Next(list.Count)];
        }

        /// <summary>
        /// Returns the last element of the given list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to retrieve the last element from.</param>
        /// <returns>The last element of the list.</returns>
        public static T Last<T>(this IList<T> list)
        {
            return list[list.Count - 1];
        }

        /// <summary>
        /// Returns a specified number of random elements from a list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to select from.</param>
        /// <param name="elementsCount">The number of elements to retrieve.</param>
        /// <returns>A new list containing randomly selected elements.</returns>
        public static List<T> GetRandomElements<T>(this List<T> list, int elementsCount)
        {
            // Randomly orders the list using GUID-based sorting, then takes the required number of elements.
            return list.OrderBy(arg => Guid.NewGuid())
                       .Take(Math.Min(list.Count, elementsCount)) // Ensures it doesn’t exceed list size
                       .ToList();
        }
    }
}
