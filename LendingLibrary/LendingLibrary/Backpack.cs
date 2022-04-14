using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LendingLibrary
{
    public class Backpack<T> : IBag<T>
    {
       private List<T> backPack = new List<T>();

        public void Pack(T item)
        {
            backPack.Add(item);
        }

        public T Unpack(int index)
        {
            try
            {
                T item = backPack[index];
                backPack.RemoveAt(index);
                return item;
            }
            catch(Exception)
            {
                return default (T);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in backPack)
            {
                yield return item; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
    public interface IBag<T> : IEnumerable<T>
    {
        /// <summary>
        /// Add an item to the bag. <c>null</c> items are ignored.
        /// </summary>
        void Pack(T item);

        /// <summary>
        /// Remove the item from the bag at the given index.
        /// </summary>
        /// <returns>The item that was removed.</returns>
        T Unpack(int index);
    }
}

