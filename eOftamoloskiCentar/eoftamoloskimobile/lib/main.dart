//import 'dart:html';

import 'package:eoftamoloskimobile/providers/product_provider.dart';
import 'package:eoftamoloskimobile/screens/products/product_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() => runApp(MultiProvider(
        providers: [
          ChangeNotifierProvider(create: (_) => ProductProvider()),
        ],
        child: MaterialApp(
          debugShowCheckedModeBanner: true,
          home: HomePage(),
          onGenerateRoute: (settings) {
            if (settings.name == ProductListScreen.routeName) {
              return MaterialPageRoute(
                  builder: ((context) => ProductListScreen()));
            }
          },
        )));

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Flutter RoxExample"),
      ),
      body: SingleChildScrollView(
          child: Column(
        children: [
          Container(
            height: 400,
            decoration: BoxDecoration(
                image: DecorationImage(
                    image: AssetImage("assets/images/background.png"),
                    fit: BoxFit.fill)),
            child: Stack(children: [
              Positioned(
                  right: 140,
                  top: 0,
                  width: 80,
                  height: 120,
                  child: Container(
                      decoration: BoxDecoration(
                          image: DecorationImage(
                    image: AssetImage("assets/images/light-1.png"),
                  )))),
              Positioned(
                  right: 40,
                  top: 0,
                  width: 80,
                  height: 120,
                  child: Container(
                      decoration: BoxDecoration(
                          image: DecorationImage(
                    image: AssetImage("assets/images/clock.png"),
                  )))),
              Container(
                child: Center(
                    child: Text(
                  "Login",
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 45,
                      fontWeight: FontWeight.bold),
                )),
              ),
            ]),
          ),
          Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10)),
                child: Column(children: [
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Email or phone"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    child: TextField(
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Password"),
                    ),
                  ),
                ]),
              )),
          SizedBox(height: 30),
          Container(
            height: 50,
            //padding: EdgeInsets.all(8),
            margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
            decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: LinearGradient(colors: [
                  Color.fromARGB(255, 106, 112, 236),
                  Color.fromRGBO(143, 148, 251, 6)
                ])),
            child: InkWell(
              onTap: () {
                Navigator.pushNamed(context, ProductListScreen.routeName);
              },
              child: Center(child: Text("Login")),
            ),
          ),
          SizedBox(height: 50),
          Text("Forgot password?")
        ],
      )),
    );
  }
}
