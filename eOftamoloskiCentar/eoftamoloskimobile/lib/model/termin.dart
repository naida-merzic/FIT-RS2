// public int terminId { get; set; }
//         public int SpolId { get; set; }
import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'termin.g.dart';

@JsonSerializable()
class Termin {
  int? terminId;
  DateTime? datumTermina;
  String? vrstaPregleda;
  int? klijentId;

  Termin() {}

  //this is smth that enables for us to create actually some termin
  factory Termin.fromJson(Map<String, dynamic> json) => _$TerminFromJson(json);

  /// Connect the generated [_$terminToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$TerminToJson(this);
}
