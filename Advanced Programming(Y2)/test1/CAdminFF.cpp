#include "CAdminFF.h"

CAdminFF::CAdminFF(istream& file, int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}


string CAdminFF::returnName()
{
	return name1 + " " + name2;
}

int CAdminFF::returnPower()
{
	return power;
}

int CAdminFF::ReturnType()
{
	return cardType;
}

int CAdminFF::ReturnResilience()
{
	return 0;
}

int CAdminFF::UpdateResilience(int Newresilience)
{
	return 0;
}

int CAdminFF::ReturnBoost()
{
	return boost;
}


istream& operator>>(istream& inputStream, CAdminFF& admin)
{
	inputStream >> admin.name1 >> admin.name2 >> admin.power >> admin.boost;
	return inputStream;
}

