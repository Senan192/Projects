#include "CPlayers.h"

void CPlayers::SetName(string playerName)
{
	
		name = playerName;
		prestiege = 30;
	
}

void CPlayers::UpdatePrestiege(int newPrestiege)
{
	prestiege = newPrestiege;
}

int CPlayers::ReturnPrestiege()
{
	return prestiege;
}

string CPlayers::ReturnName()
{
	return name;
}


