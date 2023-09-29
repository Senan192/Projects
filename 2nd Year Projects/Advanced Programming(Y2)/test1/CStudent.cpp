#include "CStudent.h"

CStudent::CStudent(istream& file, int type) : CCard(file)
{
	file >> *this;
	cardType = type;
}

string CStudent::returnName()
{
	return name1 + " " + name2;
}

int CStudent::returnPower()
{
	return power;
}

int CStudent::ReturnType()
{
	return cardType;
}

int CStudent::ReturnResilience()
{

	return resilience;
}

int CStudent::UpdateResilience(int newResilience)
{
	return resilience = newResilience;
}

int CStudent::ReturnBoost()
{
	return 0;
}


istream& operator>>(istream& inputStream, CStudent& student)
{
	inputStream >> student.name1 >> student.name2 >> student.power >> student.resilience;
	return inputStream;
}
