import 'package:eoftamoloskimobile/model/cart.dart';
import 'package:eoftamoloskimobile/model/checkOrder.dart';
import 'package:eoftamoloskimobile/model/termin.dart';
import 'package:eoftamoloskimobile/providers/cart_provider.dart';
import 'package:eoftamoloskimobile/providers/checkOrder_provider.dart';
import 'package:eoftamoloskimobile/providers/termin_provider.dart';
import 'package:eoftamoloskimobile/screens/termini/terminInsert_screen.dart';
import 'package:eoftamoloskimobile/widgets/eoftamoloski_drawer.dart';
import 'package:eoftamoloskimobile/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

//import '../../providers/order_provider.dart';
import '../../utils/utils.dart';

class TerminScreen extends StatefulWidget {
  static const String routeName = "/termini";

  const TerminScreen({Key? key}) : super(key: key);

  @override
  State<TerminScreen> createState() => _TerminScreenState();
}

class _TerminScreenState extends State<TerminScreen> {
  late TerminProvider _terminProvider;
  List<Termin> data = [];
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _terminProvider = context.read<TerminProvider>();
    loadData();
  }

  Future loadData() async {
    var tempData = await _terminProvider
        .get({'KlijentId': Authorization.loggedUser!.klijentId});
    setState(() {
      data = tempData;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        children: [
          _buildHeader(),
          Expanded(
            child: SingleChildScrollView(
                scrollDirection: Axis.vertical, child: _tablica()),
          ),
          _buildAppointmentButton(),
          SizedBox(
            height: 15,
          )
        ],
      ),
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text(
        "Appointments",
        style: TextStyle(
            color: Colors.blueGrey, fontSize: 40, fontWeight: FontWeight.w600),
      ),
    );
  }

  Widget _tablica() {
    return DataTable(
        columns: [
          DataColumn(label: Text("Type of appointment")),
          DataColumn(label: Text("Date")),
          DataColumn(label: Text("Time")),
        ],
        rows: data
            .map((e) => DataRow(cells: [
                  DataCell(Text(e.vrstaPregleda.toString())),
                  DataCell(Text(e.datumTermina!.day.toString() +
                      '.' +
                      e.datumTermina!.month.toString() +
                      '.' +
                      e.datumTermina!.year.toString())),
                  DataCell(Text(e.datumTermina!.hour.toString() +
                      ':' +
                      e.datumTermina!.minute.toString())),
                ]))
            .toList());
  }

  Widget _buildAppointmentButton() {
    return TextButton(
      child: Text("Add new appointment"),
      style: TextButton.styleFrom(
          backgroundColor: Color.fromARGB(255, 168, 204, 235),
          foregroundColor: Colors.black),
      onPressed: () async {
        Navigator.pushNamed(
          context,
          "${TerminInsertScreen.routeName}",
        );
        setState(() {});
      },
    );
  }
}
