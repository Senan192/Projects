#include "CAdminCA.h"

CAdminCA::CAdminCA(istream& file, int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}


string CAdminCA::returnName()
{
	return name1 + " " + name2;
}

int CAdminCA::returnPower()
{
	return power;
}

int CAdminCA::ReturnType()
{
	return cardType;
}

int CAdminCA::ReturnResilience()
{
	return 0;
}

int CAdminCA::UpdateResilience(int Newresilience)
{
	return 0;
}

int CAdminCA::ReturnBoost()
{
	return 0;
}


istream& operator>>(istream& inputStream, CAdminCA& admin)
{
	inputStream >> admin.name1 >> admin.name2 >> admin.power;
	return inputStream;
}
