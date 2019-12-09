/* Author: Eknoor Singh
 * Last Date Modified: 11-05-19 
 * The purpose of this program is to create the methods for die in order to play the game "Yahtzee"
 */
using System;
using static System.Console;
using System.Text;

namespace Bme121
{
    class YahtzeeDice
    {
        //Intializing the random variable as well as the face values of all die held in an array.
        static Random rGen = new Random();
        public int[] faceValues = new int [5];
        
        /* @param: N/A
         * @return: N/A
         * The purpose of this method is to output the face values of all die as a string
         */
        public override string ToString(){
            string faces = ""; 
            for(int i = 0; i < faceValues.Length; i++){
                faces = faces + " " + faceValues[i] + " ";
                }
            return faces;
            } 
       
        /* @param: N/A
         * @return: N/A
         * The purpose of this method is to assign random face values to die who have intial values set to 0.
         */
        public void Roll(){
            for (int i = 0; i < faceValues.Length; i++){
                    if(faceValues[i] == 0) {
                    faceValues[i] = rGen.Next(1,7);
                    }            
                }
            }
            
        /* @param: string faces
         * @return: N/A
         * The purpose of this method is to reset the given faces to a value of 0, in order for a re-roll.
         */
        public void Unroll (string faces) {
            //If "all" is inputted, all die face values are set to 0 for a re-roll
            if (faces == "all"){
                for(int i = 0; i < faceValues.Length; i++){
                    faceValues[i] = 0;
                    }
                }
            else {
                //If specific numbers are inputted, each face value is parsed and checked for through all the dices, and then when found, set to 0 for a re-roll.
                for(int i = 0; i < faces.Length; i++){
                int face = int.Parse(faces.Substring(i, 1));
                for (int j = 0; j < faceValues.Length; j++){
                    if (faceValues[j] == face) {
                            faceValues[j] = 0;
                        }
                    }
                }
            }
        }
          
        /* @param: N/A
         * @return: int sum
         * The purpose of this method is to sum all the face values of the die 
         */
        public int Sum(){
            int sum = 0;
            for (int i = 0; i < faceValues.Length; i++){
                sum += faceValues[i]; 
                }
            return sum;
            }
        
        /* @param: int face
         * @return: int sum
         * The purpose of this method is to sum all the face values which match the face value inputted
         */
        public int Sum(int face) {
            int sum ,count = 0;
            //The frequency of the inputted face value is countted through the count variable
            for (int i = 0; i < faceValues.Length; i++){
                if(faceValues[i] == face)   count++;
                }
            sum = face*count; //The frequency of the face value * the face value = the sum of all occourences of that face value.
            return sum;
            }
        
        /* @param: int length
         * @return: bool IsRunOf
         * The purpose of this method is to check whether an increasing sequence of the given length is present within the set of die face values.
         */
        public bool IsRunOf(int length) {
            //The array of die face values are sorted from the lowest value to highest
            sortLowToHigh();
            //The current count variable is intitalized to 1 and the temporary highest length of a sequence is also intialized to 1
            int count = 1;
            int temp = 1;
            for(int i = 0; i < faceValues.Length - 1; i++){  
                //The sequence is continued if the previous sorted dice face value is one less than the next dice value, count increments and next iteration of loop runs
                if(faceValues[i] + 1 == faceValues[i+1]) count++;
                //The sequence would not be interuptted if the same number occours in a sorted array, count does not increment but remains the same value and next iteration of loop runs
                else if (faceValues[i] == faceValues[i+1]) continue;
                //The squence is interuptted if two numbers don't match, and temp is set to count, while the count of the sequence is reset to 0, while temp holds the highest sequence length within the die face values
                else {
                    temp = count; 
                    count = 1;
                    }
                //If the count of the current sequence is ever higher than the temporary highest sequence length value, then temp is set to that count variable
                if (count > temp) temp = count;
                }
            if(temp >= length) return true; //If temp matches or is greater than the chosen length, then true is returned
            else return false;
            }
            
        /* @param: int size
         * @return: bool IsSetOf
         * The purpose of this method is to sum all the face values which match the face value inputted
         */
        public bool IsSetOf(int size) {
            //The array of die face values are sorted from the lowest value to highest
            sortLowToHigh();
            //The current count of multiple face values is intialized to 0 and the temporary highest size of multiple face values is recorded as temp and set to 0
            int count = 0;
            int temp = 0;
            for(int i = 0; i < faceValues.Length - 1; i++){ 
                if(faceValues[i] == faceValues[i+1]) count++; //If the face values of two different die match, count is increased
                if (count != 0 && faceValues[i] != faceValues[i+1]) { // If the current count of multiple face values is not 0 and the face values don't match, the count for that specific face value is set to 0 after setting the temp high to the current count.
                    temp = count;
                    count = 0; 
                }
            }
            if(count + 1 >= size || temp + 1 >= size) return true; // If either the current count of multiple face values or the temp highest count of face values is greater than the indicated size, true is returned.
            else return false;
        }
        
        /* @param: N/A
         * @return: bool IsFullHouse
         * The purpose of this method is to check whether a triple of one face value and a double of another face value is rolled(a.k.a full house).
         */
        public bool IsFullHouse() {
        //The array of die face values are sorted from the lowest value to highest
        sortLowToHigh();
        //If the first three sorted die face values match and last two sorted die values match, true is returned
        if(faceValues[0] == faceValues[1] && faceValues[2] == faceValues[3] && faceValues[3] == faceValues[4]){
            return true;
            }
        //Also if the first two sorted die face values match and last three sorted die values match, true is returned
        else if (faceValues[3] == faceValues[4] && faceValues[0] == faceValues[1] && faceValues[0] == faceValues[2]){
            return true;
            }
        //Otherwise, false is returned.
        else return false;
        }
        
        /* @param: N/A
         * @return: N/A
         * The purpose of this method is to use the bubble sort algorithim to sort the die face values from lowest value to highest
         */
        public void sortLowToHigh(){
            //A temp variable is created for the swapping two numbers
            int temp;
            bool swapped = false;
            //A do-while loops ensures the first iteration of the loop is ran, and as long as a swap occours(a number ahead of the previous number is less than that same number), this loop runs until the whole array is ran through without a swap.
            do { 
                swapped = false;
                for(int i = 1; i < faceValues.Length; i++){
                    if (faceValues[i] < faceValues[i-1]){
                        //Swapping method
                        temp = faceValues[i-1];
                        faceValues[i-1] = faceValues[i];
                        faceValues[i] = temp;
                        swapped = true;
                    }
                }
            }while(swapped);
        }
    }
}
