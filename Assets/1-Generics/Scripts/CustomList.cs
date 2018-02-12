using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generics
{
    public class CustomList<T>
    {
        private int amount = 0;
        private T[] data;

        public CustomList() { amount = 0; }
        public void Add(T item)
        {
            // Create a new array of amount + 1
            T[] cache = new T[amount + 1];
            // Create if the list has been initialised
            if (data != null)
            {
                // Copy all existing items to new array
                for (int i = 0; i < data.Length; i++)
                {
                    // Copy each element to cache
                    cache[i] = data[i];
                }
            }
            // Set the end element to new item
            cache[amount] = item;
            // Point to new array
            data = cache;
            // Increment amount
            amount++;
        }
    }
}