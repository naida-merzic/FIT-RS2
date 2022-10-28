import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'dojam.g.dart';

@JsonSerializable()
class Dojam {
  bool? isLiked;
  int? klijentId;
  int? artikalId;

  Dojam() {}

  //this is smth that enables for us to create actually some Dojam
  factory Dojam.fromJson(Map<String, dynamic> json) => _$DojamFromJson(json);

  /// Connect the generated [_$DojamToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$DojamToJson(this);
}
