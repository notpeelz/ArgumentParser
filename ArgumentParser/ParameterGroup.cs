using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArgumentParser
{
    /*public class ParameterGroup : IGrouping<Key, ParameterPair>, IPairable
    {
        private readonly IEnumerable<ParameterPair> elements;

        public ParameterGroup(IEnumerable<ParameterPair> elements, Key key)
        {
            this.Key = key;
        }

        public ParameterGroup(IEnumerable<ParameterPair> elements, String prefix, String tag)
        {
            this.elements = elements;
            this.Key = new Key(prefix, tag);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<ParameterPair> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        /// <summary>
        /// Gets the key of the <see cref="T:System.Linq.IGrouping`2"/>.
        /// </summary>
        /// <returns>
        /// The key of the <see cref="T:System.Linq.IGrouping`2"/>.
        /// </returns>
        public Key Key { get; private set; }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public Int32 CompareTo(IPairable other)
        {
            return this.Key.CompareTo(other.Key);
        }

        public Int32 CompareTo(IPairable other, StringComparison comparisonType)
        {
            return this.Key.CompareTo(other.Key, comparisonType);
        }
    }*/
}
