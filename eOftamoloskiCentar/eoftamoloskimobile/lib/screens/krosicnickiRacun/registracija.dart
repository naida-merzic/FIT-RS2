import 'package:flutter/cupertino.dart';

import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/providers/korisnickiRacun_provider.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../providers/user_provider.dart';
import '../../widgets/master_screen.dart';
import '../products/product_list_screen.dart';

class RegistracijaScreen extends StatefulWidget {
  static const String routeName = "/registracija";

  const RegistracijaScreen({Key? key}) : super(key: key);

  @override
  State<RegistracijaScreen> createState() => _RegistracijaScreenState();
}

class _RegistracijaScreenState extends State<RegistracijaScreen> {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  TextEditingController _passwordConfirmController = TextEditingController();
  TextEditingController _firstNameController = TextEditingController();
  TextEditingController _lastNameController = TextEditingController();
  TextEditingController _birthController = TextEditingController();
  TextEditingController _phoneController = TextEditingController();
  TextEditingController _emailController = TextEditingController();
  TextEditingController _adressController = TextEditingController();
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
                  "Sign in",
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
                      controller: _firstNameController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "First name"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _lastNameController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Last name"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _usernameController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Username"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _passwordController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Password"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _passwordConfirmController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Confirm password"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _emailController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Email"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _adressController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Adress"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _birthController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Date of birth"),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _phoneController,
                      decoration: InputDecoration(
                          border: InputBorder.none, hintText: "Phone"),
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
                // try {
                Map order = {
                  "ime": _firstNameController.text,
                  "prezime": _lastNameController.text,
                  "email": _emailController.text,
                  "brojTelefona": _phoneController.text,
                  "adresa": _adressController.text,
                  "korisnickoIme": _usernameController.text,
                  "datumRodjenja": DateTime.now().toIso8601String(),
                  "lozinkaHash": _passwordController.text,
                  "lozinkaSalt": _passwordConfirmController.text,
                };

                await _korisnickiProvider.insert(order);

                // Authorization.username = _usernameController.text;
                // Authorization.password = _passwordController.text;

                // List<Klijent> loggedUser = await _korisnickiProvider.get();
                // Authorization.loggedUser = loggedUser.first;

                // Navigator.pushNamed(context, ProductListScreen.routeName);
                // } catch (e) {
                //   showDialog(
                //       context: context,
                //       builder: (BuildContext context) => AlertDialog(
                //             title: Text("Error"),
                //             content: Text(e.toString()),
                //             actions: [
                //               TextButton(
                //                 child: Text("Ok"),
                //                 onPressed: () => Navigator.pop(context),
                //               )
                //             ],
                //           ));
                // }
              },
              child: Center(child: Text("Sign in")),
            ),
          ),
          SizedBox(height: 40),
        ],
      )),
    );
  }
}
