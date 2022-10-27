import 'package:eoftamoloskimobile/model/product.dart';

class Cart {
  List<CartItem> items = [];
  int? klijentId;
}

class CartItem {
  CartItem(this.product, this.count);
  late Product product;
  late int count;
}
