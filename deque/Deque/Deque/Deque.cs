using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace DequeDriver;

class Deque
{
    //values 
    private int?[] queue; // Nullable int so that an empty value is not 0
    private int head; // Holds the largest index in the array
    private int tail; // Holds the largest index in the array
    private int arraySize; // Holds the size of the array
    private int count; //how many items in array
    //constructor
    public Deque()
    {
        queue = new int?[20];
        head = -1;
        tail = 0;
        arraySize = 20;
        count = 0;
    }
    public Deque(int size)
    {
        if (size < 1)
        {
            queue = new int?[20];
            head = -1;
            tail = 0;
            arraySize = 20;
            count = 0;
        }
        else
        {
            queue = new int?[size];
            head = -1;
            tail = 0;
            arraySize = size;
            count = 0;
        }
    }

    public void addTail(int value)
    {
        if (count >= arraySize)
            resize();

        count++;

        queue[tail] = value;
        tail = tail++ % arraySize;
    }

    public int removeHead()
    {
        if (count == 0)
            throw new IndexOutOfRangeException("Array is empty in removeHead");

        count--;

        head = head++ % arraySize;
        return head;
    }

    public string dumpArray()
    {
        string result = string.Join(", ", queue);
        return result;
    }

    private void resize()
    {
        int?[] newQueue = new int?[arraySize*2];
        for (int i = 0; i < count; i++)
        {
            int copyValue = removeHead();
            newQueue[i] = copyValue;
        }
        queue = newQueue;

        head = -1;
        tail = count;
    }

    public string listQueue()  //needs work
    {
        int?[] newQueue = new int?[arraySize];
        for (int i = 0; i < count; i++)
        {
            int copyValue = removeHead();
            newQueue[i] = copyValue;
        }
        string result = string.Join(", ", queue);
        
        return result;
    }

    public bool isEmpty()
    {
        if (count == 0)
            return true;
        else
            return false;
    }

    //advanced
    public void addHead(int value)
    {
        if (count >= arraySize)
            resize();

        count++;

        queue[head] = value;
        head = head++ % arraySize;
    }

    public int removeTail()
    {
        if (count == 0)
            throw new IndexOutOfRangeException("Array is empty in removeHead");

        count--;

        tail = tail-- % arraySize;
        return tail;
    }
    //think
    public void solveThink(int[] numbers, int length)
    {
     
    }
}