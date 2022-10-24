import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/providers/cart_provider.dart';
import 'package:eoftamoloskimobile/screens/krosicnickiRacun/korisnickiRacunScreen.dart';
import 'package:eoftamoloskimobile/screens/news/news_list_screen.dart';
import 'package:eoftamoloskimobile/screens/products/product_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../screens/cart/cart_screen.dart';

class eOftamoloskiDrawer extends StatelessWidget {
  eOftamoloskiDrawer({Key? key}) : super(key: key);
  CartProvider? _cartProvider;
  @override
  Widget build(BuildContext context) {
    _cartProvider = context.watch<CartProvider>();
    print("called build drawer");
    return Drawer(
      child: ListView(
        children: [
          ListTile(
            title: Text('Home'),
            onTap: () {
              Navigator.popAndPushNamed(context, ProductListScreen.routeName);
            },
          ),
          ListTile(
            title: Text('Cart ${_cartProvider?.cart.items.length}'),
            onTap: () {
              Navigator.pushNamed(context, CartScreen.routeName);
            },
          ),
          ListTile(
            title: Text('News'),
            onTap: () {
              Navigator.pushNamed(context, NovostScreen.routeName);
            },
          ),
          ListTile(
            title: Text('Profile'),
            onTap: () {
              Navigator.pushNamed(context, KorisnickiRacunScreen.routeName);
            },
          ),
        ],
      ),
    );
  }
}
