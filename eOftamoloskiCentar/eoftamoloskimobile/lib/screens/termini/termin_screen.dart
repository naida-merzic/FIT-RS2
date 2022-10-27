import 'package:eoftamoloskimobile/model/cart.dart';
import 'package:eoftamoloskimobile/model/checkOrder.dart';
import 'package:eoftamoloskimobile/model/termin.dart';
import 'package:eoftamoloskimobile/providers/cart_provider.dart';
import 'package:eoftamoloskimobile/providers/checkOrder_provider.dart';
import 'package:eoftamoloskimobile/providers/termin_provider.dart';
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
          Expanded(child: _tablica()),
        ],
      ),
    );
  }

  Widget _tablica() {
    return Container(
        // child: ListView.builder(
        //   itemCount: _terminProvider.cart.items.length,
        //   itemBuilder: (context, index) {
        //     return _buildProductCard(_cartProvider.cart.items[index]);
        //   },
        // ),
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
}
