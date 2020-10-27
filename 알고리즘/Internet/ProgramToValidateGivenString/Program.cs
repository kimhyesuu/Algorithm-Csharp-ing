using System;

//    Example 1

//Input: s1 = "mama d"

//Output: Palindrome Permutation(permutation: madam)


//Explanation: there are 5 non-letter characters in the given string "mama d" and this is a permutation
//    of a palindrome because it has two M, two A, one d. Strings of an odd length must have exactly one character with an odd count.


//Example 2


//Input: s1 = "Tic Toe"


//Output: No Palindrome Permutation

//Explanation: there are 6 non-letter characters in the given string "Tic Toe" and this is not a permutation 
//    of a palindrome because it has two T, One C, One O One E, One I (more than one character with odd count)

//Solution

//Look at the steps described for an algorithm
//Convert the given string into an array of type character
//Declare an array of integer type with size 128 that maps the ASCII value because as per the ASCII standard character
//        set there are 128 characters for electronic communication.
//Iterate through an array and for the index matching with the character ASCII value, set the value in the integer array
//            to 1 if the value is 0 otherwise set the value in the integer array to 0 if it is already 1
//Check that no more than one character has an odd count in the integer character set. If more than one characters with odd count
//        is found, then return failure signal and print the result “No Palindrome Permutation” otherwise “Palindrome Permutation”

//문제

//주어진 문자열이 회문(Palindrome)의 순열인지 아닌지 확인하는 함수를 작성하라.회문이란 앞으로 읽으나 뒤로 읽으나 
//    같은 단어 혹은 구절을 의미하며 순열이란 문자열을 재배치하는 것을 의미한다. 회문이 꼭 사전에 등장하는 단어로 제한될 필요는 없다.

namespace ProgramToValidateGivenString
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter string to be processed: ");


            var inputString = Console.ReadLine();
            var characterSetMappingTable = PrepareCharacterSetMappingTable(inputString);
            bool isOnlyOddOneFound = IsOnlyOddOneFound(characterSetMappingTable);
            Console.WriteLine(isOnlyOddOneFound ? "Palindrome Permutation" : "No Palindrome Permutation");

            Console.ReadLine();
        }

        private static int[] PrepareCharacterSetMappingTable(string inputString)
        {
            string stringToBeProcessed = inputString.Replace(" ", "").ToLower();
            //Convert string into an array f characters   
            char[] chars = stringToBeProcessed.ToCharArray();
            //declare an array of integer type with size 128 because as per the ASCII standard character set  
            //there are 128 characters for electronic communication.  
            int[] characterSetMappingTable = new int[128];

            //Iterate through an array and for the index matching with the character ASCII value,  
            //set the value in the integer array to 1 if the value is 0 otherwise set the value  in the integer array to 0 if it is already 1   
            foreach (char c in chars)
            {
                var characterIndex = (int)c;

                // 여기서 같으면 1이었다가 지워지는 현상을 나타내는구나
                if (characterSetMappingTable[characterIndex] == 0)
                    characterSetMappingTable[characterIndex] = 1;
                else if (characterSetMappingTable[characterIndex] == 1)
                    characterSetMappingTable[characterIndex] = 0;
            }

            return characterSetMappingTable;
        }

        /// <summary>  
        /// this method will determine that no more than one character has an odd count.  
        /// </summary>  
        /// <param name="characterSetMappingTable"></param>  
        /// <returns></returns>  
        private static bool IsOnlyOddOneFound(int[] characterSetMappingTable)
        {
            int countOddOneFound = 0;

            foreach (var index in characterSetMappingTable)
            {
                if (countOddOneFound > 1)
                    return false;
                if (index == 1)
                {
                    countOddOneFound++;
                }
            }

            return true;
        }
    }
}
