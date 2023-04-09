#include "CCardClass1.h"

CCardClass1::CCardClass1(istream& file, int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}


string CCardClass1::returnName()
{
	return name1 + " " + name2;
}

int CCardClass1::returnPower()
{
	return power;
}

int CCardClass1::ReturnType()
{
	return cardType;
}

int CCardClass1::ReturnResilience()
{
	return 0;
}

int CCardClass1::UpdateResilience(int Newresilience)
{
	return 0;
}

int CCardClass1::ReturnBoost()
{
	return 0;
}


istream& operator>>(istream& inputStream, CCardClass1& type1)
{
	inputStream >> type1.name1 >> type1.name2 >> type1.power;
	return inputStream;
}

