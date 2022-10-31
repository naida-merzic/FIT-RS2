import 'dart:ffi';

import 'package:eoftamoloskimobile/model/klijent.dart';
import 'package:eoftamoloskimobile/model/stavkaRacuna.dart';
import 'package:json_annotation/json_annotation.dart';

part 'checkOrder.g.dart';

@JsonSerializable()
class Racun {
  int? racunId;
  int? brojRacuna;
  DateTime? datum;
  double? iznos;
  int? klijentId;
  Klijent? klijent;
  List<StavkaRacuna>? stavkaRacunas;

  Racun() {}

  //this is smth that enables for us to create actually some Racun
  factory Racun.fromJson(Map<String, dynamic> json) => _$RacunFromJson(json);

  /// Connect the generated [_$RacunToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$RacunToJson(this);
}
