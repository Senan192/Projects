import 'package:flutter/material.dart';
import '../screens/movieInfoPage.dart';


class MoviesUpcomingSlider extends StatelessWidget {
  final List upcoming;
  final bool loading;

  const MoviesUpcomingSlider({super.key, required this.upcoming, required this.loading});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text(
            'Upcoming Movies',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.025,),
          ),
          SizedBox(height: MediaQuery.of(context).size.height * 0.025),
          Container(
              height:MediaQuery.of(context).size.height * 0.35,
              child: loading?Center(
                child: CircularProgressIndicator(),
              ):ListView.builder(
                  scrollDirection: Axis.horizontal,
                  itemCount: upcoming.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: upcoming[index]['title'], description: upcoming[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            upcoming[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            upcoming[index]['poster_path'], vote: upcoming[index]['vote_average']
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
                                          upcoming[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.2,
                            ),
                            SizedBox(height:MediaQuery.of(context).size.height * 0.01,),
                            Container(
                              child: Text(upcoming[index]['title']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
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



class MoviesUpcomingList extends StatelessWidget {
  final List upcoming;
  final bool loading;

  const MoviesUpcomingList({super.key, required this.upcoming, required this.loading});

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

                  itemCount: upcoming.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: upcoming[index]['title'], description: upcoming[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            upcoming[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            upcoming[index]['poster_path'], vote: upcoming[index]['vote_average']
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
                                          upcoming[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.175,
                            ),
                            SizedBox(height: MediaQuery.of(context).size.height * 0.01,),
                            Container(

                              child: Text(upcoming[index]['title']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
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