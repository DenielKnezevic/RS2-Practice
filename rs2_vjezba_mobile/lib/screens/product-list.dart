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
  TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _productProvider?.Get(null);
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
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            _buildHeader(),
            _buildProductSearch(),
            Container(
              height: 200,
              child: GridView(
                gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                    crossAxisCount: 1,
                    childAspectRatio: 4 / 3,
                    crossAxisSpacing: 20,
                    mainAxisSpacing: 20),
                scrollDirection: Axis.horizontal,
                children: _productList(),
              ),
            )
          ],
        ),
      )),
    );
  }

  Widget _buildHeader() {
    return Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: Text("Products",
                style: TextStyle(
                    color: Colors.grey,
                    fontWeight: FontWeight.bold,
                    fontSize: 36)));
  }

  Widget _buildProductSearch() {
    return Container(
      child: Row(children: [
        Expanded(
          child: Padding(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tmpData = await _productProvider!.Get({"naziv": value});
                setState(() {
                  data = tmpData;
                });
              },
              decoration: InputDecoration(
                  prefixIcon: Icon(Icons.search),
                  hintText: "Search",
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: BorderSide(color: Colors.grey))),
            ),
          ),
        ),
        Container(
          child: Padding(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: IconButton(
              icon: Icon(Icons.filter_list),
              onPressed: () async {
                var tmpData = await _productProvider!
                    .Get({"naziv": _searchController.text});
                setState(() {
                  data = tmpData;
                });
              },
            ),
          ),
        )
      ]),
    );
  }

  List<Widget> _productList() {
    if (data.length == 0) {
      return [Text("Loading......")];
    }

    List<Widget> list = data
        .map((x) => Container(
              child: Column(
                children: [
                  Container(
                    height: 100,
                    width: 100,
                    child: imageFromBase64String(x.slika!),
                  ),
                  Text(x.naziv!),
                  Text(formatNumber(x.cijena))
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
