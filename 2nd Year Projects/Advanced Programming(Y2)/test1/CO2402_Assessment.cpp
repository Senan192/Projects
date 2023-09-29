#include <iostream>
#include <fstream>
#include <vector>
#include<time.h>
#include <cstdlib>
#include "CCard.h"
#include "cardFactory.h"
#include "CPlayers.h"

using namespace std;



int Random(int max)
{
    int range = max;
    return int(float(rand()) / (RAND_MAX + 1) * float(range));
}






int main()
{


    vector <CCard*> plagiaristDeck;
    vector <CCard*> piffle_paperDeck;


    ifstream file("plagiarist.txt");

    if (file.is_open()) {
        while (file) {
            double type = 0;
            file >> type;

            if (type != 0) {
                //call method in "cardFactory" to create new class objects for each card
                plagiaristDeck.push_back(NewCard(ECardType(type), file, type));

            }

        }
    }
    else {
        cout << "file not open";
    }

    ifstream file2("piffle-paper.txt");

    if (file2.is_open()) {
        while (file2) {
            int type = 0;
            file2 >> type;

            if (type != 0) {

                piffle_paperDeck.push_back(NewCard(ECardType(type), file2, type));

            }

        }
    }
    else {
        cout << "file not open";
    }


    //initialize player classes
    CPlayers plagiarist;
    plagiarist.SetName("Professor Plagiarist");

    CPlayers piffle_paper;
    piffle_paper.SetName("Professor Piffle Paper");

    cout << "Welcome to U-Can't. Let the winnowing begin..." << endl << endl;

    //players hands, tables and the cards that should be deleted at the end of each turn are saved in vectors.
    vector<int> plagiaristTable;
    vector<int> piffle_paperTable;
    vector <int> cardsToDelete;
    vector <int> plagiaristHand1;
    vector <int> piffle_paperHand1;


    //variables to keep track of the respective values during each round
    int round = 0;
    //deck index : the index of the card in the original file (deck)
    int deckIndex = 1;
    int plagiaristCardCounter = 0;
    int piffle_paperCardCounter = 0;

    //players starting hand
    for (int i = 0; i < 1; i++) {
        cout << plagiarist.ReturnName() << " starts with";
        cout << " card: " << plagiaristDeck[i]->returnName();
        cout << " (power = " << plagiaristDeck[i]->returnPower() << ")" << endl;
        plagiaristHand1.push_back(i);


        cout << piffle_paper.ReturnName() << " starts with";
        cout << " card: " << piffle_paperDeck[i]->returnName();
        cout << " (power = " << piffle_paperDeck[i]->returnPower() << ")" << endl << endl;
        piffle_paperHand1.push_back(i);


    }
    //"hand is empty" function implemeted as a failsafe if cards from deck are finished or theres an error in reading them
    bool plagiaristHandEmpty = false;
    bool piffle_paperHandEmpty = false;

    ifstream seedf("seed.txt");
    int seed;
    seedf >> seed;
    srand(seed);
    


    for (round = 0; round < 30; round++) {
        if ((plagiarist.ReturnPrestiege() > 0) && (piffle_paper.ReturnPrestiege() > 0)) {
            cout << "  ROUND " << round + 1 << endl;



            cout << plagiarist.ReturnName() << " draws ";
            cout << plagiaristDeck[deckIndex]->returnName();
            cout << " (power = " << plagiaristDeck[deckIndex]->returnPower() << ")" << endl;


            //set card index to hand
            plagiaristHand1.push_back(deckIndex);




            //get card from hand to table
            //update table
            if (plagiaristHand1.size() != 0) {
                if (plagiaristHand1.size() > 1) {

                    if (Random(2) == 1) {
                        plagiaristCardCounter = plagiaristHand1.back();
                        plagiaristHand1.pop_back();
                        plagiaristTable.push_back(plagiaristCardCounter);
                        plagiaristHandEmpty = false;

                    }
                    else {
                        plagiaristCardCounter = plagiaristHand1.front();
                        plagiaristHand1.erase(plagiaristHand1.begin());
                        plagiaristTable.push_back(plagiaristCardCounter);
                        plagiaristHandEmpty = false;
                    }
                }
                else {
                    plagiaristCardCounter = plagiaristHand1.back();
                    plagiaristHand1.pop_back();
                }

            }
            else if (plagiaristHand1.size() == 0) { plagiaristHandEmpty = true; }

            //display playing card from table
            if (plagiaristHandEmpty == false) {
                cout << plagiarist.ReturnName() << " plays ";
                cout << plagiaristDeck[plagiaristCardCounter]->returnName();
                cout << " (power = " << plagiaristDeck[plagiaristCardCounter]->returnPower() << ")" << endl;
            }
            else { cout << "no card is played" << endl; }

            //display prof plagiarists table
            cout << "Professor Plagiarist's table =";
            for (int i = 0; i < plagiaristTable.size(); i++) {
                //int playerCardIndex = plagiaristTable[i];
                cout << plagiaristDeck[plagiaristTable[i]]->returnName() << " (resilience : " << plagiaristDeck[plagiaristTable[i]]->ReturnResilience() << ") ";

            }
            cout << endl;
           




            //a players table can attack only if there are cards on the table, which is being checked here
            if (plagiaristTable.size() != 0) {
                //if card is of type 2
                if (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 2) {
                    //cardToAttack is an index of the enemies table, generated randomly
                    int cardToAttack = Random(piffle_paperTable.size());
                    cout << endl << plagiaristDeck[plagiaristTable.back()]->returnName() << " (power = " << plagiaristDeck[plagiaristTable.back()]->returnPower() << ")" << " attacks ";
                    if (piffle_paperTable.size() > 0) {

                        //that index is set as the index to the enemies card list
                        //display name and resilience of card being attacked
                        cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName();
                        cout << " (Resilience = " << piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience() << ")" << endl;



                        //if resilience of card to above 0 after being attacked
                        if (((piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable.back()]->returnPower())) > 0) {
                            //update resilience value of that card
                            piffle_paperDeck[piffle_paperTable[cardToAttack]]->UpdateResilience(((piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable.back()]->returnPower())));
                            //display resilience of card
                            cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName() << "'s resilience is now: " << piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience() << endl;

                        }
                        else {
                            //display name of card that is defeated
                            cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName() << " is defeated";
                            //delete card
                            piffle_paperTable.erase(piffle_paperTable.begin() + cardToAttack);


                        }
                    }

                    //if enemy's table is empty or, random generation function outputs its max value(max=enemy prof)
                    else if ((piffle_paperTable.size() == 0) || (cardToAttack == plagiaristTable.size())) {
                        cout << piffle_paper.ReturnName() << " directly ";
                        //substract prestiege from prof
                        piffle_paper.UpdatePrestiege(piffle_paper.ReturnPrestiege() - plagiaristDeck[plagiaristTable.back()]->returnPower());
                        //display new prestiege
                        cout << endl << piffle_paper.ReturnName() << "'s presitge is now ";
                        cout << piffle_paper.ReturnPrestiege() << endl;

                    }
                    //delete card from table after attacking
                    cout << plagiaristDeck[plagiaristTable.back()]->returnName() << " is removed from the table";
                    plagiaristTable.pop_back();

                }



                //if card is of type 3
                else if (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 3) {

                    //clear vector from past runs
                    cardsToDelete.clear();
                    cout << endl << plagiaristDeck[plagiaristTable.back()]->returnName() << " (power = " << plagiaristDeck[plagiaristTable.back()]->returnPower() << ")" << " attacks ";

                    int enemyTableSize = piffle_paperTable.size();
                    //loop for each card in the enemy's table
                    for (int i = 0; i < piffle_paperTable.size(); i++) {

                        cout << piffle_paperDeck[piffle_paperTable[i]]->returnName();
                        cout << " (Resilience = " << piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience() << ")" << endl;

                        //if attacked cards resilience is >0
                        if (((piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable.back()]->returnPower())) > 0) {
                            //update resilience
                            piffle_paperDeck[piffle_paperTable[i]]->UpdateResilience(((piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable.back()]->returnPower())));
                            //display
                            cout << piffle_paperDeck[piffle_paperTable[i]]->returnName() << "'s resilience is now: " << piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience() << endl;

                        }
                        else {
                            cout << piffle_paperDeck[piffle_paperTable[i]]->returnName() << " has 0 resilience";
                            //index of card added to this list
                            cardsToDelete.push_back(i);


                        }

                    }
                  
                    //delete cards which are 0 resilience 
                    //when a card is deleted, the whole vector gets pulled back by 1, so if theres another card to delete, it must delete the card that was pulled back, not the original index
                    if (cardsToDelete.size() > 0) {
                        for (int i = 0; i < cardsToDelete.size(); i++) {
                            piffle_paperTable.erase(piffle_paperTable.begin() + cardsToDelete[i] - i);
                        }
                    }

                    //delete card from table
                    cout << plagiaristDeck[plagiaristTable.back()]->returnName() << " is removed from the table";
                    plagiaristTable.pop_back();

                }

                //if card is of type 4
                else if (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 4) {
                    ;
                    cout << endl << plagiaristDeck[plagiaristTable.back()]->returnName();

                    //since this card attacks(or boosts) either the enemy or their allies, for the random function ive passed the length of both tables
                    int cardToAttack = Random(piffle_paperTable.size() + plagiaristTable.size());
                    //attacking the enemy
                    if (cardToAttack <= piffle_paperTable.size()) {
                        //attacking the enemy table
                        if (cardToAttack < piffle_paperTable.size()) {
                            cout << " (power = " << plagiaristDeck[plagiaristTable.back()]->returnPower() << ")" << " attacks ";
                            cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName();
                            cout << " (Resilience = " << piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience() << ")" << endl;



                            //if resilience of card to above 0 after being attacked
                            if (((piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable.back()]->returnPower())) > 0) {
                                //update resilience value of that card
                                piffle_paperDeck[piffle_paperTable[cardToAttack]]->UpdateResilience(((piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable.back()]->returnPower())));
                                //display resilience of card
                                cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName() << "'s resilience is now: " << piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience() << endl;

                            }
                            else {
                                //display name of card that is defeated
                                cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName() << " is defeated";
                                //delete card
                                piffle_paperTable.erase(piffle_paperTable.begin() + cardToAttack);


                            }
                        }
                        //attacking the enemy prof
                        else if (cardToAttack == piffle_paperTable.size()) {
                            cout << piffle_paper.ReturnName() << " directly ";
                            //substract prestiege from prof
                            piffle_paper.UpdatePrestiege(piffle_paper.ReturnPrestiege() - plagiaristDeck[plagiaristTable.back()]->returnPower());
                            //display new prestiege
                            cout << endl << piffle_paper.ReturnName() << "'s presitge is now ";
                            cout << piffle_paper.ReturnPrestiege() << endl;
                        }

                    }
                    //boosting their allies
                    else if (cardToAttack > piffle_paperTable.size()) {
                        cout << " (power = " << plagiaristDeck[plagiaristTable.back()]->ReturnBoost() << ")" << " boosts ";
                        
                        //ive used the same "cardToAttack" variable eventhough it isnt exactly being attacked, but making a new variable doesnt make much sense

                        if (cardToAttack == piffle_paperTable.size() + 1) {

                            cardToAttack = cardToAttack - 1;
                        }
                        //boosting their table
                        if (cardToAttack < piffle_paperTable.size() + plagiaristTable.size()) {
                            //output rext
                            cout << plagiaristDeck[plagiaristTable[cardToAttack - piffle_paperTable.size()]]->returnName() << " " << plagiaristDeck[plagiaristTable[cardToAttack - piffle_paperTable.size()]]->ReturnResilience()<<endl;
                           //num : new resilience
                            int num = plagiaristDeck[plagiaristTable.back()]->ReturnBoost() + plagiaristDeck[plagiaristTable[cardToAttack - piffle_paperTable.size()]]->ReturnResilience();
                            //update resilience
                            plagiaristDeck[plagiaristTable[cardToAttack - piffle_paperTable.size()]]->UpdateResilience(num);
                            //output new resilience
                            cout << plagiaristDeck[plagiaristTable[cardToAttack - piffle_paperTable.size()]]->returnName() << "'s resilience is now " << plagiaristDeck[plagiaristTable[cardToAttack - piffle_paperTable.size()]]->ReturnResilience();
                        }
                        else if (cardToAttack == piffle_paperTable.size() + plagiaristTable.size()) {
                            cout << plagiarist.ReturnName();
                            int num = plagiaristDeck[plagiaristTable.back()]->ReturnBoost() + plagiarist.ReturnPrestiege();
                            plagiarist.UpdatePrestiege(num);
                            cout << plagiarist.ReturnName() << "'s prestiege = " << plagiarist.ReturnPrestiege();

                        }
                    }
                    cout << plagiaristDeck[plagiaristTable.back()]->returnName() << " is removed from the table";
                    plagiaristTable.pop_back();

                }


                //if card played is of an unimplemented type, itll be removed from the table
                else if ((plagiaristDeck[plagiaristTable.back()]->ReturnType() == 6) || (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 7) || (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 8)
                    || (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 9) || (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 10) || (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 11)) {
                        cout << plagiaristDeck[plagiaristTable.back()]->returnName() << " is unplayable and is removed from the table" << endl;

                        plagiaristTable.pop_back();

                }

                //activating the students in the table
                if (plagiaristTable.size() > 0) {
                    if ((plagiaristDeck[plagiaristTable.back()]->ReturnType() == 1) || (plagiaristDeck[plagiaristTable.back()]->ReturnType() == 5)) {
                        //activating the students (the table) as the final event of a players turn,
                    //As mentioned in the brief ->"The final operation of each players’ turn is to activate the students in their professor’s Table"
                        for (int i = plagiaristTable.size() - 1; i >= 0; i--) {

                            //display name and power
                            cout << endl << plagiaristDeck[plagiaristTable[i]]->returnName() << " (power = " << plagiaristDeck[plagiaristTable[i]]->returnPower() << ")" << " attacks ";




                            int cardToattack;
                            if (piffle_paperTable.size() > 0) {

                                cardToattack = Random(piffle_paperTable.size());

                                //display name of card being attacked
                                cout << piffle_paperDeck[piffle_paperTable[cardToattack]]->returnName();
                                cout << " (Resilience = " << piffle_paperDeck[piffle_paperTable[cardToattack]]->ReturnResilience() << ")" << endl;


                                //if resilience > 0
                                if (((piffle_paperDeck[piffle_paperTable[cardToattack]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable[i]]->returnPower())) > 0) {
                                    piffle_paperDeck[piffle_paperTable[cardToattack]]->UpdateResilience(((piffle_paperDeck[piffle_paperTable[cardToattack]]->ReturnResilience()) - (plagiaristDeck[plagiaristTable[i]]->returnPower())));
                                    cout << piffle_paperDeck[piffle_paperTable[cardToattack]]->returnName() << "'s resilience is now: " << piffle_paperDeck[piffle_paperTable[cardToattack]]->ReturnResilience() << endl;

                                }
                                else {
                                    cout << piffle_paperDeck[piffle_paperTable[cardToattack]]->returnName() << " is defeated";
                                    piffle_paperTable.erase(piffle_paperTable.begin() + cardToattack);


                                }
                            }
                            else if (piffle_paperTable.size() == 0) {
                                cout << piffle_paper.ReturnName() << " directly ";
                                //substract prestiege from prof
                                piffle_paper.UpdatePrestiege(piffle_paper.ReturnPrestiege() - plagiaristDeck[plagiaristTable[i]]->returnPower());
                                //display new prestiege
                                cout << endl << piffle_paper.ReturnName() << "'s prestige is now ";
                                cout << piffle_paper.ReturnPrestiege() << endl;

                            }

                            if (plagiaristDeck[plagiaristTable[i]]->ReturnType() == 5) {
                                plagiaristDeck[plagiaristTable[i]]->UpdateResilience(plagiaristDeck[plagiaristTable[i]]->ReturnResilience() + 1);
                                cout << plagiaristDeck[plagiaristTable[i]]->returnName() << "'s resilience is now: " << plagiaristDeck[plagiaristTable[i]]->ReturnResilience() << endl;
                            }
                            
                        }
                    }
                }



            }

            cout << endl;

            //-------------------------------------------------
            //functions for professor piffle paper is the same as professor plagiarist
            //only difference is the names are swapped



            cout << piffle_paper.ReturnName() << " draws ";

            cout << piffle_paperDeck[deckIndex]->returnName();
            cout << " (power = " << piffle_paperDeck[deckIndex]->returnPower() << ")" << endl;


            //set card index to hand

            piffle_paperHand1.push_back(deckIndex);



            //get card from hand to table


            if (piffle_paperHand1.size() != 0) {
                if (Random(2) == 0) {

                    piffle_paperCardCounter = piffle_paperHand1.back();
                    piffle_paperHand1.pop_back();
                    piffle_paperTable.push_back(piffle_paperCardCounter);
                    piffle_paperHandEmpty = false;
                }
                else {

                    piffle_paperCardCounter = piffle_paperHand1.front();
                    if (piffle_paperHand1.size() > 1) {
                        piffle_paperHand1.erase(piffle_paperHand1.begin());
                    }
                    else { piffle_paperHand1.pop_back(); }
                    piffle_paperTable.push_back(piffle_paperCardCounter);
                    piffle_paperHandEmpty = false;
                }


            }
            else { piffle_paperHandEmpty = true; }



            //update table


            //display drawn card

            //if card type is in current implemented mark, itll be sent to the hand, if not its discarded and no card is drawn for this round
            //(as is mentioned in the Q&A)

            //display playing card from table
            if (piffle_paperHandEmpty == false) {
                cout << piffle_paper.ReturnName() << " plays ";
                cout << piffle_paperDeck[piffle_paperCardCounter]->returnName();
                cout << " (power = " << piffle_paperDeck[plagiaristCardCounter]->returnPower() << ")" << endl;
            }
            else { cout << "no play" << endl; }


            //display prof plagiarists table
            cout << "Professor piffle_paper's table =";
            for (int i = 0; i < piffle_paperTable.size(); i++) {
                //int playerCardIndex = plagiaristTable[i];
                cout << piffle_paperDeck[piffle_paperTable[i]]->returnName() << " (resilience : " << piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience() << ") ";

            }
            cout << endl;


            if (piffle_paperTable.size() != 0) {

                //if card is of type 2
                if (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 2) {
                    //cardToAttack is an index of the enemies table, generated randomly
                    int cardToAttack = Random(plagiaristTable.size());
                    cout << endl << piffle_paperDeck.back()->returnName() << " (power = " << piffle_paperDeck.back()->returnPower() << ")" << " attacks ";
                    if (plagiaristTable.size() > 0) {

                        //that index is set as the index to the enemies card list

                        //display name and resilience of card being attacked
                        cout << plagiaristDeck[plagiaristTable[cardToAttack]]->returnName();
                        cout << " (Resilience = " << plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience() << ")" << endl;



                        //if resilience of card to above 0 after being attacked
                        if (((plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience()) - (piffle_paperDeck[piffle_paperTable.back()]->returnPower())) > 0) {
                            //update resilience value of that card
                            plagiaristDeck[plagiaristTable[cardToAttack]]->UpdateResilience(((plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience()) - piffle_paperDeck[piffle_paperTable.back()]->returnPower()));
                            //display resilience of card
                            cout << plagiaristDeck[plagiaristTable[cardToAttack]]->returnName() << "'s resilience is now: " << plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience() << endl;

                        }
                        else {
                            //display name of card that is defeated
                            cout << plagiaristDeck[plagiaristTable[cardToAttack]]->returnName() << " is defeated";
                            //delete card
                            plagiaristTable.erase(plagiaristTable.begin() + cardToAttack);


                        }
                    }

                    //if enemy's table is empty or, random generation function outputs its max value(max=enemy prof)
                    else if ((plagiaristTable.size() == 0) || (cardToAttack == piffle_paperTable.size())) {
                        cout << plagiarist.ReturnName() << " directly ";
                        //substract prestiege from prof
                        plagiarist.UpdatePrestiege(plagiarist.ReturnPrestiege() - piffle_paperDeck[piffle_paperTable.back()]->returnPower());
                        //display new prestiege
                        cout << endl << plagiarist.ReturnName() << "'s presitge is now ";
                        cout << plagiarist.ReturnPrestiege() << endl;

                    }
                    //delete card from table
                    cout << piffle_paperDeck[piffle_paperTable.back()]->returnName() << " is removed from the table" << endl;
                    plagiaristTable.pop_back();

                }



                //if card is of type 3
                else if (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 3) {

                    //clear vector from past runs
                    cardsToDelete.clear();


                    int enemyTableSize = plagiaristTable.size();
                    //loop for each card in the enemy's table
                    for (int i = 0; i < plagiaristTable.size(); i++) {

                        cout << endl << piffle_paperDeck[piffle_paperTable.back()]->returnName() << " (power = " << piffle_paperDeck[piffle_paperTable.back()]->returnPower() << ")" << " attacks ";
                        cout << plagiaristDeck[plagiaristTable[i]]->returnName();
                        cout << " (Resilience = " << plagiaristDeck[plagiaristTable[i]]->ReturnResilience() << ")" << endl;

                        //if attacked cards resilience is >0
                        if (((plagiaristDeck[plagiaristTable[i]]->ReturnResilience()) - (piffle_paperDeck[piffle_paperTable.back()]->returnPower())) > 0) {
                            //update resilience
                            plagiaristDeck[plagiaristTable[i]]->UpdateResilience(((plagiaristDeck[plagiaristTable[i]]->ReturnResilience()) - (piffle_paperDeck[piffle_paperTable.back()]->returnPower())));
                            //display
                            cout << plagiaristDeck[plagiaristTable[i]]->returnName() << "'s resilience is now: " << plagiaristDeck[plagiaristTable[i]]->ReturnResilience() << endl;

                        }
                        else {
                            cout << plagiaristDeck[plagiaristTable[i]]->returnName() << " has 0 resilience";
                            //index of card added to this list
                            cardsToDelete.push_back(i);


                        }

                    }
                   
                    //delete cards which are 0 resilience 
                    if (cardsToDelete.size() > 0) {
                        for (int i = 0; i < cardsToDelete.size(); i++) {
                            plagiaristTable.erase(plagiaristTable.begin() + cardsToDelete[i] - i);
                        }
                    }
                    cout << endl << piffle_paperDeck[piffle_paperTable.back()]->returnName() << " (power = " << piffle_paperDeck[piffle_paperTable.back()]->returnPower() << ")" << " attacks ";
                    cout << plagiarist.ReturnName() << " directly ";
                    //substract prestiege from prof
                    plagiarist.UpdatePrestiege(plagiarist.ReturnPrestiege() - piffle_paperDeck[piffle_paperTable.back()]->returnPower());
                    //display new prestiege
                    cout << endl << plagiarist.ReturnName() << "'s prestige is now ";
                    cout << plagiarist.ReturnPrestiege() << endl;

                    //delete card from table
                    cout << piffle_paperDeck[piffle_paperTable.back()]->returnName() << " is removed from the table" << endl;
                    piffle_paperTable.pop_back();

                }

                else if (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 4) {
                    ;
                    cout << endl << piffle_paperDeck[piffle_paperTable.back()]->returnName();

                    int cardToAttack = Random(plagiaristTable.size() + plagiaristTable.size());
                    if (cardToAttack <= plagiaristTable.size()) {
                        cout << " (power = " << piffle_paperDeck[piffle_paperTable.back()]->returnPower() << ")" << " attacks ";
                        if (cardToAttack < plagiaristTable.size()) {
                            cout << plagiaristDeck[plagiaristTable[cardToAttack]]->returnName();
                            cout << " (Resilience = " << plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience() << ")" << endl;



                            //if resilience of card to above 0 after being attacked
                            if (((plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience()) - (piffle_paperDeck[piffle_paperTable.back()]->returnPower())) > 0) {
                                //update resilience value of that card
                                plagiaristDeck[plagiaristTable[cardToAttack]]->UpdateResilience(((plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience()) - (piffle_paperDeck[plagiaristTable.back()]->returnPower())));
                                //display resilience of card
                                cout << plagiaristDeck[plagiaristTable[cardToAttack]]->returnName() << "'s resilience is now: " << plagiaristDeck[plagiaristTable[cardToAttack]]->ReturnResilience() << endl;

                            }
                            else {
                                //display name of card that is defeated
                                cout << plagiaristDeck[plagiaristTable[cardToAttack]]->returnName() << " is defeated";
                                //delete card
                                plagiaristTable.erase(plagiaristTable.begin() + cardToAttack);


                            }
                        }
                        else if (cardToAttack == plagiaristTable.size()) {
                            cout << plagiarist.ReturnName() << " directly ";
                            //substract prestiege from prof
                            plagiarist.UpdatePrestiege(plagiarist.ReturnPrestiege() - piffle_paperDeck[piffle_paperTable.back()]->returnPower());
                            //display new prestiege
                            cout << endl << plagiarist.ReturnName() << "'s presitge is now ";
                            cout << plagiarist.ReturnPrestiege() << endl;
                        }

                    }
                    else if (cardToAttack > plagiaristTable.size()) {
                        cout << " (power = " << piffle_paperDeck[piffle_paperTable.back()]->ReturnBoost() << ")" << " boosts ";
                        if (cardToAttack < plagiaristTable.size() + piffle_paperTable.size()) {
                            if (cardToAttack = plagiaristTable.size() + 1) {
                                cardToAttack = cardToAttack + 1;
                            }
                            cout << piffle_paperDeck[piffle_paperTable[cardToAttack]]->returnName() << " " << piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience();
                            int num = piffle_paperDeck[piffle_paperTable.back()]->ReturnBoost() + piffle_paperDeck[piffle_paperTable[cardToAttack]]->ReturnResilience();
                            piffle_paperDeck[piffle_paperTable[cardToAttack]]->UpdateResilience(num);
                        }
                        else if (cardToAttack == piffle_paperTable.size() + plagiaristTable.size()) {

                        }
                    }
                    cout << piffle_paperDeck[piffle_paperTable.back()]->returnName() << " is removed from the table" << endl;
                    piffle_paperTable.pop_back();

                }



                else if ((piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 6) || (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 7) || (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 8)
                    || (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 9) || (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 10) || (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 11)) {
                        cout << piffle_paperDeck[piffle_paperTable.back()]->returnName() << " is unplayable and is removed from the table" << endl;
                    piffle_paperTable.pop_back();

                }
                if (piffle_paperTable.size() > 0) {
                    if ((piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 1) || (piffle_paperDeck[piffle_paperTable.back()]->ReturnType() == 5)) {
                        //activating the students (the table) as the final event of a players turn,
                    //As mentioned in the brief ->"The final operation of each players’ turn is to activate the students in their professor’s Table"
                        for (int i = piffle_paperTable.size() - 1; i >= 0; i--) {

                            //display name and power
                            cout << endl << piffle_paperDeck[piffle_paperTable[i]]->returnName() << " (power = " << piffle_paperDeck[piffle_paperTable[i]]->returnPower() << ")" << " attacks ";





                            if (plagiaristTable.size() > 0) {
                                int cardToattack;

                                cardToattack = Random(plagiaristTable.size());




                                //display name of card being attacked
                                cout << plagiaristDeck[plagiaristTable[cardToattack]]->returnName();
                                cout << " (Resilience = " << plagiaristDeck[plagiaristTable[cardToattack]]->ReturnResilience() << ")" << endl;


                                //if resilience > 0
                                if (((plagiaristDeck[plagiaristTable[cardToattack]]->ReturnResilience()) - (piffle_paperDeck[piffle_paperTable[i]]->returnPower())) > 0) {
                                    plagiaristDeck[plagiaristTable[cardToattack]]->UpdateResilience(((plagiaristDeck[plagiaristTable[cardToattack]]->ReturnResilience()) - (piffle_paperDeck[piffle_paperTable[i]]->returnPower())));
                                    cout << plagiaristDeck[plagiaristTable[cardToattack]]->returnName() << "'s resilience is now: " << plagiaristDeck[plagiaristTable[cardToattack]]->ReturnResilience() << endl;

                                }
                                else {
                                    cout << plagiaristDeck[plagiaristTable[cardToattack]]->returnName() << " is defeated";
                                    plagiaristTable.erase(plagiaristTable.begin() + cardToattack);


                                }
                            }
                            else if (plagiaristTable.size() == 0) {


                                cout << plagiarist.ReturnName() << " directly ";
                                //substract prestiege from prof
                                plagiarist.UpdatePrestiege(plagiarist.ReturnPrestiege() - piffle_paperDeck[piffle_paperTable[i]]->returnPower());
                                //display new prestiege
                                cout << endl << plagiarist.ReturnName() << "'s presitge is now ";
                                cout << plagiarist.ReturnPrestiege() << endl;

                            }

                            if (piffle_paperDeck[piffle_paperTable[i]]->ReturnType() == 5) {
                                piffle_paperDeck[piffle_paperTable[i]]->UpdateResilience(piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience() + 1);
                                cout << piffle_paperDeck[piffle_paperTable[i]]->returnName() << "'s resilience is now: " << piffle_paperDeck[piffle_paperTable[i]]->ReturnResilience() << endl;
                            }
                         
                        }
                    }
                }



            }

            cout << endl;

            deckIndex++;

        }
        if (round == 30) {
            cout << "Game Over" << endl;
            cout << plagiarist.ReturnName() << "'s prestige is " << plagiarist.ReturnPrestiege() << endl;
            cout << piffle_paper.ReturnName() << "'s prestige is " << piffle_paper.ReturnPrestiege() << endl;
            if (plagiarist.ReturnPrestiege() > piffle_paper.ReturnPrestiege()) {
                cout << plagiarist.ReturnName() << " Wins!";
            }
            else  if (plagiarist.ReturnPrestiege() < piffle_paper.ReturnPrestiege()) {
                cout << piffle_paper.ReturnName() << " Wins!";
            }
            else if (plagiarist.ReturnPrestiege() == piffle_paper.ReturnPrestiege()) {
                cout << "Both professors have the same prestige, game ends in draw";
            }


        }
        if (plagiarist.ReturnPrestiege() <= 0) {
            cout << plagiarist.ReturnName() << " has no prestige and is Sacked!!";
            break;
        }
        else  if (piffle_paper.ReturnPrestiege() <= 0) {
            cout << piffle_paper.ReturnName() << " has no prestige and is Sacked!!";
            break;
        }
       
    }
   

    for (auto CCard : plagiaristDeck) {
        delete CCard;
    }
    for (auto CCard : piffle_paperDeck) {
        delete CCard;
    }
   
     _CrtDumpMemoryLeaks();

}