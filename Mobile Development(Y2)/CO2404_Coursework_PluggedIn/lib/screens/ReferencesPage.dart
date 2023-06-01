import 'package:flutter/material.dart';
import 'package:url_launcher/url_launcher.dart';

final Uri carousel = Uri.parse('https://stackoverflow.com/questions/55413525/flutter-carousel-image-slider-open-separate-page-during-on-tap-event-is-called');
final Uri tmdb = Uri.parse("https://www.youtube.com/watch?v=s8hxGwF6pvE&ab_channel=AkshitMadan");
final Uri sqflite = Uri.parse("https://www.youtube.com/watch?v=3SU34qF8_v4&ab_channel=DevStack");



class references extends StatelessWidget {
  const references({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('References'),centerTitle: true,titleTextStyle: TextStyle(color: Colors.black,fontWeight: FontWeight.bold,fontSize: 20),
        backgroundColor: Colors.yellowAccent,),

      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [

          SizedBox(height: 10,),
          Text('1 Carousel Slider',style:
          TextStyle(fontSize: 15) ,),
          InkWell(
            child: Text("https://stackoverflow.com/questions/55413525/flutter-carousel-image-slider-open-separate-page-during-on-tap-event-is-called"),
            onTap: ()async {
          if (!await launchUrl(carousel)) {
          throw Exception('Could not launch $carousel');
          }
          },
          ),
          SizedBox(height: 10,),

          Text('2 TMDB API',style:
          TextStyle(fontSize: 15) ,),
          InkWell(
            child: Text("https://www.youtube.com/watch?v=s8hxGwF6pvE&ab_channel=AkshitMadan"),
            onTap: ()async {
              if (!await launchUrl(tmdb)) {
                throw Exception('Could not launch $tmdb');
              }
            },
          ),
          SizedBox(height: 10,),

          Text('3 sqflite',style:
          TextStyle(fontSize: 15) ,),
          InkWell(
            child: Text("https://www.youtube.com/watch?v=3SU34qF8_v4&ab_channel=DevStack"),
            onTap: ()async {
              if (!await launchUrl(sqflite)) {
                throw Exception('Could not launch $sqflite');
              }
            },
          ),
          SizedBox(height: 10,),

        
        ],
      ),
    );
  }
}


