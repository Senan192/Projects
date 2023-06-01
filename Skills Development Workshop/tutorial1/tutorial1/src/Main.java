import java.util.Scanner;
public class Main {

    public static void One(){
        System.out.println("Hello Programming");
    }

    public static void Two(){
        System.out.println("Hello \nProgramming");
    }

    public static void Three(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter name");
        String name = scanner.nextLine();
        System.out.println("Hello " +name);
    }

    public static void Four(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter 1st number");
        int one = scanner.nextInt();
        System.out.println("Enter 2nd number");
        int two = scanner.nextInt();
        System.out.println(one +"+" + two + "="+(one+two) );
    }

    public static void Five(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter salesman number");
        int sNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter salesman name");
        String sName = scanner.nextLine();
        System.out.println("Enter number of units sold");
        int units = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter unit price");
        int unitPrice = scanner.nextInt();
        scanner.nextLine();

        System.out.println("Salesman number: "+sNumber);
        System.out.println("Salesman name: " + sName);
        System.out.println("Sales value: "+ (units*unitPrice));
    }

    public static void Six(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter student number");
        int sNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter student name");
        String sName = scanner.nextLine();
        System.out.println("Enter module 1 mark");
        int mod1 = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter module 2 mark");
        int mod2 = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter module 3 mark");
        int mod3 = scanner.nextInt();
        scanner.nextLine();

        System.out.println("Student number: "+sNumber);
        System.out.println("Student name: " + sName);
        System.out.println("Total marks: "+ (mod1+mod2+mod3));
        System.out.println("Avg marks: "+ ((mod1+mod2+mod3)/3));
    }

    public static void Seven(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter student number");
        int sNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter student name");
        String sName = scanner.nextLine();
        System.out.println("Enter module 1 mark");
        int mod1 = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter module 2 mark");
        int mod2 = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter module 3 mark");
        int mod3 = scanner.nextInt();
        scanner.nextLine();
        String mod1Results,mod2Results,mod3Results;
        if(mod1>50){
            mod1Results="Pass";
        }
        else{
            mod1Results="fail";}

        if(mod2>50){
            mod2Results="Pass";
        }
        else{
            mod2Results="fail";}

        if(mod3>50){
            mod3Results="Pass";
        }
        else{
            mod3Results="fail";}

        System.out.println("Student number: "+sNumber);
        System.out.println("Student name: " + sName);
        System.out.println("Total marks: "+ (mod1+mod2+mod3));
        System.out.println("Avg marks: "+ ((mod1+mod2+mod3)/3));
        System.out.println("Module 1: "+ mod1Results);
        System.out.println("Module 2: "+ mod2Results);
        System.out.println("Module 3: "+ mod3Results);
    }


    public static void Eight(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter student number");
        int sNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter student name");
        String sName = scanner.nextLine();
        System.out.println("Enter module 1 mark");
        int mod1 = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter module 2 mark");
        int mod2 = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter module 3 mark");
        int mod3 = scanner.nextInt();
        scanner.nextLine();
        String mod1Results,mod2Results,mod3Results;
        if(mod1>=80){
            mod1Results="Distinction";
        }
        else if(mod1>=70){
            mod1Results="very good pass";
        }
        else if(mod1>=60){
            mod1Results="credit";
        }
        else if(mod1>=50){
            mod1Results="pass";
        }
        else{
            mod1Results="fail";
        }

        if(mod2>=80){
            mod2Results="Distinction";
        }
        else if(mod2>=70){
            mod2Results="very good pass";
        }
        else if(mod2>=60){
            mod2Results="credit";
        }
        else if(mod2>=50){
            mod2Results="pass";
        }
        else{
            mod2Results="fail";
        }

        if(mod3>=80){
            mod3Results="Distinction";
        }
        else if(mod3>=70){
            mod3Results="very good pass";
        }
        else if(mod3>=60){
            mod3Results="credit";
        }
        else if(mod3>=50){
            mod3Results="pass";
        }
        else{
            mod3Results="fail";
        }

        System.out.println("Student number: "+sNumber);
        System.out.println("Student name: " + sName);
        System.out.println("Total marks: "+ (mod1+mod2+mod3));
        System.out.println("Avg marks: "+ ((mod1+mod2+mod3)/3));
        System.out.println("Module 1: "+ mod1Results);
        System.out.println("Module 2: "+ mod2Results);
        System.out.println("Module 3: "+ mod3Results);
    }
    public static void Nine(){
        boolean exit =false;

        while(!exit){
            Scanner scanner = new Scanner(System.in);
            System.out.println("Enter student number");
            int sNumber = scanner.nextInt();
            scanner.nextLine();
            System.out.println("Enter student name");
            String sName = scanner.nextLine();
            System.out.println("Enter module 1 mark");
            int mod1 = scanner.nextInt();
            scanner.nextLine();
            System.out.println("Enter module 2 mark");
            int mod2 = scanner.nextInt();
            scanner.nextLine();
            System.out.println("Enter module 3 mark");
            int mod3 = scanner.nextInt();
            scanner.nextLine();
            String mod1Results,mod2Results,mod3Results;
            if(mod1>=80){
                mod1Results="Distinction";
            }
            else if(mod1>=70){
                mod1Results="very good pass";
            }
            else if(mod1>=60){
                mod1Results="credit";
            }
            else if(mod1>=50){
                mod1Results="pass";
            }
            else{
                mod1Results="fail";
            }

            if(mod2>=80){
                mod2Results="Distinction";
            }
            else if(mod2>=70){
                mod2Results="very good pass";
            }
            else if(mod2>=60){
                mod2Results="credit";
            }
            else if(mod2>=50){
                mod2Results="pass";
            }
            else{
                mod2Results="fail";
            }

            if(mod3>=80){
                mod3Results="Distinction";
            }
            else if(mod3>=70){
                mod3Results="very good pass";
            }
            else if(mod3>=60){
                mod3Results="credit";
            }
            else if(mod3>=50){
                mod3Results="pass";
            }
            else{
                mod3Results="fail";
            }

            System.out.println("Student number: "+sNumber);
            System.out.println("Student name: " + sName);
            System.out.println("Total marks: "+ (mod1+mod2+mod3));
            System.out.println("Avg marks: "+ ((mod1+mod2+mod3)/3));
            System.out.println("Module 1: "+ mod1Results);
            System.out.println("Module 2: "+ mod2Results);
            System.out.println("Module 3: "+ mod3Results);
            System.out.println("Enter 0 to exit");
            String input =scanner.nextLine();
            if(input.equals("0")){
                exit=true;
            }
        }
    }

    public static void Ten(){
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter salesman number");
        int sNumber = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter salesman name");
        String sName = scanner.nextLine();
        System.out.println("Enter number of units sold");
        int units = scanner.nextInt();
        scanner.nextLine();
        System.out.println("Enter unit price");
        int unitPrice = scanner.nextInt();
        scanner.nextLine();

        int salesValue=units*unitPrice;
        float salary=20000;
        float commission=0;
        if(salesValue>50000){
            int excess= salesValue-50000;
            commission= (float) (excess*0.1);
            salary+=commission;
        }

        System.out.println("Salesman number: "+sNumber);
        System.out.println("Salesman name: " + sName);
        System.out.println("Sales value: "+ salesValue );
        System.out.println("Commission: " + commission);
        System.out.println("Salary: " + salary);
    }

    public static void Eleven(){
        Scanner scanner = new Scanner(System.in);
        float radius=0;
        double pi = 3.1428;
        System.out.println("Enter radius");
        radius = scanner.nextFloat();
        scanner.nextLine();
        System.out.println("Circumference: " + (2*pi*radius));
        System.out.println("Area: " + (pi *radius*radius));

    }

    public static void Tweleve(){
        Scanner scanner = new Scanner(System.in);
        double height=0;
        double width =0;
        System.out.println("Enter height");
        height = scanner.nextDouble();
        System.out.println("Enter width");
        width = scanner.nextDouble();
        System.out.println("Perimeter: " +((width*2)+(height*2)));
        System.out.println("Area: "+ (width*height));
    }

    public  static void Thirteen(){
        Scanner scanner = new Scanner(System.in);
        double pi = 3.1428;
        double height=0;
        double radius =0;
        System.out.println("Enter height");
        height = scanner.nextDouble();
        System.out.println("Enter radius");
        radius = scanner.nextFloat();
        System.out.println("SA: "+ (2*pi*radius*height));
        System.out.println("V: " + (pi*radius*radius*height));
    }

    public static void Circle(){
        Scanner scanner = new Scanner(System.in);
        float radius=0;
        double pi = 3.1428;
        System.out.println("Enter radius");
        radius = scanner.nextFloat();
        scanner.nextLine();
        System.out.println("Circumference: " + (2*pi*radius));
        System.out.println("Area: " + (pi *radius*radius));
        System.out.println("Press enter to go to Menu");
        scanner.nextLine();
        Fourteen();

    }

    public static void Rectangle(){
        Scanner scanner = new Scanner(System.in);
        double height=0;
        double width =0;
        System.out.println("Enter height");
        height = scanner.nextDouble();
        System.out.println("Enter width");
        width = scanner.nextDouble();
        System.out.println("Perimeter: " +((width*2)+(height*2)));
        System.out.println("Area: "+ (width*height));
        System.out.println("Press enter to go to Menu");
        scanner.nextLine();
        Fourteen();
    }

    public  static void Cylinder(){
        Scanner scanner = new Scanner(System.in);
        double pi = 3.1428;
        double height=0;
        double radius =0;
        System.out.println("Enter height");
        height = scanner.nextDouble();
        System.out.println("Enter radius");
        radius = scanner.nextFloat();
        System.out.println("SA: "+ (2*pi*radius*height));
        System.out.println("V: " + (pi*radius*radius*height));
        System.out.println("Press enter to go to Menu");
        scanner.nextLine();
        Fourteen();
    }
    public static void Fourteen(){
        Scanner scanner = new Scanner(System.in);
        int choice=0;
        System.out.println("Select choice \n 1. Cricle \n 2. Rectangle \n 3. Cylinder \n 0. Exit");
        choice = scanner.nextInt();
        switch(choice){
            case 1:
                Circle();
                break;
            case 2:
                Rectangle();
                break;
            case 3:
                Cylinder();
                break;
            case 0:
                break;
        }
    }

    public static void main(String[] args) {
        //One();
        //Two();
        // Three();
        //Four();
       //Five();
        //Six();
        //Seven();
        //Eight();
        //Nine();
        Ten();
        //Eleven();
        //Tweleve();
        //Thirteen();
        //Fourteen();
    }
}