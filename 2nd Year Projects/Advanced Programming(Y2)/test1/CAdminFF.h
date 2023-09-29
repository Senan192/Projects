#pragma once
#include "CCard.h"
class CAdminFF :
    public CCard
{
protected:
    int cardType;
    string name1;
    string name2;
    int power;
    int boost;


public:
    CAdminFF(istream& file, int type);

    string returnName();
    int returnPower();
    int ReturnType();
    int ReturnResilience();
    int UpdateResilience(int Newresilience);
    int ReturnBoost();

    friend istream& operator >> (istream& inputStream, CAdminFF& admin);
    friend int Settype(int type, CAdminFF& admin);
};

