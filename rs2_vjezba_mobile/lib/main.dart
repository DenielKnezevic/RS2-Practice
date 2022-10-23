import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:rs2_vjezba_mobile/providers/product-provider.dart';
import 'package:rs2_vjezba_mobile/screens/product-list.dart';
import 'package:provider/provider.dart';
import 'package:rs2_vjezba_mobile/utils/util.dart';

void main() {
  runApp(MultiProvider(
      providers: [ChangeNotifierProvider(create: (_) => ProductProvider())],
      child: MaterialApp(
        title: 'Welcome to Flutter',
        onGenerateRoute: (settings) {
          if (settings.name == ProductListScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => ProductListScreen()));
          }
        },
        home: MyApp(),
      )));
}

class MyApp extends StatelessWidget {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late ProductProvider _productProvider;

  @override
  Widget build(BuildContext context) {
    _productProvider = Provider.of<ProductProvider>(context, listen: false);

    return Scaffold(
        appBar: AppBar(
          title: const Text('RS2 vjezba'),
        ),
        body: SingleChildScrollView(
          child: Column(
            children: [
              Container(
                height: 350,
                decoration: BoxDecoration(
                    image: DecorationImage(
                        image: AssetImage("assets/images/background.png"),
                        fit: BoxFit.fill)),
                child: Stack(
                  children: [
                    Positioned(
                      top: 0,
                      left: 120,
                      height: 120,
                      width: 100,
                      child: Container(
                        decoration: BoxDecoration(
                            image: DecorationImage(
                                image:
                                    AssetImage("assets/images/light-1.png"))),
                      ),
                    ),
                    Positioned(
                      top: 40,
                      right: 40,
                      height: 60,
                      width: 60,
                      child: Container(
                        decoration: BoxDecoration(
                            image: DecorationImage(
                                image: AssetImage("assets/images/clock.png"))),
                      ),
                    ),
                    Container(
                      child: Center(
                        child: Text(
                          "Login",
                          style: TextStyle(
                              color: Colors.white,
                              fontWeight: FontWeight.bold,
                              fontSize: 40),
                        ),
                      ),
                    )
                  ],
                ),
              ),
              Padding(
                padding: EdgeInsets.all(40),
                child: Column(
                  children: [
                    Container(
                      child: TextField(
                        controller: _usernameController,
                        decoration: InputDecoration(
                            border: InputBorder.none,
                            hintText: "Username or email",
                            hintStyle: TextStyle(
                                color: Color.fromARGB(255, 164, 164, 164))),
                      ),
                      padding: EdgeInsets.all(8),
                      decoration: BoxDecoration(
                          color: Colors.white,
                          border: Border(
                              bottom: BorderSide(
                                  color: Color.fromARGB(255, 224, 224, 224)))),
                    ),
                    Container(
                      child: TextField(
                        obscureText: true,
                        controller: _passwordController,
                        decoration: InputDecoration(
                            border: InputBorder.none,
                            hintText: "Password",
                            hintStyle: TextStyle(
                                color: Color.fromARGB(255, 164, 164, 164))),
                      ),
                      padding: EdgeInsets.all(8),
                      decoration: BoxDecoration(color: Colors.white),
                    ),
                  ],
                ),
              ),
              Container(
                height: 50,
                margin: EdgeInsets.fromLTRB(40, 0, 40, 20),
                decoration: BoxDecoration(
                    gradient: LinearGradient(colors: [
                      Color.fromRGBO(143, 148, 251, 1),
                      Color.fromRGBO(143, 148, 251, 0.6)
                    ]),
                    borderRadius: BorderRadius.circular(10)),
                child: InkWell(
                  onTap: () async {
                    try {
                      Authorization.Username = _usernameController.text;
                      Authorization.Password = _passwordController.text;

                      await _productProvider.Get(null);

                      Navigator.pushNamed(context, ProductListScreen.routeName);
                    } catch (e) {
                      showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                                title: Text("Error"),
                                content: Text(e.toString()),
                                actions: [
                                  TextButton(
                                      onPressed: () => Navigator.pop(context),
                                      child: Text("Ok"))
                                ],
                              ));
                    }
                  },
                  child: Center(
                      child: Text(
                    "Login",
                    style: TextStyle(
                        color: Colors.white, fontWeight: FontWeight.bold),
                  )),
                ),
              ),
              SizedBox(
                height: 3,
              ),
              Container(
                child: Center(
                    child: Text(
                  "Forgot password?",
                  style: TextStyle(color: Color.fromRGBO(143, 148, 251, 1)),
                )),
              ),
              SizedBox(
                height: 20,
              )
            ],
          ),
        ));
  }
}
