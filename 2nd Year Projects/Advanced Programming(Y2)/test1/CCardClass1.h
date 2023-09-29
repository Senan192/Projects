#pragma once
#include "CCard.h"
class CCardClass1 :
    public CCard
{
protected :
    int cardType;
    string name1;
    string name2;
    int power;
  

public:
    CCardClass1(istream& file,int type);

    string returnName();
    int returnPower();
    int ReturnType();
    int ReturnResilience();
    int UpdateResilience(int Newresilience);
    int ReturnBoost();

    friend istream& operator >> (istream& inputStream, CCardClass1& type1);
    friend int Settype(int type, CCardClass1& type1);
};

