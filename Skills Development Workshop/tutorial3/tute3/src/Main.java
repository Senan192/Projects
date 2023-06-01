import java.util.Scanner;
import java.util.Random;
public class Main {

    public static void One(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter first number");
        int one = scanner.nextInt();
        System.out.println("Enter second number");
        int two = scanner.nextInt();

        int answer=1;
        for (int i=1;i<=two;i++){
            answer *=one;
        }
        System.out.println("= " + answer);

    }

    public static int Conversion(int tempF){
        return (((tempF-32)*5)/9);
    }
    public static void Two(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter temp in F");
        int f = scanner.nextInt();
        int c=Conversion(f);
        System.out.println("Temp in C = " + c);
    }

    public static int[] Reverse(int[] arr){
        int arrLength= arr.length;
        int arrR[]=new int[arrLength];
        int counter=0;
        for(int i=arrLength-1;i>=0;i--){
            arrR[counter]=arr[i];
            counter++;
        }
        return arrR;
    }
    public static void Three(){
        int arr[]= new int[]{1,2,3,4,5};
        int arrR[]=Reverse(arr);
        System.out.print("Original array: ");
        for(int i=0;i<arr.length;i++){
            System.out.print(arr[i]+",");
        }
        System.out.println("");
        System.out.print("Reversed array: ");
        for(int i=0;i<arrR.length;i++){
            System.out.print(arrR[i]+",");
        }
    }

    public static boolean PalindromeCheck(String word){
        int lengthString = word.length()-1;
        boolean isPalindrome=false;
        for(int i=0;i<=lengthString/2;i++){
            if(word.charAt(i)==word.charAt(lengthString-i)){
                isPalindrome=true;
            }
            else{isPalindrome=false;}
        }
        return isPalindrome;
    }
    public static void Four(){
        boolean isPalindrome;
        String word="madaam";
        isPalindrome= PalindromeCheck(word);
        if(isPalindrome==true){
            System.out.println(word+ " is a palindrome");
        }
        else{
            System.out.println(word+ " is not a palindrome");
        }
    }

    public static void Five(){
        Random random= new Random();
        Scanner scanner = new Scanner(System.in);
        int randomNum = random.nextInt(100);
        int chances=7;
        boolean didntFind=true;
        System.out.print("Number generated. \nType in guess\n");

        while(chances>0){
            System.out.println(chances +" chance/s left");
            int guess = scanner.nextInt();
            if(guess<randomNum){
                System.out.println("Too low, try again");
            }
            else if(guess>randomNum){
                System.out.println("Too high, try again");
            }
            else if(guess==randomNum){
                System.out.println("Correct guess");
                chances=0;
                didntFind=false;
            }
            chances--;
        }
        if(didntFind==true){
            System.out.println("Out of guesses");
        }

    }

    public static void Six(){
        for(int i=1;i<=500;i++){
            String number = String.valueOf(i);
            if(number.length() == 1){

                int oneFirst = number.charAt(0);
                System.out.println(oneFirst);
                if((oneFirst*oneFirst*oneFirst)==i){
                    System.out.println(i);
                }

            }
        }
    }

    public static void main(String[] args) {
       //One();
       // Two();
        //Three();
        //Four();
        //Five();
        Six();
    }
}