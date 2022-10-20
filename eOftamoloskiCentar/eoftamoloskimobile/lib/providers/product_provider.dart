import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eoftamoloskimobile/model/product.dart';
import 'package:eoftamoloskimobile/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class ProductProvider extends BaseProvider<Product> {
  ProductProvider() : super("Artikli");

  @override
  Product fromJson(data) {
    return Product.fromJson(data);
  }
}
