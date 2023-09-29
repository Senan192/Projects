#pragma once
#include "CCard.h"

class CCardClass2 :
    public CCard
{
protected:
    int cardType;
    string name1;
    string name2;
    int power;
    int resilience;

public:
    CCardClass2(istream& file,int type);

    string returnName();
    int returnPower();
    int ReturnType();
    int ReturnResilience();
    int UpdateResilience(int Newresilience);
    int ReturnBoost();

    friend istream& operator >> (istream& inputStream, CCardClass2& type2);
    
};



