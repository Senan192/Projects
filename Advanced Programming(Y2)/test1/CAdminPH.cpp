#include "CAdminPH.h"

CAdminPH::CAdminPH(istream& file, int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}


string CAdminPH::returnName()
{
	return name1 + " " + name2;
}

int CAdminPH::returnPower()
{
	return power;
}

int CAdminPH::ReturnType()
{
	return cardType;
}

int CAdminPH::ReturnResilience()
{
	return 0;
}

int CAdminPH::UpdateResilience(int Newresilience)
{
	return 0;
}

int CAdminPH::ReturnBoost()
{
	return 0;
}


istream& operator>>(istream& inputStream, CAdminPH& admin)
{
	inputStream >> admin.name1 >> admin.name2 >> admin.power;
	return inputStream;
}

