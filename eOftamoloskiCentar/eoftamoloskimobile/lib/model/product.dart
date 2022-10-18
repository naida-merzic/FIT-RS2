//import 'package:json_serializable/json_serializable.dart';

import 'package:json_annotation/json_annotation.dart';

part 'product.g.dart';

@JsonSerializable()
class Product {
  int? artikalId;
  String? naziv;
  String? slika;

  Product() {}

  //this is smth that enables for us to create actually some Product
  factory Product.fromJson(Map<String, dynamic> json) =>
      _$ProductFromJson(json);

  /// Connect the generated [_$ProductToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ProductToJson(this);
}
