import java.util.Scanner;
import java.util.Arrays;
import java.util.Vector;

public class Main {




    public static double Addition(double one, double two){
        return (one+two);
    }
    public static double Substraction(double one, double two){
        return (one-two);
    }
    public static double Multiplication(double one, double two){
        return (one*two);
    }
    public static double Division(double one, double two){
        return (one/two);
    }
    public static double Modulous(double one, double two){
        return (one%two);
    }

    public static void One(){
        Scanner scanner =new Scanner(System.in);
        double firstNum=0,secondNum=0,answer=0;
        String operation="";
        boolean exit=false;
        while(!exit){
            System.out.println("Enter first number");
            firstNum = scanner.nextDouble();
            scanner.nextLine();
            System.out.println("Enter operation");
            operation= scanner.nextLine();
            System.out.println("Enter second number");
            secondNum = scanner.nextDouble();
            scanner.nextLine();

            if(operation.equals("+")){
                answer=Addition(firstNum,secondNum);
                System.out.println(answer);
            }
            else if(operation.equals("-")){
                answer=Substraction(firstNum,secondNum);
                System.out.println(answer);
            }
            else if(operation.equals("*")){
                answer=Multiplication(firstNum,secondNum);
                System.out.println(answer);
            }
            else if(operation.equals("/")){
                answer=Division(firstNum,secondNum);
                System.out.println(answer);
            }
            else if(operation.equals("%")){
                answer=Modulous(firstNum,secondNum);
                System.out.println(answer);
            }
            else {
                System.out.println("Invalid operator");
            }

            System.out.println("Press Enter to retry.\n0 to exit");
            String input =  scanner.nextLine();
            if(input.equals("0")){
                exit=true;
            }

        }

    }

    public static void Two(){
        int answer=0;
        for(int i=1;i<=10;i++){
            answer+=i;
            //System.out.println();
        }
        System.out.println(answer);
    }

    public static void Three(){
        for(int i=0;i<=100;i++){
            if(i%2!=0){
                System.out.println(i);
            }
        }
    }

    public static void Four(){
        Scanner scanner =new Scanner(System.in);
        int rangeL=0,rangeH=0,answer=0;
        System.out.println("Enter range lower limit ");
        rangeL= scanner.nextInt();
        System.out.println("Enter range upper limit ");
        rangeH= scanner.nextInt();
        for (int i=rangeL;i<=rangeH;i++){
            if(i%2==0){
                answer+=i;
            }
        }
        System.out.println(answer);

    }

    public static void Five(){
        Scanner scanner =new Scanner(System.in);
        int number=0;
        System.out.println("Enter number");
        number = scanner.nextInt();
        if(number<0){
            number=0-number;
        }
        for(int i =1;i<=10;i++){
            System.out.println(number +" x " + i + " = " + (number*i));
        }
    }

    public static void Six(){
        Scanner scanner = new Scanner(System.in);
        int number=0,total=0,counter=0;
        boolean exit =false;
        while(!exit){
            System.out.println("Enter number");
            number=scanner.nextInt();
            if(number<0){
                exit=true;
            }
            else{
                total+=number;
                counter++;
            }
        }
        System.out.println("Total: "+ total + "\nCount: "+ counter + "\nAverage: "+ (total/counter));

    }

    public static void Seven(){
        Scanner scanner = new Scanner(System.in);
        int number=0,oddSum=0,evenSum=0;
        boolean exit=false;
        while(!exit){
            System.out.println("input number \nPress 0 to stop");
            number=scanner.nextInt();
            if(number==0){
                exit = true;
            }
            if(number%2==0){
                evenSum+=number;
            }
            else{
                oddSum+=number;
            }
        }
        System.out.println("Even # sum: "+ evenSum + "\nOdd # sum: "+ oddSum);

    }

    public static void Eight(){
        Scanner scanner =new Scanner(System.in);
        int [] arr =new int[10];
        int total=0,avg=0;
        for(int i=0;i<10;i++){
            System.out.println("Enter number "+(i+1));
            arr[i]=scanner.nextInt();
            total +=arr[i];
        }
        avg=total/10;
        System.out.println("Total: "+ total+"\nAvg:" +avg);
    }

    public static void Nine(){
        Scanner scanner =new Scanner(System.in);
        int [] arr =new int[10];
        for(int i=0;i<10;i++){
            System.out.println("Enter number "+(i+1));
            arr[i]=scanner.nextInt();
        }
        System.out.println("Unsorted array:");
        for(int i=0;i<10;i++){
            System.out.print(arr[i]+",");
        }
        Arrays.sort(arr);
        System.out.println("\nsorted array :");
        for(int i=0;i<10;i++){
            System.out.print(arr[i]+",");
        }
    }

    public static void Ten(){
        for(int i=0;i<5;i++){
            for(int j=0;j<10;j++){
                System.out.print("* ");
            }
            System.out.println("");
        }
    }

    public static void Eleven(){
        char star ='*';
        for(int i=0;i<5;i++){
            for(int j=0;j<=i;j++){
                System.out.print("* ");
            }
            System.out.println("");
        }
    }

    public static void Twelve(){
        int arr1[]={1,2,3,4,5};
        int arr2[]={4,5,6,7,8};
        Vector<Integer> common = new Vector<Integer>();
        int looplength=0;
        if(arr1.length>arr2.length){
            looplength=arr1.length;
        }
        else{
            looplength=arr2.length;
        }
        for(int i=0;i<looplength;i++){
            for(int j=0;j<looplength;j++){
                if(arr1[i]==arr2[j]){
                    common.add(arr1[i]);
                }
            }
        }

        for(int p=0;p<common.size();p++){
            System.out.println(common.get(p));
        }
    }
    public static void main(String[] args) {
       // One();
        //Two();
       // Three();
        //Four();
       // Five();
        //Six();
       // Seven();
        //Eight();
        //Nine();
        //Ten();
       // Eleven();
        Twelve();
    }
}