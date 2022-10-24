import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'novost.g.dart';

@JsonSerializable()
class Novost {
  int? novostId;
  String? naslov;
  String? sadrzaj;
  DateTime? datumObjave;

  Novost() {}

  //this is smth that enables for us to create actually some Novost
  factory Novost.fromJson(Map<String, dynamic> json) => _$NovostFromJson(json);

  /// Connect the generated [_$NovostToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$NovostToJson(this);
}
