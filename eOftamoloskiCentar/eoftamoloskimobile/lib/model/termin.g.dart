// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'termin.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Termin _$TerminFromJson(Map<String, dynamic> json) => Termin()
  ..terminId = json['terminId'] as int?
  ..datumTermina = json['datumTermina'] == null
      ? null
      : DateTime.parse(json['datumTermina'] as String)
  ..vrstaPregleda = json['vrstaPregleda'] as String?
  ..klijentId = json['klijentId'] as int?;

Map<String, dynamic> _$TerminToJson(Termin instance) => <String, dynamic>{
      'terminId': instance.terminId,
      'datumTermina': instance.datumTermina?.toIso8601String(),
      'vrstaPregleda': instance.vrstaPregleda,
      'klijentId': instance.klijentId,
    };
