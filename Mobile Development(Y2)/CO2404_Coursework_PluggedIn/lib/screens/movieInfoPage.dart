import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:youtube_player_flutter/youtube_player_flutter.dart';
import 'package:shared_preferences/shared_preferences.dart';

import '../widgets/dataBase.dart';

class descriptionScreen extends StatefulWidget {
  final String name, description, bannerurl, posterurl, vote;
  
  const descriptionScreen({Key? key, required this.name, required this.description, required this.bannerurl, required this.posterurl, required this.vote}) : super(key: key);

  @override
  State<descriptionScreen> createState() => _descriptionState();
}

class _descriptionState extends State<descriptionScreen> {

  List<DataModel> data = [];
  bool loadingDB = true;
  late DB db;

  @override
  void initState() {
    super.initState();
    db =DB();
    getDataFunction();
  }

  void getDataFunction() async {
    data = await db.getData();
    setState(() {
      loadingDB = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    String titleName = widget.name;
    bool alreadyAdded=false;
    for(int index=0; index< data.length ; index++ ){
      if(widget.posterurl==data[index].poster ){
        //assign bool as true
        alreadyAdded=true;
        break;
      }
    }

    return Scaffold(
      backgroundColor: Colors.yellow[500],
      //appBar: AppBar(title: Text(widget.name),backgroundColor: Colors.black,),
      body:Container(
        child:
        Stack(
          children: [
            //background image
            Container(
              height:MediaQuery.of(context).size.height,
              child: Stack(
                fit: StackFit.expand,
                children: [
                  Image.network(widget.posterurl,fit: BoxFit.cover,),
                  ClipRRect(
                    child: BackdropFilter(filter: ImageFilter.blur(sigmaX: 10, sigmaY: 10),
                    child: Container(
                      color: Colors.grey.withOpacity(0.1),
                    ),),
                  )
                ],
              ),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Stack(
                  children: [
                    Positioned(child: Container(
                      width: MediaQuery.of(context).size.width,
                      height: MediaQuery.of(context).size.height * 0.3,
                      child: Image.network(widget.bannerurl,fit: BoxFit.cover,),
                    )),
                    Positioned(
                        bottom: 10,
                        child: Container(
                          padding: const EdgeInsets.all(8.0),
                          child: Text(widget.name,
                            style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.025, fontWeight: FontWeight.bold),),
                        )
                    ),
                  ],
                ),
                SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Container(
                        decoration: BoxDecoration(borderRadius: BorderRadius.circular(7.5),color: Colors.black,),
                        height: MediaQuery.of(context).size.height * 0.03,
                        width: MediaQuery.of(context).size.width * 0.3,
                        child: Text("   ★ Rating : " + widget.vote,
                          style: TextStyle(color: Colors.white,fontSize: MediaQuery.of(context).size.height * 0.02,),),
                      ),
                    ),
                    Padding(
                      //ps- I encountered issues when trying to sync the button size and text according to the screen size
                      //therefore its left at its default scalling
                      padding: const EdgeInsets.all(8.0),
                        child: ElevatedButton.icon(
                          //button to the movie name and the poster URL to DB
                          onPressed: () async{
                            //fucntion implemented to check if the movie the user is trying to add is already there
                            //checking if movie already exists

                              if(alreadyAdded==true ){
                                showDialog(context: context, builder: (context)=>AlertDialog(
                                  title: Text("$titleName Has Already Been Added To Your Favourites",textAlign: TextAlign.center,style: TextStyle(
                                    color: Colors.yellow
                                  )),
                                  backgroundColor: Colors.black,
                                  actions: [
                                    TextButton(onPressed: ()=>Navigator.pop(context), child: Text("Ok"))
                                  ],
                                ));
                                //assign bool as true
                                alreadyAdded=true;

                              }

                            //check bool value
                            if(alreadyAdded==false){
                              db.insertData(DataModel(poster: widget.posterurl, title: widget.name));//save string
                              showDialog(context: context, builder: (context)=>AlertDialog(
                                title: Text("$titleName Added To Your Favourites",textAlign: TextAlign.center,),
                                actions: [
                                  TextButton(onPressed: ()=>Navigator.pop(context), child: Text("Ok"))
                                ],
                              ));

                            }
                          },
                          style: ButtonStyle(
                            backgroundColor: MaterialStateProperty.all(Colors.yellowAccent),
                          ),
                          icon:alreadyAdded==false?const Icon(Icons.favorite_border,color: Colors.black,):const Icon(Icons.favorite_outlined,color: Colors.black,),
                          label: alreadyAdded==false?Text("Add to Favourites",style: TextStyle(color: Colors.black),):Text("Added to Favourites",style: TextStyle(color: Colors.black),), // <-- Text
                        ),

                    ),
                  ],
                ),
                SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
                //movie description
                Expanded(child:SingleChildScrollView(
                    child:Container(
                      padding: const EdgeInsets.all(5.0),
                      width: MediaQuery.of(context).size.width,
                      child: Text(widget.description,
                        style: TextStyle(color: Colors.yellowAccent,fontWeight: FontWeight.bold,fontSize: MediaQuery.of(context).size.height * 0.02,),),
                    ) ,
                  ) ,),

                SizedBox(height: MediaQuery.of(context).size.height * 0.02,),
              ],
            ),
            //back button
            Container(
              child: Align(
                alignment: Alignment.bottomRight,
                child: IconButton(
                  onPressed:() => Navigator.of(context).pop(),
                  icon : const Icon(Icons.arrow_back,size: 20,),
                  color: Colors.white,
                )
              ),
            )
          ],
        )
      )
    );
  }
}
