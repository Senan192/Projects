import java.lang.Math;
public class Line {
    public static void CalculateLength(Point p1, Point p2){
        int p1X= p1.GetX();
        int p1Y = p1.GetY();
        int p2X = p2.GetX();
        int p2Y = p2.GetY();

        float length = ((p2X-p1X)*(p2X-p1X))+((p2Y-p1Y)*(p2Y-p1Y));
        System.out.println("Length=" + Math.sqrt(length));
    }

    public static void main(String[] args) {
        Point p1 = new Point();
        p1.SetX(-1);
        p1.SetY(0);

        Point p2 = new Point();
        p2.SetX(1);
        p2.SetY(0);

        CalculateLength(p1,p2);
    }

}
