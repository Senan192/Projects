import 'package:path/path.dart';
import 'package:sqflite/sqflite.dart';

class DB {
  Future<Database> initDB() async {
    String path = await getDatabasesPath();
    return openDatabase(
      join(path, "Db.db"),
      onCreate: (database, verison) async {
        await database.execute("""
        CREATE TABLE MYTable(
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        poster TEXT,
        title TEXT
        )
        """);
      },
      version: 2,
    );
  }

  Future<bool> insertData(DataModel dataModel) async {
    final Database db = await initDB();
    db.insert("MYTable", dataModel.toMap());
    return true;
  }

  Future<List<DataModel>> getData() async {
    final Database db = await initDB();
    final List<Map<String, Object?>> datas = await db.query("MYTable");
    return datas.map((e) => DataModel.fromMap(e)).toList();
  }

  Future<void> delete(int id) async {
    final Database db = await initDB();
    await db.delete("MYTable", where: "id=?", whereArgs: [id]);
  }
}

class DataModel {
  //id value is set to auto increment thus isnt passed in when inserting data
  int? id;
  String poster;
  String title;
  DataModel({this.id, required this.poster, required this.title});

  factory DataModel.fromMap(Map<String, dynamic> json) => DataModel(
      id: json['id'], poster: json["poster"], title: json["title"]);

  Map<String, dynamic> toMap() => {
    "id": id,
    "poster": poster,
    "title": title,
  };
}