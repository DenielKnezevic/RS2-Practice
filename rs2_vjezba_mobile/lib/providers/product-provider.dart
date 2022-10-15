import 'package:flutter/cupertino.dart';

class ProductProvider with ChangeNotifier {
  Future<dynamic> get(dynamic searchObject) async {
    return await "Test";
  }
}