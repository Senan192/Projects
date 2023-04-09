#pragma once
#include "CCard.h"
class CStudentIP :
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
    CStudentIP(istream& file, int type);

    string returnName();
    int returnPower();
    int ReturnType();
    int ReturnResilience();
    int UpdateResilience(int Newresilience);
    int ReturnBoost();

    friend istream& operator >> (istream& inputStream, CStudentIP& student);
};

