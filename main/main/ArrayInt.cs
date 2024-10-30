using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;

// Created by Katie Sullivan 4/7/23
// with modifications by Tina Majchrzak
// Data Structures

namespace ArrayIntDriver;

class ArrayInt
{
    #region Fields
    private int?[] _intArray; // Nullable int so that an empty value is not 0
    private int _lastIndex; // Holds the largest index in the array
    private int _size; // Holds the size of the array
    #endregion


    #region Constructors
    public ArrayInt()
    {
        _intArray = new int?[10];
        _lastIndex = -1;
        _size = 10;
    }

    public ArrayInt(int size)
    {
        _intArray = new int?[size];
        _lastIndex = -1;
        _size = size;
    }
    #endregion


    #region Basic Lab Specification
    public int GetSize()
    {
        // Return the size of the array
        return _size;
    }

    public void Resize(int size)
    {
        if (size <= _size)
        {
            Console.WriteLine("Attempted Resize value is less than or equal to current size.");
        }
        else
        {
            int?[] temp = new int?[size];
            Array.Copy(_intArray, temp, _intArray.Length);
            _intArray = temp;
            _size = size;
            Console.WriteLine("new size : " + _size);
        }
    }

    public void Append(int value)
    {
        if (_lastIndex >= _size)
        {
            Resize(_size * 2);
            //Console.WriteLine("!!!!!!!!!!RESIZING DUMBFUCK!!!!!!!!");
        }
        int targetIndex = _lastIndex + 1;
        _intArray[targetIndex] = value;
        _lastIndex++;
    }

    public int GetLast()
    {
        if (_lastIndex == -1)
            throw new IndexOutOfRangeException("Array is empty!");
        else
            return _lastIndex;
    }

    public void DeleteLast()
    {
        if (_lastIndex == -1)
            throw new IndexOutOfRangeException("Array is empty!");
        else
            _lastIndex--;
    }

    public string ListElements()
    {
        if (_lastIndex == -1)
            return "Empty Array.";
        else
            return string.Join(", ", _intArray);
    }

    public void InsertAt(int index, int value)
    {
        if (index < 0 || index > _lastIndex || index > _size)
            throw new IndexOutOfRangeException("Attempt to write at invalid location.");
        else
        {
            if (_lastIndex + 1 > _size)
                Resize(_size * 2);
            for (int i = 0; i < _size; i++)
            {
                int? insertValue = value;
                if (_intArray[i] >= index)
                {
                    int? storedValue = _intArray[i];
                    _intArray[i] = insertValue;
                    insertValue = storedValue;
                }
            }
        }
    }

    public int RemoveAt(int index)
    {
        return 7;
    }

    public bool Find(int value)
    {
        bool present = false;

        for (int i = 0; i <= _intArray.Length -1; i++)
            if(value == _intArray[i])
                present = true;
        return present;
    }

    public bool FindRemove(int value) //needs work
    {
        bool present = false;
        for (int i = 0; i > _size; i++)
        {
            if (_intArray[i] == value)
            {
                present = true;
                _intArray[i] = null;
            }
        }
        return present;
    }

    public int FindLargest()
    {
        if (_lastIndex == -1)
            throw new IndexOutOfRangeException("Attempt to read from empty array.");
        int? bigNum = _intArray[0];
        for (int i = 0; i < _size; i++)
            if(bigNum < _intArray[i])
                bigNum = _intArray[i];
        return (int)bigNum;
    }

    public void RemoveLargest()
    {
        if (_lastIndex == -1)
            throw new IndexOutOfRangeException("Attempt to remove from empty array.");
        int largest = FindLargest();
        for (int i = 0; i < _size; i++)
            if (_intArray[i] == largest)
                _intArray[i] = null;
    }
    #endregion


    #region Advanced Lab Specification
    public int GetAt(int index)
    {
        if (index < 0 || index >= _size)
            throw new IndexOutOfRangeException("Attempt to read at invalid location.");
        else
        {
            if (_intArray[index] == null) //code wont run without this
                return -999;
            else
            {
                int getTarget = (int)_intArray[index];
                return getTarget;
            }
        }
    }

    public void SetAt(int index, int value)
    {
        if (index < 0 || index >= _size)
            throw new IndexOutOfRangeException("Attempt to store at invalid location.");
        _intArray[index] = value;
        if (index > _lastIndex)
            _lastIndex = index;
    }
    #endregion


    #region Helper Methods
    private int FindReturnIndex(int value)
    {
        return 7;
    }
    #endregion


    #region Thinking Problem
    public void SolveThink(int[] values, int numValues)
    {
    }
    #endregion
}
