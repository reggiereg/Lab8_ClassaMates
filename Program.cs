using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab8_Classmates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Continue looking for students?
            bool studentLookupContinue = true;
            
            //Set the size of all the arrays
            int arraySize = 20;
               
            //name array for classmates
            string[] ClassMatesName = new string[arraySize];
            
            //array for storing age of classmates
            int[] ClassMatesAge = new int[arraySize];
            
            //array for classmates favorite song
            string[] ClassMatesSong = new string[arraySize];
            
            //array for classmates favorite food
            string[] ClassMatesFood = new string[arraySize];
            
            //add classmates and their information
            ClassMatesName[0] = "Reginald Richardson";
            ClassMatesSong[0] = "In the Air Tonight (Phil Collins)";
            ClassMatesFood[0] = "Pizza";
            ClassMatesAge[0] = 30;
            ClassMatesName[1] = "Sherita Brown";
            ClassMatesSong[1] = "Liking What You See (Chris Brown)";
            ClassMatesFood[1] = "Pineapples";
            ClassMatesAge[1] = 36;
            ClassMatesName[2] = "Shamita Kandru";
            ClassMatesSong[2] = "Survivor (Destiny's Child)";
            ClassMatesFood[2] = "Mac and Cheese";
            ClassMatesAge[2] = 37;
            ClassMatesName[3] = "Marcus Richardson";
            ClassMatesSong[3] = "If I Ruled the World (NAS)";
            ClassMatesFood[3] = "Cookies";
            ClassMatesAge[3] = 35;
            ClassMatesName[4] = "Kyle Vaughn";
            ClassMatesSong[4] = "Voodoo Child (Stevie Ray Vaughn)";
            ClassMatesFood[4] = "Wine";
            ClassMatesAge[4] = 29;
            ClassMatesName[5] = "Erwin Coronel";
            ClassMatesSong[5] = "Get Ready (Temptations)";
            ClassMatesFood[5] = "Ribye Steak";
            ClassMatesAge[5] = 28;

            int numClassmates = ClassMatesName.Length;
            //captures value of how to lookup classmate 
            int userInput;

            //holds index for referencing classmate info when looked up by number
            int lookupOption;

            //holds index for referencing classmate info when looked up by name
            int lookUpOption2;
            
            //loop continue looking up classmate information
            while (studentLookupContinue == true)
            {
                Console.WriteLine("========================================================================================================");
                userInput = UserOption(ClassMateUserInput("How would you like to look up your classmates info (Enter 1 or 2 for options below)\n1 By Name\n2 By Number"));
                Console.WriteLine("========================================================================================================");

                //if looking up classmate by name 
                if (userInput == 1)
                {
                    //holds value for deciding if user wants to know more about classmate
                    int learnMore;

                    //prints out the classmates names in the list
                    foreach (string classmate in ClassMatesName)
                    {
                        //breaks out of loop to print from list if index is null
                        if (classmate == null)
                        {
                            break;
                        }

                        //prints out a list of all the classmates
                        Console.WriteLine($"{classmate}"); 
                    }

                    //returns the index to use in all list to display selected classmate and there corresponding information
                    lookUpOption2 = LookupStudentByName(numClassmates, ClassMatesName, CheckUserNameFormat(ClassMateUserInput("Type in the name of the classmate you would like to lookup: ")));
                    
                    //this section prints out color formatted classmate information
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Here is {ClassMatesName[lookUpOption2]}'s information:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"He/she is: {ClassMatesAge[lookUpOption2]} years old!!");
                    learnMore = KnowMoreOption(ClassMateUserInput($"Would you like to know more about {ClassMatesName[lookUpOption2]}? (1 for yes 2 for no): "));
                    
                    //if user wants to view more information about the classmate
                    if (learnMore == 1)
                    {
                        //this section prints out color formatted classmate information
                        Console.WriteLine($"More info about {ClassMatesName[lookUpOption2]}: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"His/her favorite food is: {ClassMatesFood[lookUpOption2]}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"His/her favorite song is: {ClassMatesSong[lookUpOption2]}");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("==================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        studentLookupContinue = UserContinue(ClassMateUserInput("Would you like to continue? (y/n)"));
                    }
                    //if student doesn't want to view more information
                    else
                    {
                        //prompt user to see if they would like to lookup another classmate
                        studentLookupContinue = UserContinue(ClassMateUserInput("Would you like to continue? (y/n)"));
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                //if user wants to lookup classmate by number
                if (userInput == 2)
                {
                    //number used for user to specify what classmate theey want to lookup
                    int i = 1;
                    int learnMore;
                    foreach(string classmate in ClassMatesName)
                    { 
                        if(classmate == null)
                        {
                            break;
                        }
                        Console.WriteLine($"{i} {classmate}");
                        i++;
                    }

                    //Calls method to lookup the classmate specified by the user 
                    lookupOption = UserOption(numClassmates , ClassMateUserInput("Select the number by the name of the classmate you would like to lookup: "));
                    

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Here is {ClassMatesName[lookupOption - 1]}'s information:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"He/she is: {ClassMatesAge[lookupOption - 1]} years old!!");

                    learnMore = KnowMoreOption(ClassMateUserInput($"Would you like to know more about {ClassMatesName[lookupOption - 1]}? (1 for yes 2 for no): "));
                    
                    if (learnMore == 1)
                    {
                        Console.WriteLine($"More info about {ClassMatesName[lookupOption - 1]}: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"His/her favorite food is: {ClassMatesFood[lookupOption - 1]}");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"His/her favorite song is: {ClassMatesSong[lookupOption - 1]}");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("==================================");
                        Console.ForegroundColor = ConsoleColor.White;
                        studentLookupContinue = UserContinue(ClassMateUserInput("Would you like to continue? (y/n)"));
                    }

                    else
                    {
                        studentLookupContinue = UserContinue(ClassMateUserInput("Would you like to continue? (y/n)"));
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }

        //gets userinput
        public static string ClassMateUserInput(string message)
        {
            string userInput = "";
            Console.WriteLine($"{message} ");
            userInput = Console.ReadLine();
            return userInput;
        }

        //validates users input when prompted to continue program
        public static string ValidateContinueEntry(string message)
        {
            string userInput = "";
            Console.WriteLine($"{message}");
            userInput = Console.ReadLine();
            if (userInput[0] != 'y' && userInput[0] != 'n')
            {
                return ValidateContinueEntry("Invalid Entry.  Please type in y or n: ");
            }
            else
            {
                return userInput;
            }
        }

        //validates that user inputs can be parsed as integers
        public static int UserOption(string message)
        {
            int userInput;
            try
            {
                userInput = int.Parse(message);
                return userInput;
            }
            catch (FormatException)
            {
                return UserOption("Invalid entry.  Please enter a number: ");
            }
        }

        //method to handle option that user wants to view more information about classmate
        public static int KnowMoreOption(string message)
        {
            int userInput;
            try
            {
                userInput = int.Parse(message);
                return userInput;
            }
            catch (FormatException)
            {
                return KnowMoreOption("Type in 1 if you want to know more about this classmate or 2 if done with this classmate: ");
            }
        }

        //checks the format of the name put in by user when looking up classmate by name
        public static string CheckUserNameFormat(string name)
        {
            if(!Regex.IsMatch(name, @"([A-Z])([a-z]+) ([A-Z])([a-z]){1,30}"))
            {
                return CheckUserNameFormat(ClassMateUserInput("Invalid format for name entry.  (ex.  Reginald Richardson).\nPlease type in the name again with the specified format"));
            }

            else
            {
                return name;
            }
        }

        //overloaded function for user to select the classmate to view when selecting by number.
        //Takes in the number of students as a parameter to ensure user isn't selecting an integer value that is out of range
        public static int UserOption(int numStudents, string message)
        {
            int userInput;
            try
            {
                userInput = int.Parse(message);
                if (userInput > numStudents || userInput < 1)
                {
                    return UserOption(ClassMateUserInput($"Invalid selection.  There are {numStudents} classmates to lookup.  Enter a number between 1 and {numStudents}:  "));
                }
                else
                {
                    return userInput;
                }
            }
            catch (FormatException)
            {
                return UserOption("Invalid selection.  Enter 1 to lookup a classmates information\nEnter 2 to add a classmates information\nEnter 3 to exit the Program");
            }
        }

        //method to lookup classmate by name
        public static int LookupStudentByName(int numClassMates, string[] listOfClassmates, string classmate)
        {
            int index = 0;
            //loops through list of names to see if a match can be found
            for (int i = 0; i < numClassMates; i++)
            {
                //check if users input matches any of the names in the list
                if (listOfClassmates[i] == classmate)
                {
                    index = i;
                    return index;
                }
            }
            //reccursion if list is exceeded and a match has not been found for the user entry
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < numClassMates; x++)
            {
                Console.WriteLine(listOfClassmates[x]);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            //recursive step to prompt the user for a name that is in the list
            return LookupStudentByName(numClassMates, listOfClassmates, (ClassMateUserInput("Could not find that name.  Please make sure you're typing in one of the names listed above:  ")));
        }
       
        //handles users input to specify if they want to continue the program or not
        public static bool UserContinue(string input)
        {
            if (input[0] != 'y' && input[0] != 'n')
            {
                return UserContinue(ClassMateUserInput("Invalid Entry.  Please type in y or n: "));
            }
            else if (input[0] == 'y')
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
