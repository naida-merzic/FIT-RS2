import 'package:eoftamoloskimobile/providers/product_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../model/product.dart';
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
    print("anisxa");
    var tempData = await _productProvider?.getById(int.parse(widget.id));
    setState(() {
      _product = tempData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(
        child: Text(this.widget.id),
      ),
    );
  }
}
