
import 'package:flutter/material.dart';
import 'package:flutter_test/flutter_test.dart';

import '../screens/1StartPage.dart';

void main(){
  testWidgets('Find arrow icon on start page',(WidgetTester tester)async {

    await tester.pumpWidget( new MediaQuery(
        data: new MediaQueryData(),
        child: new MaterialApp(home:
        start())));
    final button = find.byIcon(Icons.arrow_circle_right_rounded);
    expect (button,findsOneWidget);
  }
  );

  testWidgets('Find images on start page',(WidgetTester tester)async {

    await tester.pumpWidget( new MediaQuery(
        data: new MediaQueryData(),
        child: new MaterialApp(home:
        start())));
    final button = find.byType(Image);
    expect (button,findsWidgets);
  }
  );
}

