import 'package:carousel_slider/carousel_slider.dart';
import 'package:flutter/material.dart';

class carouselSliderWidget extends StatelessWidget {
  final List trending;
  final bool loading;

  const carouselSliderWidget({Key? key,required this.trending, required this.loading}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    List imageList = [
      for(int i=1;i<trending.length;i++)...[
        'https://image.tmdb.org/t/p/w500' +trending[i]['backdrop_path'],
      ]
    ];

    return Container(
      child: Center(
        child: loading?Center(
          child: CircularProgressIndicator(),
        ):CarouselSlider(
          options: CarouselOptions(
            enlargeCenterPage: true,
            enableInfiniteScroll: true,
            autoPlay: true,
          ),
          items: imageList.map((imgList) => Stack(
            fit: StackFit.expand,
            children: <Widget>[
              Image.network(
                imgList ?? [],
                width: 1050,
                height: 350,
                fit: BoxFit.scaleDown,
              ),
            ],
          ) ,
          ).toList(),
        ),
      ),
    );
  }
}
