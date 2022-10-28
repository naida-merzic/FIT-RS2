//import 'dart:html';

import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/model/novost.dart';
import 'package:eoftamoloskimobile/providers/cart_provider.dart';
import 'package:eoftamoloskimobile/providers/checkOrder_provider.dart';
import 'package:eoftamoloskimobile/providers/dojam_provider.dart';
import 'package:eoftamoloskimobile/providers/korisnickiRacun_provider.dart';
import 'package:eoftamoloskimobile/providers/novost_provider.dart';
import 'package:eoftamoloskimobile/providers/product_provider.dart';
import 'package:eoftamoloskimobile/providers/termin_provider.dart';
import 'package:eoftamoloskimobile/providers/user_provider.dart';
import 'package:eoftamoloskimobile/screens/cart/cart_screen.dart';
import 'package:eoftamoloskimobile/screens/krosicnickiRacun/korisnickiRacunScreen.dart';
import 'package:eoftamoloskimobile/screens/krosicnickiRacun/registracija.dart';
import 'package:eoftamoloskimobile/screens/news/news_list_screen.dart';
import 'package:eoftamoloskimobile/screens/products/product_details_screen.dart';
import 'package:eoftamoloskimobile/screens/products/product_list_screen.dart';
import 'package:eoftamoloskimobile/screens/termini/terminInsert_screen.dart';
import 'package:eoftamoloskimobile/screens/termini/termin_Screen.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'model/user.dart';
import 'providers/user_provider.dart';

void main() => runApp(MultiProvider(
        providers: [
          ChangeNotifierProvider(create: (_) => ProductProvider()),
          ChangeNotifierProvider(create: (_) => UserProvider()),
          ChangeNotifierProvider(create: (_) => CartProvider()),
          ChangeNotifierProvider(create: (_) => CheckOrderProvider()),
          ChangeNotifierProvider(create: (_) => NovostProvider()),
          ChangeNotifierProvider(create: (_) => KorisnickiRacunProvider()),
          ChangeNotifierProvider(create: (_) => TerminProvider()),
          ChangeNotifierProvider(create: (_) => DojamProvider()),
        ],
        child: MaterialApp(
          debugShowCheckedModeBanner: true,
          theme: ThemeData(
            // Define the default brightness and colors.
            brightness: Brightness.light,
            primaryColor: Colors.deepPurple,
            textButtonTheme: TextButtonThemeData(
                style: TextButton.styleFrom(
                    foregroundColor: Colors.deepPurple,
                    textStyle: const TextStyle(
                        fontSize: 24,
                        fontWeight: FontWeight.bold,
                        fontStyle: FontStyle.italic))),

            // Define the default `TextTheme`. Use this to specify the default
            // text styling for headlines, titles, bodies of text, and more.
            textTheme: const TextTheme(
              headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
              headline6: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
            ),
          ),
          home: HomePage(),
          onGenerateRoute: (settings) {
            if (settings.name == ProductListScreen.routeName) {
              return MaterialPageRoute(
                  builder: ((context) => ProductListScreen()));
            } else if (settings.name == CartScreen.routeName) {
              return MaterialPageRoute(builder: ((context) => CartScreen()));
            } else if (settings.name == NovostScreen.routeName) {
              return MaterialPageRoute(builder: ((context) => NovostScreen()));
            } else if (settings.name == NovostScreen.routeName) {
              return MaterialPageRoute(builder: ((context) => NovostScreen()));
            } else if (settings.name == KorisnickiRacunScreen.routeName) {
              return MaterialPageRoute(
                  builder: ((context) => KorisnickiRacunScreen()));
            } else if (settings.name == TerminScreen.routeName) {
              return MaterialPageRoute(builder: ((context) => TerminScreen()));
            } else if (settings.name == TerminInsertScreen.routeName) {
              return MaterialPageRoute(
                  builder: ((context) => TerminInsertScreen()));
            } else if (settings.name == RegistracijaScreen.routeName) {
              return MaterialPageRoute(
                  builder: ((context) => RegistracijaScreen()));
            }

            var uri = Uri.parse(settings.name!);
            if (uri.pathSegments.length == 2 &&
                "/${uri.pathSegments.first}" ==
                    ProductDetailsScreen.routeName) {
              var id = uri.pathSegments[1];
              return MaterialPageRoute(
                  builder: (context) => ProductDetailsScreen(id));
            }
          },
        )));

class HomePage extends StatelessWidget {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late UserProvider _userProvider;
  late KorisnickiRacunProvider _korisnickiProvider;

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);
    _korisnickiProvider =
        Provider.of<KorisnickiRacunProvider>(context, listen: false);

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
                  "Welcome",
                  style: TextStyle(
                      color: Colors.white,
                      fontSize: 45,
                      fontWeight: FontWeight.bold),
                )),
              ),
            ]),
          ),
          Padding(
              padding: EdgeInsets.fromLTRB(40, 0, 40, 10),
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
                      controller: _usernameController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Email or phone"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    child: TextField(
                      controller: _passwordController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Password"),
                    ),
                  ),
                ]),
              )),
          SizedBox(height: 2),
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
              onTap: () async {
                try {
                  Authorization.username = _usernameController.text;
                  Authorization.password = _passwordController.text;

                  List<Klijent> loggedUser = await _korisnickiProvider.get();
                  Authorization.loggedUser = loggedUser.first;

                  Navigator.pushNamed(context, ProductListScreen.routeName);
                } catch (e) {
                  showDialog(
                      context: context,
                      builder: (BuildContext context) => AlertDialog(
                            title: Text("Error"),
                            content: Text(e.toString()),
                            actions: [
                              TextButton(
                                child: Text("Ok"),
                                onPressed: () => Navigator.pop(context),
                              )
                            ],
                          ));
                }
              },
              child: Center(child: Text("Login")),
            ),
          ),
          SizedBox(height: 20),
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
              onTap: () async {
                Navigator.pushNamed(context, RegistracijaScreen.routeName);
              },
              child: Center(child: Text("Sign in")),
            ),
          ),
          SizedBox(height: 40),
          Text("Forgot password?"),
          SizedBox(height: 40),
        ],
      )),
    );
  }
}
