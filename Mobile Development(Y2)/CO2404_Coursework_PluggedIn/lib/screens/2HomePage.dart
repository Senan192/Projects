import 'package:co2404_coursework_pluggedin/widgets/TVSeries.dart';
import 'package:co2404_coursework_pluggedin/widgets/aboutAppWidget.dart';
import 'package:co2404_coursework_pluggedin/widgets/carousel.dart';
import 'package:co2404_coursework_pluggedin/widgets/navBar.dart';
import 'package:co2404_coursework_pluggedin/widgets/TopTVSeries.dart';
import 'package:co2404_coursework_pluggedin/widgets/TopRated.dart';
import 'package:co2404_coursework_pluggedin/widgets/TrendingMovies.dart';
import 'package:co2404_coursework_pluggedin/widgets/UpcomingMoviesSlider.dart';
import 'package:flutter/material.dart';
import 'package:tmdb_api/tmdb_api.dart';
import 'package:flutter/widgets.dart';
import 'package:connection_notifier/connection_notifier.dart';
import 'package:google_fonts/google_fonts.dart';

 class homeScreen extends StatefulWidget {
   const homeScreen({Key? key}) : super(key: key);

   @override
   State<homeScreen> createState() => _homeScreenState();
 }
 
 class _homeScreenState extends State<homeScreen> {

   //Api key and read access token taken from tmdb site
   final String apikey = '2006914bad323cfb8b7346303c8ccbf5';
   final String readaccesstoken =
       'eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyMDA2OTE0YmFkMzIzY2ZiOGI3MzQ2MzAzYzhjY2JmNSIsInN1YiI6IjYzZjIzYzA1YTY3MjU0MDA3ZGU5MGUyZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.JpZJggCrsY87pcwUMscMnsRWr8g3ZyjpSKs2wjPM218';

   List trendingmovies = [];
   List topratedmovies = [];
   List moviesPopular =[];
   List moviesUpcoming =[];
   List tvSeries = [];
   List tvTopRated =[];
   //once lists have been loaded from the api the loading function will be set as false
   bool loading =true;


   //init function to get data from api
   @override
   void initState() {
     super.initState();
     loadmovies();
   }

   loadmovies() async {
     TMDB tmdb = TMDB(
       ApiKeys(apikey, readaccesstoken),
     );

     Map trendingJSON = await tmdb.v3.trending.getTrending();
     Map moviesTopratedJSON = await tmdb.v3.movies.getTopRated();
     Map tvJSON = await tmdb.v3.tv.getPopular();
     Map tvTopRatedJSON = await tmdb.v3.tv.getTopRated();
     Map moviesPopluarJSON = await tmdb.v3.movies.getPopular();
     Map moviesUpcomingJSON = await tmdb.v3.movies.getUpcoming();

     setState(() {
       trendingmovies = trendingJSON['results'];
       topratedmovies = moviesTopratedJSON['results'];
       tvSeries = tvJSON['results'];
       tvTopRated= tvTopRatedJSON['results'];
       moviesPopular= moviesPopluarJSON['results'];
       moviesUpcoming= moviesUpcomingJSON['results'];
       loading=false;
     });

   }

   int viewState=1;
   @override
   Widget build(BuildContext context) {
     return Scaffold(
       backgroundColor: Colors.black,
       appBar: AppBar(title: Text('PluggedIn',style:  GoogleFonts.rubik(),),centerTitle: true,titleTextStyle: TextStyle(color: Colors.black,fontWeight: FontWeight.bold,fontSize: 20),
       backgroundColor: Colors.yellowAccent,automaticallyImplyLeading: false,
         ),

         body:
         Container(
           child: Column(
             children: [

               Expanded(child: SingleChildScrollView(
                 physics: BouncingScrollPhysics(),
                 child: Column(
                   children: [
                     ConnectionNotifierToggler(
                       onConnectionStatusChanged: (connected) {
                         if (connected == null) return;
                         print(connected);
                       },
                       connected: Text(" "),
                       disconnected: Container(width: double.infinity,
                       height: MediaQuery.of(context).size.height * 0.03,
                       color: Colors.red,
                         child: Text("Connection Error, Please Check Your Connection"),
                       ),

                     ),
                     carouselSliderWidget(trending: trendingmovies, loading: loading,),
                     SizedBox(height: MediaQuery.of(context).size.height * 0.01,),

                    // Button for switching between list view and grid view
                       Container(alignment: Alignment.centerLeft,
                         child: IconButton(
                           icon: viewState == 0 ? Icon(Icons.list,color: Colors.white,) : Icon(Icons.grid_view,color: Colors.white,),
                           onPressed: () {setState(() {if (viewState == 0) {viewState = 1;} else {viewState = 0;}});},
                         ),
                       ),

                     viewState ==0?TrendingMoviesSlider(trending: moviesPopular, loading: loading,):TrendingMoviesList(trending: moviesPopular, loading: loading,),
                     viewState ==0? TopTVSeriesSlider(latest: tvTopRated, loading: loading,): TopTVSeriesList(latest: tvTopRated, loading: loading,),
                     viewState ==0? MoviesUpcomingSlider(upcoming: moviesUpcoming, loading: loading,):MoviesUpcomingList(upcoming: moviesUpcoming, loading: loading,),
                     viewState ==0? TopRatedMoviesSlider(toprated: topratedmovies, loading: loading,):TopRatedMoviesList(toprated: topratedmovies, loading: loading,),
                     viewState ==0? TVSeries(TV: tvSeries, loading: loading,):TVSeriesList(TV: tvSeries, loading: loading,),

                     SizedBox(height: MediaQuery.of(context).size.height * 0.03,),
                     aboutApp(),
                   ],
                 ),
               ),),
               navbar(homeColour: Colors.yellowAccent, watchListColour: Colors.grey, trendingColour: Colors.grey,),

             ],
           )
         )

     );
   }
 }