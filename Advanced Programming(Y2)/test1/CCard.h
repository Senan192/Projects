#pragma once
#include <iostream>

using namespace std;

class CCard
{
	//protected:string name;

public:
	CCard(istream& file);

	virtual int ReturnType() = 0;
	virtual string returnName() = 0;
	virtual int returnPower() = 0;
	virtual int ReturnResilience() = 0;
	virtual int UpdateResilience(int Newresilience) = 0;
	virtual int ReturnBoost() = 0;


	/*friend istream& operator >> (istream& inputStream, CCard& pet);
	friend ostream& operator << (ostream& outputStream, const CCard& pet);*/
};

