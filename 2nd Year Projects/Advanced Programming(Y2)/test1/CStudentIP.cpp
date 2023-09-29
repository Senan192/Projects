#include "CStudentIP.h"

CStudentIP::CStudentIP(istream& file, int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}

string CStudentIP::returnName()
{
	return name1 + " " + name2;
}

int CStudentIP::returnPower()
{
	return power;
}

int CStudentIP::ReturnType()
{
	return cardType;
}

int CStudentIP::ReturnResilience()
{

	return resilience;
}

int CStudentIP::UpdateResilience(int newResilience)
{
	return resilience = newResilience;
}

int CStudentIP::ReturnBoost()
{
	return boost;
}


istream& operator>>(istream& inputStream, CStudentIP& student)
{
	inputStream >> student.name1 >> student.name2 >> student.power >> student.resilience>>student.boost;
	return inputStream;
}
