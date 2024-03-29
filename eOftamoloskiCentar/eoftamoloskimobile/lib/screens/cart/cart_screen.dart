import 'package:eoftamoloskimobile/main.dart';
import 'package:eoftamoloskimobile/model/cart.dart';
import 'package:eoftamoloskimobile/model/checkOrder.dart';
import 'package:eoftamoloskimobile/model/stavkaRacuna.dart';
import 'package:eoftamoloskimobile/providers/cart_provider.dart';
import 'package:eoftamoloskimobile/providers/checkOrder_provider.dart';
import 'package:eoftamoloskimobile/widgets/eoftamoloski_drawer.dart';
import 'package:eoftamoloskimobile/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

//import '../../providers/order_provider.dart';
import '../../utils/utils.dart';
import '../payment/payment_screen.dart';
import '../products/product_list_screen.dart';

class CartScreen extends StatefulWidget {
  static const String routeName = "/cart";

  const CartScreen({Key? key}) : super(key: key);

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {
  late CartProvider _cartProvider;
  late CheckOrderProvider _orderProvider;
  double total = 0;
  bool active = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _cartProvider = context.watch<CartProvider>();
    _orderProvider = context.read<CheckOrderProvider>();

    for (var item in _cartProvider.cart.items) {
      total += double.parse(item.count.toString()) *
          double.parse(item.product.cijena.toString());
    }
    if (total == 0) {
      active = false;
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Column(
        children: [
          Expanded(child: _buildProductCardList()),
          SizedBox(
            height: 15,
          ),
          Padding(
            padding: const EdgeInsets.all(10.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Total : " + total.toString() + " €",
                  style: TextStyle(fontSize: 18),
                ),
                _buildBuyButton(),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _buildProductCardList() {
    return Container(
      child: ListView.builder(
        itemCount: _cartProvider.cart.items.length,
        itemBuilder: (context, index) {
          return _buildProductCard(_cartProvider.cart.items[index]);
        },
      ),
    );
  }

  Widget _buildProductCard(CartItem item) {
    return ListTile(
      leading: imageFromBase64String(item.product.slika!),
      title: Text(item.product.naziv ?? ""),
      subtitle: Text(item.product.cijena.toString()),
      trailing: Text(item.count.toString()),
    );
  }

  Widget _buildBuyButton() {
    return TextButton(
      child: Text("Buy"),
      style: TextButton.styleFrom(
          backgroundColor: Color.fromARGB(255, 168, 204, 235),
          foregroundColor: Colors.black),
      onPressed: active
          ? () async {
              total = 0;
              List<Map> items = [];
              _cartProvider.cart.items.forEach((item) {
                items.add(
                  {
                    "artikalId": item.product.artikalId,
                    "kolicina": item.count,
                  },
                );
              });
              Map order = {
                "items": items,
                "klijentId": Authorization.loggedUser!.klijentId
              };

              var response = await _orderProvider.insert(order);
              _cartProvider.cart.items.clear();
              setState(() {});

              // Navigator.pushNamed(context, PaymentScreen.routeName,
              //     arguments: response);

              Navigator.of(context).push(MaterialPageRoute(
                  builder: (BuildContext context) => PaymentScreen(
                      racun: response,
                      onFinish: (number) async {
                        Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => ProductListScreen()));
                        setState(() {});
                      })));
            }
          : null,
    );
  }
}
