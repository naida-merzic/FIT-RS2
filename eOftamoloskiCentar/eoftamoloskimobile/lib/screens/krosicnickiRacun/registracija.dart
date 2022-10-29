import 'package:flutter/cupertino.dart';

import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/providers/korisnickiRacun_provider.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
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
  int spol = 3;
  DateTime selectedDate = DateTime.now();
  DateTime dateTime = DateTime.now();
  bool showDate = false;
  late KorisnickiRacunProvider _korisnickiProvider;

  // Select for Date
  Future<DateTime> _selectDate(BuildContext context) async {
    final selected = await showDatePicker(
      context: context,
      initialDate: selectedDate,
      firstDate: DateTime(2000),
      lastDate: DateTime(2025),
    );
    if (selected != null && selected != selectedDate) {
      setState(() {
        selectedDate = selected;
      });
    }
    return selectedDate;
  }

  @override
  Widget build(BuildContext context) {
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
                    padding: const EdgeInsets.symmetric(horizontal: 15),
                    width: double.infinity,
                    child: ElevatedButton(
                      onPressed: () {
                        _selectDate(context);
                        showDate = true;
                      },
                      child: const Text('Birth date'),
                    ),
                  ),
                  showDate ? Center(child: Text(getDate())) : const SizedBox(),
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
                  Row(
                    children: [
                      IconButton(
                        icon: Icon(Icons.male),
                        onPressed: () {
                          spol = 1;
                        },
                      ),
                      IconButton(
                        icon: Icon(Icons.female),
                        onPressed: () {
                          spol = 2;
                        },
                      ),
                      TextButton(
                          onPressed: () {
                            spol = 3;
                          },
                          child: Text(
                            "Other",
                            style: TextStyle(fontSize: 16, color: Colors.black),
                          ))
                    ],
                  )
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
                  "datumRodjenja": selectedDate.toIso8601String(),
                  "lozinka": _passwordController.text,
                  "lozinkaPotvrda": _passwordConfirmController.text,
                  "spolId": spol,
                };

                var x = await _korisnickiProvider.SignIn(order);
                if (x != null) {
                  Authorization.loggedUser = x;
                  Authorization.username = _usernameController.text;
                  Authorization.password = _passwordController.text;

                  Navigator.pushNamed(context, ProductListScreen.routeName);
                }
              },
              child: Center(child: Text("Sign in")),
            ),
          ),
          SizedBox(height: 40),
        ],
      )),
    );
  }

  String getDate() {
    // ignore: unnecessary_null_comparison
    if (selectedDate == null) {
      return 'select date';
    } else {
      return DateFormat('MMM d, yyyy').format(selectedDate);
    }
  }
}
