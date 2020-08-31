using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Transactions;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50
            int[] numbers = new int[50];

            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(numbers);

            //Print the first number of the array
            Console.WriteLine(numbers[0]);

            //Print the last number of the array  
            Console.WriteLine(numbers[numbers.Length - 1]);

            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists
            //NumberPrinter();
            NumberPrinter(numbers);

            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */


            Console.WriteLine("All Numbers Reversed:");

            ReverseArray(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("---------REVERSE CUSTOM------------");

            Array.Reverse(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            ThreeKiller(numbers);
            NumberPrinter(numbers);
            

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");

            Array.Sort(numbers);
            NumberPrinter(numbers);
            

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List
            List<int> numberList = new List<int>();


            //Print the capacity of the list to the console
            Console.WriteLine("Starting capacity is " + numberList.Capacity);

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(numberList);

            //Print the new capacity
            Console.WriteLine("Updated capacity is " + numberList.Capacity);

            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list
            //Remember: if the user types "abc" on accident, your app should handle it!
            
            //Console.WriteLine("What NUMBER will you search for in the number list?");
            
            //int searchNumber = Convert.ToInt32(Console.ReadLine());

            string moveOn = "";
            bool invalid = false;
        
            do
            {
                Console.WriteLine("What NUMBER will you search for in the number list?");

                try
                {
                    invalid = false;
                    int searchNumber = Convert.ToInt32(Console.ReadLine());
                    NumberChecker(numberList, searchNumber);
                    Console.WriteLine("Move on? (To search again, type no.)");
                    moveOn = Console.ReadLine();
                }
                catch (System.FormatException)
                {
                    invalid = true;
                    Console.WriteLine("Oops! You needed to type in a number to search.");
                }
            } while (moveOn == "no" || invalid == true);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            //NumberPrinter();
           
            NumberPrinter(numberList);

            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");

            OddKiller(numberList);
            NumberPrinter(numberList);
            
            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted evens!!");
           
            numberList.Sort();
            NumberPrinter(numberList);
            
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable

            int[] arr = numberList.ToArray();


            //Clear the list

            numberList.Clear();

            NumberPrinter(arr);
            NumberPrinter(numberList);
            

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            int i = 0;

            for (i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                    numbers[i] = 0;
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            // This is Whit's code--might be for this one. (It's for one of these, but I can't remember which):
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.RemoveAt(i--);
                }
            }

        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
                Console.WriteLine("Yes, that number was found in the list!");
            else
                Console.WriteLine("Not found!");
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++)
            {
                int rando = rng.Next(50);
                numberList.Add(rando);
            }

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            int i = 0;

            for (i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 50);
            }

        }        

        private static void ReverseArray(int[] array)
        {
            int x = 0;
            int final = array.Length - 1;
            for (int i = 0; i < array.Length / 2; i++)
            {
                x = array[i];
                array[i] = array[final - i];
                array[final - i] = x;
            }

        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
