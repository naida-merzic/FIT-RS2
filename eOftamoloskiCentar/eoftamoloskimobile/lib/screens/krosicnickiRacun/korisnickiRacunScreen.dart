import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/providers/korisnickiRacun_provider.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../widgets/master_screen.dart';

class KorisnickiRacunScreen extends StatefulWidget {
  static const String routeName = "/korisnicki";

  const KorisnickiRacunScreen({Key? key}) : super(key: key);

  @override
  State<KorisnickiRacunScreen> createState() => _KorisnickiRacunScreenState();
}

class _KorisnickiRacunScreenState extends State<KorisnickiRacunScreen> {
  Klijent? data;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    data = Authorization.loggedUser;
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        child: SingleChildScrollView(
            child: Column(
      children: [
        _buildHeader(),
        SizedBox(height: 35),
        Center(
            child: Text(
          "Ime i prezime: " +
              data!.korisnickiRacun!.ime.toString() +
              " " +
              data!.korisnickiRacun!.prezime.toString(),
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        )),
        SizedBox(height: 15),
        Text(
          "Datum rođenja: " +
              data!.korisnickiRacun!.datumRodjenja!.day.toString() +
              '.' +
              data!.korisnickiRacun!.datumRodjenja!.month.toString() +
              '.' +
              data!.korisnickiRacun!.datumRodjenja!.year.toString(),
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        ),
        SizedBox(height: 15),
        Text(
          "Broj telefona: " + data!.korisnickiRacun!.brojTelefona.toString(),
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        ),
        SizedBox(height: 15),
        Text(
          "Adresa: " + data!.korisnickiRacun!.adresa.toString(),
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        ),
        SizedBox(height: 15),
        Text(
          "Email: " + data!.korisnickiRacun!.email.toString(),
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        ),
        SizedBox(height: 15),
        Text(
          "Korisnicko ime: " + data!.korisnickiRacun!.korisnickoIme.toString(),
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        ),
      ],
    )));
  }
}

Widget _buildHeader() {
  return Container(
    padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
    child: Text(
      "Profil",
      style: TextStyle(
          color: Colors.blueGrey, fontSize: 40, fontWeight: FontWeight.w600),
    ),
  );
}
