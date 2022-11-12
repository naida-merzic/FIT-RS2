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
    loadData();
  }

  Future loadData() async {
    var tempData = await novostiProvider?.get(null);
    setState(() {
      data = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: SingleChildScrollView(
        child: Container(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildHeader(),
              _buildProductSearch(),
              SizedBox(height: 5),
              Container(
                height: 400,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 2,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 5,
                      mainAxisSpacing: 5),
                  scrollDirection: Axis.vertical,
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
        "News",
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
        .map((x) => Padding(
              padding: const EdgeInsets.all(8.0),
              child: Container(
                decoration:
                    BoxDecoration(color: Color.fromARGB(255, 220, 228, 245)),
                child: Padding(
                  padding: const EdgeInsets.all(12.0),
                  child: Column(
                    children: [
                      Text(x.naslov ?? "",
                          style: TextStyle(
                              color: Color.fromARGB(255, 41, 83, 105),
                              fontSize: 20,
                              fontWeight: FontWeight.w600)),
                      SizedBox(
                        height: 15,
                      ),
                      Text(x.sadrzaj ?? ""),
                    ],
                  ),
                ),
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
