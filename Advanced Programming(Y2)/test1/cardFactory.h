#pragma once
#include "CCard.h"


enum class ECardType : int {
	type1 = 1,
	type2 = 2,
	type3 =3,
	type4=4,
	type5 = 5,
	type6 = 6,
	type7 = 7,
	type8 = 8,
	type9 = 9,
	type10 = 10,
	type11 = 11,
	
};

CCard* NewCard(ECardType card, istream& file,int type);