import java.util.Scanner;
public class Point {
    private int x=0;
    private int y=0;

    public void SetX(int xValue){
        x = xValue;
    }
    public void SetY(int yValue){
        y = yValue;
    }
    public int GetX(){
        return x;
    }
    public int GetY(){
        return y;
    }

    Point(){
        SetX(100);
        SetY(200);
    }

    Point(int xVal,int yVal){
        SetX(xVal);
        SetY(yVal);
    }

    public void SetValuesG(){
        SetX(1000);
        SetY(2000);
    }

    public void SetCustomValues(int xVal,int yVal){
        SetX(xVal);
        SetY(yVal);
    }

}
