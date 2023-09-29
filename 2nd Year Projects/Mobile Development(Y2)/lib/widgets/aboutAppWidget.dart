import 'package:flutter/material.dart';
import 'package:page_transition/page_transition.dart';

import '../screens/ReferencesPage.dart';
import '../screens/test.dart';

class aboutApp extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return Container(
      height: MediaQuery.of(context).size.height * 0.1,
      width: double.infinity,
      color: Colors.yellowAccent,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text('About App',style: TextStyle(fontSize: MediaQuery.of(context).size.height * 0.03,fontWeight: FontWeight.bold),),
          GestureDetector(
            child: Text('References',style: TextStyle(decoration: TextDecoration.underline,fontSize: MediaQuery.of(context).size.height * 0.02,),),
            onTap: (){
              Navigator.push(
                context,
                PageTransition(
                    type: PageTransitionType.fade,
                    child: references(),
                    inheritTheme: true,
                    ctx: context),
              );
            },
          ),
        ],
      ),
    );
  }
}
