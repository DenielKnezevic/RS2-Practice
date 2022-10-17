import 'dart:convert';
import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';

import '../models/product.dart';

class ProductProvider with ChangeNotifier {

  HttpClient client = HttpClient();
  IOClient? http ;

  ProductProvider(){
    client.badCertificateCallback =(cert, host, port) => true;
    http = IOClient(client);
  }
  
  Future<List<Product>> get(dynamic searchObject) async {

    var url = Uri.parse("http://10.0.2.2:5192/api/Proizvodi");

    String username = "test";
    String passowrd = "test";

    String basicAuth = "Basic ${base64Encode(utf8.encode('$username:$passowrd'))}";

    var headers = {
      "Content-Type" : "application/json",
      "Authorization": basicAuth
    };

    var response = await http!.get(url, headers: headers);

    if(response.statusCode < 400)
    {
      var data = jsonDecode(response.body);
      List<Product> list = data.map((x) => Product.fromJson(x)).cast<Product>().toList();
      return list;
    }
    else{
      throw Exception("Wrong username or password");
    }

  }
}