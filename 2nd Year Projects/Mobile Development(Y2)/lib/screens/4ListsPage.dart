import 'dart:ui';

import 'package:co2404_coursework_pluggedin/widgets/navBar.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:tmdb_api/tmdb_api.dart';

class trendingScreen extends StatefulWidget {
  const trendingScreen({Key? key}) : super(key: key);

  @override
  State<trendingScreen> createState() => _trendingScreenState();
}

class _trendingScreenState extends State<trendingScreen> {
  final String apikey = '2006914bad323cfb8b7346303c8ccbf5';
  final String readaccesstoken =
      'eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIyMDA2OTE0YmFkMzIzY2ZiOGI3MzQ2MzAzYzhjY2JmNSIsInN1YiI6IjYzZjIzYzA1YTY3MjU0MDA3ZGU5MGUyZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.JpZJggCrsY87pcwUMscMnsRWr8g3ZyjpSKs2wjPM218';
  List trendingmovies = [];
  List topratedmovies = [];
  List tv = [];
  List newMovies =[];
  bool loading =true;

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
    Map topratedJSON= await tmdb.v3.movies.getTopRated();
    Map tvJSON = await tmdb.v3.tv.getPopular();
    Map newMoviesJSON = await tmdb.v3.movies.getUpcoming();

    setState(() {
      trendingmovies = trendingJSON['results'];
      topratedmovies = topratedJSON['results'];
      tv = tvJSON['results'];
      newMovies= newMoviesJSON['results'];
      loading=false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('PluggedIn',style:  GoogleFonts.rubik(),),centerTitle: true,titleTextStyle: TextStyle(color: Colors.black,fontWeight: FontWeight.bold,fontSize: 20),
        backgroundColor: Colors.yellowAccent,automaticallyImplyLeading: false,),

      body: Container(
        color: Colors.black,
        child: Column(
          children: [
            Expanded(child: SingleChildScrollView(
                child:
                Container(
                  color: Colors.black,
                  child: Column(
                    children: [
                      SizedBox(height: MediaQuery.of(context).size.height * 0.02,),

                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Container(
                          //padding: const EdgeInsets.all(8.0),
                          child: loading?Center(
                            child: CircularProgressIndicator(),
                          ): Stack(
                            children: [
                              Container(
                                height:MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                child: Stack(
                                  fit: StackFit.expand,
                                  children: [
                                    Image.network('https://image.tmdb.org/t/p/w500' +
                                        trendingmovies[1]['poster_path'],fit: BoxFit.cover,),
                                    ClipRRect(
                                      child: BackdropFilter(filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                                        child: Container(
                                          color: Colors.grey.withOpacity(0.01),
                                        ),),
                                    )
                                  ],
                                ),

                              ),
                              Container(
                                height: MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                //color: Colors.grey,
                                //loading icon until data is fetched from api
                                child: loading?Center(
                                  child: CircularProgressIndicator(),
                                ):Column(
                                  children: [
                                    Text("Top 10 Movies",
                                      style: TextStyle(fontSize: 20,fontWeight: FontWeight.bold,color: Colors.yellowAccent),),
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
                                    //display the 1st 10 movies in the respective list
                                    for(int i=1;i<11;i++)...[
                                      Container(
                                          child: Row(
                                            children: [
                                              Text(" $i ",style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                              Text(trendingmovies[i]['title']??trendingmovies[i]['original_name'],
                                                  style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                            ],
                                          )
                                      ),
                                      SizedBox(height: MediaQuery.of(context).size.height * 0.0125,),
                                    ],
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.03,),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),


                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Container(
                          //padding: const EdgeInsets.all(8.0),
                          child: loading?Center(
                            child: CircularProgressIndicator(),
                          ): Stack(
                            children: [
                              Container(
                                height:MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                child: Stack(
                                  fit: StackFit.expand,
                                  children: [
                                    Image.network('https://image.tmdb.org/t/p/w500' +
                                        tv[1]['poster_path'],fit: BoxFit.cover,),
                                    ClipRRect(
                                      child: BackdropFilter(filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                                        child: Container(
                                          color: Colors.grey.withOpacity(0.01),
                                        ),),
                                    )
                                  ],
                                ),

                              ),
                              Container(
                                height: MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                //color: Colors.grey,
                                //loading icon until data is fetched from api
                                child: loading?Center(
                                  child: CircularProgressIndicator(),
                                ):Column(
                                  children: [
                                    Text("Trending TV Series",
                                      style: TextStyle(fontSize: 20,fontWeight: FontWeight.bold,color: Colors.yellowAccent),),
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
                                    //display the 1st 10 movies in the respective list
                                    for(int i=1;i<11;i++)...[
                                      Container(
                                          child: Row(
                                            children: [
                                              Text(" $i ",style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                              Text(tv[i]['title']??tv[i]['original_name'],
                                                  style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                            ],
                                          )
                                      ),
                                      SizedBox(height: MediaQuery.of(context).size.height * 0.005,),
                                    ],
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.03,),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),

                      SizedBox(height: MediaQuery.of(context).size.height * 0.02,),

                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Container(
                          //padding: const EdgeInsets.all(8.0),
                          child: loading?Center(
                            child: CircularProgressIndicator(),
                          ): Stack(
                            children: [
                              Container(
                                height:MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                child: Stack(
                                  fit: StackFit.expand,
                                  children: [
                                    Image.network('https://image.tmdb.org/t/p/w500' +
                                        newMovies[1]['poster_path'],fit: BoxFit.cover,),
                                    ClipRRect(
                                      child: BackdropFilter(filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                                        child: Container(
                                          color: Colors.grey.withOpacity(0.01),
                                        ),),
                                    )
                                  ],
                                ),

                              ),
                              Container(
                                height: MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                //color: Colors.grey,
                                //loading icon until data is fetched from api
                                child: loading?Center(
                                  child: CircularProgressIndicator(),
                                ):Column(
                                  children: [
                                    Text("New Movies",
                                      style: TextStyle(fontSize: 20,fontWeight: FontWeight.bold,color: Colors.yellowAccent),),
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
                                    //display the 1st 10 movies in the respective list
                                    for(int i=1;i<11;i++)...[
                                      Container(
                                          child: Row(
                                            children: [
                                              Text(" $i ",style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                              Text(newMovies[i]['title']??newMovies[i]['original_name'],
                                                  style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                            ],
                                          )
                                      ),
                                      SizedBox(height: MediaQuery.of(context).size.height * 0.0125,),
                                    ],
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.03,),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),

                      SizedBox(height: MediaQuery.of(context).size.height * 0.02,),

                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Container(
                          //padding: const EdgeInsets.all(8.0),
                          child: loading?Center(
                            child: CircularProgressIndicator(),
                          ): Stack(
                            children: [
                              Container(
                                height:MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                child: Stack(
                                  fit: StackFit.expand,
                                  children: [
                                    Image.network('https://image.tmdb.org/t/p/w500' +
                                        topratedmovies[1]['poster_path'],fit: BoxFit.cover,),
                                    ClipRRect(
                                      child: BackdropFilter(filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                                        child: Container(
                                          color: Colors.grey.withOpacity(0.01),
                                        ),),
                                    )
                                  ],
                                ),

                              ),
                              Container(
                                height: MediaQuery.of(context).size.height * 0.5,
                                width: MediaQuery.of(context).size.width,
                                //color: Colors.grey,
                                //loading icon until data is fetched from api
                                child: loading?Center(
                                  child: CircularProgressIndicator(),
                                ):Column(
                                  children: [
                                    Text("All Time Top Rated Movies",
                                      style: TextStyle(fontSize: 20,fontWeight: FontWeight.bold,color: Colors.yellowAccent),),
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
                                    //display the 1st 10 movies in the respective list
                                    for(int i=1;i<11;i++)...[
                                      Container(
                                          child: Row(
                                            children: [
                                              Text(" $i ",style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                              Text(topratedmovies[i]['title']??topratedmovies[i]['original_name'],
                                                  style: TextStyle(fontSize: MediaQuery.of(context).size.width * 0.0325,fontWeight: FontWeight.bold,color: Colors.yellowAccent)),
                                            ],
                                          )
                                      ),
                                      SizedBox(height: MediaQuery.of(context).size.height * 0.0125,),
                                    ],
                                    SizedBox(height: MediaQuery.of(context).size.height * 0.03,),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),




                      SizedBox(height: 20,),
                    ],
                  ),
                )

            )),
            navbar(homeColour: Colors.grey, watchListColour: Colors.grey, trendingColour: Colors.yellow),

          ],
        ),
      )
      );
  }
}