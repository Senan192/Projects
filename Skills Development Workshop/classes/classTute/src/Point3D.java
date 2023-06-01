public class Point3D extends Point{
    private int z=0;

    public void SetZ(int zValue){
        z = zValue;
    }
    Point3D(){
        SetZ(300);
    }

    Point3D(int z){
        SetZ(z);
    }

    public void SetValuesG(){
        SetX(1000);
        SetY(2000);
        SetZ(3000);
    }

    public void SetCustomValues(int xVal,int yVal,int zVal){
        SetX(xVal);
        SetY(yVal);
        SetZ(zVal);
    }
}
