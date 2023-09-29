#pragma once
#include "CCard.h"
class CAdminPH :
    public CCard
{
protected:
    int cardType;
    string name1;
    string name2;
    int power;


public:
    CAdminPH(istream& file, int type);

    string returnName();
    int returnPower();
    int ReturnType();
    int ReturnResilience();
    int UpdateResilience(int Newresilience);
    int ReturnBoost();

    friend istream& operator >> (istream& inputStream, CAdminPH& admin);
    friend int Settype(int type, CAdminPH& admin);
};

