import 'package:flutter/material.dart';

import '../screens/movieInfoPage.dart';


class TopTVSeriesSlider extends StatelessWidget {
  final List latest;
  final bool loading;

  const TopTVSeriesSlider({Key? key,required this.latest, required this.loading}) : super(key: key);
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
              height:MediaQuery.of(context).size.height * 0.35,
              child: loading?Center(
                child: CircularProgressIndicator(),
              ):ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: latest.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: latest[index]['original_name'], description: latest[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            latest[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            latest[index]['poster_path'], vote: latest[index]['vote_average']
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
                                          latest[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.2,
                            ),
                            SizedBox(height:MediaQuery.of(context).size.height * 0.01,),
                            Container(
                              child: Text(latest[index]['original_name']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
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


class TopTVSeriesList extends StatelessWidget {
  final List latest;
  final bool loading;

  const TopTVSeriesList({Key? key,required this.latest, required this.loading}) : super(key: key);
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

                  itemCount: latest.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: latest[index]['original_name'], description: latest[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            latest[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            latest[index]['poster_path'], vote: latest[index]['vote_average']
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
                                          latest[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.175,
                            ),
                            SizedBox(height: MediaQuery.of(context).size.height * 0.01,),
                            Container(

                              child: Text(latest[index]['original_name']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
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