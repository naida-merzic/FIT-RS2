import 'package:eoftamoloskimobile/model/novost.dart';
import 'package:eoftamoloskimobile/providers/novost_provider.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../widgets/master_screen.dart';

class NovostScreen extends StatefulWidget {
  static const String routeName = "/novost";

  const NovostScreen({Key? key}) : super(key: key);

  @override
  State<NovostScreen> createState() => _NovostScreenState();
}

class _NovostScreenState extends State<NovostScreen> {
  NovostProvider? novostiProvider = null;
  List<Novost> data = [];
  TextEditingController _searchController = TextEditingController(); //search

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    novostiProvider = context.read<NovostProvider>();
    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tempData = await novostiProvider?.get(null);
    setState(() {
      data = tempData!;
    });

    print("data : " + data[0].naslov.toString());
  }

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return MasterScreenWidget(
      child: SingleChildScrollView(
        child: Container(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildHeader(),
              _buildProductSearch(),
              //SizedBox(height: 50),
              Container(
                height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.horizontal,
                  children: _buildProductCardList(),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text(
        Authorization.loggedUser11!.korisnickiRacun!.ime.toString(),
        style: TextStyle(
            color: Colors.blueGrey, fontSize: 40, fontWeight: FontWeight.w600),
      ),
    );
  }

  Widget _buildProductSearch() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tmpData = await novostiProvider?.get({'naslov': value});
                setState(() {
                  data = tmpData!;
                });
              },
              /*onChanged: (value) async {
                var tmpData = await _productProvider?.get({'naziv': value});
                setState(() {
                  data = tmpData!;
                });
              },*/
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: Icon(Icons.search),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: BorderSide(color: Colors.grey))),
            ),
          ),
        ),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            onPressed: () async {
              var tmpData =
                  await novostiProvider?.get({'naziv': _searchController.text});
              setState(() {
                data = tmpData!;
              });
            },
          ),
        )
      ],
    );
  }

  List<Widget> _buildProductCardList() {
    if (data.length == 0) {
      return [Text("Loading...")];
    }
    List<Widget> list = data
        .map((x) => Container(
              //height: 200,
              //width: 200,
              child: Column(
                children: [
                  Text(x.naslov ?? ""),
                  Text(x.sadrzaj ?? ""),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
