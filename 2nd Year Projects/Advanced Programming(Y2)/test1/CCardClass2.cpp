#include "CCardClass2.h"


CCardClass2::CCardClass2(istream& file,int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}

string CCardClass2::returnName()
{
	return name1 + " " + name2;
}

int CCardClass2::returnPower()
{
	return power;
}

int CCardClass2::ReturnType()
{
	return cardType;
}

int CCardClass2::ReturnResilience()
{
	
	return resilience;
}

int CCardClass2::UpdateResilience(int newResilience)
{
	return resilience=newResilience;
}

int CCardClass2::ReturnBoost()
{
	return 0;
}


istream& operator>>(istream& inputStream, CCardClass2& type2)
{
	inputStream >> type2.name1 >> type2.name2 >> type2.power >> type2.resilience;
	return inputStream;
}



