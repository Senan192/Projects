#include "cardFactory.h"
#include "CCard.h"

#include "CCardClass1.h"
#include "CCardClass2.h"
#include "CCardClass3.h"
#include "CStudent.h"
#include "CAdminPH.h"
#include "CAdminCA.h"
#include "CAdminFF.h"
#include"CStudentIP.h"




CCard* NewCard(ECardType card, istream& file,int type)
{
	CCard* cardPtr = nullptr;

	switch (card)
	{
	case ECardType::type1: {
		cardPtr = new CStudent(file,type);
		break;
	}

	case ECardType::type2: {
		cardPtr = new CAdminPH(file, type);
		break;
	}
	case ECardType::type3: {
		cardPtr = new CAdminCA(file, type);
		break;
	}
	case ECardType::type4: {
		cardPtr = new CAdminFF(file, type);
		break;
	}
	case ECardType::type5: {
		cardPtr = new CStudentIP(file, type);
		break;
	}

	case ECardType::type6: {
		cardPtr = new CCardClass3(file, type);
		break;
	}
	case ECardType::type7: {
		cardPtr = new CCardClass1(file, type);
		break;
	}
	case ECardType::type8: {
		cardPtr = new CCardClass1(file, type);
		break;
	}
	case ECardType::type9: {
		cardPtr = new CCardClass3(file, type);
		break;
	}
	case ECardType::type10: {
		cardPtr = new CCardClass2(file, type);
		break;
	}
	case ECardType::type11: {
		cardPtr = new CCardClass3(file, type);
		break;
	}

	default: {
		break;
	}
		   return cardPtr;

	}
}
