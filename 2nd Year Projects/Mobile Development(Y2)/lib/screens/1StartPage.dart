import 'package:flutter/material.dart';
import '2HomePage.dart';


//start fucntion on splash screen
class start extends StatelessWidget {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Stack(
          children: <Widget>[
            Container(
              decoration: BoxDecoration(
                image: DecorationImage(
                    image: AssetImage('assets/startPage.jpg'),
                    fit: BoxFit.cover
                ) ,
              ),
            ),
            Container(
                alignment: Alignment.bottomCenter,
                child: IconButton(

                  onPressed: () {
                    Navigator.push(context, MaterialPageRoute(
                        builder: (context) => new homeScreen())
                    );
                  },
                  icon : const Icon(Icons.arrow_circle_right_rounded,size: 40,),
                  color: Colors.white,
                )
            ),
            Container(
              alignment: Alignment.center,

              child: Image.asset('assets/pluggedIn.png'),
            )
          ],
        ),
      ),
    );
  }
}