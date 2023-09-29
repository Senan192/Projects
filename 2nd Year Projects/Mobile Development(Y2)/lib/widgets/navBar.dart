import 'package:co2404_coursework_pluggedin/screens/2HomePage.dart';
import 'package:co2404_coursework_pluggedin/screens/4ListsPage.dart';
import 'package:flutter/material.dart';
import 'package:co2404_coursework_pluggedin/screens/3FavouritesPage.dart';
import 'package:page_transition/page_transition.dart';

import '../screens/3FavouritesPage.dart';

class navbar extends StatelessWidget {
  final Color homeColour, watchListColour, trendingColour;

  const navbar({super.key, required this.homeColour, required this.watchListColour, required this.trendingColour});


  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height * 0.1,
      width: MediaQuery.of(context).size.width ,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          SizedBox(
            height: MediaQuery.of(context).size.height * 0.05,
            width: MediaQuery.of(context).size.width * 0.3,
            child: ElevatedButton.icon(

              style: ElevatedButton.styleFrom(shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(12), // <-- Radius
              ),backgroundColor: homeColour),
              onPressed: () {
                Navigator.push(
                  context,
                  PageTransition(
                      type: PageTransitionType.fade,
                      child: homeScreen(),
                      inheritTheme: true,
                      ctx: context),
                );
              },
                icon: Icon(Icons.home,color: Colors.black,),
                label: const Text(
                  'Home',
                  style: TextStyle(color: Colors.black, fontSize: 13.0),
                ),
            ),
          ),
          SizedBox(
            height: MediaQuery.of(context).size.height * 0.05,
            width: MediaQuery.of(context).size.width * 0.3,
            child: ElevatedButton.icon(
              style: ElevatedButton.styleFrom(shape:RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(12), // <-- Radius
              ),backgroundColor: watchListColour),
              onPressed: () {
                Navigator.push(
                  context,
                  PageTransition(
                      type: PageTransitionType.fade,
                      child: watchList(),
                      inheritTheme: true,
                      ctx: context),
                );
              },
                icon: Icon(Icons.favorite,color: Colors.black,),
                label: const Text(
                  'Favourites',
                  style: TextStyle(color: Colors.white, fontSize: 12.0,),
                ),

            ),
          ),

          SizedBox(
            height: MediaQuery.of(context).size.height * 0.05,
            width: MediaQuery.of(context).size.width * 0.3,
            child: ElevatedButton.icon(
              style: ElevatedButton.styleFrom(shape:RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(12), // <-- Radius
              ),backgroundColor: trendingColour),
              onPressed: () {

                Navigator.push(
                  context,
                  PageTransition(
                      type: PageTransitionType.fade,
                      child: trendingScreen(),
                      inheritTheme: true,
                      ctx: context),
                );
              },
              icon: Icon(Icons.list_sharp,color: Colors.black,),
              label: const Text(
                'Trending',
                style: TextStyle(color: Colors.white, fontSize: 13.0),
              ),

            ),
          ),


        ],
      ),
    );
  }
}

