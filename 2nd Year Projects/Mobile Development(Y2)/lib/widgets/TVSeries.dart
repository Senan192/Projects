import 'package:flutter/material.dart';

import '../screens/movieInfoPage.dart';


class TVSeries extends StatelessWidget {
  final List TV;
  final bool loading;

  const TVSeries({Key? key,required this.TV, required this.loading}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            'Popular TV Series',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.025,),
          ),
          SizedBox(height: MediaQuery.of(context).size.height * 0.025),
          Container(
              height:MediaQuery.of(context).size.height * 0.35,
              child: loading?Center(
                child: CircularProgressIndicator(),
              ):ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: TV.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: TV[index]['original_name'], description: TV[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            TV[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            TV[index]['poster_path'], vote: TV[index]['vote_average']
                            .toString()))
                        );
                      },
                      child: Container(
                        width: MediaQuery.of(context).size.width * 0.275,
                        child: Column(
                          children: [
                            Container(
                              decoration: BoxDecoration(
                                image: DecorationImage(
                                  image: NetworkImage(
                                      'https://image.tmdb.org/t/p/w500' +
                                          TV[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.2,
                            ),
                            SizedBox(height:MediaQuery.of(context).size.height * 0.01,),
                            Container(
                              child: Text(TV[index]['original_name']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
                              ),
                            ),
                          ],
                        ),
                      ),
                    );
                  }))
        ],
      ),
    );
  }
}

class TVSeriesList extends StatelessWidget {
  final List TV;
  final bool loading;

  const TVSeriesList({Key? key,required this.TV, required this.loading}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            'Trending Movies',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.025,),
          ),
          SizedBox(height: MediaQuery.of(context).size.height * 0.025),
          Container(
              height: MediaQuery.of(context).size.height * 2.6,
              child: loading?Center(
                child: CircularProgressIndicator(),
              ):GridView.builder( gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 2, mainAxisSpacing: MediaQuery.of(context).size.height * 0.025,),
                  physics: NeverScrollableScrollPhysics(),
                  scrollDirection: Axis.vertical,

                  itemCount: TV.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: TV[index]['original_name'], description: TV[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            TV[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            TV[index]['poster_path'], vote: TV[index]['vote_average']
                            .toString()))
                        );
                      },
                      child:
                      Container(
                        width: 200,
                        child: Column(
                          children: [
                            Container(
                              decoration: BoxDecoration(
                                image: DecorationImage(
                                  image: NetworkImage(
                                      'https://image.tmdb.org/t/p/w500' +
                                          TV[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.175,
                            ),
                            SizedBox(height: MediaQuery.of(context).size.height * 0.01,),
                            Container(

                              child: Text(TV[index]['original_name']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
                              ),
                              height: MediaQuery.of(context).size.height * 0.05,
                            ),
                          ],
                        ),
                      ),
                    );
                  }))
        ],
      ),
    );
  }
}