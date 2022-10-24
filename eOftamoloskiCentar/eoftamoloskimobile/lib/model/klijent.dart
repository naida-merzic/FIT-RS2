// public int KlijentId { get; set; }
//         public int SpolId { get; set; }
import 'dart:ffi';

import 'package:eoftamoloskimobile/model/korisnickiRacun.dart';
import 'package:json_annotation/json_annotation.dart';

part 'klijent.g.dart';

@JsonSerializable()
class Klijent {
  int? klijentId;
  String? spolId;
  KorisnickiRacun? korisnickiRacun;

  Klijent() {}

  //this is smth that enables for us to create actually some Klijent
  factory Klijent.fromJson(Map<String, dynamic> json) =>
      _$KlijentFromJson(json);

  /// Connect the generated [_$KlijentToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$KlijentToJson(this);
}
