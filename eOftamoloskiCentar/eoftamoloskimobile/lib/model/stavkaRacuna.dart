//import 'package:json_serializable/json_serializable.dart';

import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'stavkaRacuna.g.dart';

@JsonSerializable()
class StavkaRacuna {
  int? artikalId;
  int? kolicina;

  StavkaRacuna() {}

  //this is smth that enables for us to create actually some StavkaRacuna
  factory StavkaRacuna.fromJson(Map<String, dynamic> json) =>
      _$StavkaRacunaFromJson(json);

  /// Connect the generated [_$StavkaRacunaToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$StavkaRacunaToJson(this);
}
