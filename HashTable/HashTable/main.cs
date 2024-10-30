using HashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Driver
    {
        // basic lab
        const int BASE_SIZE = 5;
        static string[] baseWords = new string[BASE_SIZE] { "maple", "spruce", "oak", "cedar", "cherry" };

        // advanced lab
        const int ADV_SIZE = 10;
        static string[] advWords = new string[ADV_SIZE] { "dog", "cat", "ape", "cow", "frog", "fish", "goat", "bear", "deer", "elk" };

        static void Main(string[] args)
        {
            // uncomment functions to run tests

            // Basic tests
            testBaseFind();
            // testBaseRemove();
            // testBaseDisplay();
            // testBaseGrow();

            // Advanced tests
            // testAdvFind();
            // testAdvRemove();
            // testAdvDisplay();

            // test thinking problem
            // testThink();
        }

        static void testBaseFind()
        {
            Console.Write("Testing base AddItem and FindItem\n\n");
            StringHash baseFind = new StringHash();

            for (int i = 0; i < BASE_SIZE; i++)
            {
                baseFind.AddItem(baseWords[i]);
            }
            Console.Write("Should find maple and not apple\n");
            Console.Write("  maple" + (baseFind.FindItem("maple") ? " " : " not ") + "found\n");
            Console.Write("  apple" + (baseFind.FindItem("apple") ? " " : " not ") + "found\n");


            Console.Write("\nDone testing base AddItem and FindItem\n\n");
        }

        static void testBaseRemove()
        {
            Console.Write("Testing base AddItem, FindItem, and RemoveItem\n\n");
            StringHash baseRemove = new StringHash();

            for (int i = 0; i < BASE_SIZE; i++)
            {
                baseRemove.AddItem(baseWords[i]);
            }
            Console.Write("Should find maple and then not find maple\n");
            Console.Write("  maple" + (baseRemove.FindItem("maple") ? " " : " not ") + "found\n");
            baseRemove.RemoveItem("maple");
            Console.Write("  maple" + (baseRemove.FindItem("maple") ? " " : " not ") + "found\n");
            Console.Write("Should find spruce\n");
            Console.Write("  spruce" + (baseRemove.FindItem("spruce") ? " " : " not ") + "found\n");

            Console.Write("\nDone testing base AddItem, FindItem, and RemoveItem\n\n");
        }

        static void testBaseDisplay()
        {
            Console.Write("Testing base AddItem, FindItem, RemoveItem, and display\n\n");
            StringHash baseList = new StringHash();

            for (int i = 0; i < BASE_SIZE; i++)
            {
                baseList.AddItem(baseWords[i]);
            }
            baseList.RemoveItem("maple");
            Console.Write("Should be \ncedar \ncherry \n_deleted_ \nspruce \n_empty_ \n_empty_ \n_empty_   \n_empty_ \n_empty_ \n_empty_ \noak");

            Console.Write("\n\nActually is\n");
            Console.Write(baseList.DisplayTable());

            Console.Write("\nDone testing base AddItem, FindItem, RemoveItem, and display\n\n");
        }

        static void testBaseGrow()
        {
            Console.Write("Testing base growing StringHash\n\n");
            const int BASE_EXTRA = 3;
            string[] baseExtraWords = new string[BASE_EXTRA] { "bear", "pony", "cow" };

            StringHash baseGrow = new StringHash();

            for (int i = 0; i < BASE_SIZE; i++)
            {
                baseGrow.AddItem(baseWords[i]);
            }

            for (int i = 0; i < BASE_EXTRA; i++)
            {
                baseGrow.AddItem(baseExtraWords[i]);
            }
            Console.Write("After growing the list should be \n");
            Console.Write("_empty_ \nbear \noak \n_empty_ "
              + "\nspruce \n_empty_ \n_empty_ \nmaple \ncow "
              + "\n_empty_ \n_empty_ \npony \n_empty_ "
              + "\n_empty_ \n_empty_ \ncherry \n_empty_ "
              + "\ncedar \n_empty_ \n_empty_ \n_empty_ "
              + "\n_empty_ \n_empty_\n");

            Console.Write("\nAnd actually is \n");
            Console.Write(baseGrow.DisplayTable());

            Console.Write("\nNow testing find and remove after growing\n");
            Console.Write("Should find maple and then not find maple\n");
            Console.Write(" maple" + (baseGrow.FindItem("maple") ? " " : " not ") + "found\n");
            baseGrow.RemoveItem("maple");
            Console.Write(" maple" + (baseGrow.FindItem("maple") ? " " : " not ") + "found\n");
            Console.Write("Should find spruce\n");
            Console.Write(" spruce" + (baseGrow.FindItem("spruce") ? " " : " not ") + "found\n");

            Console.Write("\nDone testing base growing StringHash\n\n");
        }

        static void testAdvFind()
        {
            Console.Write("Testing advanced AddItem and FindItem\n\n");
            ChainHash advFind = new ChainHash();

            for (int i = 0; i < ADV_SIZE; i++)
            {
                advFind.AddItem(advWords[i]);
            }
            Console.Write("Should find goat and not horse\n");
            Console.Write("  goat" + (advFind.FindItem("goat") ? " " : " not ") + "found\n");
            Console.Write("  horse" + (advFind.FindItem("horse") ? " " : " not ") + "found\n");

            Console.Write("\nDone testing advanced AddItem and FindItem\n\n");
        }


        static void testAdvRemove()
        {
            Console.Write("Testing advanced AddItem, FindItem, and RemoveItem\n\n");
            ChainHash advRemove = new ChainHash();

            for (int i = 0; i < ADV_SIZE; i++)
            {
                advRemove.AddItem(advWords[i]);
            }
            Console.Write("Should find goat and then not find goat\n");
            Console.Write("  goat" + (advRemove.FindItem("goat") ? " " : " not ") + "found\n");
            advRemove.RemoveItem("goat");
            Console.Write("  goat" + (advRemove.FindItem("goat") ? " " : " not ") + "found\n");

            Console.Write("\nDone testing advanced AddItem, FindItem, and RemoveItem\n\n");
        }

        static void testAdvDisplay()
        {
            Console.Write("Testing advanced AddItem, FindItem, RemoveItem, and display\n\n");
            ChainHash advList = new ChainHash();

            for (int i = 0; i < ADV_SIZE; i++)
            {
                advList.AddItem(advWords[i]);
            }

            advList.RemoveItem("goat");
            Console.Write("Should be: \n_empty_ \nfrog deer "
              + "\ncow fish \n_empty_ \ndog \nbear "
              + "\ncat ape elk\n");

            Console.Write("\nAnd is \n");
            Console.Write(advList.DisplayTable());

            Console.Write("\nDone testing advanced AddItem, FindItem, RemoveItem, and display\n\n");
        }

        static void testThink()
        {
            Console.Write("Testing thinking problem (growing ChainHash)\n\n");
            const int ADV_EXTRA = 6;
            string[] advExtraWords = new string[ADV_EXTRA] { "apple", "pine", "fir", "oak", "maple", "fig" };

            ChainHash advGrow = new ChainHash();

            for (int i = 0; i < ADV_SIZE; i++)
            {
                advGrow.AddItem(advWords[i]);
            }
            for (int i = 0; i < ADV_EXTRA; i++)
            {
                advGrow.AddItem(advExtraWords[i]);
            }
            Console.Write("\nAfter growing the list "
              + "should have 17 rows and include ");
            Console.Write("\nfrog \n_empty_ \n_empty_ \n_empty_ ");
            Console.Write("\n_empty_ \nfish fir dog pine");
            Console.Write("\n_empty_ \nape \ncow \noak ");
            Console.Write("\n_empty_ \ndeer fig \nelk \nbear \n_empty_ ");
            Console.Write("\napple cat \ngoat maple ");

            Console.Write("\n\nAnd is \n");
            Console.Write(advGrow.DisplayTable());

            Console.Write("\nDone testing thinking problem\n\n");
        }
    }
}
