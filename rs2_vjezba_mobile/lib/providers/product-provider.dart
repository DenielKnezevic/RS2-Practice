import 'dart:convert';
import 'dart:io';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/io_client.dart';
import 'package:rs2_vjezba_mobile/providers/base-provider.dart';

import '../models/product.dart';

class ProductProvider extends BaseProvider<Product> {
  ProductProvider() : super("Proizvodi");

  @override
  fromJson(data) {
    return Product.fromJson(data);
  }
}