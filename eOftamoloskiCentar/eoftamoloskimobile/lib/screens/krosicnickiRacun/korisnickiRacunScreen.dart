import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:eoftamoloskimobile/providers/korisnickiRacun_provider.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

class KorisnickiRacunScreen extends StatefulWidget {
  static const String routeName = "/korisnicki";

  const KorisnickiRacunScreen({Key? key}) : super(key: key);

  @override
  State<KorisnickiRacunScreen> createState() => _KorisnickiRacunScreenState();
}

class _KorisnickiRacunScreenState extends State<KorisnickiRacunScreen> {
  KorisnickiRacunProvider? racunProvider = null;
  KorisnickiRacun? data;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    racunProvider = context.read<KorisnickiRacunProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    // int.parse(Authorization.loggedUser?.korisnickiRacunId)
    var tempData = await racunProvider?.getById(1012);
    setState(() {
      // data = tempData!;
    });

    print("data : " + data!.ime.toString());
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Text("anisaaaaaa"),
    );
  }
}
