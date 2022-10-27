import 'package:eoftamoloskimobile/providers/product_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../model/product.dart';
import '../../utils/utils.dart';
import '../../widgets/master_screen.dart';

class ProductDetailsScreen extends StatefulWidget {
  static const String routeName = "/product_details";
  String id;
  ProductDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ProductDetailsScreen> createState() => _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {
  ProductProvider? _productProvider = null;
  Product? _product;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    loadData();
  }

  Future loadData() async {
    var tempData = await _productProvider?.getById(int.parse(widget.id));
    setState(() {
      _product = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(child: SingleChildScrollView(child: _detalji()));
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text(
        _product!.naziv.toString(),
        style: TextStyle(
            color: Colors.blueGrey, fontSize: 20, fontWeight: FontWeight.w600),
      ),
    );
  }

  Widget _detalji() {
    if (_product == null) {
      return Text("Loading...");
    }
    return Column(
      children: [
        _buildHeader(),
        SizedBox(height: 35),
        Container(
          height: 100,
          width: 100,
          child: _product!.slika == null
              ? Text("No image")
              : imageFromBase64String(_product!.slika!),
        ),
        SizedBox(height: 35),
        Text(
          _product!.cijena.toString() + " KM",
          style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
        ),
        SizedBox(height: 35),
        Text(
          _product!.opis.toString(),
          style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
        ),
      ],
    );
  }
}
