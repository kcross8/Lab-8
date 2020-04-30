using System;
using System.Threading;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] names = { "Billy", "Bob", "Barbara", "Bella", "Ben", "Britta", "Jeff", "Annie", "Troy", "Abed", "Shirley", "Pierce", "Dean", "Frankie", "Elroy", "Neil", "Vickie", "Alex", "Todd" };
            string[] favoriteFoods = { "Pizza", "Sushi", "Tacos", "Spaghetti", "Eggs", "Salmon", "Scallops", "Candy", "Toast", "Burritos", "Avocado", "Veal", "Carrots", "Onions", "Clams", "Cheese", "Icecream", "Chicken", "Tuna" }; 
            string[] hometown = { "Detroit", "Cleveland", "Grand Rapids", "Toledo", "Chicago", "Kalamazoo", "Lansing", "Muskegon", "Boston", "New York", "Denver", "Philadelphia", "San Diego", "Dallas", "Austin", "San Antonio", "Rome", "Vienna", "Shanghai" };
            string[] favoriteAnimal = { "Cat", "Dog", "Monkey", "Dolphin", "Tiger", "Wolf", "Lion", "Whale", "Gecko", "Ape", "Snake", "Parrot", "Squirrel", "Panda", "Owl", "Frog", "Fish" };

            bool retry = true;
            bool run = true;
            while (run)
            {
                Console.WriteLine($"Which student would you like to learn more about? (enter a number from 0 to {names.Length - 1}):");
                string input = Console.ReadLine();
                int index = 0;
                string name = "";
                try
                {
                    index = int.Parse(input);

                    if (index >= 0 && index < names.Length)
                    {
                        name = names[index];
                    }
                    else
                    {
                        throw new Exception($"That student number does not exist. Please enter a number from 0 to {names.Length - 1}:");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("That is not a number. Please try again:");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"That number is not between 0 and {names.Length - 1}. Please try again:");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                if (name != "")
                {
                    Console.WriteLine($"You selected {name} at index: {index}");
                    while (retry == true || run == true)
                        try
                        {
                            {
                                Console.WriteLine($"What would you like to learn about {name}? Enter ht (for hometown), ff (for favorite food), or fa (for favorite animal).");

                                string response = Console.ReadLine();

                                if (response == "ff")
                                {
                                    Console.WriteLine($"{name}'s favorite food is {favoriteFoods[index]}.");
                                    if (LearnMore(name) == true)
                                    {
                                        retry = true;
                                    }
                                    else
                                    {
                                        retry = false;
                                        run = false;
                                    }
                                }
                                else if (response == "ht")
                                {
                                    Console.WriteLine($"{name} is from the city of {hometown[index]}.");
                                    if (LearnMore(name) == true)
                                    {
                                        retry = true;
                                    }
                                    else
                                    {
                                        retry = false;
                                        run = false;
                                    }
                                }
                                else if (response == "fa")
                                {
                                    Console.WriteLine($"{name}'s favorite animal is a {favoriteAnimal[index]}.");
                                    if (LearnMore(name) == true)
                                    {
                                        retry = true;
                                    }
                                    else
                                    {
                                        retry = false;
                                        run = false;
                                    }
                                }
                                else
                                {
                                    throw new Exception($"That is not an option. Please enter ht, ff, or fa.");
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                }
                run = Ask();
            }
        }

        public static bool LearnMore(string name)
        {            
            Console.WriteLine();
            Console.WriteLine($"Would you like to know more about {name}? (y/n)" ); ;
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                Console.WriteLine("Thanks.");
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, I did not understand that. Please enter y or n.");
                return LearnMore(name);
            }
        }
        public static bool Ask()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to learn about another student? (y/n):");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                Console.WriteLine("Goodbye.");
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, I did not understand that. Please try again.");
                return Ask();
            }
        }               
    }
}
