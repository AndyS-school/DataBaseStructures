using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class StringHash
    {
        //constructor
        private string[]? _hash;
        private int _empty = -1;
        private int _deleted = -2;
        private int _arraySize;
        private int _count;

        public StringHash() { _hash = new string[11]; }

        public StringHash(int size)
        {
            if (size < 11)
                _hash = new string[11];
            else
                _hash = new string[size];
        }

        //base
        public int hashCode(string value)
        {
            return value % _arraySize;
        }
        public void addItem(string value)
        {

        }

        public bool findItem(string value)
        {
            return false;
        }

        public void removeItem(string value)
        {

        }

        public string displayTable()
        {
            return "";
        }
        //adv

        //think
    }
}