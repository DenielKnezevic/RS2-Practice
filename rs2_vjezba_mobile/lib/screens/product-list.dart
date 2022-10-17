import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:rs2_vjezba_mobile/providers/product-provider.dart';
import 'package:rs2_vjezba_mobile/utils/util.dart';

import '../models/product.dart';

class ProductListScreen extends StatefulWidget {
  static const String routeName = "/productList";

  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  ProductProvider? _productProvider = null;
  List<Product> data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _productProvider?.get(null);
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
          child: Container(
        child: Column(
          children: [
            Container(
              height: 200,
              child: GridView(gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 1,
                childAspectRatio: 4/3,
                crossAxisSpacing: 20,
                mainAxisSpacing: 20
              ) ,
              scrollDirection: Axis.horizontal,
              children: _productList(),),
            )
          ],
        ),
      )),
    );
  }

  List<Widget> _productList() {
    if (data.length == 0) {
      return [Text("Loading......")];
    }

    List<Widget> list = data.map((x) => 
          Container(child: 
          Column(
            children: [
              Container(
                height: 100,
                width: 100,
                child: imageFromBase64String(x.slika!),
              ),
              Text(x.naziv!)
            ],
          ),)
        ).cast<Widget>().toList();

    return list;
  }
}
