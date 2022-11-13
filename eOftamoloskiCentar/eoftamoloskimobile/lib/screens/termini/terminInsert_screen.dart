import 'dart:ffi';

import 'package:eoftamoloskimobile/model/cart.dart';
import 'package:eoftamoloskimobile/model/checkOrder.dart';
import 'package:eoftamoloskimobile/model/termin.dart';
import 'package:eoftamoloskimobile/providers/cart_provider.dart';
import 'package:eoftamoloskimobile/providers/checkOrder_provider.dart';
import 'package:eoftamoloskimobile/providers/termin_provider.dart';
import 'package:eoftamoloskimobile/screens/termini/termin_Screen.dart';
import 'package:eoftamoloskimobile/widgets/eoftamoloski_drawer.dart';
import 'package:eoftamoloskimobile/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

//import '../../providers/order_provider.dart';
import '../../utils/utils.dart';

class TerminInsertScreen extends StatefulWidget {
  static const String routeName = "/terminiInsert";

  const TerminInsertScreen({Key? key}) : super(key: key);

  @override
  State<TerminInsertScreen> createState() => _TerminInsertScreenState();
}

class _TerminInsertScreenState extends State<TerminInsertScreen> {
  late TerminProvider _terminProvider;
  TextEditingController _vrstaPregledaController = TextEditingController();
  late String vrstaPregleda = "";

  DateTime selectedDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  DateTime dateTime = DateTime.now();
  bool showDate = false;
  bool showTime = false;

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

// Select for Time
  Future<TimeOfDay> _selectTime(BuildContext context) async {
    final selected = await showTimePicker(
      context: context,
      initialTime: selectedTime,
    );
    if (selected != null && selected != selectedTime) {
      setState(() {
        selectedTime = selected;
      });
    }
    return selectedTime;
  }
  // select date time picker

  Future _selectDateTime(BuildContext context) async {
    final date = await _selectDate(context);
    if (date == null) return;

    final time = await _selectTime(context);

    if (time == null) return;
    setState(() {
      dateTime = DateTime(
        date.year,
        date.month,
        date.day,
        time.hour,
        time.minute,
      );
    });
  }

  String getDate() {
    // ignore: unnecessary_null_comparison
    if (selectedDate == null) {
      return 'select date';
    } else {
      return DateFormat('MMM d, yyyy').format(selectedDate);
    }
  }

  String getDateTime() {
    // ignore: unnecessary_null_comparison
    if (dateTime == null) {
      return 'select date timer';
    } else {
      return DateFormat('yyyy-MM-dd HH: ss a').format(dateTime);
    }
  }

  String getTime(TimeOfDay tod) {
    final now = DateTime.now();

    final dt = DateTime(now.year, now.month, now.day, tod.hour, tod.minute);
    final format = DateFormat.jm();
    return format.format(dt);
  }

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _terminProvider = context.read<TerminProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        child: SingleChildScrollView(
      child: Column(children: [
        _buildHeader(),
        SizedBox(
          height: 40,
        ),
        Text("Type of medical service: "),
        Container(
          padding: EdgeInsets.all(8),
          decoration: BoxDecoration(
              border: Border(bottom: BorderSide(color: Colors.grey))),
          child: TextField(
            controller: _vrstaPregledaController,
            decoration: InputDecoration(
                border: InputBorder.none, hintText: "Vrsta pregleda"),
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
            child: const Text('Date Picker'),
          ),
        ),
        showDate ? Center(child: Text(getDate())) : const SizedBox(),
        Container(
          padding: const EdgeInsets.symmetric(horizontal: 15),
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {
              _selectTime(context);
              showTime = true;
            },
            child: const Text('Timer Picker'),
          ),
        ),
        showTime
            ? Center(child: Text(getTime(selectedTime)))
            : const SizedBox(),
        // _dateTimePicker(),
        SizedBox(
          height: 35,
        ),
        _buildAppointmentButton(),
      ]),
    ));
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text(
        "Add new appointment",
        style: TextStyle(
            color: Colors.blueGrey, fontSize: 40, fontWeight: FontWeight.w600),
      ),
    );
  }

  Widget _buildAppointmentButton() {
    return TextButton(
      child: Text("Save"),
      style: TextButton.styleFrom(
          backgroundColor: Color.fromARGB(255, 168, 204, 235),
          foregroundColor: Colors.black),
      onPressed: () async {
        if (_vrstaPregledaController.text.isEmpty == true) {
          showAlertDialog(context);
        } else {
          Map order = {
            "datumTermina": dateTime.toIso8601String(),
            "vrstaPregleda": _vrstaPregledaController.text,
            "klijentId": Authorization.loggedUser!.klijentId
          };

          var x = await _terminProvider.insert(order);
          if (x != null) {
            ScaffoldMessenger.of(context).showSnackBar(const SnackBar(
              backgroundColor: Colors.green,
              duration: Duration(milliseconds: 1000),
              content: Text("You successfully add new appointment."),
            ));
            Navigator.pushNamed(
              context,
              "${TerminScreen.routeName}",
            ).timeout(const Duration(seconds: 10));
          }
        }
        setState(() {});
      },
    );
  }

  showAlertDialog(BuildContext context) {
    // set up the button
    Widget okButton = TextButton(
      child: Text("OK"),
      onPressed: () {
        Navigator.of(context).pop();
      },
    );

    // set up the AlertDialog
    AlertDialog alert = AlertDialog(
      content: Text("Required field - type of appointment"),
      actions: [
        okButton,
      ],
    );

    // show the dialog
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return alert;
      },
    );
  }
}
