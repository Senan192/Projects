#pragma once
#include <string>

using namespace std;

class CPlayers
{
protected:
	string name;
	int prestiege;

public: void SetName(string playerName);
	  void UpdatePrestiege(int newPrestiege);
	  int ReturnPrestiege();
	  string ReturnName();

	  
	
	

};

