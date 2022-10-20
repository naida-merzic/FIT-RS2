import 'package:collection/collection.dart';
import 'package:eoftamoloskimobile/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/product.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Product product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }

    notifyListeners();
  }

  removeFromCart(Product product) {
    cart.items
        .removeWhere((item) => item.product.artikalId == product.artikalId);
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull(
        (item) => item.product.artikalId == product.artikalId);
    return item;
  }
}
