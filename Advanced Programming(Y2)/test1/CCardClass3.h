#pragma once
#include "CCard.h"

class CCardClass3 :
    public CCard
{
protected:
    int cardType;
    string name1;
    string name2;
    int power;
    int resilience;
    int boost;


public:
    CCardClass3(istream& file,int type);

    string returnName();
    int returnPower();
    int ReturnType();
    int ReturnResilience();
    int UpdateResilience(int Newresilience);
    int ReturnBoost();

    friend istream& operator >> (istream& inputStream, CCardClass3& type1);
    friend void Settype(int type, CCardClass3& type2);
};


