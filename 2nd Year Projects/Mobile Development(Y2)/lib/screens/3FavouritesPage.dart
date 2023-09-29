import 'package:co2404_coursework_pluggedin/widgets/navBar.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import '../widgets/dataBase.dart';

class watchList extends StatefulWidget {
  const watchList({Key? key}) : super(key: key);

  @override
  State<watchList> createState() => _watchListState();
}

class _watchListState extends State<watchList> {

  List<DataModel> data = [];
  bool loadingInfo = true;
  late DB db;

  @override
  void initState() {

    super.initState();
    db =DB();
    getDataFunction();
  }


  //get favourites from Db
  //loading function until data is loaded
  void getDataFunction() async {
    data = await db.getData();
    setState(() {
      loadingInfo = false;
    });
  }

  //delete movie from db by user
  void delete(int index) {
    db.delete(data[index].id!);
    setState(() {
      data.removeAt(index);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.black,
        appBar: AppBar(title: Text('PluggedIn',style:  GoogleFonts.rubik(),),centerTitle: true,titleTextStyle: TextStyle(color: Colors.black,fontWeight: FontWeight.bold,fontSize: 20),
          backgroundColor: Colors.yellowAccent,automaticallyImplyLeading: false,),
        body:Container(
          color: Colors.black,
          child: Column(
            children: [
              Expanded(child: SingleChildScrollView(
                child:Column(
                  children: [
                    SizedBox(height: MediaQuery.of(context).size.height * 0.01,),
                    Container(
                      height: MediaQuery.of(context).size.height,
                      child: ListView.builder(
                          scrollDirection: Axis.vertical,
                          // shrinkWrap: true,
                          itemCount: data.length,
                          itemBuilder: (context, index){
                            return Row(
                              mainAxisAlignment: MainAxisAlignment.spaceAround,
                              children: [
                                Padding(
                                  padding: const EdgeInsets.only(bottom: 10.0),
                                  child: Container(
                                    height: MediaQuery.of(context).size.height * 0.2,
                                    width: MediaQuery.of(context).size.width * 0.3,
                                    child: Image.network(data[index].poster),
                                  ),
                                ),
                                Container(
                                  height: MediaQuery.of(context).size.height * 0.05,
                                  width: MediaQuery.of(context).size.width * 0.3,
                                  child: Text(data[index].title,style: TextStyle(color: Colors.white,fontSize:MediaQuery.of(context).size.height * 0.02, ),),
                                ),
                                TextButton(onPressed: (){
                                  delete(index);
                                }, child: Text("Remove"),),
                              ],
                            );
                          }),
                    ),
                  ],
                ) ,
              )),
              navbar(homeColour: Colors.grey, watchListColour: Colors.yellow, trendingColour: Colors.grey),
            ],
          ),
        )
    );
  }
}