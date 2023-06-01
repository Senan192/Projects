public class ColoredPoint3D extends Point3D{
    private String colour;
    public void SetColur(String col){
        colour=col;
    }
    ColoredPoint3D(){
        SetColur("Green");
    }

    ColoredPoint3D(String col){
        SetColur(col);
    }

    public void SetValuesG(){
        SetX(1000);
        SetY(2000);
        SetZ(3000);
        SetColur("Red");
    }
    public void SetCustomValues(int xVal,int yVal,int zVal,String col){
        SetX(xVal);
        SetY(yVal);
        SetZ(zVal);
        SetColur(col);
    }
}
