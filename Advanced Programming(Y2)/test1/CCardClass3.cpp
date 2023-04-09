#include "CCardClass3.h"

CCardClass3::CCardClass3(istream& file,int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}

string CCardClass3::returnName()
{
	return name1+" "+name2;
}

int CCardClass3::returnPower()
{
	return power;
}

int CCardClass3::ReturnType()
{
	return cardType;
}

int CCardClass3::ReturnResilience()
{
	return resilience;
}

int CCardClass3::UpdateResilience(int Newresilience)
{
	resilience = Newresilience;
		return 0;
}

int CCardClass3::ReturnBoost()
{
	return boost;
}


istream& operator>>(istream& inputStream, CCardClass3& type3)
{
	inputStream >> type3.name1 >> type3.name2 >> type3.power >> type3.resilience >>type3.boost;
	return inputStream;
}

