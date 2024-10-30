/*
 * Directly transpiled from Jim Bailey's C++ driver for this assignment 
 */

using System;

namespace ArrayIntDriver;

class Driver
{
    static void Main(string[] args)
    {
        // Uncomment test functions to run

        //TestConstructor(); //check
        //TestAppend();
        //TestMakeRoom();
        //TestInsertRemove();
        //TestFind();
        //TestFindLargest();
        //TestSetGet();
        //TestMixed();
        //TestThink();
    }

    static void TestConstructor()
    {
        const int DEFAULT = 10;
        const int OVERLOAD = 15;
        Console.Write("Testing default and overloaded constructors.\n");

        ArrayInt defaultSize = new ArrayInt();
        ArrayInt defineSize = new ArrayInt(OVERLOAD);

        Console.Write("Default size should be " + DEFAULT + " and is " + defaultSize.GetSize() + "\n");
        Console.Write("Overload size should be " + OVERLOAD + " and is " + defineSize.GetSize() + "\n");
        Console.Write("\n\n");
    }

    static void TestAppend()
    {
        Console.Write("Testing append with mix of appends and sets\n\n");
        
        ArrayInt appends = new ArrayInt();
        const int NUM_APPENDS = 5;
        int[] primes = new int[NUM_APPENDS] { 2, 3, 5, 7, 11 };

        for (int i = 0; i < NUM_APPENDS; i++)
        {
            appends.Append(primes[i]);
        }

        Console.Write("The array should be: 11, 7, 5, 3, 2\n");
        Console.Write("The array really is: ");
        try
        {
            for (int i = 0; i < NUM_APPENDS - 1; i++)
            {
                Console.Write(appends.GetLast() + ", ");
                appends.DeleteLast();
            }
            Console.Write(appends.GetLast() + "\n");
            appends.DeleteLast();
        }
        catch (Exception)
        {
            Console.Write("Problem with appending and deleting\n");
        }

        Console.Write("Trying GetLast on empty array, should throw exception\n");
        try
        {
            Console.Write(appends.GetLast() + "\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }

        Console.Write("trying to delete from empty array, should throw exception\n");
        try
        {
            appends.DeleteLast();
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }

        Console.Write("\n\n");
    }

    static void TestMakeRoom()
    {
        const int START = 7;
        const int UPDATE = 12;
        Console.Write("Testing SetSize and auto expansion on appends\n");
        Console.Write("Also tests ListElements\n\n");

        ArrayInt room = new ArrayInt(START);
        Console.Write("Starting size should be " + START + " and is " + room.GetSize() + "\n");
        room.Resize(UPDATE);
        Console.Write("After SetSize, size should be " + UPDATE + " and is " + room.GetSize() + "\n");

        Console.Write("\nNow going to fill array and see if expands\n");
        for (int i = 0; i < UPDATE; i++)
        {
            room.Append(2 * i + 1);
        }
        Console.Write("Filled with 12 values, no problem\n");
        Console.Write("Size should still be " + UPDATE + " and is " + room.GetSize() + "\n");

        Console.Write("\nAdding one more\n");
        room.Append(25);
        Console.Write("Size should now be " + 2 * UPDATE + " and is " + room.GetSize() + "\n");

        Console.Write("\nShould show: 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 \n");
        Console.Write("Array returns: " + room.ListElements() + " ");

        Console.Write("\n\n");
    }

    static void TestInsertRemove()
    {
        const int BEGIN = 10;
        Console.Write("Testing insert and remove \n\n");

        ArrayInt insertRemove = new ArrayInt();
        for (int i = 0; i < BEGIN; i++)
            insertRemove.Append(2 * i);
        Console.Write("Array starting with: " + insertRemove.ListElements());

        Console.Write("\nSize should be " + BEGIN + " and is " + insertRemove.GetSize() + "\n");

        Console.Write("\nNow inserting the numbers 5, 9, and 13\n");
        insertRemove.InsertAt(7, 13);
        insertRemove.InsertAt(5, 9);
        insertRemove.InsertAt(3, 5);
        Console.Write("Size should be " + 2 * BEGIN + " and is " + insertRemove.GetSize() + "\n");
        Console.Write("The values should be:  0 2 4 5 6 8 9 10 12 13 14 16 18\n");
        Console.Write("The values really are: ");
        Console.Write(insertRemove.ListElements());

        Console.Write("\n\nNow removing the values: ");
        Console.Write(insertRemove.RemoveAt(8) + " "
                    + insertRemove.RemoveAt(5) + " "
                    + insertRemove.RemoveAt(0) + "\n");
        Console.Write("The array should be: 2 4 5 6 9 10 13 14 16 18 \n");
        Console.Write("The values really are: ");
        Console.Write(insertRemove.ListElements());

        Console.Write("\n\nNow testing illegal inserts and removes \n");
        Console.Write("\nTesting invalid InsertAt at index larger than array size\n");
        try
        {
            insertRemove.InsertAt(BEGIN * 3, -1);
            Console.Write("Should have thrown an exception inserting at " + BEGIN * 3 + "\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }
        Console.Write("\nTesting invalid InsertAt at negative index\n");
        try
        {
            insertRemove.InsertAt(-1, 500);
            Console.Write("Should have thrown an exception inserting at -1\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }

        Console.Write("\nEmptying the array, expecting: 18 16 14 13 10 9 6 5 4 2 ");
        Console.Write("\nActually removed the values  : ");
        for (int i = 0; i < BEGIN; i++)
        {
            Console.Write(insertRemove.GetLast() + " ");
            insertRemove.DeleteLast();
        }
        Console.WriteLine();

        Console.Write("\nTesting RemoveAt on empty array\n");
        try
        {
            insertRemove.RemoveAt(0);
            Console.Write("Should have thrown an exception\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }
        Console.Write("\n\n");

    }

    static void TestFind()
    {
        const int FIND_COUNT = 10;
        Console.Write("Testing find and findRemove \n\n");

        ArrayInt findRemove = new ArrayInt();
        int[] primes = new int[FIND_COUNT] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        for (int i = 0; i < FIND_COUNT; i++)
        {
            findRemove.Append(primes[i]);
        }

        Console.Write("Testing find on 4 and 7.  4 should not be found, 7 should be found.\n");
        Console.Write("Array contains " + findRemove.ListElements() + "\n");

        Console.Write(4 + (findRemove.Find(4) ? " was " : " was not ") + "found\n");
        Console.Write(7 + (findRemove.Find(7) ? " was " : " was not ") + "found\n");

        Console.Write("Testing findRemove on 4 and 7.  4 should not be removed, 7 should be removed.\n");
        Console.Write(4 + (findRemove.FindRemove(4) ? " was " : " was not ") + "removed\n");
        Console.Write(7 + (findRemove.FindRemove(7) ? " was " : " was not ") + "removed\n");

        Console.Write("After the remove\n");
        Console.Write(" expected: 2, 3, 5, 11, 13, 17, 19, 23, 29\n");
        Console.Write(" actually: " + findRemove.ListElements() + "\n");

        Console.Write("Using findRemove on final element, 29\n");
        Console.Write(29 + (findRemove.FindRemove(29) ? " was " : " was not ") + "removed\n");

        Console.Write("Using find to look for 29 after removal.  Should not find\n");
        Console.Write(29 + (findRemove.Find(29) ? " was " : " was not ") + "found\n");

        int last = findRemove.GetLast();
        Console.Write("Testing find after deleteLast.  Should not find.\n");
        findRemove.DeleteLast();
        Console.Write(last + (findRemove.Find(last) ? " was " : " was not ") + "found\n");

        Console.Write("Ending array\n");
        Console.Write(" expected: 2, 3, 5, 11, 13, 17, 19\n");
        Console.Write(" actually: " + findRemove.ListElements() + "\n");

        Console.Write("\n\n");
    }

    static void TestFindLargest()
    {
        const int LARGE_COUNT = 8;
        Console.Write("Testing findLargest and removeLargest \n\n");

        ArrayInt findLarge = new ArrayInt();
        int[] large = new int[LARGE_COUNT] { 3, 11, 19, 7, 5, 2, 13, 23 };
        for (int i = 0; i < LARGE_COUNT; i++)
        {
            findLarge.Append(large[i]);
        }

        Console.Write("Array contains " + findLarge.ListElements() + "\n");

        Console.Write("Largest should be 23 and is " + findLarge.FindLargest() + "\n");

        findLarge.RemoveLargest();
        findLarge.RemoveLargest();
        Console.Write("After removing two Largest \n");
        Console.Write("should be 3, 11, 7, 5, 2, 13\n");
        Console.Write("actually  " + findLarge.ListElements() + "\n");

        Console.Write("Emptying array\n");
        for (int i = 0; i < LARGE_COUNT - 2; i++)
        {
            findLarge.DeleteLast();
        }

        Console.Write("\nNow testing findLargest on empty array\n");
        try
        {
            findLarge.FindLargest();
            Console.Write("Should have thrown an exception\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }

        Console.Write("\nNow testing removeLargest on empty array\n");
        try
        {
            findLarge.RemoveLargest();
            Console.Write("Should have thrown an exception\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }

        Console.Write("\n\n");
    }

    static void TestSetGet()
    {
        const int SET_COUNT = 12;
        Console.Write("Testing setting values and reading them back\n\n");

        ArrayInt SetGet = new ArrayInt(SET_COUNT);
        Console.Write("Testing invalid SetAt index of -1\n");
        try
        {
            SetGet.SetAt(-1, 12);
            Console.Write("Should have thrown an exception\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }

        Console.Write("\nNow loading some values and displaying them\n");
        SetGet.SetAt(0, 3);
        SetGet.SetAt(2, 7);
        SetGet.SetAt(1, 5);
        SetGet.SetAt(4, 13);
        SetGet.SetAt(3, 11);
        SetGet.SetAt(6, 17);
        int maxSet = 6;

        Console.Write("The values should be:  3, 5, 7, 11, 13, unknown, 17\n");
        Console.Write("The values really are: ");
        for (int i = 0; i < 6; i++)
            Console.Write(SetGet.GetAt(i) + ", ");
        Console.Write(SetGet.GetAt(6) + "\n");

        Console.Write("\nTesting invalid GetAt index that is larger than array size\n");
        try
        {
            SetGet.GetAt(15);
            Console.Write("Should have thrown an exception\n");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.Write("Caught out of range with message: " + e.Message + "\n");
        }
        catch (Exception)
        {
            Console.Write("Caught something weird \n");
        }
        Console.Write("\n\n");

        Console.Write("\nNow testing mixed sets and appends\n");
        SetGet.Append(27);
        SetGet.SetAt(maxSet + 3, -1);
        SetGet.Append(42);
        Console.Write("After appends and sets \n");
        Console.Write(" should be 3, 5, 7, 11, 13, unknown, 17, 27, unknown, -1, 42\n");
        Console.Write(" actually  " + SetGet.ListElements() + "\n");
    }

    static void TestMixed()
    {
        Console.Write("Testing append with mix of appends, inserts, sets, and removes \n");

        ArrayInt mixed = new ArrayInt();

        mixed.Append(2);
        mixed.Append(4);
        mixed.Append(6);
        mixed.SetAt(5, 16);
        mixed.Append(32);
        mixed.DeleteLast();
        mixed.InsertAt(4, 19);
        mixed.InsertAt(4, 1900);
        mixed.SetAt(1, 7);
        mixed.Append(64);
        mixed.Append(256);
        mixed.RemoveAt(1);
        mixed.InsertAt(1, 4);
        mixed.RemoveLargest();
        mixed.InsertAt(5, 88);

        Console.Write("\nThe array should be: 2 4 6 unknown 19 88 unknown 16 64 256\n");
        Console.Write("The array really is: " + mixed.ListElements());

        Console.Write("\n\n");
    }

    static void TestThink()
    {
        Console.WriteLine("Now testing the thinking problem");

        ArrayInt think = new ArrayInt();
        int[] thinkValues = { 1, 3, 22, 18, 95, -1, 7, 0, 99, 4 };

        Console.WriteLine("Values in order should be 99, 95, 22, 18, 7, 4, 3, 1, 0, -1");

        think.SolveThink(thinkValues, thinkValues.Length);
        Console.WriteLine($"Values in order are:      {think.ListElements()}");
        Console.WriteLine("\nDone with thinking test\n");


    }

}
