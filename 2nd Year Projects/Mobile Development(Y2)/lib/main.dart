import 'package:co2404_coursework_pluggedin/screens/4ListsPage.dart';
import 'package:co2404_coursework_pluggedin/screens/3FavouritesPage.dart';
import 'package:flutter/material.dart';
import 'package:path/path.dart';
import 'screens/2HomePage.dart';
import 'screens/1StartPage.dart';
import 'screens/movieInfoPage.dart';

void main() =>runApp(MaterialApp(
  initialRoute: ' /start',
  routes: {
    '/' :(context) => start(),
    '/homePage' : (context) => homeScreen(),
    '/tredingPage' : (context) => trendingScreen(),
    '/watchListPage' : (context) => watchList(),
    //the movie page hasnt been added as parameters from movie db has to be passed

  },

)
);