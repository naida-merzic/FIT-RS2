import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'korisnickiRacun.g.dart';

@JsonSerializable()
class KorisnickiRacun {
  int? korisnickiRacunId;
  String? ime;
  String? prezime;
  String? email;
  String? brojTelefona;
  String? adresa;
  String? korisnickoIme;
  DateTime? datumRodjenja;

  KorisnickiRacun() {}

  //this is smth that enables for us to create actually some KorisnickiRacun
  factory KorisnickiRacun.fromJson(Map<String, dynamic> json) =>
      _$KorisnickiRacunFromJson(json);

  /// Connect the generated [_$KorisnickiRacunToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$KorisnickiRacunToJson(this);
}
