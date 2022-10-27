// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'klijent.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Klijent _$KlijentFromJson(Map<String, dynamic> json) => Klijent()
  ..klijentId = json['klijentId'] as int?
  ..spolId = json['spolId'] as int?
  ..korisnickiRacun = json['korisnickiRacun'] == null
      ? null
      : KorisnickiRacun.fromJson(
          json['korisnickiRacun'] as Map<String, dynamic>);

Map<String, dynamic> _$KlijentToJson(Klijent instance) => <String, dynamic>{
      'klijentId': instance.klijentId,
      'spolId': instance.spolId,
      'korisnickiRacun': instance.korisnickiRacun,
    };
