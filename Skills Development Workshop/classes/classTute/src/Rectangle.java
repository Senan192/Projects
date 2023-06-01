import java.lang.Math;
public class Rectangle {

    public static void CalculateLengths(Point p1,Point p2,Point p3,Point p4){
        int lengthTmp = p1.GetX()- p2.GetX();
        int length= (int) Math.sqrt(lengthTmp*lengthTmp);
        int widthTmp = p3.GetY()-p2.GetY();
        int width = (int) Math.sqrt(widthTmp*widthTmp);
        System.out.println("length="+length + "\nwidth="+ width);
        System.out.println("Perimeter=" + (length*2+width*2));
        System.out.println("Area="+ (length*width));
    }
    public static void main(String[] args) {
        Point p1 = new Point(-1,1);
        Point p2 = new Point(1,1);
        Point p3 = new Point(1,-1);
        Point p4 = new Point(-1,-1);

        CalculateLengths(p1,p2,p3,p4);
    }
}
