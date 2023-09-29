import 'package:flutter/material.dart';
import '../screens/movieInfoPage.dart';


class TopRatedMoviesSlider extends StatelessWidget {
  final List toprated;
  final bool loading;

  const TopRatedMoviesSlider({Key? key,required this.toprated, required this.loading}) : super(key: key);
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
                  itemCount: toprated.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: toprated[index]['title'], description: toprated[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            toprated[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            toprated[index]['poster_path'], vote: toprated[index]['vote_average']
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
                                          toprated[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.2,
                            ),
                            SizedBox(height:MediaQuery.of(context).size.height * 0.01,),
                            Container(
                              child: Text(toprated[index]['title']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
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


class TopRatedMoviesList extends StatelessWidget {
  final List toprated;
  final bool loading;

  const TopRatedMoviesList({Key? key,required this.toprated, required this.loading}) : super(key: key);
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

                  itemCount: toprated.length,
                  itemBuilder: (context, index) {
                    return GestureDetector(
                      onTap: () {
                        Navigator.push(
                            context,MaterialPageRoute(builder: (context) => descriptionScreen(name: toprated[index]['title'], description: toprated[index]['overview'], bannerurl: 'https://image.tmdb.org/t/p/w500' +
                            toprated[index]['backdrop_path'], posterurl: 'https://image.tmdb.org/t/p/w500' +
                            toprated[index]['poster_path'], vote: toprated[index]['vote_average']
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
                                          toprated[index]['poster_path']),
                                ),
                              ),
                              height: MediaQuery.of(context).size.height * 0.175,
                            ),
                            SizedBox(height: MediaQuery.of(context).size.height * 0.01,),
                            Container(

                              child: Text(toprated[index]['title']?? 'Loading',style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.015,),textAlign: TextAlign.center,
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