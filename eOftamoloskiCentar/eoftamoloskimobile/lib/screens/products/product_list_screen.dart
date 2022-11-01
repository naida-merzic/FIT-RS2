import 'package:eoftamoloskimobile/providers/dojam_provider.dart';
import 'package:eoftamoloskimobile/providers/product_provider.dart';
import 'package:eoftamoloskimobile/screens/products/product_details_screen.dart';
import 'package:eoftamoloskimobile/utils/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';

import '../../../model/product.dart';

import '../../../providers/cart_provider.dart';
import '../../../widgets/eoftamoloski_drawer.dart';
import '../../widgets/master_screen.dart';

class ProductListScreen extends StatefulWidget {
  static const String routeName = "/product";

  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  ProductProvider? _productProvider = null;
  DojamProvider? _dojamProvider = null;
  List<Product> data = [];
  List<Product> dataRecomm = [];
  TextEditingController _searchController = TextEditingController();
  CartProvider? _cartProvider = null;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();
    _cartProvider = context.read<CartProvider>();
    _dojamProvider = context.read<DojamProvider>();
    loadData();
  }

  Future loadData() async {
    var tempData = await _productProvider?.get();

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
                  children: _buildProductCardList(data, false),
                ),
              ),
              SizedBox(
                height: 15,
              ),
              Text(
                "Recommended articles:",
                style: TextStyle(
                    color: Colors.blueGrey,
                    fontSize: 25,
                    fontWeight: FontWeight.w600),
              ),
              SizedBox(height: 15),
              Container(
                height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.horizontal,
                  children: _buildProductCardList(dataRecomm, true),
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
        "Articles",
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
                var tmpData = await _productProvider?.get({'naziv': value});
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
              var tmpData = await _productProvider
                  ?.get({'naziv': _searchController.text});
              setState(() {
                data = tmpData!;
              });
            },
          ),
        )
      ],
    );
  }

  List<Widget> _buildProductCardList(dataX, rec) {
    if (rec == true && dataX.length == 0) {
      return [Text("No recommended articles")];
    }
    if (rec == false && dataX.length == 0) {
      return [Text("Loading...")];
    }
    List<Widget> list = dataX
        .map((x) => Container(
              //height: 200,
              //width: 200,
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      Navigator.pushNamed(
                        context,
                        "${ProductDetailsScreen.routeName}/${x.artikalId}",
                      );
                    },
                    child: Container(
                      height: 100,
                      width: 100,
                      child: x.slika == null
                          ? Text("No image")
                          : imageFromBase64String(x.slika!),
                    ),
                  ),
                  Text(x.naziv ?? ""),
                  Text(formatNumber(x.cijena)),
                  Row(
                    children: [
                      IconButton(
                        icon: Icon(Icons.shopping_cart),
                        onPressed: () async {
                          _cartProvider?.addToCart(x);
                          ScaffoldMessenger.of(context)
                              .showSnackBar(const SnackBar(
                            backgroundColor: Colors.green,
                            duration: Duration(milliseconds: 1000),
                            content: Text("Successful added to cart."),
                          ));
                          Product _x = x;
                          var id = _x.artikalId;
                          var tempDataRecom =
                              await _productProvider?.recom(id!);
                          setState(() {
                            dataRecomm = tempDataRecom! as List<Product>;
                          });
                        },
                      ),
                      IconButton(
                        icon: Icon(Icons.star),
                        onPressed: () {
                          Map order = {
                            "isLiked": true,
                            "artikalId": x.artikalId,
                            "klijentId": Authorization.loggedUser!.klijentId
                          };
                          _dojamProvider?.insert(order);
                          ScaffoldMessenger.of(context)
                              .showSnackBar(const SnackBar(
                            backgroundColor: Colors.yellow,
                            duration: Duration(milliseconds: 1000),
                            content: Text("You liked this article."),
                          ));
                        },
                      ),
                      IconButton(
                        icon: Icon(Icons.heart_broken),
                        onPressed: () {
                          Map order = {
                            "isLiked": false,
                            "artikalId": x.artikalId,
                            "klijentId": Authorization.loggedUser!.klijentId
                          };
                          _dojamProvider?.insert(order);
                          ScaffoldMessenger.of(context)
                              .showSnackBar(const SnackBar(
                            backgroundColor: Colors.yellow,
                            duration: Duration(milliseconds: 1000),
                            content: Text("You disliked this article."),
                          ));
                        },
                      )
                    ],
                  ),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
