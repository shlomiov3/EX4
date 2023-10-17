using System.Transactions;

public class Program
{
    static void Main(string[] args){
        int currentNumber;
        int[] maxTriple = new int[3];
        int maxSum = 0; // this will be the sum of the max triple
        int[] currentTriple = new int[2]; // [20, 3]
        // 20 3 2 9 8 11 -1
        int inputsCount = 0;
        do {
            string input = Console.ReadLine();
            if(!int.TryParse(input, out currentNumber) && (currentNumber < -1 || currentNumber == 0) ){
                Console.WriteLine("Invalid input!");
                return;
            }

            if(inputsCount < 3 && currentNumber == -1){
                Console.WriteLine("Invalid input!!!!");
                return;
            }

            if(inputsCount < 2){
                maxTriple[inputsCount] = currentNumber;
                currentTriple[inputsCount] = currentNumber;
                inputsCount++;
                continue;
            }
            inputsCount++;

            int currentSum = currentNumber + currentTriple[0] + currentTriple[1];
            if(currentSum > maxSum){
                maxSum = currentSum;
                maxTriple[0] = currentTriple[0];
                maxTriple[1] = currentTriple[1];
                maxTriple[2] = currentNumber;
            }

            currentTriple[0] = currentTriple[1];
            currentTriple[1] = currentNumber;
        } while(currentNumber != -1);

        foreach (int num in maxTriple){
            Console.Write("{0} ", num);
        }
    }
}